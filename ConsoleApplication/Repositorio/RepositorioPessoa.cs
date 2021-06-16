using System;
using Interface;
using System.Collections.Generic;
using System.Text;
using Modelo;
using System.Data.SqlClient;
using Service;
using Dapper;

namespace Calendario.Repositorio
{
    public class RepositorioPessoa : BaseService, IRepositorioPessoa
    {
        private static List<Pessoa> ListaDePessoasCadastradas { get; set; } = new List<Pessoa>();

        public void Create(Pessoa pessoa)
        {
            using (SqlConnection dbConnection = new SqlConnection(ConnectDataBase()))
            {
                var sql = @"dbo.InsertPessoa";

                dbConnection.Execute(sql, new
                {
                    id = pessoa.ID,
                    Nome = pessoa.Nome,
                    SobreNome = pessoa.SobreNome,
                    DataNascimento = pessoa.DataNascimento
                }, commandType: System.Data.CommandType.StoredProcedure);
            }

        }

        public void Delete(Pessoa pessoa)
        {
            using (SqlConnection dbConnection = new SqlConnection(ConnectDataBase()))
            {
                var sql = @"dbo.DeletePessoa";

                dbConnection.Execute(sql, new
                {
                    IdPessoa = pessoa.ID,
                }, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public List<Pessoa> GetAll()
        {
            using (SqlConnection dbConnection = new SqlConnection(ConnectDataBase()))
            {
                var sql = @"[dbo].[GetAll]";

                var resultado = dbConnection.Query<Pessoa>(sql, commandType: System.Data.CommandType.StoredProcedure);

                return resultado.AsList();
            }
        }

        public Pessoa GetPessoa(int id)
        {
            using (SqlConnection dbConnection = new SqlConnection(ConnectDataBase()))
            {
                var sql = @"[dbo].[SelectCustomerById]";

                dbConnection.Open();

                var command = dbConnection.CreateCommand();

                command.CommandText = sql;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@IdPessoa", id));

                var result = command.ExecuteReader();

                Pessoa pessoa = null;

                while (result.Read())
                {
                    pessoa = new Pessoa();
                    pessoa.SobreNome = result[2].ToString();
                    pessoa.Nome = result[1].ToString();
                    pessoa.ID = Convert.ToInt32(result[0]);
                }

                dbConnection.Close();

                return pessoa;
            }
        }

        public void Update(Pessoa pessoa, int id)
        {
            using (SqlConnection dbConnection = new SqlConnection(ConnectDataBase()))
            {
                var sql = @"dbo.UpdatePessoa";

                dbConnection.Execute(sql, new
                {
                    Nome = pessoa.Nome,
                    SobreNome = pessoa.SobreNome,
                    DataNascimento = pessoa.DataNascimento,
                    IdPessoa = id
                }, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
