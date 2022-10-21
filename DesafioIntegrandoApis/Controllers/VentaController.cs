using DesafioIntegrandoApis.Models;
using DesafioIntegrandoApis.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DesafioIntegrandoApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        public VentaRepository _ventaRepository;

        public VentaController()
        {
            _ventaRepository = new VentaRepository();
        }


        /// <summary>
        /// Traer todas las ventas
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        public ActionResult TraerVenta()
        {
            var result = _ventaRepository.TraerVentas();
            return Ok(result);
        }

        /// <summary>
        /// Agrego una venta nueva
        /// </summary>
        /// <param name="comentarios"></param>
        /// <param name="idUsuario"></param>
        /// <returns></returns>

        [HttpPost("{idUsuario}")]
        public ActionResult CargarVenta(List<Producto> productos, int idUsuario)
        {
            var result = _ventaRepository.CargarVenta(productos, idUsuario);
            return Ok(result);
            
        }

        /// <summary>
        /// Creo un registro nuevo en la tabla venta
        /// </summary>
        /// <param name="comentarios"></param>
        /// <param name="idUsuario"></param>
        /// <returns></returns>


        [HttpPost]
        public ActionResult Crearventa(string comentarios, int idUsuario)
        {
            var result = _ventaRepository.CrearVenta(comentarios, idUsuario);

            return Ok(result);
        }

        /// <summary>
        /// Modifico los datos en la tabla venta pasando el ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="comentarios"></param>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult ModificarVenta(long id,string comentarios, int idUsuario)
        {
            var result = _ventaRepository.ModificarVenta(id, comentarios, idUsuario);

            return Ok(result);
        }

        /// <summary>
        /// Elimino un registro de la Tabla venta pasando el ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public ActionResult EliminarVenta(long id)
        {
            var result = _ventaRepository.EliminarVenta(id);

            return Ok(result);
        }
    }

}
