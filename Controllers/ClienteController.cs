using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSVenta.Models;
using WSVenta.Models.Response;
using WSVenta.Models.Request;

namespace WSVenta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        //creamos metodo para acceder a los datos de la tabla cliente

        //especificamos el protocolo (HttpGet es consulta de datos)
        [HttpGet]
        public IActionResult Get()
        {
            //usaremos la clase ventarealcontext para crear consultas, por ende, creamos un objeto
            Respuesta oRespuesta = new Respuesta();

            try
            {

                using (VentaRealContext db = new VentaRealContext())
                {
                    //aqui creamos la consulta
                    var lst = db.Clientes.ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = lst;


                }
            }
            catch (Exception ex)
            {
                oRespuesta.msg = ex.Message;
            }
            return Ok(oRespuesta);

        }

        //HttpPost es introduccion de datos
        [HttpPost]
        public IActionResult Add(ClienteRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                using (VentaRealContext db = new VentaRealContext())
                {
                    Cliente oCliente = new Cliente();
                    oCliente.Dni = oModel.Dni;
                    oCliente.Nombre = oModel.Nombre;
                    db.Clientes.Add(oCliente);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }

            }

            catch (Exception ex)
            {
                oRespuesta.msg = ex.Message;
            }
            return Ok(oRespuesta);
        }

        //HttpPut es Edicion de datos
        [HttpPut]
        public IActionResult Edit(ClienteRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                using (VentaRealContext db = new VentaRealContext())
                {
                    Cliente oCliente = db.Clientes.Find(oModel.Dni);
                    oCliente.Nombre = oModel.Nombre;
                    db.Entry(oCliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }

            }

            catch (Exception ex)
            {
                oRespuesta.msg = ex.Message;
            }
            return Ok(oRespuesta);
        }

        //HttpDelete es Eliminacion de datos
        [HttpDelete("{Dni}")]
        public IActionResult Delete(string Dni)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                using (VentaRealContext db = new VentaRealContext())
                {
                    Cliente oCliente = db.Clientes.Find(Dni);
                    db.Remove(oCliente);                    
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }

            }

            catch (Exception ex)
            {
                oRespuesta.msg = ex.Message;
            }
            return Ok(oRespuesta);
        }
    }
}
