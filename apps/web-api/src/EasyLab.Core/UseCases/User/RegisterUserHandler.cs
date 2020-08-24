using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyLab.Core.Dto;
using EasyLab.Core.Dto.GatewayResponses.Repositories;
using EasyLab.Core.Dto.UseCaseRequests;
using EasyLab.Core.Dto.UseCaseResponses;
using EasyLab.Core.Helpers.Exceptions.User;
using EasyLab.Core.Interfaces.Gateways.Repositories;
using EasyLab.Core.Interfaces.UseCases;
using EasyLab.Core.Interfaces.UseCases.User;

namespace EasyLab.Core.UseCases.User
{
    public class RegisterUserHandler : IRegisterUserHandler
    {
        private readonly IUserRepository _userRepository;

        public RegisterUserHandler(
            IUserRepository userRepository)
        {
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
                CreateUserResponse createUserResponse = await _userRepository.Create(message.Name, 
                    message.Surname, message.Email, message.Password);

                //returning operation result 
                response = createUserResponse.Success ? new RegisterUserResponse(createUserResponse.Id) : new RegisterUserResponse(createUserResponse.Errors);
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
