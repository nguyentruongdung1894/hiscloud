using Dapper;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace Nencer.Modules.Users.Repository
{
    public interface IRoleRepository
    {
        Task<int> DeleteAllByUserId(long userId);
        Task<List<Role>> GetRolesByUserId(long userId);
    }

    public class RoleRepotisoty : IRoleRepository
    {
        private readonly DapperContext _dapperContext;
        private readonly NencerDbContext nencerDbContext;

        public RoleRepotisoty(DapperContext dapperContext, NencerDbContext nencerDbContext)
        {
            this._dapperContext = dapperContext;
            this.nencerDbContext = nencerDbContext;
        }

        public async Task<int> DeleteAllByUserId(long userId)
        {
            var role = await nencerDbContext.Roles.FirstOrDefaultAsync();
            if (role == null)
            {
                return 0;
            }
            nencerDbContext.Remove(role);
            return await nencerDbContext.SaveChangesAsync();
        }

        public async Task<List<Role>> GetRolesByUserId(long userId)
        {
            var procName = "sp_get_roles_by_userid";
            var param = new DynamicParameters();
            param.Add("P_USER_ID", userId, DbType.Int64, ParameterDirection.Input);

            using (var con = _dapperContext.CreateConnection())
            {
                var x = await con
                    .QueryAsync<Role>(procName, param, commandType: CommandType.StoredProcedure);

                return x.ToList();
            }
        }
    }
}
