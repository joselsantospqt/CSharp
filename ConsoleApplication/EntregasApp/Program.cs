using System;
using System.Collections.Generic;

namespace EntregasApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //local.ITENS_ENTREGA.Add(item);
            //local.ITENS_ENTREGA.Add(item2);
            //local.ITENS_ENTREGA.Add(item3);

            //caminhao.PushLocal(local);
            List<Local> listaDeLocal = new List<Local>();
            List<Caminhao> listaCaminhao = new List<Caminhao>();
            List<ItemEntrega> listaItem = new List<ItemEntrega>();

            var opcao = 0;
            int itemSelecionado;
            int LocalSelecionado;
            int CaminhaoSelecionado;
            var loop = true;
            int n;

            ExibeFuncionalidades();
            var vTemp = Console.ReadLine();
            bool result = Int32.TryParse(vTemp, out n);
            if (result)
            {
                opcao = Convert.ToInt32(vTemp);
            }
            else
            {
                opcao = 99;
            }

            while (loop)
            {
                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Insira o nome do local de entrega:");
                        Local local = new Local();
                        local.ID = RandomNumber();
                        local.NM_NOME = Console.ReadLine().ToString();
                        listaDeLocal.Add(local);
                        opcao = 99;
                        break;
                    case 2:
                        Console.WriteLine("Insira o nome do item de entrega:");
                        ItemEntrega item = new ItemEntrega();
                        item.ID = RandomNumber();
                        item.NM_NOME = Console.ReadLine().ToString();
                        listaItem.Add(item);
                        opcao = 99;
                        break;
                    case 3:
                        Console.WriteLine("Insira a placa do caminhão:");
                        Caminhao caminhao = new Caminhao();
                        caminhao.PLACA = Console.ReadLine().ToString();
                        listaCaminhao.Add(caminhao);
                        opcao = 99;
                        break;
                    case 4:
                        itemSelecionado = 0;
                        LocalSelecionado = 0;

                        if (listaItem.Count == 0)
                        {
                            Console.WriteLine("Não existe itens a ser associado:");
                            opcao = 99;
                            break;
                        }

                        if (listaDeLocal.Count == 0)
                        {
                            Console.WriteLine("Não existe Locais a ser associado:");
                            opcao = 99;
                            break;
                        }

                        Console.WriteLine("Escolha um item a ser associado:");
                        foreach (ItemEntrega ItemSelecao in listaItem)
                        {
                            Console.WriteLine($"{listaItem.IndexOf(ItemSelecao)} - {ItemSelecao.NM_NOME}");
                        }
                        var inputItem = Console.ReadLine();
                        result = Int32.TryParse(inputItem, out n);
                        if (result)
                        {
                            itemSelecionado = Convert.ToInt32(inputItem);
                        }
                        else
                        {
                            Console.WriteLine("Valor Invalido");
                            break;
                        }

                        Console.WriteLine("Escolha um local a ser associado:");
                        foreach (Local LocalSelecao in listaDeLocal)
                        {
                            Console.WriteLine($"{listaDeLocal.IndexOf(LocalSelecao)} - {LocalSelecao.NM_NOME}");
                        }
                        var inputLocal = Console.ReadLine();
                        result = Int32.TryParse(inputLocal, out n);
                        if (result)
                        {
                            LocalSelecionado = Convert.ToInt32(inputLocal);
                        }
                        else
                        {
                            Console.WriteLine("Valor Invalido");
                            break;
                        }

                        listaDeLocal[LocalSelecionado].ITENS_ENTREGA.Add(listaItem[itemSelecionado]);
                        listaItem.Remove(listaItem[itemSelecionado]);
                        Console.WriteLine("Associação realizada");
                        opcao = 99;
                        break;
                    case 5:
                        CaminhaoSelecionado = 0;
                        LocalSelecionado = 0;


                        if (listaCaminhao.Count == 0)
                        {
                            Console.WriteLine("Não existe Caminhões a ser associado:");
                            opcao = 99;
                            break;
                        }

                        if (listaDeLocal.Count == 0)
                        {
                            Console.WriteLine("Não existe Locais a ser associado:");
                            opcao = 99;
                            break;
                        }


                        Console.WriteLine("Escolha um Caminhão para Carregar:");
                        foreach (Caminhao CaminhaoSelecao in listaCaminhao)
                        {
                            Console.WriteLine($"{listaCaminhao.IndexOf(CaminhaoSelecao)} - Caminhão Placa : {CaminhaoSelecao.PLACA}");
                        }
                        var inputCaminhao = Console.ReadLine();
                        result = Int32.TryParse(inputCaminhao, out n);
                        if (result)
                        {
                            CaminhaoSelecionado = Convert.ToInt32(inputCaminhao);
                        }
                        else
                        {
                            Console.WriteLine("Valor Invalido");
                            break;
                        }

                        Console.WriteLine("Escolha um local a ser associado:");
                        foreach (Local LocalSelecao in listaDeLocal)
                        {
                            Console.WriteLine($"{listaDeLocal.IndexOf(LocalSelecao)} - {LocalSelecao.NM_NOME}");
                        }
                        var inputLocalAssociacao = Console.ReadLine();
                        result = Int32.TryParse(inputLocalAssociacao, out n);
                        if (result)
                        {
                            LocalSelecionado = Convert.ToInt32(inputLocalAssociacao);
                        }
                        else
                        {
                            Console.WriteLine("Valor Invalido");
                            break;
                        }
                        if (listaCaminhao[CaminhaoSelecionado].TemEspaco())
                        {
                            var espacoLivre = listaCaminhao[CaminhaoSelecionado].QtdEspacoVazio();
                            var CopyLocal = new Local();
                            CopyLocal.ID = listaDeLocal[LocalSelecionado].ID;
                            CopyLocal.NM_NOME = listaDeLocal[LocalSelecionado].NM_NOME;

                            for (var i = 0; i < espacoLivre; i++)
                            {
                                if (listaDeLocal[LocalSelecionado].ITENS_ENTREGA.Count > 0)
                                {
                                    CopyLocal.ITENS_ENTREGA.Add(listaDeLocal[LocalSelecionado].PrimeiroDaLista());
                                    listaDeLocal[LocalSelecionado].ITENS_ENTREGA.Remove(listaDeLocal[LocalSelecionado].PrimeiroDaLista());
                                }
                            }

                            if (CopyLocal.ITENS_ENTREGA.Count > 0)
                            {
                                listaCaminhao[CaminhaoSelecionado].PushLocal(CopyLocal);
                                Console.WriteLine("Associação realizada");
                            }
                            else
                                Console.WriteLine("Ponto de entrega não possui itens para ser entrege");
                        }
                        else
                            Console.WriteLine("Caminhão sem espaço");

                        opcao = 99;
                        break;
                    case 6:

                        foreach (var lista in listaDeLocal)
                        {
                            foreach (var vCaminhao in listaCaminhao)
                            {
                                if (vCaminhao.TemEspaco() && lista.ITENS_ENTREGA.Count > 0)
                                {
                                    var espacoLivre = vCaminhao.QtdEspacoVazio();
                                    var CopyLocal = new Local();
                                    CopyLocal.ID = lista.ID;
                                    CopyLocal.NM_NOME = lista.NM_NOME;

                                    for (var i = 0; i < espacoLivre; i++)
                                    {
                                        if (lista.ITENS_ENTREGA.Count > 0)
                                        {
                                            CopyLocal.ITENS_ENTREGA.Add(lista.PrimeiroDaLista());
                                            lista.ITENS_ENTREGA.Remove(lista.PrimeiroDaLista());
                                        }
                                    }
                                    vCaminhao.PushLocal(CopyLocal);
                                }
                            }
                        }

                        listaCaminhao.ForEach(x => x.Print());
                        opcao = 99;
                        break;
                    case 99:
                        ExibeFuncionalidades();
                        vTemp = Console.ReadLine();
                        result = Int32.TryParse(vTemp, out n);
                        if (result)
                        {
                            opcao = Convert.ToInt32(vTemp);
                        }
                        else
                        {
                            opcao = 99;
                        }
                        break;
                    default:
                        if (vTemp == "0")
                        {
                            loop = false;
                        }
                        else
                            opcao = 99;
                        break;
                }
            }

        }

        private static void ExibeFuncionalidades()
        {
            Console.WriteLine("1 - Inserir ponto de entrega");
            Console.WriteLine("2 - Inserir item de entrega");
            Console.WriteLine("3 - Inserir caminhão");
            Console.WriteLine("4 - Associar item a ponto de entrega");
            Console.WriteLine("5 - Associar ponto de entrega a caminhão");
            Console.WriteLine("6 - Realizar entregas");
            Console.WriteLine("0 - Para sair \n");
        }

        public static int RandomNumber()
        {
            Random generator = new Random();
            return generator.Next(0, 10000);
        }
    }
}
