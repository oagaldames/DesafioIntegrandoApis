using System.Data.SqlClient;
using System.Data;
using DesafioIntegrandoApis.Models;

namespace DesafioIntegrandoApis.Repository
{
    public class ProductoVendidoRepository
    {

        public List<ProductoVendido> TraerProductosVendidos()
        {
            var listaProductosVendidos = new List<ProductoVendido>();
            try
            {
                List<Producto> listaProductosUsaurio = new List<Producto>();
                
                DataSql db = new DataSql();

                if (db.ConectarSQL())
                {
                    SqlCommand cmd = db.Connection.CreateCommand();

                    cmd.CommandText = "SELECT Id,Stock,IdProducto,IdVenta FROM ProductoVendido ";
                        
                    using var reader = cmd.ExecuteReader();
                    {
                        while (reader.Read())
                        {
                            var productoVendido = new ProductoVendido();
                            productoVendido.Id = Convert.ToInt64(reader.GetValue(0));
                            productoVendido.Stock = Convert.ToInt32(reader.GetValue(1));
                            productoVendido.IdProducto = Convert.ToInt64(reader.GetValue(2));
                            productoVendido.IdVenta = Convert.ToInt64(reader.GetValue(3));

                            listaProductosVendidos.Add(productoVendido);
                        }
                        reader.Close();
                    }
                    
                    db.DesconectarSQL();
                }
                return listaProductosVendidos;
            }
            catch (Exception err)
            {
                string error = err.Message;
                Console.WriteLine("\nERROR TraerProductosVendidos  " + error);
                return listaProductosVendidos;
            }
        }

        public bool CrearProductoVendido(int stock, long idproducto, long idventa)

        {
            bool respuesta = false;
            try
            {
                    DataSql db = new DataSql();
                    if (db.ConectarSQL())
                    {
                        var queryInsert = @"Insert Into ProductoVendido (Stock, IdProducto
                                           ,idventa) 
                                          values (@Stock,@IdPro,@idventa); select @@IDENTITY";
                        var paramStocknuevo = new SqlParameter("Stock", SqlDbType.Int);
                        paramStocknuevo.Value = stock;
                        var paramCostoNuevo = new SqlParameter("IdPro", SqlDbType.BigInt);
                        paramCostoNuevo.Value = idproducto;
                        var paramIdVenNuevo = new SqlParameter("idventa", SqlDbType.BigInt);
                        paramIdVenNuevo.Value = idventa;

                        SqlCommand commandoInsert = new SqlCommand(queryInsert, db.Connection);
                        commandoInsert.Parameters.Add(paramStocknuevo);
                        commandoInsert.Parameters.Add(paramCostoNuevo);
                        commandoInsert.Parameters.Add(paramIdVenNuevo);
                        
                        double idNuevo = Convert.ToInt64(commandoInsert.ExecuteScalar());
                        if (idNuevo > 0)
                        {
                            respuesta = true;
                        }
                        else
                        {
                            respuesta = false;
                        }
                    }
                    else
                    {
                        respuesta = false;
                    }
                
            }
            catch (Exception err)
            {
                string error = err.Message;
                Console.WriteLine("\nERROR CrearProducto  " + error);
                respuesta = false;
            }
            return respuesta;
        }

        public bool ModificarProductoVendido(long id, int stock, long idproducto, long idventa)

        {
            try
            {
                DataSql db = new DataSql();
                if (db.ConectarSQL())
                {
                    var queryUpdate = @"UPDATE ProductoVendido set 
                                     Stock=@Stock
                                     ,IdProducto=@IdProd
                                     ,idventa =@IdVenta
                                    WHERE Id = @Id";


                    var paramStock = new SqlParameter("Stock", SqlDbType.Int);
                    paramStock.Value = stock;
                    var paramCosto = new SqlParameter("IdProd", SqlDbType.BigInt);
                    paramCosto.Value = idproducto;
                    var paramIdVen = new SqlParameter("idventa", SqlDbType.BigInt);
                    paramIdVen.Value = idventa;
                    var paramId = new SqlParameter("id", SqlDbType.BigInt);
                    paramId.Value = id;

                    SqlCommand commandoUpdate = new SqlCommand(queryUpdate, db.Connection);
                    commandoUpdate.Parameters.Add(paramStock);
                    commandoUpdate.Parameters.Add(paramCosto);
                    commandoUpdate.Parameters.Add(paramIdVen);
                    commandoUpdate.Parameters.Add(paramId);
                    int recordsAffected = commandoUpdate.ExecuteNonQuery();

                    db.DesconectarSQL();

                    if (recordsAffected == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }

            }
            catch (Exception err)
            {
                string error = err.Message;
                Console.WriteLine("\nERROR ModificarProducto  " + error);
                return false;
            }
        }


        public bool EliminarProductoVendido(long id)

        {
            try
            {

                DataSql db = new DataSql();
                if (db.ConectarSQL())
                {
                   var queryDelete = @" DELETE
                                    ProductoVendido
                                    WHERE 
                                    Id = @ID
                                    ";
                    var paramId = new SqlParameter("id", SqlDbType.BigInt);
                    paramId.Value = id;
                    SqlCommand commandoDelete = new SqlCommand(queryDelete, db.Connection);
                    commandoDelete.Parameters.Add(paramId);
                    int recordsAffected = commandoDelete.ExecuteNonQuery();
                    db.DesconectarSQL();

                    if (recordsAffected == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }


                }
                else
                {
                    return false;
                }
            }

            catch (Exception err)
            {
                string error = err.Message;
                Console.WriteLine("\nERROR EliminarProducto  " + error);
                return false;
            }
        }
        public static bool EliminarProductoVendidoPorProducto(long id)

        {
            try
            {

                DataSql db = new DataSql();
                if (db.ConectarSQL())
                {
                    var queryDelete = @" DELETE
                                       ProductoVendido
                                       WHERE 
                                       IdProducto = @ID
                                       ";
                    var paramId = new SqlParameter("id", SqlDbType.BigInt);
                    paramId.Value = id;
                    SqlCommand commandoDelete = new SqlCommand(queryDelete, db.Connection);
                    commandoDelete.Parameters.Add(paramId);
                    int recordsAffected = commandoDelete.ExecuteNonQuery();
                    db.DesconectarSQL();

                    if (recordsAffected == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }

            catch (Exception err)
            {
                string error = err.Message;
                Console.WriteLine("\nERROR EliminarProducto  " + error);
                return false;
            }
        }
    }
}
