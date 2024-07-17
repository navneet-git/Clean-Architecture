using Application.Contracts.Repository;
using Domain.Entities;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        private readonly IConfiguration _configuration;
        public UserRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> Add(UserEntity user)
        {
            var result = 0;
            try
            {
                if (user != null)
                {
                    var userModel = new User
                    {
                        Name = user.Name,
                        Email = user.Email,
                        Dob = user.Dob,
                        UserName = user.UserName,
                        Password = user.Password,
                        CreatedBy = user.CreatedBy,
                        Created = user.Created,
                    };
                    await _dbContext.AddAsync<User>(userModel);
                    result = await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public async Task<int> Update(UserEntity user)
        {
            var result = 0;
            try
            {
                if (user != null)
                {
                    var userModel = new User
                    {
                        Name = user.Name,
                        Email = user.Email,
                        Dob = user.Dob,
                        UserName = user.UserName,
                        Password= user.Password,
                        Updated = user.Updated,
                        UpdatedBy = user.UpdatedBy,
                        Id = user.Id
                    };
                    _dbContext.Update<User>(userModel);
                    result = await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
        public async Task<int> Delete(int id)
        {
            var result = 0;
            try
            {
                if (id > 0)
                {
                    var entity = _dbContext.Users.SingleOrDefault(x => x.Id == id);
                    if (entity != null)
                        _dbContext.Remove(entity);

                    result = await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return result;
        }
        public async Task<UserEntity> Get(int id)
        {
            var response = await _dbContext.Users.SingleOrDefaultAsync(x => x.Id == id);
            if (response != null)
            {
                var userEntity = new UserEntity
                {
                    Name = response.Name,
                    Email = response.Email,
                    Dob = response.Dob,
                    UserName = response.UserName,
                    Updated = response.Updated,
                    UpdatedBy = response.UpdatedBy,
                    Password = response.Password,
                    Id = response.Id,
                    Created = response.Created,
                    CreatedBy = response.CreatedBy,
                    IsActive = response.IsActive,
                    IsDeleted = response.IsDeleted,
                    LastUpdated = response.LastUpdated
                };
                return userEntity;
            }
            return await Task.Run(() => new UserEntity());
        }
        public async Task<IEnumerable<UserEntity>> GetAll()
        {
            var response = await _dbContext.Users.ToListAsync();
            if (response != null)
            {
                return response.Select(x => new UserEntity
                {
                    Name = x.Name,
                    Email = x.Email,
                    Dob = x.Dob,
                    UserName = x.UserName,
                    Updated = x.Updated,
                    UpdatedBy = x.UpdatedBy,
                    Password= x.Password,
                    Id = x.Id,
                    Created = x.Created,
                    CreatedBy = x.CreatedBy,
                    IsActive = x.IsActive,
                    IsDeleted = x.IsDeleted,
                    LastUpdated = x.LastUpdated
                });
            }
            return await Task.Run(() => new List<UserEntity>());
        }
    }
}
