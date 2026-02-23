using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.DTOs;
using Application.DTOs.UserDto;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;

namespace Application.Services
{
    public class UserService : IUserService
    {
        public IGenericRepository<User, int> _userRepository;

        //public IPasswordHasher _passwordHasher;

        public UserService(IGenericRepository<User, int> userRepository)
        {
            _userRepository = userRepository;
            //_passwordHasher = passwordHasher;
        }

        public UserDto GetById(int id)
        {
            var user = _userRepository.GetAllEntitys().FirstOrDefault(u => u.ID == id);
            return user == null ? null : MapToDto(user);
        }

        public IQueryable<UserDto> GetAll()
        {
            return _userRepository
                .GetAllEntitys()
                .Select(u => new UserDto
                {
                    Id = u.ID,
                    Name = u.Name,
                    UserName = u.UserName,
                    Email = u.Email,
                    Phone_Number = u.PhoneNumber,
                    Profile_Picture = u.ProfilePicture,
                    Address = u.Address,
                    DateOfBirth = u.DateOfBirth,
                    Role = u.Role.ToString(),
                });
        }

        public UserDto Create(CreateUserDto dto)
        {
            var user = new User
            {
                Name = dto.Name,
                UserName = dto.UserName,
                Email = dto.Email,
                Password = (dto.Password),
                PhoneNumber = dto.Phone_Number,
                ProfilePicture = dto.Profile_Picture,
                Address = dto.Address,
                DateOfBirth = dto.DateOfBirth,
                Role = Role.Customer,
            };
            _userRepository.Add(user);
            _userRepository.SaveChanges();
            return MapToDto(user);
        }

        public UserDto Update(int id, UpdateUserDto dto)
        {
            var user = _userRepository.GetAllEntitys().FirstOrDefault(u => u.ID == id);
            if (user == null)
                return null;
            user.Name = dto.Name ?? user.Name;
            user.PhoneNumber = dto.Phone_Number ?? user.PhoneNumber;
            user.ProfilePicture = dto.Profile_Picture ?? user.ProfilePicture;
            user.Address = dto.Address ?? user.Address;
            user.DateOfBirth = dto.DateOfBirth ?? user.DateOfBirth;
            _userRepository.Update(user);
            _userRepository.SaveChanges();
            return MapToDto(user);
        }

        public bool Delete(int id)
        {
            var user = _userRepository.GetAllEntitys().FirstOrDefault(u => u.ID == id);
            if (user == null)
                return false;
            _userRepository.Delete(user);
            _userRepository.SaveChanges();
            return true;
        }

        public UserDto Authenticate(string email, string password)
        {
            var user = _userRepository.GetAllEntitys().FirstOrDefault(u => u.Email == email);
            if (user == null)
                return null;

            var valid = user.Password == password;
            return valid ? MapToDto(user) : null;
        }

        private UserDto MapToDto(User user) =>
            new UserDto
            {
                Id = user.ID,
                Name = user.Name,
                UserName = user.UserName,
                Email = user.Email,
                Phone_Number = user.PhoneNumber,
                Profile_Picture = user.ProfilePicture,
                Address = user.Address,
                DateOfBirth = user.DateOfBirth,
                Role = user.Role.ToString(),
            };
    }
}
