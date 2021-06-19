using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio
{
    public abstract class BaseRepositorio
    {
        public string ConnectDataBase()
        {
            var ConnectionString = @"Data Source=localhost;Initial Catalog=BancoCalendario;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            return ConnectionString;
        }
    }
}
