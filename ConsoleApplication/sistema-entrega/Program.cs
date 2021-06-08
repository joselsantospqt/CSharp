using sistema_entrega.Entity;
using System;

namespace sistema_entrega
{
    class Program
    {
        static void Main(string[] args)
        {
            //Cliente cliente = new Cliente();

            //var endereco = cliente.ObterEndereco(TipoEnderecoEnum.Comercial);
            //var contato = cliente.ObterContato(TipoContatoEnum.Residencial);

            //Console.WriteLine($"Nome do cliente: {cliente.NomeCompleto},{contato.DDI}-{contato.Fixo}, {endereco.CEP}");
            //Console.Read();

            var data = Delivery.CalculaEntrega();
            foreach (var item in data)
                Console.WriteLine(item);
        }

       
    }
}
