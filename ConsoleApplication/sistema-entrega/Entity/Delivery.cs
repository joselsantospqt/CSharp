using System;
using System.Collections.Generic;
using System.Text;

namespace sistema_entrega.Entity
{
    public static class Delivery
    {

        public static int QuantidadeDias = 5;

        public static List<DateTime> CalculaEntrega(){

            List<DateTime> dataDisponiveisEntrega = new List<DateTime>();

            for (int i = 1; i <= QuantidadeDias; i++)
                dataDisponiveisEntrega.Add(DateTime.Now.AddDays(i));

            return dataDisponiveisEntrega;
        }

        public void ObterEnderecoEntrega()
        {


        }
    }
}
