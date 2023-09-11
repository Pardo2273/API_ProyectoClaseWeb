using API_ClaseWeb.Entities;

namespace API_ClaseWeb.Interfaces
{
    public interface IUsuariosModel
    {
        public UsuariosEntities? ValidarCredenciales(UsuariosEntities entidad);
    }
}
