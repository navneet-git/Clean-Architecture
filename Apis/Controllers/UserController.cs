using Application.Common;
using Application.Contracts.Service;
using Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpGet]
        public async Task<ActionResult<Response<UserDto>>> GetAll()
        {
            var response = new Response<UserDto>();
            try
            {
                response.ListData = await _userService.GetAll();
            }
            catch (Exception ex)
            {
                response.Error = ex.Message;
                response.IsSuccess = false;
            }

            return response;
        }

        [HttpGet("id")]
        public async Task<ActionResult<Response<UserDto>>> GetUser(int id)
        {
            var response = new Response<UserDto>();
            try
            {
                response.Data = await _userService.Get(id);
            }
            catch (Exception ex)
            {
                response.Error = ex.Message;
                response.IsSuccess = false;
            }

            return response;
        }
        
        [HttpPost]
        public async Task<ActionResult<Response<int>>> Add(UserDto userDto)
        {
            var response = new Response<int>();
            try
            {
                response.Data = await _userService.Add(userDto);
            }
            catch (Exception ex)
            {
                response.Error = ex.Message;
                response.IsSuccess = false;
            }

            return response;
        }

        [HttpPut]
        public async Task<ActionResult<Response<int>>> Update(UserDto userDto)
        {
            var response = new Response<int>();
            try
            {
                response.Data = await _userService.Update(userDto);
            }
            catch (Exception ex)
            {
                response.Error = ex.Message;
                response.IsSuccess = false;
            }

            return response;
        }

        [HttpDelete("id")]
        public async Task<ActionResult<Response<int>>> Delete(int id)
        {
            var response = new Response<int>();
            try
            {
                response.Data = await _userService.Delete(id);
            }
            catch (Exception ex)
            {
                response.Error = ex.Message;
                response.IsSuccess = false;
            }

            return response;
        }
    }
}
