using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using APICORE.Models;
using System.Data;
using System.Data.SqlClient;

namespace APICORE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratistaController : ControllerBase
    {
        private readonly string cadenaSQL;

        public ContratistaController(IConfiguration config) {
            cadenaSQL = config.GetConnectionString("CadenaSQL");
        }

        [HttpGet]
        [Route("Lista")]

        public IActionResult Lista() {
            List<Contratista> lista = new List<Contratista>();

            try
            {
                using (var conexion = new SqlConnection(cadenaSQL)) { 

                    conexion.Open();
                    var cmd = new SqlCommand("sp_listar_contratista", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var rd = cmd.ExecuteReader()) { 
                        
                        while (rd.Read())
                        {
                            lista.Add(new Contratista
                            {
                                iIdContratista = Convert.ToInt32(rd["iIdContratista"]),
                                vRuc = rd["vRuc"].ToString(),
                                vRazonSocial = rd["vRazonSocial"].ToString(),
                                vRepresentante = rd["vRepresentante"].ToString(),
                                vCorreo = rd["vCorreo"].ToString(),
                                vTelefono = rd["vTelefono"].ToString(),
                                iEstado = Convert.ToInt32(rd["iEstado"]),
                               

                            });
                        }
                    }
                
                }
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", Response = lista });

            }
            catch (Exception error)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, Response = lista });
            }

        
        }
    }
}
