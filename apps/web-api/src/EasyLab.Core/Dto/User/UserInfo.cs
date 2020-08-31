using System.Collections.Generic;

namespace EasyLab.Core.Dto.User{
    public class UserInfo{
        public UserInfo(string name, string surname, List<string> roles)
        {
            Name = name;
            Surname = surname;
            Roles = roles;
        }

        public string Name { get; private set; }

        public string Surname { get; private set; }

        public List<string> Roles { get; private set; }
    }
}