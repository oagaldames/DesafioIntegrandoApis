using DesafioIntegrandoApis.Models;
using DesafioIntegrandoApis.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioIntegrandoApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public UsuarioRepository _usuarioRepository;

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// trae una lista de todos los usuarios <summary>
        /// trae una lista de todos los usuarios
        /// </summary>
        /// <returns></returns>
        
        [HttpGet]
        public ActionResult TraerUsuarios()
        {
            var result = _usuarioRepository.TraerUsuarios();
            return Ok(result);
            
        }
        /// Trae los datos de un usuario de acuerdo al nombre ingresado <summary>
        /// Trae los datos de un usuario de acuerdo al nombre ingresado
        /// </summary>
        /// <param name="nombreUsuario"></param>
        /// <returns></returns>
        /// 
        [HttpGet("{nombreUsuario}")]
        public ActionResult TraerUsuarioPorNombre(string nombreUsuario)
        {
            var result = _usuarioRepository.TraerUsuarioPorNombre(nombreUsuario);

            return Ok(result);
        }

        /// Login de usuario <summary>
        /// Se ingresa nombre usuario y contraseña
        /// si es correcto devuelve todos los datos de ese usuario
        /// si no es correcto devuelve el usuario con id=0 y el resto de los datos vacio
        /// </summary>
        /// <param name="nombreUsuario"></param>
        /// <param name="contraseña"></param>
        /// <returns></returns>
        
        [HttpGet("{nombreUsuario}/{contraseña}")]
        public ActionResult LoginUsuario(string nombreUsuario, string contraseña)
        {
            var result = _usuarioRepository.LoginUsuario(nombreUsuario, contraseña);

            return Ok(result);
            
        }

        /// <summary>
        /// Crear un nuevo usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>

        [HttpPost]
        public ActionResult CrearUsuario(Usuario usuario)
        {
            var result = _usuarioRepository.CrearUsuario(usuario);

            return Ok(result);
        }

        /// <summary>
        /// Modificacion de usuario con los datos del objeto usuario ingresado 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        
        [HttpPut]

        public ActionResult ModificarUsuario(Usuario usuario)
        {
            var result = _usuarioRepository.ModificarUsuario(usuario);

            return Ok(result);
        }

        /// <summary>
        /// Elimino un usuario ingreso ID de usuario a eliminar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
        [HttpDelete]

        public ActionResult EliminarUsuario(long id)
        {
            var result = _usuarioRepository.EliminarUsuario(id);

            return Ok(result);
        }
    }
}
