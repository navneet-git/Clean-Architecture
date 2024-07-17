using Domain.Entities;

namespace Application.Contracts.Repository
{
    public interface IUserRepository
    {
        Task<int> Add(UserEntity user);
        Task<int> Update(UserEntity user);
        Task<int> Delete(int id);
        Task<UserEntity> Get(int id);
        Task<IEnumerable<UserEntity>> GetAll();
    }
}
