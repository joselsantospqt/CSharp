using Modelo;
using System;
using System.Collections.Generic;
using System.Globalization;
using Calendario.Repositorio;
using Service;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;

namespace Calendario
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            int n;
            var start = 0;
            var loop = true;
            var vListaPessoas = new List<Pessoa>();
            PessoaService ServicoPessoa = new PessoaService();
            DateTime DataHoje = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));

            ExibeFuncionalidades();
            var vTemp = Console.ReadLine();
            bool result = Int32.TryParse(vTemp, out n);
            if (result)
            {
                start = Convert.ToInt32(vTemp);
            }
            else
            {
                start = 99;
            }


            while (loop)
            {
                switch (start)
                {
                    case 0:
                        ExibeFuncionalidades();
                        vTemp = Console.ReadLine();
                        result = Int32.TryParse(vTemp, out n);
                        if (result)
                        {
                            start = Convert.ToInt32(vTemp);
                        }
                        else
                        {
                            start = 99;
                        }
                        break;
                    case 1:
                        var ListDeRegistros = ServicoPessoa.GetAll();
                        int vId = ListDeRegistros.Count;
                        var pessoa = new Pessoa();
                        Console.WriteLine("Digite o nome:");
                        pessoa.NM_NOME = Console.ReadLine();
                        Console.WriteLine("Digite o SobreNome:");
                        pessoa.NM_SOBRENOME = Console.ReadLine();
                        Console.WriteLine("Digite o aniversário: ex(dd/mm/yyyy)");
                        var date = Console.ReadLine().Split('/');
                        while (date.Length != 3)
                        {
                            Console.WriteLine("Digite o aniversário no formato: (dd/mm/yyyy) para prosseguir: ");
                            date = Console.ReadLine().Split('/');
                        }
                        pessoa.DT_NASCIMENTO = new DateTime(Convert.ToInt32(date[2]), Convert.ToInt32(date[1]), Convert.ToInt32(date[0]));

                        if (vId != 0)
                        {
                            var vPessoa = ListDeRegistros[vId - 1];
                            vId = vPessoa.ID + 1;
                            pessoa.ID = vId;
                        }
                        else
                            pessoa.ID = vId;


                        ServicoPessoa.Create(pessoa);
                        //REGIÃO AONDE SERÁ TUDO SALVO NEM UM ARQUIVO EM BRANCO 
                        ListDeRegistros = ServicoPessoa.GetAll();
                        var json = JsonConvert.SerializeObject(ListDeRegistros, Formatting.Indented);
                        string PathRelatorio = Path.Combine(path, "relatorio.txt");
                        if (File.Exists(PathRelatorio))
                        {
                            StreamWriter sw = new StreamWriter(PathRelatorio.ToString());
                            sw.WriteLine(json);
                            sw.Close();
                        }
                        else
                        {
                            StreamWriter sw = new StreamWriter(PathRelatorio.ToString(), true, Encoding.UTF8);
                            sw.WriteLine(json);
                            sw.Close();
                        }

                        start = 0;
                        break;

                    case 2:
                        var vRetornoAtualiza = SolicitaNomeBuscar();
                        Console.WriteLine("--- RESULTADO ---");
                        vListaPessoas = ServicoPessoa.GetByName(vRetornoAtualiza[0]);
                        if (vListaPessoas != null && vListaPessoas.Count != 0)
                        {
                            Console.WriteLine(JsonConvert.SerializeObject(vListaPessoas, Formatting.Indented));
                            Console.WriteLine("Selecione o ID da pessoa que deseja EDITAR:");
                            var vIndex = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Carregando...");
                            var vRetornoPessoa = ServicoPessoa.GetById(vIndex);
                            if (vRetornoPessoa.ID != -1)
                            {
                                Console.WriteLine("Digite novo nome:");
                                vRetornoPessoa.NM_NOME = Console.ReadLine();
                                Console.WriteLine("Digite novo SobreNome:");
                                vRetornoPessoa.NM_SOBRENOME = Console.ReadLine();
                                Console.WriteLine("Digite novo aniversário: ex(dd/mm/yyyy)");
                                var vDate = Console.ReadLine().Split('/');
                                vRetornoPessoa.DT_NASCIMENTO = new DateTime(Convert.ToInt32(vDate[2]), Convert.ToInt32(vDate[1]), Convert.ToInt32(vDate[0]));
                                ServicoPessoa.Update(vRetornoPessoa, vIndex);
                            }
                            else
                                Console.WriteLine($"Não foi encontrado uma pessoa com o ID: {vIndex}.");
                        }
                        else
                            Console.WriteLine($"Não foi encontrado uma pessoa com o nome: {vRetornoAtualiza[0]}.");

                        start = 0;
                        break;
                    case 3:
                        var vRetornoExcluir = SolicitaNomeBuscar();
                        Console.WriteLine("--- RESULTADO ---");
                        vListaPessoas = ServicoPessoa.GetByName(vRetornoExcluir[0]);
                        if (vListaPessoas != null && vListaPessoas.Count != 0)
                        {
                            Console.WriteLine(JsonConvert.SerializeObject(vListaPessoas, Formatting.Indented));
                            Console.WriteLine("Selecione o ID da pessoa que deseja APAGAR:");
                            var vIndex = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Carregando...");
                            var vRetornoPessoa = ServicoPessoa.GetById(vIndex);
                            if (vRetornoPessoa.ID != -1)
                                ServicoPessoa.Delete(vRetornoPessoa);
                            else
                                Console.WriteLine($"Não foi encontrado uma pessoa com o ID: {vIndex}.");


                        }
                        else
                            Console.WriteLine($"Não foi encontrado uma pessoa com o nome: {vRetornoExcluir[0]}.");

                        start = 0;
                        break;

                    case 4:
                        Console.WriteLine("Digite o ID da pessoa que deseja Buscar:");
                        var vRetornoBuscarPorID = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("--- RESULTADO ---");
                        var vPessoaByID = ServicoPessoa.GetById(vRetornoBuscarPorID);
                        if (vPessoaByID.ID != -1)
                        {
                            var vData = Data.CalculaPeriodo(vPessoaByID.DT_NASCIMENTO, DataHoje);
                            Console.WriteLine(JsonConvert.SerializeObject(vPessoaByID, Formatting.Indented));
                            if (vData.NR_DIAS == 0)
                                Console.WriteLine($"Parabéns {Regex.Replace(vPessoaByID.NM_NOME, @"\s+", "")} seu aniversário é hoje !!! Felicidades !!! \n");
                            else
                                Console.WriteLine($"Para o aniversário do {vPessoaByID.NM_NOME} faltam: {vData.NR_DIAS} Dias e será : {vData.NM_DIA}.\n");

                        }
                        else
                            Console.WriteLine($"Não foi encontrado uma pessoa com o ID: {vRetornoBuscarPorID}.");

                        start = 0;
                        break;

                    case 5:
                        Console.WriteLine("Você está preste a DELETAR todos do banco de dados.");
                        Console.WriteLine("Deseja continuar ?(S/N)");
                        var vConfirmaDelete = Console.ReadLine();
                        if (vConfirmaDelete == "S")
                        {
                            vListaPessoas = ServicoPessoa.GetAll();
                            foreach (var Pessoa in vListaPessoas)
                            {
                                ServicoPessoa.Delete(Pessoa);
                            }
                        }

                        start = 0;
                        break;
                    default:
                        if (vTemp == "q")
                        {
                            loop = false;
                        }
                        else
                            start = 0;
                        break;

                }
            }

        }
        private static void ExibeFuncionalidades()
        {
            Console.WriteLine("1 - Para criar um cliente");
            Console.WriteLine("2 - Para atualizar um cliente");
            Console.WriteLine("3 - Para excluir um cliente");
            Console.WriteLine("4 - Para obter um cliente");
            Console.WriteLine("5 - Para excluir todos os clientes");
            Console.WriteLine("q - Para sair \n");
        }

        private static string[] SolicitaNomeBuscar()
        {
            Console.WriteLine("Digite o nome da pessoa que deseja procurar:");
            return Console.ReadLine().Split();
        }

    }
}
