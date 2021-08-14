using Microsoft.Extensions.Configuration;
using Api.Orm.Interfaces;
using Api.Domain.Entities;
using System.Collections.Generic;
using Dapper;
using System.Data.SqlClient;
using Api.Domain.Dtos;

namespace Api.Orm
{
    public class CadastroPropostaRepository : ConnectorRepository, ICadastroPropostaRepository
    {
        public CadastroPropostaRepository(IConfiguration configuration) : base(configuration)
        {

        }
        public void Add(PropostaDtoCreate propostaDtoCreate)
        {
            string sqlProposta = @"INSERT INTO [dbo].[TREINA_PROPOSTAS]
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

            string sqlCliente = @"INSERT INTO [dbo].[TREINA_CLIENTES]
           ([CPF]
           ,[NOME]
           ,[DT_NASCIMENTO]
           ,[GENERO]
           ,[VLR_SALARIO]
           ,[LOGRADOURO]
           ,[NUMERO_RESIDENCIA]
           ,[BAIRRO]
           ,[CIDADE]
           ,[CEP]
           ,[USUARIO_ATUALIZACAO]
           ,[DATA_ATUALIZACAO])
     VALUES
           (@CPF
           ,@NOME
           ,@DT_NASCIMENTO
           ,@GENERO
           ,@VLR_SALARIO
           ,@LOGRADOURO
           ,@NUMERO_RESIDENCIA
           ,@BAIRRO
           ,@CIDADE
           ,@CEP
           ,@USUARIO_ATUALIZACAO
           ,@DATA_ATUALIZACAO)";

            string sqlEncontrarProposta = "SELECT MAX(PROPOSTA) FROM TREINA_PROPOSTAS";

            TreinaClientesEntity treinaClientesEntity = propostaDtoCreate.TreinaClientesEntity;
            TreinaPropostasEntity treinaPropostasEntity = propostaDtoCreate.TreinaPropostasEntity;

            using (var con = new SqlConnection(base.GetConnection()))
            {
                int proposta = con.QueryFirst<int>(sqlEncontrarProposta);
                treinaPropostasEntity.Proposta = proposta + 1;

                DynamicParameters parameterProposta = new DynamicParameters();
                parameterProposta.Add("@PROPOSTA", treinaPropostasEntity.Proposta);
                parameterProposta.Add("@CPF", treinaPropostasEntity.CPF);
                parameterProposta.Add("@CONVENIADA", treinaPropostasEntity.Conveniada);
                parameterProposta.Add("@VLR_SOLICITADO", treinaPropostasEntity.Vlr_Solicitado);
                parameterProposta.Add("@PRAZO", treinaPropostasEntity.Prazo);
                parameterProposta.Add("@VLR_FINANCIADO", treinaPropostasEntity.Vlr_Financiado);
                parameterProposta.Add("@SITUACAO", treinaPropostasEntity.Situacao);
                parameterProposta.Add("@OBSERVACAO", treinaPropostasEntity.Observacao);
                parameterProposta.Add("@DT_SITUACAO", treinaPropostasEntity.Dt_Situacao);
                parameterProposta.Add("@USUARIO", treinaPropostasEntity.Usuario);
                parameterProposta.Add("@USUARIO_ATUALIZACAO", treinaPropostasEntity.Usuario_Atualizacao);
                parameterProposta.Add("@DATA_ATUALIZACAO", treinaPropostasEntity.Data_Atualizacao);

                con.Execute(sqlProposta, parameterProposta);

                DynamicParameters parametersCliente = new DynamicParameters();

                parametersCliente.Add("@CPF", treinaClientesEntity.CPF);
                parametersCliente.Add("@NOME", treinaClientesEntity.Nome);
                parametersCliente.Add("@DT_NASCIMENTO", treinaClientesEntity.Dt_Nascimento);
                parametersCliente.Add("@GENERO", treinaClientesEntity.Genero);
                parametersCliente.Add("@VLR_SALARIO", treinaClientesEntity.Vlr_Salario);
                parametersCliente.Add("@LOGRADOURO", treinaClientesEntity.Logradouro);
                parametersCliente.Add("@NUMERO_RESIDENCIA", treinaClientesEntity.Numero_Residencia);
                parametersCliente.Add("@BAIRRO", treinaClientesEntity.Bairro);
                parametersCliente.Add("@CIDADE", treinaClientesEntity.Cidade);
                parametersCliente.Add("@CEP", treinaClientesEntity.CEP);
                parametersCliente.Add("@USUARIO_ATUALIZACAO", treinaClientesEntity.Usuario_Atualizacao);
                parametersCliente.Add("@DATA_ATUALIZACAO", treinaClientesEntity.Data_Atualizacao);

                con.Execute(sqlCliente, parametersCliente);
            }
        }
        public PropostaDtoCreate Get(int Id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<PropostaDtoCreate> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void Remove(PropostaDtoCreate treinaPropostasEntity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(PropostaDtoCreate treinaPropostasEntity)
        {
            throw new System.NotImplementedException();
        }
    }
}
