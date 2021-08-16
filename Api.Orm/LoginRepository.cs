using System.Data.SqlClient;
using Api.Domain.Dtos;
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
            string sql = @"SELECT [dbo].[F_LOGIN_USUARIO] (
                        @USUARIO,
                        @SENHA)";

            using (var con = new SqlConnection(base.GetConnection()))
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@USUARIO", loginDto.Usuario);
                parameters.Add("@SENHA", loginDto.Senha);

                return (con.QueryFirstOrDefault<int>(sql, parameters));
            }
        }
    }
}
