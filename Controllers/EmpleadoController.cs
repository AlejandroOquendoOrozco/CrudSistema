using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CrudSistema.Services;
using CrudSistema.Models;
namespace CrudSistema.Controllers
{
    [Route("api/[controller]")]
    public class EmpleadoController : ControllerBase
    {

        private readonly EmpleadoService _service;


        public EmpleadoController(EmpleadoService service){
            _service = service;

        }

        [HttpGet]
        [Route("Lista")]
        public async  Task<ActionResult<List<Empleado>>> Lista(){

           return Ok( await _service.ListaEmpleados() );

        }

        [HttpGet]
        [Route("Obtener/{id}")]
        public async Task<ActionResult<Empleado>> Obtener(int id)
        {
            var empleado = await _service.ObtenerEmpleado(id);
            if (empleado == null)
            {
                return NotFound("No se encontró el empleado");
            }
            return Ok(empleado);
        }
        [HttpPost]
        [Route("Crear")]
        public async Task<ActionResult> Crear(Empleado empleado)
        {
            var respuesta = await _service.CrearEmpleado(empleado);
            if (respuesta != "")
            {
                return NotFound(respuesta);
            }
            return Ok("Empleado registrado");
        }
        [HttpPut]
        [Route("Actualizar")]
        public async Task<ActionResult> Actualizar(Empleado empleado)
        {
            var respuesta = await _service.ActualizarEmpleado(empleado);
            if (respuesta != "")
            {
                return NotFound(respuesta);
            }
            return Ok("Empleado Actualizado");
        }
        [HttpDelete]
        [Route("Eliminar/{id}")]
        public async Task<ActionResult> Eliminar(int id)
        {
            await _service.EliminarEmpleado(id);
            
            return Ok("Empleado Eliminado");
        }


        }
       
    }
