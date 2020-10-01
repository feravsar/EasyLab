using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EasyLab.Core.Dto;
using EasyLab.Core.Dto.GatewayResponses.Repositories;
using EasyLab.Core.Dto.UseCaseRequests.Account;
using EasyLab.Core.Dto.UseCaseResponses.Account;
using EasyLab.Core.Helpers.Exceptions.User;
using EasyLab.Core.Interfaces.Gateways.Repositories;
using EasyLab.Core.Interfaces.Services;
using EasyLab.Core.Interfaces.UseCases;
using EasyLab.Core.Interfaces.UseCases.Account;

namespace EasyLab.Core.UseCases.Account
{
    public class RegisterUserHandler : IRegisterUserHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly IProjectFactory _projectFactory;


        public RegisterUserHandler(IUserRepository userRepository, IProjectFactory projectFactory)
        {
            _projectFactory = projectFactory;
            _userRepository = userRepository;
        }

        public async Task Handle(RegisterUserRequest message, IOutputPort<RegisterUserResponse> outputPort)
        {
            RegisterUserResponse response = null;
            try
            {
                if (await _userRepository.CheckDuplicateMail(message.Email))
                    throw new DuplicateMailException(message.Email);


                //creating user and adding verification code to repository
                CreateUserResponse createUserResponse = await _userRepository.Create(message.Username,message.Name,
                    message.Surname, message.Email, message.Password);

                //returning operation result 
                if (createUserResponse.Success)
                {
                    await _projectFactory.CreateUser(message.Username);
                    response = new RegisterUserResponse(createUserResponse.Id);
                }
                else
                {
                    response = new RegisterUserResponse(createUserResponse.Errors);
                }
            }
            catch (Exception ex)
            {
                response = new RegisterUserResponse(new List<Error>() { new Error(ex.GetType().Name, ex.Message) });
            }
            finally
            {
                outputPort.Handle(response);
            }
        }
    }
}
