using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.UserDto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone_Number { get; set; }
        public string Profile_Picture { get; set; }
        public string Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Role { get; set; }
    }
}
