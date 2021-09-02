using Microsoft.Extensions.Configuration;
using Api.Orm.Interfaces;
using Api.Domain.Entities;
using System.Collections.Generic;
using Dapper;
using System.Data.SqlClient;
using Api.Service.Dtos;
using System;

namespace Api.Orm
{
    public class CadastroPropostaRepository : ConnectorRepository, ICadastroPropostaRepository
    {
        public CadastroPropostaRepository(IConfiguration configuration) : base(configuration)
        {

        }
        public int Add(PropostaDtoCreate propostaDtoCreate)
        {

            string sqlAlterarCliente = @"UPDATE [dbo].[TREINA_CLIENTES]
                            SET [CPF] = @CPF
                                ,[NOME] = @NOME
                                ,[DT_NASCIMENTO] = @DT_NASCIMENTO
                                ,[GENERO] = @GENERO
                                ,[VLR_SALARIO] = @VLR_SALARIO
                                ,[LOGRADOURO] = @LOGRADOURO
                                ,[NUMERO_RESIDENCIA] = @NUMERO_RESIDENCIA
                                ,[BAIRRO] = @BAIRRO
                                ,[CIDADE] = @CIDADE
                                ,[CEP] = @CEP
                                ,[USUARIO_ATUALIZACAO] = @USUARIO_ATUALIZACAO
                                ,[DATA_ATUALIZACAO] = @DATA_ATUALIZACAO
                            WHERE [CPF] = @CPF";

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
                            ,@VLR_FINANCIADO
                            ,@SITUACAO
                            ,@OBSERVACAO
                            ,@DT_SITUACAO
                            ,@USUARIO
                            ,@USUARIO_ATUALIZACAO
                            ,@DATA_ATUALIZACAO)";

            string sqlAlterarProposta = @"UPDATE [dbo].[TREINA_PROPOSTAS]
                                        SET [CONVENIADA] = @CONVENIADA
                                            ,[VLR_SOLICITADO] = @VLR_SOLICITADO
                                            ,[PRAZO] = @PRAZO
                                            ,[VLR_FINANCIADO] = @VLR_FINANCIADO
                                            ,[SITUACAO] = @SITUACAO
                                            ,[OBSERVACAO] = @OBSERVACAO
                                            ,[DT_SITUACAO] = @DT_SITUACAO
                                            ,[USUARIO] = @USUARIO
                                            ,[USUARIO_ATUALIZACAO] = @USUARIO_ATUALIZACAO
                                            ,[DATA_ATUALIZACAO] = @DATA_ATUALIZACAO
                                        WHERE [CPF] = @CPF";

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

            string sqlIncrementarProposta = @"UPDATE [dbo].[TREINA_PARAMETRO]
                                            SET VALOR = VALOR + 1
                                            WHERE PropostaParametros = 'UltimaProposta'
                                            SELECT VALOR from TREINA_PARAMETRO WHERE PropostaParametros = 'UltimaProposta'";

            string sqlEcontrarCPF = "SELECT CPF FROM TREINA_CLIENTES WHERE CPF=@CPF";
            string sqlEncontrarProposta = "SELECT PROPOSTA FROM TREINA_PROPOSTAS WHERE CPF=@CPF";

            TreinaClientesEntity treinaClientesEntity = propostaDtoCreate.TreinaClientesEntity;
            TreinaPropostasEntity treinaPropostasEntity = propostaDtoCreate.TreinaPropostasEntity;

            using (var con = new SqlConnection(base.GetConnection()))
            {

                DynamicParameters CPFparameter = new DynamicParameters();
                CPFparameter.Add("@CPF", treinaClientesEntity.CPF);
                var encontrarCPF = con.QueryFirstOrDefault(sqlEcontrarCPF, CPFparameter);

                if (encontrarCPF == null)
                {
                    var proposta = con.QueryFirst<int>(sqlIncrementarProposta);
                    treinaPropostasEntity.Proposta = proposta + 1;
                }

                DynamicParameters parameterProposta = new DynamicParameters();
                parameterProposta.Add("@PROPOSTA", treinaPropostasEntity.Proposta);
                parameterProposta.Add("@CPF", new DbString { Value = treinaPropostasEntity.CPF, IsFixedLength = true, IsAnsi = true, Length = 11 });
                parameterProposta.Add("@CONVENIADA", new DbString { Value = treinaPropostasEntity.Conveniada, IsFixedLength = true, IsAnsi = true, Length = 6 });
                parameterProposta.Add("@VLR_SOLICITADO", treinaPropostasEntity.Vlr_Solicitado);
                parameterProposta.Add("@PRAZO", treinaPropostasEntity.Prazo);
                parameterProposta.Add("@VLR_FINANCIADO", treinaPropostasEntity.Vlr_Financiado);
                parameterProposta.Add("@SITUACAO", new DbString { Value = treinaPropostasEntity.Situacao, IsAnsi = true, IsFixedLength = true, Length = 2 });
                parameterProposta.Add("@OBSERVACAO", new DbString { Value = treinaPropostasEntity.Observacao, IsFixedLength = false, IsAnsi = true });
                parameterProposta.Add("@DT_SITUACAO", treinaPropostasEntity.Dt_Situacao);
                parameterProposta.Add("@USUARIO", new DbString { Value = treinaPropostasEntity.Usuario, IsAnsi = true, IsFixedLength = true, Length = 10 });
                parameterProposta.Add("@USUARIO_ATUALIZACAO", new DbString { Value = treinaPropostasEntity.Usuario_Atualizacao, IsAnsi = true, IsFixedLength = true, Length = 10 });
                parameterProposta.Add("@DATA_ATUALIZACAO", treinaPropostasEntity.Data_Atualizacao);

                DynamicParameters parametersCliente = new DynamicParameters();


                parametersCliente.Add("@CPF", new DbString { Value = treinaPropostasEntity.CPF, IsFixedLength = true, IsAnsi = true, Length = 11 });
                parametersCliente.Add("@NOME", new DbString { Value = treinaClientesEntity.Nome, IsFixedLength = false, IsAnsi = true });
                parametersCliente.Add("@DT_NASCIMENTO", treinaClientesEntity.Dt_Nascimento);
                parametersCliente.Add("@GENERO", treinaClientesEntity.Genero);
                parametersCliente.Add("@VLR_SALARIO", treinaClientesEntity.Vlr_Salario);
                parametersCliente.Add("@LOGRADOURO", new DbString { Value = treinaClientesEntity.Logradouro, IsFixedLength = false, IsAnsi = true });
                parametersCliente.Add("@NUMERO_RESIDENCIA", new DbString { Value = treinaClientesEntity.Numero_Residencia, IsAnsi = true, IsFixedLength = true, Length = 10 });
                parametersCliente.Add("@BAIRRO", new DbString { Value = treinaClientesEntity.Bairro, IsFixedLength = false, IsAnsi = true });
                parametersCliente.Add("@CIDADE", new DbString { Value = treinaClientesEntity.Cidade, IsAnsi = true, IsFixedLength = false });
                parametersCliente.Add("@CEP", new DbString { Value = treinaClientesEntity.CEP, IsFixedLength = true, IsAnsi = true, Length = 8 });
                parametersCliente.Add("@USUARIO_ATUALIZACAO", new DbString { Value = treinaClientesEntity.Usuario_Atualizacao, IsAnsi = true, IsFixedLength = true, Length = 10 });
                parametersCliente.Add("@DATA_ATUALIZACAO", treinaClientesEntity.Data_Atualizacao);


                if (encontrarCPF == null)
                {
                    con.Execute(sqlCliente, parametersCliente);
                    con.Execute(sqlProposta, parameterProposta);
                    return treinaPropostasEntity.Proposta;
                }
                else
                {
                    con.Execute(sqlAlterarCliente, parametersCliente);
                    con.Execute(sqlAlterarProposta, parameterProposta);
                    return con.QueryFirstOrDefault<int>(sqlEncontrarProposta, CPFparameter);

                }
            }
        }
        public PropostaDtoCreate Get(string CPF)
        {
            var sqlProposta = "SELECT * FROM TREINA_PROPOSTAS WHERE CPF = @CPF";
            var sqlCliente = "SELECT * FROM TREINA_CLIENTES WHERE CPF = @CPF";

            TreinaClientesEntity treinaClientesEntity = new TreinaClientesEntity();
            TreinaPropostasEntity treinaPropostasEntity = new TreinaPropostasEntity();

            using (var con = new SqlConnection(base.GetConnection()))
            {

                DynamicParameters parameterCPF = new DynamicParameters();
                parameterCPF.Add("@CPF", new DbString { Value = CPF, IsFixedLength = true, IsAnsi = true, Length = 11 });
                treinaClientesEntity = con.QueryFirstOrDefault<TreinaClientesEntity>(sqlCliente, parameterCPF);
                treinaPropostasEntity = con.QueryFirstOrDefault<TreinaPropostasEntity>(sqlProposta, parameterCPF);

                return (new PropostaDtoCreate()
                {
                    TreinaClientesEntity = treinaClientesEntity,
                    TreinaPropostasEntity = treinaPropostasEntity
                });

            }

        }

        public List<PropostaDtoCreate> GetAll(string usuario)
        {
            var sqlProposta = "SELECT * FROM TREINA_PROPOSTAS WHERE USUARIO=@USUARIO";
            var slqCliente = "SELECT * FROM TREINA_CLIENTES WHERE CPF=@CPF";

            TreinaClientesEntity treinaClientesEntity = new TreinaClientesEntity();
            List<PropostaDtoCreate> listPropostaDtoCreate = new List<PropostaDtoCreate>();

            using (var con = new SqlConnection(base.GetConnection()))
            {
                DynamicParameters parameterUsuario = new DynamicParameters();
                parameterUsuario.Add("@USUARIO", new DbString { Value = usuario, IsAnsi = true, IsFixedLength = true, Length = 10 });
                IEnumerable<TreinaPropostasEntity> listTreinaPropostaEntity = con.Query<TreinaPropostasEntity>(sqlProposta, parameterUsuario);

                foreach (TreinaPropostasEntity item in listTreinaPropostaEntity)
                {
                    DynamicParameters parameterCPF = new DynamicParameters();
                    parameterCPF.Add("@CPF", new DbString { Value = item.CPF, IsFixedLength = true, IsAnsi = true, Length = 11 });
                    treinaClientesEntity = con.QueryFirstOrDefault<TreinaClientesEntity>(slqCliente, parameterCPF);
                    listPropostaDtoCreate.Add(new PropostaDtoCreate
                    {
                        TreinaClientesEntity = treinaClientesEntity,
                        TreinaPropostasEntity = item
                    });
                }
                return listPropostaDtoCreate;

            }
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
