using Microsoft.EntityFrameworkCore;
using Nencer.Modules.Users.Model;
using Nencer.Modules.Users.Model.Dto;
using Nencer.Shared;
using System.Collections.Generic;
using System.Linq;

namespace Nencer.Modules.Users.Repository
{
    public interface IUserRepository
    {
        Task<BasePaggingResponse<List<User>>> GetListUserAsync(string? filter, int skipCount = 0, int maxResultCount = 10);
        Task<List<User>> GetListUserAsync();
        Task<User?> GetUserByIdAsync(long id);
        Task<User?> GetUserByUserNameAsync(string userName);
        Task<BaseResponse<User>> CreateUserAsync(User user);
        Task<BaseResponse<User>> UpdateUserAsync(UpdateUserInput input);
        Task<BaseResponse<object?>> DeleteUserAsync(long id);

        Task<User> FindByUserNameOrEmail(string userName, string email);
    }

    public class UserRepository : IUserRepository
    {
        private readonly IRoleRepository roleRepository;
        private readonly IGroupRepository groupRepository;

        private readonly NencerDbContext context;
        private readonly DapperContext dapperContext;

        public UserRepository(NencerDbContext context, DapperContext dapperContext, IRoleRepository roleRepository, IGroupRepository groupRepository)
        {
            this.context = context;
            this.dapperContext = dapperContext;
            this.roleRepository = roleRepository;
            this.groupRepository = groupRepository;
        }

        public async Task<BasePaggingResponse<List<User>>> GetListUserAsync(string? filter = "", int skipCount = 0, int maxResultCount = 10)
        {
            BasePaggingResponse<List<User>> b = new BasePaggingResponse<List<User>>();


            var x1 = await context.Users
                //.Include(x=>x.Groups)
                //.Include(x=>x.Roles)
                .Where(x => string.IsNullOrEmpty(filter)
            ? true : x.Username.Contains(filter) || x.Email.Contains(filter))
                .Skip((int)skipCount)
                .Take((int)maxResultCount)
                .ToListAsync();
            var x2 = await context.Users.Where(x => string.IsNullOrEmpty(filter)
            ? true : x.Username.Contains(filter) || x.Email.Contains(filter)).CountAsync();

            b.Data = x1;
            b.TotalItems = x2;

            return b;
        }

        public async Task<List<User>> GetListUserAsync()
        {
            return await context.Users.ToListAsync();
        }

        public async Task<BaseResponse<User>> CreateUserAsync(User user)
        {
            using (var transaction = await context.Database.BeginTransactionAsync())
            {
                try
                {
                    // save user
                    await context.Users.AddAsync(user);
                    await context.SaveChangesAsync();

                    // save role
                    await roleRepository.DeleteAllByUserId(user.Id);
                    foreach (var role in user.Roles)
                    {

                    }
                    // save group

                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                    return new BaseResponse<User>
                    {
                        Message = ex.Message,
                        ResponseCode = "500",
                        Data = null
                    };
                }
            }


            return new BaseResponse<User>
            {
                Message = "Thành công!",
                ResponseCode = "200",
                Data = user
            };
        }

        public async Task<BaseResponse<User>> UpdateUserAsync(UpdateUserInput input)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == input.Id);
            if (user != null)
            {
                user.Email = input.Email;
                user.Phone = input.PhoneNumber;
                context.Users.Update(user);
                await context.SaveChangesAsync();
                return new BaseResponse<User>
                {
                    Message = "Thành công!",
                    ResponseCode = "200",
                    Data = user
                };
            }
            return new BaseResponse<User>
            {
                Message = "User không tồn tại!",
                ResponseCode = "500",
            };
        }

        public async Task<User?> GetUserByIdAsync(long id)
        {
            return await context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<BaseResponse<object?>> DeleteUserAsync(long id)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user != null)
            {
                context.Users.Remove(user);
                await context.SaveChangesAsync();
                return new BaseResponse<object?>
                {
                    Message = "Thành công!",
                    ResponseCode = "200",
                };
            }
            return new BaseResponse<object?>
            {
                ResponseCode = "500",
                Message = "Không tìm thấy user!"
            };
        }

        public async Task<User?> GetUserByUserNameAsync(string userName)
        {
            return await context.Users.FirstOrDefaultAsync(x => x.Username.ToLower().Trim() == userName.ToLower().Trim());
        }

        public async Task<User?> FindByUserNameOrEmail(string userName, string email)
        {
            return await context.Users.FirstOrDefaultAsync(x => x.Username.ToLower().Trim() == userName || x.Email == email.ToLower().Trim());
        }
    }
}

