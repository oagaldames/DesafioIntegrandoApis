using DesafioIntegrandoApis.Models;
using DesafioIntegrandoApis.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioIntegrandoApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoVendidoController : ControllerBase
    {
        public ProductoVendidoRepository _productoVendidoRepository;

        public ProductoVendidoController()
        {
            _productoVendidoRepository = new ProductoVendidoRepository();
        }



        /// <summary>
        /// Traer todos los productos vendidos
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        public ActionResult TraerProductosVendidos()
        {
            var result = _productoVendidoRepository.TraerProductosVendidos();
            return Ok(result);

        }

        /// <summary>
        /// Creo un nuevo productovendido 
        /// </summary>
        /// <param name="descripciones"></param>
        /// <param name="costo"></param>
        /// <param name="precioventa"></param>
        /// <param name="stock"></param>
        /// <param name="idusuario"></param>
        /// <returns></returns>

        [HttpPost]
        public ActionResult CrearProductoProductoVendido(int stock, long idproducto, long idventa)
        {
            var result = _productoVendidoRepository.CrearProductoVendido(stock, idproducto, idventa);

            return Ok(result);
        }

        /// <summary>
        /// Modifico tabla producto vendido ingresando Id 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="stock"></param>
        /// <param name="idproducto"></param>
        /// <param name="idventa"></param>
        /// <returns></returns>


        [HttpPut]

        public ActionResult ModificarProductoVEndido(long id, int stock, long idproducto, long idventa)
        {
            var result = _productoVendidoRepository.ModificarProductoVendido(id, stock,idproducto, idventa);

            return Ok(result);
        }

        /// <summary>
        /// Borro un producto que tenga el id ingresado 
        /// primero elimino de la tabla producto vendido el registro que ecorresponde a ese proucto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete]

        public ActionResult EliminarProductoVendido(long id)
        {
            var result = _productoVendidoRepository.EliminarProductoVendido(id);

            return Ok(result);
        }
    }
}

