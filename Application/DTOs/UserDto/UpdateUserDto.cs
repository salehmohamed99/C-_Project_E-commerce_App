using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.UserDto
{
    internal class UpdateUserDto
    {
        public string Name { get; set; }
        public string Phone_Number { get; set; }
        public string Profile_Picture { get; set; }
        public string Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
