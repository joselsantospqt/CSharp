using Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Service
{
    public abstract class BaseService
    {
        public string ConnectDataBase()
        {
            var ConnectionString = @"Data Source=localhost;Initial Catalog=BancoCalendario;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            return ConnectionString;
        }
    }
}
