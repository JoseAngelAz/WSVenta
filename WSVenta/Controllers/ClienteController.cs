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
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();
            oRespuesta.Exito = 0;
            try
            {             
                using (VentaRealContext db = new VentaRealContext())
                {
                    var lst = db.Clientes.ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Mensaje = "Data Servida Exitosamente!";
                    oRespuesta.Data = lst;
                }
            }
            catch (Exception ex) { oRespuesta.Mensaje = ex.Message; }
            return Ok(oRespuesta);
        }
        //Crear
        [HttpPost]
        public IActionResult Add(ClienteRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();            
            try
            {
                using (VentaRealContext db = new VentaRealContext())
                {
                    Cliente oCliente = new Cliente();
                    oCliente.Nombre = oModel.Nombre;
                    db.Clientes.Add(oCliente);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                    oRespuesta.Mensaje = "Data Insertada Exitosamente!";
                }               
            }
            catch (Exception ex) { oRespuesta.Mensaje = ex.Message; }
            return Ok(oRespuesta);
        }
        //Editar
        [HttpPut]
        public IActionResult Edit(ClienteRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (VentaRealContext db = new VentaRealContext())
                {
                    Cliente oCliente = db.Clientes.Find(oModel.id);
                    oCliente.Nombre = oModel.Nombre;
                    db.Entry(oCliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                    oRespuesta.Mensaje = "Data Modificada Exitosamente!";
                }                
            }
            catch (Exception ex) { oRespuesta.Mensaje = ex.Message; }
            return Ok(oRespuesta);
        }
        //Eliminar
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (VentaRealContext db = new VentaRealContext())
                {
                    Cliente oCliente = db.Clientes.Find(id);
                    db.Remove(oCliente);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                    oRespuesta.Mensaje = "Data Eliminada Exitosamente!";
                }
            }
            catch (Exception ex) { oRespuesta.Mensaje = ex.Message; }
            return Ok(oRespuesta);
        }
    }
}
