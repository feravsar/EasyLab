using System;
using System.Collections.Generic;

namespace EasyLab.Core.Dto.Entity
{
    public class UserDto
    {
        public UserDto(string name, string surname, List<string> roles)
        {
            Name = name;
            Surname = surname;
            Roles = roles;
        }

        public UserDto(Guid id, string email, string username, string name, string surname)
        {
            Id = id;
            Email = email;
            Username = username;
            Name = name;
            Surname = surname;
        }

        public Guid Id { get; private set; }

        public string Email { get; private set; }

        public string Username { get; private set; }
        public string Name { get; private set; }

        public string Surname { get; private set; }

        public List<string> Roles { get; private set; }
    }
}