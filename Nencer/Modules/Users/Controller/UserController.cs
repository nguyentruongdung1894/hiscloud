using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.IdentityModel.Tokens;
using Nencer.Helpers;
using Nencer.Modules.Users.Model;
using Nencer.Modules.Users.Model.Dto;
using Nencer.Modules.Users.Repository;
using Nencer.Resources;
using Nencer.Shared;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Nencer.Modules.Users.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IGroupRepository groupRepository;
        private readonly IRoleRepository roleRepository;
        private readonly IConfiguration configuration;
        private readonly IStringLocalizer<NencerResource> localizer;
        private readonly IMapper _mapper;
        public UserController(IUserRepository userRepository, IConfiguration configuration, IStringLocalizer<NencerResource> localizer, IMapper mapper, IGroupRepository groupRepository, IRoleRepository roleRepository)
        {
            this.userRepository = userRepository;
            this.configuration = configuration;
            this.localizer = localizer;
            _mapper = mapper;
            this.groupRepository = groupRepository;
            this.roleRepository = roleRepository;
        }

        [HttpGet("/user/get_all")]
        public async Task<BaseResponse<List<User>>> GetUsersAsync(string? filter)
        {
            var item = await userRepository.GetListUserAsync();
            return new BaseResponse<List<User>>
            {
                Message = "",
                ResponseCode = "200",
                Data = item
            };
        }

        [HttpGet("/user")]
        public async Task<BaseResponse<Dictionary<String, object>>> GetUsersAsync(string? filter, int? skipCount = 0, int? maxResultCount = 10)
        {
            Dictionary<String, object> data = new Dictionary<string, object>();
            var item = await userRepository.GetListUserAsync(filter, skipCount.GetValueOrDefault(), maxResultCount.GetValueOrDefault());
            List<User> users = item.Data;
            if (users != null)
            {
                foreach (var user in users)
                {
                    // get role
                    List<Role> roles = await roleRepository.GetRolesByUserId(user.Id);
                    user.Roles = roles;
                    // get group
                    List<Group> groups = await groupRepository.GetGroupsByUserId(user.Id);
                    user.Groups = groups;

                }
            }
            data.Add("users", item.Data);
            data.Add("totalItems", item.TotalItems);
            return new BaseResponse<Dictionary<String, object>>
            {
                Message = "",
                ResponseCode = "200",
                Data = data
            };
        }

        [HttpGet("/user/{username}")]
        public async Task<BaseResponse<Dictionary<String, object>>> GetUserByName(string username)
        {
            Dictionary<String, object> data = new Dictionary<string, object>();
            var item = await userRepository.GetUserByUserNameAsync(username);
            data.Add("user", item);
            return new BaseResponse<Dictionary<String, object>>
            {
                Message = "",
                ResponseCode = "200",
                Data = data
            };
        }

        [HttpGet("/userbyId/{id}")]
        public async Task<BaseResponse<Dictionary<String, object>>> GetUserById(long id)
        {
            Dictionary<String, object> data = new Dictionary<string, object>();
            var item = await userRepository.GetUserByIdAsync(id);
            data.Add("user", item);
            return new BaseResponse<Dictionary<String, object>>
            {
                Message = "",
                ResponseCode = "200",
                Data = data
            };
        }

        [HttpPost("user")]
        [Authorize]
        public async Task<BaseResponse<User>> CreateUserAsync(CreateUserRequest req)
        {
            if (ModelState.IsValid)
            {

            }

            var user = userRepository.FindByUserNameOrEmail(req.Username, req.Email);
            if (user != null)
            {
                return new BaseResponse<User>
                {
                    Message = "",
                    ResponseCode = "500",
                    Data = null
                };
            }
            foreach (var role in req.Roles)
            {

            }
            foreach (var group in req.Groups)
            {

            }
            var user1 = _mapper.Map<User>(req);
            user1.Password = PasswordHasher.HashPassword(req.Password);
            user1.CreatedAt = DateTime.Now;
            user1.Username = req.Username;

            return await userRepository.CreateUserAsync(user1);
        }

        [HttpPut("UpdateUser")]
        public async Task<BaseResponse<User>> UpdateUserAsync(UpdateUserInput input)
        {
            return await userRepository.UpdateUserAsync(input);
        }

        [HttpDelete("DeleteUser")]
        public async Task<BaseResponse<object?>> DeleteUserAsync(long id)
        {
            return await userRepository.DeleteUserAsync(id);
        }

        [HttpPost("Login")]
        public async Task<BaseResponse<LoginResponse>> Login(string userName, string password)
        {
            var user = await userRepository.GetUserByUserNameAsync(userName);
            if (user != null && PasswordHasher.VerifyHash(password, user.Password))
            {
                return new BaseResponse<LoginResponse>
                {
                    ResponseCode = "200",
                    Message = "Thành công!",
                    Data = new LoginResponse()
                    {
                        UserName = user.Username,
                        Email = user.Email,
                        PhoneNumber = user.Phone,
                        Id = user.Id,
                        Token = GenerateToken(user)
                    }
                };
            }
            else
            {
                return new BaseResponse<LoginResponse>
                {
                    ResponseCode = "500",
                    Message = "Tài khoản hoặc mật khẩu không đúng!",
                    Data = null,
                };
            }
        }

        [HttpGet("GetMessage")]
        public string GetMessage(string key)
        {
            return localizer[key].Value;
        }

        [HttpGet("GenPass")]
        public string GenPass(string pass)
        {
            return PasswordHasher.HashPassword(pass);
        }

        private string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var secretKey = configuration["Settings:SecretKey"];
            var secretByte = Encoding.UTF8.GetBytes(secretKey);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
                {

                     new Claim("UserName", user.Username),
                     new Claim("Id", user.Id.ToString()),
                     new Claim("TokenId", Guid.NewGuid().ToString()),
                 }),
                Expires = DateTime.UtcNow.AddMinutes(360),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretByte), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(token);
        }
    }
}
