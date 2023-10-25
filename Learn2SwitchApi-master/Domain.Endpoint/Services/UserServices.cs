using Domain.Endpoint.DTOs;
using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace Domain.Endpoint.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;       
        }
        public User createUser(UserDTO newUserDTO)
        {
            

                User nuevoUsuario = new User()
                {
                    Id = Guid.NewGuid(),
                    FirstName = newUserDTO.FirstName,
                    LastName = newUserDTO.LastName,
                    Email = newUserDTO.Email,
                    Gender = newUserDTO.Gender,
                    SchoolName = newUserDTO.SchoolName,
                    GradeLevel = newUserDTO.GradeLevel,
                    Password = newUserDTO.Password
                    
                };
                _userRepository.Create(nuevoUsuario);
                return nuevoUsuario;

            



            
        }



        public User FilterUser(Guid id)
        {
            return _userRepository.GetById(id);
        }

        public Task<List<User>> Get()
        {
            return _userRepository.GetAll();
        }
    }
}
