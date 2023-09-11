using API_ClaseWeb.Entities;
using API_ClaseWeb.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace API_ClaseWeb.Models
{
    public class UsuariosModel : IUsuariosModel
    {
        //interfaz del sistema para inyectarla..
        private readonly IConfiguration _configuration;
        public UsuariosModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public UsuariosEntities? ValidarCredenciales(UsuariosEntities entidad)
        {
            //todo lo que exista dentro del using va a poder usar la variable conexion
            using (var conexion = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))//aqui accedemos al string de conexion que esta en el appsettings.json
            {
                //para que me devuelva un resultado o informacion
                return conexion.Query<UsuariosEntities>("ValidarCredenciales",
                    new { entidad.CorreoElectronico, entidad.Contrasenna },
                    commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            }
        }
    }
}
