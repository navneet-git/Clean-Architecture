using Application.Contracts.Repository;
using Application.Contracts.Service;
using Application.Models;
using Domain.Entities;

namespace Application.Features
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<int> Add(UserDto user)
        {
            var userEntity = new UserEntity
            {
                Name = user.Name,
                Email = user.Email,
                Dob = user.Dob,
                Password = user.Password,
                UserName = user.UserName,
                Created = user.Created,
                IsActive = user.IsActive,
                IsDeleted = user.IsDeleted,
                CreatedBy = user.CreatedBy,
            };
            return await _userRepository.Add(userEntity);
        }
        public async Task<int> Update(UserDto user)
        {
            var userEntity = new UserEntity
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Dob = user.Dob,
                Password = user.Password,
                UserName = user.UserName,
                Updated = user.Updated,
                IsActive = user.IsActive,
                IsDeleted = user.IsDeleted,
                UpdatedBy = user.UpdatedBy,
            };
            return await _userRepository.Update(userEntity);
        }
        public async Task<int> Delete(int id)
        {
            return await (_userRepository.Delete(id));
        }
        public async Task<UserDto> Get(int id)
        {
            var response = await _userRepository.Get(id);
            return new UserDto { 
                Id=response.Id, 
                Name=response.Name, 
                Email=response.Email,  
                Password   = response.Password ,
                UserName = response.UserName,
                Dob=response.Dob,
                CreatedBy = response.CreatedBy,
                Created    = response.Created,
                IsDeleted=response.IsDeleted,
                IsActive = response.IsActive,
                Updated=response.Updated,
                UpdatedBy=response.UpdatedBy,
                LastUpdated=response.LastUpdated
            };
        }
        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var response= await _userRepository.GetAll();
            if(response == null)
                return Enumerable.Empty<UserDto>();

            return response.Select(x => new UserDto {
                Name = x.Name,
                Email = x.Email,
                Dob = x.Dob,
                UserName = x.UserName,
                Updated = x.Updated,
                UpdatedBy = x.UpdatedBy,
                Id = x.Id,
                Created = x.Created,
                CreatedBy = x.CreatedBy,
                IsActive = x.IsActive,
                IsDeleted = x.IsDeleted,
                LastUpdated = x.LastUpdated
            }).ToList(); 
        }
    }
}
