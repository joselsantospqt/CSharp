using System;
using System.Collections.Generic;
using System.Text;
using Modelo;
using Dapper;
using Repositorio;
using System.Data.SqlClient;

namespace Calendario.Repositorio
{
    public class RepositorioPessoa : BaseRepositorio
    {
        private static List<Pessoa> ListaDePessoasCadastradas { get; set; } = new List<Pessoa>();

        public void Create(Pessoa pessoa)
        {
            using (SqlConnection dbConnection = new SqlConnection(ConnectDataBase()))
            {
                var sql = @"InsertPessoa";

                dbConnection.Execute(sql, new
                {
                    ID = pessoa.ID,
                    NOME = pessoa.NM_NOME,
                    SOBRENOME = pessoa.NM_SOBRENOME,
                    DATANASCIMENTO = pessoa.DT_NASCIMENTO
                }, commandType: System.Data.CommandType.StoredProcedure);
            }

        }

        public void Delete(Pessoa pessoa)
        {
            using (SqlConnection dbConnection = new SqlConnection(ConnectDataBase()))
            {
                var sql = @"DeletePessoa";

                dbConnection.Execute(sql, new
                {
                    ID = pessoa.ID,
                }, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public List<Pessoa> GetAll()
        {
            using (SqlConnection dbConnection = new SqlConnection(ConnectDataBase()))
            {
                var sql = @"GetAll";

                var resultado = dbConnection.Query<Pessoa>(sql, commandType: System.Data.CommandType.StoredProcedure);

                return resultado.AsList();
            }
        }

        //public Pessoa GetPessoa(int id)
        //{
        //    using (SqlConnection dbConnection = new SqlConnection(ConnectDataBase()))
        //    {
        //        Pessoa obj = new Pessoa();
        //        var sql = @"GetById";
        //        var resultado = dbConnection.Query<Pessoa>(sql, new
        //        {
        //            ID = id,
        //        },
        //        commandType: System.Data.CommandType.StoredProcedure);

        //        return resultado;
        //    }
        //}

        public void Update(Pessoa pessoa, int id)
        {
            using (SqlConnection dbConnection = new SqlConnection(ConnectDataBase()))
            {
                var sql = @"UpdatePessoa";

                dbConnection.Execute(sql, new
                {
                    ID = id,
                    NOME = pessoa.NM_NOME,
                    SOBRENOME = pessoa.NM_SOBRENOME,
                    DATANASCIMENTO = pessoa.DT_NASCIMENTO,
               
                }, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
