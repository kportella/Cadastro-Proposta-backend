using Microsoft.Extensions.Configuration;
using Api.Orm.Interfaces;
using Api.Domain.Entities;
using System.Collections.Generic;
using Dapper;
using System.Data.SqlClient;

namespace Api.Orm
{
    public class CadastroPropostaRepository : ConnectorRepository, ICadastroPropostaRepository
    {
        public CadastroPropostaRepository(IConfiguration configuration) : base(configuration)
        {

        }
        public void Add(TreinaPropostasEntity obj)
        {
            string sql = @"INSERT INTO [dbo].[TREINA_PROPOSTAS]
           ([PROPOSTA]
           ,[CPF]
           ,[CONVENIADA]
           ,[VLR_SOLICITADO]
           ,[PRAZO]
           ,[VLR_FINANCIADO]
           ,[SITUACAO]
           ,[OBSERVACAO]
           ,[DT_SITUACAO]
           ,[USUARIO]
           ,[USUARIO_ATUALIZACAO]
           ,[DATA_ATUALIZACAO])
     VALUES
           (@PROPOSTA
           ,@CPF
           ,@CONVENIADA
           ,@VLR_SOLICITADO
           ,@PRAZO
           ,@VLR_SOLICITADO
           ,@SITUACAO
           ,@OBSERVACAO
           ,@DT_SITUACAO
           ,@USUARIO
           ,@USUARIO_ATUALIZACAO
           ,@DATA_ATUALIZACAO)";

            using (var con = new SqlConnection(base.GetConnection()))
            {
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@PROPOSTA", obj.Proposta);
                parameter.Add("@CPF", obj.CPF);
                parameter.Add("@CONVENIADA", obj.Conveniada);
                parameter.Add("@VLR_SOLICITADO", obj.Vlr_Solicitado);
                parameter.Add("@PRAZO", obj.Prazo);
                parameter.Add("@VLR_FINANCIADO", obj.Vlr_Financiado);
                parameter.Add("@SITUACAO", obj.Situacao);
                parameter.Add("@OBSERVACAO", obj.Observacao);
                parameter.Add("@DT_SITUACAO", obj.Dt_Situacao);
                parameter.Add("@USUARIO", obj.Usuario);
                parameter.Add("@USUARIO_ATUALIZACAO", obj.Usuario_Atualizacao);
                parameter.Add("@DATA_ATUALIZACAO", obj.Data_Atualizacao);

                con.Execute(sql, parameter);
            }
        }

        public TreinaPropostasEntity Get(int Id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<TreinaPropostasEntity> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void Remove(TreinaPropostasEntity obj)
        {
            throw new System.NotImplementedException();
        }

        public void Update(TreinaPropostasEntity obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
