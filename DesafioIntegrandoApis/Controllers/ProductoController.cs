using DesafioIntegrandoApis.Models;
using DesafioIntegrandoApis.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioIntegrandoApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        public ProductoRepository _productoRepository;

        public ProductoController()
        {
            _productoRepository = new ProductoRepository();
        }

        /// <summary>
        /// Traer todos los productos
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        public ActionResult TraerProductos()
        {
            var result = _productoRepository.TraerProductos();
            return Ok(result);

        }

        /// <summary>
        /// Creo un nuevo producto con los datos ingresados
        /// </summary>
        /// <param name="productos"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CrearProducto(Producto productos)
        {
            var result = _productoRepository.CrearProducto(productos);

            return Ok(result);
        }

        /// <summary>
        /// Modifico un producto con los datos recibidos en una lista 
        /// el id del producto viene en la lista
        /// </summary>
        /// <param name="productos"></param>
        /// <returns></returns>

        [HttpPut]
       
        public ActionResult ModificarProducto(Producto productos)
        {
            var result = _productoRepository.ModificarProducto(productos); 
             
            return Ok(result);
        }

        /// <summary>
        /// Borro un producto que tenga el id ingresado 
        /// primero elimino de la tabla producto vendido el registro que ecorresponde a ese proucto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
        [HttpDelete]

        public ActionResult EliminarProducto(long id)
        {
            var result = _productoRepository.EliminarProducto(id);

            return Ok(result);
        }
    }
}
