using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DapperConexion
{
    public class FactoryConnection : IFactoryConnection
    {
        private IDbConnection _connection;
        // importar cadena de conexion desde WebAPI
        private readonly IOptions<ConexionConfiguration> _configs; //cadena de conexion a un servidor (servidor, bd, politicas de acceso)


        public FactoryConnection(IOptions<ConexionConfiguration> configs)
        {
            _configs = configs; // injeccion de objeto connection
        }
        public void CloseConnection()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        public IDbConnection GetConnection()
        {
            if (_connection == null)
            {
                _connection = new SqlConnection(_configs.Value.DefaultConnection); // parametro de cadena de conexion
                                                                                   // para este momento configs ya tiene cargada la cadena de conexion desde el Startup
            }
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
            return _connection;
        }
    }
}
