using System;
using System.Collections.Generic;
using System.Text;
using Modelo;
using Dapper;
using Repositorio;
using System.Data.SqlClient;

namespace Calendario.Repositorio
{
    public class RepositorioPessoa : BaseRepositorio, IRepositorioPessoa
    {
        public void Create(Pessoa pessoa)
        {
            try
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
                Console.WriteLine($"{pessoa.NM_NOME} Cadastrado com Sucesso !");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERRO !!");
                Console.WriteLine(ex.ToString());

            }
        }

        public void Delete(Pessoa pessoa)
        {
            try
            {
                using (SqlConnection dbConnection = new SqlConnection(ConnectDataBase()))
                {
                    var sql = @"DeletePessoa";

                    dbConnection.Execute(sql, new
                    {
                        ID = pessoa.ID,
                    }, commandType: System.Data.CommandType.StoredProcedure);
                }
                Console.WriteLine($"{pessoa.NM_NOME} Deletado com Sucesso !");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }
        }

        public void Update(Pessoa pessoa, int id)
        {
            try
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
                    Console.WriteLine("Atualizado com Sucesso !");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }
        }

        public List<Pessoa> GetAll()
        {
            try
            {
                using (SqlConnection dbConnection = new SqlConnection(ConnectDataBase()))
                {
                    var sql = @"GetAll";

                    var resultado = dbConnection.Query<Pessoa>(sql, commandType: System.Data.CommandType.StoredProcedure);

                    return resultado.AsList();
                }
            }
            catch (Exception ex)
            {
                var retorno = new List<Pessoa>();
                Console.WriteLine(ex.ToString());
                return retorno;

            }
        }

        public Pessoa GetById(int id)
        {
            try
            {
                using (SqlConnection dbConnection = new SqlConnection(ConnectDataBase()))
                {
                    var sql = @"GetById";

                    dbConnection.Open();

                    var command = dbConnection.CreateCommand();
                    command.CommandText = sql;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ID", id));

                    var resultado = command.ExecuteReader();

                    Pessoa pessoa = new Pessoa();

                    while (resultado.Read())
                    {
                        pessoa.ID = id;
                        pessoa.NM_NOME = resultado[1].ToString();
                        pessoa.NM_SOBRENOME = resultado[2].ToString();
                        pessoa.DT_NASCIMENTO = Convert.ToDateTime(resultado[3].ToString());

                    }
                    return pessoa;
                }
            }
            catch (Exception ex)
            {
                var retorno = new Pessoa();
                Console.WriteLine(ex.ToString());
                return retorno;

            }
        }

        public List<Pessoa> GetByName(string nome)
        {
            try
            {
                using (SqlConnection dbConnection = new SqlConnection(ConnectDataBase()))
                {
                    var sql = @"GetByName";

                    dbConnection.Open();

                    var command = dbConnection.CreateCommand();
                    command.CommandText = sql;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@NOME", $"{nome}%"));

                    var resultado = command.ExecuteReader();
                    List<Pessoa> ListaDePessoas = new List<Pessoa>();

                    while (resultado.Read())
                    {
                        Pessoa pessoa = new Pessoa();
                        pessoa.ID = (int)resultado[0];
                        pessoa.NM_NOME = resultado[1].ToString();
                        pessoa.NM_SOBRENOME = resultado[2].ToString();
                        pessoa.DT_NASCIMENTO = Convert.ToDateTime(resultado[3].ToString());
                        ListaDePessoas.Add(pessoa);
                    }
                    return ListaDePessoas;
                }
            }
            catch (Exception ex)
            {
                var retorno = new List<Pessoa>();
                Console.WriteLine(ex.ToString());
                return retorno;

            }
        }

    }
}
