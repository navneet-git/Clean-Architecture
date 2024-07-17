using Application.Models;

namespace Application.Contracts.Service
{
    public interface IUserService
    {
        Task<int> Add(UserDto user);
        Task<int> Update(UserDto user);
        Task<int> Delete(int id);
        Task<UserDto> Get(int id);
        Task<IEnumerable<UserDto>> GetAll();
    }
}
