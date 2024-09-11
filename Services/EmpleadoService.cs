using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudSistema.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CrudSistema.Services
{
    public class EmpleadoService
    {
        private readonly IConfiguration _configuration;
        private readonly string CadenaSql;



        public EmpleadoService(IConfiguration configuration){
            _configuration = configuration;
            CadenaSql=_configuration.GetConnectionString("CadenaSQL")!;
        }
        
        public async Task<List<Empleado>> ListaEmpleados(){
            string Query="SP_LISTA_EMPLEADOS";

            using(var Conexion=new SqlConnection(CadenaSql)){

             var Lista=await Conexion.QueryAsync<Empleado>(Query,commandType:CommandType.StoredProcedure);
             return Lista.ToList();
            }

        }
        public async Task<Empleado> ObtenerEmpleado(int Id){
            string Query="SP_OBTENER_EMPLEADO";
            var parametros=new DynamicParameters();
            parametros.Add("@IdEmpleado",Id,dbType:DbType.Int64);

            using(var Conexion=new SqlConnection(CadenaSql)){

             var Empleado=await Conexion.QueryFirstOrDefaultAsync<Empleado>(Query,parametros,commandType:CommandType.StoredProcedure);
             return Empleado!;
            }

        }
        
        public async Task<string> CrearEmpleado(Empleado empleado){
            string Query="SP_CREAR_EMPLEADO";
            var parametros=new DynamicParameters();
            parametros.Add("@NumeroDocumento",empleado.NumeroDocumento,dbType:DbType.String);
            parametros.Add("@NombreCompleto",empleado.NombreCompleto,dbType:DbType.String);
            parametros.Add("@Sueldo",empleado.Sueldo,dbType:DbType.Int64);
            parametros.Add("@msError",dbType:DbType.String,direction:ParameterDirection.Output,size:50);

            using(var Conexion=new SqlConnection(CadenaSql)){

            await Conexion.ExecuteAsync(Query,parametros,commandType:CommandType.StoredProcedure);
            return parametros.Get<String>("@msError");
            }

        }
        public async Task EliminarEmpleado(int id){
            string Query="SP_ELIMINAR_EMPLEADO";
            var parametros=new DynamicParameters();
            parametros.Add("@IdEmpleado",id,dbType:DbType.Int64);
          

            using(var Conexion=new SqlConnection(CadenaSql)){

               await Conexion.ExecuteAsync(Query,parametros,commandType:CommandType.StoredProcedure);
         
            }

        }
        public async Task<string> ActualizarEmpleado(Empleado empleado){
            string Query="SP_ACTUALIZAR_EMPLEADO";
            var parametros=new DynamicParameters();
            parametros.Add("@IdEmpleado",empleado.IdEmpleado,dbType:DbType.Int64);
            parametros.Add("@NumeroDocumento",empleado.NumeroDocumento,dbType:DbType.String);
            parametros.Add("@NombreCompleto",empleado.NombreCompleto,dbType:DbType.String);
            parametros.Add("@Sueldo",empleado.Sueldo,dbType:DbType.Int64);
            parametros.Add("@msError",dbType:DbType.String,direction:ParameterDirection.Output,size:50);

            using(var Conexion=new SqlConnection(CadenaSql)){

            await Conexion.ExecuteAsync(Query,parametros,commandType:CommandType.StoredProcedure);
            return parametros.Get<String>("@msError");
            }

        }


    }
}