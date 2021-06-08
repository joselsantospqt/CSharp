using sistema_entrega.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace sistema_entrega.Entity
{
    public class Cliente
    {

        public Cliente()
        {
            this.NomeCompleto = "Nome 1";
            this.Documento = "Nome 1";
            this.Email = "Nome 1";
            this.DataNascimento = new DateTime(1994, 04, 04);

            this.Enderecos = new List<Endereco>()
            {
                new Endereco()
                {
                    Bairro = "Teste",
                    CEP = "00000-000",
                    Cidade = "Dummy",
                    Complemento = "Apto 303",
                    Estado = "Rio de Janeiro",
                    Logradouro = "Rua do teste",
                    TipoEndereco = TipoEnderecoEnum.Residencial,
                },
                new Endereco()
                {
                    Bairro = "Teste Comercial",
                    CEP = "00000-001",
                    Cidade = "Dummy",
                    Complemento = "SL 989",
                    Estado = "Rio de Janeiro",
                    Logradouro = "Rua do teste do comercial",
                    TipoEndereco = TipoEnderecoEnum.Comercial
                },
            };

            this.Telefones = new List<Telefone>() {
                new Telefone(){
                    DDD = "21",
                    DDI = "+55",
                    Fixo = "33972742",
                    Celular = "979578914",
                    TipoContato = TipoContatoEnum.Comercial
                },
                new Telefone(){
                    DDD = "21",
                    DDI = "+55",
                    Fixo = "77777-9999",
                    Celular = "9999-9999",
                    Ramal = "979111188SC",

                    TipoContato = TipoContatoEnum.Residencial
                },

            };


        }

        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public string Documento { get; set; }
        public DateTime DataNascimento { get; set; }
        public List<Endereco> Enderecos { get; set; }
        public List<Telefone> Telefones { get; set; }

        public Endereco ObterEndereco(TipoEnderecoEnum TipoEndereco)
        {
            foreach (var endereco in this.Enderecos)
            {
                if (endereco.TipoEndereco == TipoEndereco)
                    return endereco;
            }

            return null;
        }
        public void Save(IRepositoryCliente repository)
        {
            repository.Create(this);
        }

        public Telefone ObterContato(TipoContatoEnum TipoContato)
        {
            foreach (var contato in this.Telefones)
            {
                if (contato.TipoContato == TipoContato)
                    return contato;
            }

            return null;
        }
    }
}
