using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs.UserDto;

namespace Application.Interfaces.Services
{
    public interface IUserService
    {
        UserDto GetById(int id);
        IQueryable<UserDto> GetAll();
        UserDto Create(CreateUserDto dto);
        UserDto Update(int id, UpdateUserDto dto);
        bool Delete(int id);
        UserDto Authenticate(string email, string password);
    }
}
