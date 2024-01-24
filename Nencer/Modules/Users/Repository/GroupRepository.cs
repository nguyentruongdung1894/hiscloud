using Dapper;
using System.Data;

namespace Nencer.Modules.Users.Repository
{
    public interface IGroupRepository
    {
        Task<List<Group>> GetGroupsByUserId(long userId);
    }

    public class GroupRepository : IGroupRepository
    {
        private readonly DapperContext _dapperContext;

        public GroupRepository(DapperContext dapperContext)
        {
            this._dapperContext = dapperContext;
        }

        public async Task<List<Group>> GetGroupsByUserId(long userId)
        {
            var procName = "sp_get_group_by_userid";
            var param = new DynamicParameters();
            param.Add("P_USER_ID", userId, DbType.Int64, ParameterDirection.Input);

            using (var con = _dapperContext.CreateConnection())
            {
                var x = await con
                    .QueryAsync<Group>(procName, param, commandType: CommandType.StoredProcedure);

                return x.ToList();
            }
        }
    }
}
