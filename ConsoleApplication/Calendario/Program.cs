using Calendario.Models;
using Calendario.Repositorio;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Calendario
{
    class Program
    {
        static void Main(string[] args)
        {
            var opcao = 0;
            var loop = true;
            var vListaPessoas = new List<Pessoa>();
            RepositorioPessoa repositorioPessoa = new RepositorioPessoa();


            while (loop)
            {
                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Digite da pessoa que deseja procurar:");
                        var pesquisar = Console.ReadLine().Split();
                        switch (Convert.ToInt32(pesquisar.Length))
                        {
                            case 1:
                                vListaPessoas = repositorioPessoa.BuscaPrimeiroNomePessoa(pesquisar[0]);
                                Console.WriteLine("--- RESULTADO ---");
                                if (vListaPessoas != null && vListaPessoas.Count != 0)
                                {
                                    foreach (var item in vListaPessoas)
                                    {
                                        Console.WriteLine("Pessoa: " + vListaPessoas.IndexOf(item));
                                        Console.WriteLine("Nome Completo: " + item.NomeCompleto);
                                        Console.WriteLine("Data de Nascimento: " + item.DataNascimento);
                                        Console.WriteLine("--- ---");
                                    }

                                    Console.WriteLine("Selecione a pessoa:");
                                    var vIndex = Convert.ToInt32(Console.ReadLine());
                                    var retorno = vListaPessoas[vIndex];
                                    DateTime DataHoje = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));
                                    int AnoAtual = DataHoje.Year;
                                    var DtAniversarioAnoAtual = new DateTime(AnoAtual, Convert.ToInt32(retorno.DataNascimento.Month), Convert.ToInt32(retorno.DataNascimento.Day));
                                    System.TimeSpan diferenca = DtAniversarioAnoAtual - DataHoje;
                                    if (diferenca.Days > 0)
                                        Console.WriteLine($"Faltam apenas: {diferenca.Days}");
                                    else
                                        Console.WriteLine("O aniversário já passou");
                                }
                                else
                                    Console.WriteLine("Não foi encontrado !");

                                opcao = 0;
                                break;
                            case 2:

                                var nomeCompleto = $"{pesquisar[0]} {pesquisar[1]}";
                                vListaPessoas = repositorioPessoa.BuscaNomeCompletoPessoa(nomeCompleto);
                                Console.WriteLine("--- RESULTADO ---");
                                if (vListaPessoas != null && vListaPessoas.Count != 0)
                                {
                                    foreach (var item in vListaPessoas)
                                    {
                                        Console.WriteLine("Pessoa: " + vListaPessoas.IndexOf(item));
                                        Console.WriteLine("Nome Completo: " + item.NomeCompleto);
                                        Console.WriteLine("Data de Nascimento: " + item.DataNascimento);
                                        Console.WriteLine("--- ---");
                                    }

                                    Console.WriteLine("Selecione a pessoa:");
                                    var vIndex = Convert.ToInt32(Console.ReadLine());
                                    var retorno = vListaPessoas[vIndex];
                                    DateTime DataHoje = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));
                                    int AnoAtual = DataHoje.Year;
                                    var DtAniversarioAnoAtual = new DateTime(AnoAtual, Convert.ToInt32(retorno.DataNascimento.Month), Convert.ToInt32(retorno.DataNascimento.Day));
                                    System.TimeSpan diferenca = DtAniversarioAnoAtual - DataHoje;
                                    if (diferenca.Days > 0)
                                        Console.WriteLine($"Faltam apenas: {diferenca.Days}");
                                    else
                                        Console.WriteLine("O aniversário já passou");
                                }
                                else
                                    Console.WriteLine("Não foi encontrado !");

                                opcao = 0;
                                break;

                        }

                        break;

                    case 2:
                        var pessoa = new Pessoa();
                        Console.WriteLine("Digite seu nome:");
                        pessoa.Nome = Console.ReadLine();
                        Console.WriteLine("Digite seu SobreNome:");
                        pessoa.SobreNome = Console.ReadLine();
                        Console.WriteLine("Digite seu aniversário: ex(dd/mm/yyyy)");
                        var date = Console.ReadLine().Split('/');
                        pessoa.DataNascimento = new DateTime(Convert.ToInt32(date[2]), Convert.ToInt32(date[1]), Convert.ToInt32(date[0]));
                        pessoa.MontaNomeCompleto();
                        repositorioPessoa.Adicionar(pessoa);
                        opcao = 0;
                        break;

                    case 3:
                        loop = false;

                        break;

                    default:
                        Console.WriteLine("Selecione uma das opções abaixo:");
                        Console.WriteLine("1 - Pesquisar pessoa");
                        Console.WriteLine("2 - Adicionar nova pessoa");
                        Console.WriteLine("3 - Sair");
                        opcao = Convert.ToInt16(Console.ReadLine());

                        break;

                }
            }

        }
    }
}
