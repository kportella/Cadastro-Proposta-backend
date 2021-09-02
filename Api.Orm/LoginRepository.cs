using System.Data.SqlClient;
using Api.Service.Dtos;
using Api.Orm.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Api.Orm
{
    public class LoginRepository : ConnectorRepository, IUsuarioLoginRepository
    {
        public LoginRepository(IConfiguration configuration) : base(configuration)
        {
        }


        public int Login(LoginDto loginDto)
        {
            var sql = @"SELECT [dbo].[F_LOGIN_USUARIO] (
                        @USUARIO,
                        @SENHA)";

            using (var con = new SqlConnection(base.GetConnection()))
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@USUARIO", new DbString { Value = loginDto.Usuario, IsAnsi = true, IsFixedLength = true, Length = 10 });
                parameters.Add("@SENHA", new DbString { Value = loginDto.Senha, IsAnsi = true, IsFixedLength = true, Length = 10 });

                return (con.QueryFirstOrDefault<int>(sql, parameters));
            }
        }
    }
}
