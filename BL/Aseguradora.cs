using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Aseguradora
    {

        public static ML.Result Add(ML.Aseguradora aseguradora) //add con store procedures
        {
            ML.Result result = new ML.Result();

            try
            {

                //SqlConnection es para conexión a sql server
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    //almacenar querys de sql y ejercutarlos 
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "AseguradoraAdd";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = context;
                        // ya tiene la sentencia y la conexión, hacen falta los parametros


                        //agregar parametros 
                        SqlParameter[] collection = new SqlParameter[2];

                        collection[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                        collection[0].Value = aseguradora.Nombre;

                        //collection[11] = new SqlParameter("@IdRol", System.Data.SqlDbType.Int);
                        //collection[11].Value = usuario.IdRol;

                        collection[1] = new SqlParameter("@IdUsuario", System.Data.SqlDbType.Int);
                        collection[1].Value = aseguradora.Usuario.IdUsuario;

                        //pasarle a mi command los parametros
                        cmd.Parameters.AddRange(collection);

                        //Abrir la conexión
                        cmd.Connection.Open();

                        //ejecutando nuestra sentencia
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result Delete(ML.Aseguradora aseguradora)
        {
            //instancia de result
            ML.Result result = new ML.Result();
            try
            {
                //SqlCnnnection es para la conexion a sql server
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    //almacenar y ejecutar querys de sql
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "AseguradoraDelete";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = context;
                        //ya tiene la sentancia y la conexion, hacen falta parametros 



                        //Agregar parametros
                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("@IdAseguradora", System.Data.SqlDbType.Int);
                        collection[0].Value = aseguradora.IdAseguradora;


                        //pasarle a mi command los parametros
                        cmd.Parameters.AddRange(collection);

                        //Abrir la conexión
                        cmd.Connection.Open();

                        //ejecutando nuestra sentencia
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;

        }

        public static ML.Result Update(ML.Aseguradora aseguradora)
        {
            //instancia de result
            ML.Result result = new ML.Result();
            try
            {
                //SqlCnnnection es para la conexion a sql server
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    //almacenar y ejecutar querys de sql
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "AseguradoraUpdate";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = context;
                        //ya tiene la sentancia y la conexion, hacen falta parametros 



                        //Agregar parametros
                        SqlParameter[] collection = new SqlParameter[3];

                        collection[0] = new SqlParameter("@IdAseguradora", System.Data.SqlDbType.Int);
                        collection[0].Value = aseguradora.IdAseguradora;

                        collection[1] = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
                        collection[1].Value = aseguradora.Nombre;

                        collection[2] = new SqlParameter("@IdUsuario", System.Data.SqlDbType.Int);
                        collection[2].Value = aseguradora.Usuario.IdUsuario;


                        //pasarle a mi command los parametros
                        cmd.Parameters.AddRange(collection);

                        //Abrir la conexión
                        cmd.Connection.Open();

                        //ejecutando nuestra sentencia
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "AseguradoraGetAll";
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        //aqui voy a almacenar la información
                        DataTable tableAseguradora = new DataTable();

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                        //adapter.SelectCommand = cmd;
                        adapter.Fill(tableAseguradora);

                        if (tableAseguradora.Rows.Count > 0)
                        {
                            //mi lista
                            result.Objects = new List<object>();
                            foreach (DataRow row in tableAseguradora.Rows)
                            {
                                ML.Aseguradora aseguradora = new ML.Aseguradora();
                                aseguradora.IdAseguradora = int.Parse(row[0].ToString());
                                aseguradora.Nombre = row[1].ToString();
                                aseguradora.FechaCreacion = row[2].ToString();
                                aseguradora.FechaModificacion = row[3].ToString();
                                aseguradora.Usuario = new ML.Usuario(); 
                                aseguradora.Usuario.IdUsuario = int.Parse(row[4].ToString());


                                result.Objects.Add(aseguradora);
                            }
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }

                    }
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public static ML.Result GetById(int idAseguradora)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "AseguradoraGetById";
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("@IdAseguradora", SqlDbType.Int);
                        collection[0].Value = idAseguradora;

                        cmd.Parameters.AddRange(collection);

                        //aqui voy a almacenar la información
                        DataTable tableAseguradora = new DataTable();

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                        //adapter.SelectCommand = cmd;
                        adapter.Fill(tableAseguradora);

                        if (tableAseguradora.Rows.Count > 0)
                        {
                            //DataRow row = new DataRow(tableUsuario.Rows);
                            DataRow row = tableAseguradora.Rows[0];

                            ML.Aseguradora aseguradora = new ML.Aseguradora();
                            aseguradora.IdAseguradora = int.Parse(row[0].ToString());
                            aseguradora.Nombre = row[1].ToString();
                            aseguradora.FechaCreacion = row[2].ToString();
                            aseguradora.FechaModificacion = row[3].ToString();
                            aseguradora.Usuario = new ML.Usuario();
                            aseguradora.Usuario.IdUsuario = int.Parse(row[4].ToString());


                            //boxing
                            //Almacenar cualquier tipo de dato en un dato object
                            result.Object = aseguradora;

                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }

                    }
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public static ML.Result AddEF(ML.Aseguradora aseguradora)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.MJuarezProgramacionNCapasEntities1 context = new DL_EF.MJuarezProgramacionNCapasEntities1())
                {

                    var query = context.AseguradoraAdd(aseguradora.Nombre,aseguradora.Usuario.IdUsuario);


                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se insertó el registro";
                    }

                    result.Correct = true;

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result DeleteEF(int IdAseguradora)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.MJuarezProgramacionNCapasEntities1 context = new DL_EF.MJuarezProgramacionNCapasEntities1())
                {

                    var query = context.AseguradoraDelete(IdAseguradora);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se eliminó el registro";
                    }

                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public static ML.Result UpdateEF(ML.Aseguradora aseguradora)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (DL_EF.MJuarezProgramacionNCapasEntities1 context = new DL_EF.MJuarezProgramacionNCapasEntities1())
                {
                    var updateResult = context.AseguradoraUpdate(aseguradora.IdAseguradora,aseguradora.Nombre,aseguradora.Usuario.IdUsuario);
                    if (updateResult >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se actualizó los datos";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.MJuarezProgramacionNCapasEntities1 context = new DL_EF.MJuarezProgramacionNCapasEntities1())
                {

                    var aseguradoras = context.AseguradoraGetAll().ToList();

                    result.Objects = new List<object>();

                    if (aseguradoras != null)
                    {
                        foreach (var obj in aseguradoras)
                        {
                            ML.Aseguradora aseguradora = new ML.Aseguradora();
                            aseguradora.IdAseguradora = obj.IdAseguradora;
                            aseguradora.Nombre = obj.Nombre;
                            aseguradora.FechaCreacion = obj.FechaCreacion.ToString();
                            aseguradora.FechaModificacion = obj.FechaModificacion.ToString();
                            aseguradora.Usuario = new ML.Usuario();
                            aseguradora.Usuario.IdUsuario = obj.IdUsuario.Value;
                            aseguradora.Usuario.Nombre = obj.UsuarioNombre;


                            result.Objects.Add(aseguradora);
                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros.";
                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }

            return result;
        }

        public static ML.Result GetByIdEF(int idAseguradora)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MJuarezProgramacionNCapasEntities1 context = new DL_EF.MJuarezProgramacionNCapasEntities1())
                {

                    var objAseguradora = context.AseguradoraGetById(idAseguradora).FirstOrDefault();

                    result.Objects = new List<object>();

                    if (objAseguradora != null)
                    {

                        ML.Aseguradora aseguradora = new ML.Aseguradora();
                        aseguradora.IdAseguradora = objAseguradora.IdAseguradora;
                        aseguradora.Nombre = objAseguradora.Nombre;
                        aseguradora.FechaCreacion = objAseguradora.FechaCreacion.ToString();
                        aseguradora.FechaModificacion = objAseguradora.FechaModificacion.ToString();
                        aseguradora.Usuario = new ML.Usuario();
                        aseguradora.Usuario.IdUsuario = objAseguradora.IdUsuario.Value;


                        result.Object = aseguradora;


                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al obtener los registros en la tabla usuarios";
                    }

                }


            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        public static ML.Result AddEFLINQ(ML.Aseguradora aseguradora)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MJuarezProgramacionNCapasEntities1 context = new DL_EF.MJuarezProgramacionNCapasEntities1())
                {
                    DL_EF.Aseguradora aseguradoraDL = new DL_EF.Aseguradora();

                    aseguradoraDL.Nombre = aseguradora.Nombre;
                    aseguradoraDL.FechaCreacion = DateTime.Now;
                    aseguradoraDL.FechaModificacion = DateTime.Now;
                    aseguradoraDL.IdUsuario = aseguradora.Usuario.IdUsuario;
               
                    context.Aseguradoras.Add(aseguradoraDL);

                    var query = context.SaveChanges();

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }

                }
            }

            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result DeleteEFLINQ(ML.Aseguradora aseguradora)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.MJuarezProgramacionNCapasEntities1 context = new DL_EF.MJuarezProgramacionNCapasEntities1())
                {
                    var query = (from Aseguradora in context.Aseguradoras
                                 where Aseguradora.IdAseguradora == aseguradora.IdAseguradora
                                 select Aseguradora).SingleOrDefault();

                    context.Aseguradoras.Remove(query);
                    int resp = context.SaveChanges();

                    if (resp > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }

            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public static ML.Result UpdateEFLINQ(ML.Aseguradora aseguradora)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.MJuarezProgramacionNCapasEntities1 context = new DL_EF.MJuarezProgramacionNCapasEntities1())
                {
                    var query = (from Aseguradora in context.Aseguradoras
                                 where Aseguradora.IdAseguradora == aseguradora.IdAseguradora
                                 select Aseguradora).SingleOrDefault();

                    if (query != null)
                    {
                        query.Nombre = aseguradora.Nombre;
                        query.FechaModificacion = DateTime.Now;
                        query.Usuario.IdUsuario = aseguradora.Usuario.IdUsuario;

                        context.SaveChanges();
                        result.Correct = true;
                    }

                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;



        }

        public static ML.Result GetAllEFLINQ()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.MJuarezProgramacionNCapasEntities1 context = new DL_EF.MJuarezProgramacionNCapasEntities1())
                {
                    var query = (from Aseguradora in context.Aseguradoras
                                 select new
                                 {
                                     IdAseguradora = Aseguradora.IdAseguradora,
                                     Nombre = Aseguradora.Nombre,
                                     FechaCreacion = Aseguradora.FechaCreacion,
                                     FechaModificacion = Aseguradora.FechaModificacion,
                                     IdUsuario = Aseguradora.IdUsuario
                                 });

                    result.Objects = new List<object>();

                    if (query != null && query.ToList().Count > 0)
                    {
                        foreach (var obj in query)
                        {
                            ML.Aseguradora aseguradora = new ML.Aseguradora();
                            aseguradora.IdAseguradora = obj.IdAseguradora;
                            aseguradora.Nombre = obj.Nombre;
                            aseguradora.FechaCreacion = obj.FechaCreacion.ToString();
                            aseguradora.FechaModificacion = obj.FechaModificacion.ToString();

                            aseguradora.Usuario = new ML.Usuario();
                            aseguradora.Usuario.IdUsuario = obj.IdUsuario.Value;

                            result.Objects.Add(aseguradora);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result GetByIdEFLINQ(int idAseguradora)
        {
            ML.Result Result = new ML.Result();

            try
            {
                using (DL_EF.MJuarezProgramacionNCapasEntities1 Context = new DL_EF.MJuarezProgramacionNCapasEntities1())
                {
                    var ResultQuery = (from Aseguradora in Context.Aseguradoras
                                       where Aseguradora.IdAseguradora == idAseguradora
                                       select new
                                       {
                                           Aseguradora.IdAseguradora,
                                           Aseguradora.Nombre,
                                           Aseguradora.FechaCreacion,
                                           Aseguradora.FechaModificacion,
                                           Aseguradora.IdUsuario
                                       }).FirstOrDefault();

                    if (ResultQuery != null)
                    {

                        ML.Aseguradora aseguradora = new ML.Aseguradora();
                        aseguradora.IdAseguradora = ResultQuery.IdAseguradora;
                        aseguradora.Nombre = ResultQuery.Nombre;
                        aseguradora.FechaCreacion = ResultQuery.FechaCreacion.ToString();
                        aseguradora.FechaModificacion = ResultQuery.FechaModificacion.ToString();
                        //DateTime.ParseExact(usuario.FechaNacimiento, "dd-MM-yyyy", null);

                        aseguradora.Usuario = new ML.Usuario();
                        aseguradora.Usuario.IdUsuario = ResultQuery.IdUsuario.Value;

                        Result.Object = aseguradora;
                        Result.Correct = true;
                    }
                    else
                    {
                        Result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Result.Correct = false;
                Result.ErrorMessage = ex.Message;
                Result.Ex = ex;
            }
            return Result;
        }

    }

}
