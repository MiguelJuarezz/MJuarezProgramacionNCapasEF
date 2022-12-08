using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        //public static void Add(ML.Usuario usuario)
        //{
        //    try
        //    {          //SqlCOnnection es para la conexion
        //        using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
        //        {
        //                  //almacenar y ejecutar querys de sql
        //            using (SqlCommand cmd = new SqlCommand())
        //            {
        //                cmd.CommandText = "INSERT INTO Usuario (Nombre, ApellidoPaterno, ApellidoMaterno, FechaNacimiento, Sexo, Telefono, Email) VALUES (@Nombre, @ApellidoPaterno, @ApellidoMaterno, @FechaNacimiento, @Sexo, @Telefono, @Email)";
        //                cmd.Connection = context;
        //                //ya tiene la sentancia y la conexion, hacen falta parametros 



        //                //Agregar parametros
        //                SqlParameter[] collection = new SqlParameter[7];

        //                collection[0] = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
        //                collection[0].Value = usuario.Nombre;

        //                collection[1] = new SqlParameter("@ApellidoPaterno", System.Data.SqlDbType.VarChar);
        //                collection[1].Value = usuario.ApellidoPaterno;

        //                collection[2] = new SqlParameter("@ApellidoMaterno", System.Data.SqlDbType.VarChar);
        //                collection[2].Value = usuario.ApellidoMaterno;

        //                collection[3] = new SqlParameter("FechaNacimiento", System.Data.SqlDbType.Date);
        //                collection[3].Value = usuario.FechaNaciminento;

        //                collection[4] = new SqlParameter("@Sexo", System.Data.SqlDbType.Char);
        //                collection[4].Value = usuario.Sexo;

        //                collection[5] = new SqlParameter("@Telefono", System.Data.SqlDbType.VarChar);
        //                collection[5].Value = usuario.Telefono;

        //                collection[6] = new SqlParameter("@Email", System.Data.SqlDbType.VarChar);
        //                collection[6].Value = usuario.Email;

        //                //pasarle a mi command los parametros
        //                cmd.Parameters.AddRange(collection);

        //                //Abrir la conexión
        //                cmd.Connection.Open();

        //                //ejecutando nuestra sentencia
        //                int rowsAffected = cmd.ExecuteNonQuery();

        //                if (rowsAffected > 0)
        //                {
        //                    Console.WriteLine("El Usario se ha agregado");
        //                }
        //                else
        //                {
        //                    Console.WriteLine("El Usuario no se registro ");
        //                }

        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    Console.ReadKey();  
        //}


        //public static ML.Result Add(ML.Usuario usuario) //add con result
        //{
        //    //instancia de result
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        //SqlCnnnection es para la conexion a sql server
        //        using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
        //        {
        //            //almacenar y ejecutar querys de sql
        //            using (SqlCommand cmd = new SqlCommand())
        //            {
        //                cmd.CommandText = "INSERT INTO Usuario (Nombre, ApellidoPaterno, ApellidoMaterno, FechaNacimiento, Sexo, Telefono, Email, UserName, Password, Celular, Curp, IdRol) VALUES (@Nombre, @ApellidoPaterno, @ApellidoMaterno, @FechaNacimiento, @Sexo, @Telefono, @Email, @UserName, @Password, @Celular, @Curp, @IdRol)";
        //                cmd.Connection = context;
        //                //ya tiene la sentancia y la conexion, hacen falta parametros 



        //                //Agregar parametros
        //                SqlParameter[] collection = new SqlParameter[12];

        //                collection[0] = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
        //                collection[0].Value = usuario.Nombre;

        //                collection[1] = new SqlParameter("@ApellidoPaterno", System.Data.SqlDbType.VarChar);
        //                collection[1].Value = usuario.ApellidoPaterno;

        //                collection[2] = new SqlParameter("@ApellidoMaterno", System.Data.SqlDbType.VarChar);
        //                collection[2].Value = usuario.ApellidoMaterno;

        //                collection[3] = new SqlParameter("FechaNacimiento", System.Data.SqlDbType.Date);
        //                collection[3].Value = usuario.FechaNacimiento;

        //                collection[4] = new SqlParameter("@Sexo", System.Data.SqlDbType.Char);
        //                collection[4].Value = usuario.Sexo;

        //                collection[5] = new SqlParameter("@Telefono", System.Data.SqlDbType.VarChar);
        //                collection[5].Value = usuario.Telefono;

        //                collection[6] = new SqlParameter("@Email", System.Data.SqlDbType.VarChar);
        //                collection[6].Value = usuario.Email;

        //                collection[7] = new SqlParameter("@UserName", System.Data.SqlDbType.VarChar);
        //                collection[7].Value = usuario.UserName;

        //                collection[8] = new SqlParameter("@Password", System.Data.SqlDbType.VarChar);
        //                collection[8].Value = usuario.Password;

        //                collection[9] = new SqlParameter("@Celular", System.Data.SqlDbType.VarChar);
        //                collection[9].Value = usuario.Celular;

        //                collection[10] = new SqlParameter("@Curp", System.Data.SqlDbType.VarChar);
        //                collection[10].Value = usuario.Curp;

        //                collection[11] = new SqlParameter("@IdRol.", System.Data.SqlDbType.VarChar);
        //                collection[11].Value = usuario.IdRol;


        //                //pasarle a mi command los parametros
        //                cmd.Parameters.AddRange(collection);

        //                //Abrir la conexión
        //                cmd.Connection.Open();

        //                //ejecutando nuestra sentencia
        //                int rowsAffected = cmd.ExecuteNonQuery();

        //                if (rowsAffected > 0)
        //                {
        //                    result.Correct = true;
        //                }
        //                else
        //                {
        //                    result.Correct = false;
        //                }

        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //    }
        //    return result;
        //}

        public static ML.Result AddSP(ML.Usuario usuario) //add con store procedures
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
                        cmd.CommandText = "UsuarioAdd";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = context;
                        // ya tiene la sentencia y la conexión, hacen falta los parametros7


                        //agregar parametros 
                        SqlParameter[] collection = new SqlParameter[12];

                        collection[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                        collection[0].Value = usuario.Nombre;

                        collection[1] = new SqlParameter("@ApellidoPaterno", System.Data.SqlDbType.VarChar);
                        collection[1].Value = usuario.ApellidoPaterno;

                        collection[2] = new SqlParameter("@ApellidoMaterno", System.Data.SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoMaterno;

                        collection[3] = new SqlParameter("@FechaNacimiento", System.Data.SqlDbType.Date);
                        collection[3].Value = usuario.FechaNacimiento;

                        collection[4] = new SqlParameter("@Sexo", System.Data.SqlDbType.Char);
                        collection[4].Value = usuario.Sexo;

                        collection[5] = new SqlParameter("@Telefono", System.Data.SqlDbType.Char);
                        collection[5].Value = usuario.Telefono;

                        collection[6] = new SqlParameter("@Email", System.Data.SqlDbType.VarChar);
                        collection[6].Value = usuario.Email;

                        collection[7] = new SqlParameter("@UserName", System.Data.SqlDbType.VarChar);
                        collection[7].Value = usuario.UserName;

                        collection[8] = new SqlParameter("@Password", System.Data.SqlDbType.VarChar);
                        collection[8].Value = usuario.Password;

                        collection[9] = new SqlParameter("@Celular", System.Data.SqlDbType.VarChar);
                        collection[9].Value = usuario.Celular;

                        collection[10] = new SqlParameter("@Curp", System.Data.SqlDbType.VarChar);
                        collection[10].Value = usuario.Curp;

                        //collection[11] = new SqlParameter("@IdRol", System.Data.SqlDbType.Int);
                        //collection[11].Value = usuario.IdRol;

                        collection[11] = new SqlParameter("@IdRol", System.Data.SqlDbType.Int);
                        collection[11].Value = usuario.Rol.IdRol;

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


        //public static ML.Result Delete(ML.Usuario usuario)
        //{
        //    //instancia de result
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        //SqlCnnnection es para la conexion a sql server
        //        using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
        //        {
        //            //almacenar y ejecutar querys de sql
        //            using (SqlCommand cmd = new SqlCommand())
        //            {
        //                cmd.CommandText = "DELETE FROM Usuario WHERE IdUsuario=@IdUsuario";
        //                cmd.Connection = context;
        //                //ya tiene la sentancia y la conexion, hacen falta parametros 



        //                //Agregar parametros
        //                SqlParameter[] collection = new SqlParameter[1];

        //                collection[0] = new SqlParameter("@IdUsuario", System.Data.SqlDbType.Int);
        //                collection[0].Value = usuario.IdUsuario;


        //                //pasarle a mi command los parametros
        //                cmd.Parameters.AddRange(collection);

        //                //Abrir la conexión
        //                cmd.Connection.Open();

        //                //ejecutando nuestra sentencia
        //                int rowsAffected = cmd.ExecuteNonQuery();

        //                if (rowsAffected > 0)
        //                {
        //                    result.Correct = true;
        //                }
        //                else
        //                {
        //                    result.Correct = false;
        //                }

        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //    }
        //    return result;

        //}

        public static ML.Result DeleteSP(ML.Usuario usuario)
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
                        cmd.CommandText = "UsuarioDelete";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = context;
                        //ya tiene la sentancia y la conexion, hacen falta parametros 



                        //Agregar parametros
                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("@IdUsuario", System.Data.SqlDbType.Int);
                        collection[0].Value = usuario.IdUsuario;


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

        //public static ML.Result Update(ML.Usuario usuario)
        //{
        //    //instancia de result
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        //SqlCnnnection es para la conexion a sql server
        //        using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
        //        {
        //            //almacenar y ejecutar querys de sql
        //            using (SqlCommand cmd = new SqlCommand())
        //            {
        //                cmd.CommandText = "UPDATE Usuario SET Telefono = @Telefono, Email =@Email WHERE IdUsuario = @IdUsuario";
        //                cmd.Connection = context;
        //                //ya tiene la sentancia y la conexion, hacen falta parametros 



        //                //Agregar parametros
        //                SqlParameter[] collection = new SqlParameter[3];

        //                collection[0] = new SqlParameter("@IdUsuario", System.Data.SqlDbType.Int);
        //                collection[0].Value = usuario.IdUsuario;

        //                collection[1] = new SqlParameter("@Telefono", System.Data.SqlDbType.VarChar);
        //                collection[1].Value = usuario.Telefono;

        //                collection[2] = new SqlParameter("@Email", System.Data.SqlDbType.VarChar);
        //                collection[2].Value = usuario.Email;


        //                //pasarle a mi command los parametros
        //                cmd.Parameters.AddRange(collection);

        //                //Abrir la conexión
        //                cmd.Connection.Open();

        //                //ejecutando nuestra sentencia
        //                int rowsAffected = cmd.ExecuteNonQuery();

        //                if (rowsAffected > 0)
        //                {
        //                    result.Correct = true;
        //                }
        //                else
        //                {
        //                    result.Correct = false;
        //                }

        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //    }
        //    return result;
        //}

        public static ML.Result UpdateSP(ML.Usuario usuario)
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
                        cmd.CommandText = "UsuarioUpdate";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = context;
                        //ya tiene la sentancia y la conexion, hacen falta parametros 



                        //Agregar parametros
                        SqlParameter[] collection = new SqlParameter[13];

                        collection[0] = new SqlParameter("@IdUsuario", System.Data.SqlDbType.Int);
                        collection[0].Value = usuario.IdUsuario;

                        collection[1] = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
                        collection[1].Value = usuario.Nombre;

                        collection[2] = new SqlParameter("@ApellidoPaterno", System.Data.SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoPaterno;

                        collection[3] = new SqlParameter("@ApellidoMaterno", System.Data.SqlDbType.VarChar);
                        collection[3].Value = usuario.ApellidoMaterno;

                        collection[4] = new SqlParameter("@FechaNacimiento", System.Data.SqlDbType.VarChar);
                        collection[4].Value = usuario.FechaNacimiento;

                        collection[5] = new SqlParameter("@Sexo", System.Data.SqlDbType.Char);
                        collection[5].Value = usuario.Sexo;

                        collection[6] = new SqlParameter("@Telefono", System.Data.SqlDbType.VarChar);
                        collection[6].Value = usuario.Telefono;

                        collection[7] = new SqlParameter("@Email", System.Data.SqlDbType.VarChar);
                        collection[7].Value = usuario.Email;

                        collection[8] = new SqlParameter("@UserName", System.Data.SqlDbType.VarChar);
                        collection[8].Value = usuario.UserName;

                        collection[9] = new SqlParameter("@Password", System.Data.SqlDbType.VarChar);
                        collection[9].Value = usuario.Password;

                        collection[10] = new SqlParameter("@Celular", System.Data.SqlDbType.VarChar);
                        collection[10].Value = usuario.Celular;

                        collection[11] = new SqlParameter("@Curp", System.Data.SqlDbType.VarChar);
                        collection[11].Value = usuario.Curp;

                        collection[12] = new SqlParameter("@IdRol", System.Data.SqlDbType.Int);
                        collection[12].Value = usuario.Rol.IdRol;


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

        //public static ML.Result GetAll()
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
        //        {
        //            using (SqlCommand cmd = new SqlCommand())
        //            {
        //                cmd.CommandText = "UsuarioGetAll";
        //                cmd.Connection = context;
        //                cmd.CommandType = CommandType.StoredProcedure;

        //                //aqui voy a almacenar la información
        //                DataTable tableUsuario = new DataTable();

        //                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        //                //adapter.SelectCommand = cmd;
        //                adapter.Fill(tableUsuario);

        //                if (tableUsuario.Rows.Count > 0)
        //                {
        //                    //mi lista
        //                    result.Objects = new List<object>();
        //                    foreach (DataRow row in tableUsuario.Rows)
        //                    {
        //                        ML.Usuario usuario = new ML.Usuario();
        //                        usuario.IdUsuario = int.Parse(row[0].ToString());
        //                        usuario.Nombre = row[1].ToString();
        //                        usuario.ApellidoPaterno = row[2].ToString();
        //                        usuario.ApellidoMaterno = row[3].ToString();
        //                        usuario.FechaNacimiento = row[4].ToString();
        //                        usuario.Sexo = row[5].ToString();
        //                        usuario.Telefono = row[6].ToString();
        //                        usuario.Email = row[7].ToString();
        //                        usuario.UserName = row[8].ToString();
        //                        usuario.Password = row[9].ToString();
        //                        usuario.Celular = row[10].ToString();
        //                        usuario.Curp = row[11].ToString();
        //                        usuario.Rol = new ML.Rol();
        //                        usuario.Rol.IdRol = int.Parse(row[12].ToString());


        //                        result.Objects.Add(usuario);
        //                    }
        //                    result.Correct = true;
        //                }
        //                else
        //                {
        //                    result.Correct = false;
        //                }

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return result;
        //}

        //public static ML.Result GetById(int idUsuario)
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
        //        {
        //            using (SqlCommand cmd = new SqlCommand())
        //            {
        //                cmd.CommandText = "UsuarioGetById";
        //                cmd.Connection = context;
        //                cmd.CommandType = CommandType.StoredProcedure;

        //                SqlParameter[] collection = new SqlParameter[1];

        //                collection[0] = new SqlParameter("@IdUsuario", SqlDbType.Int);
        //                collection[0].Value = idUsuario;

        //                cmd.Parameters.AddRange(collection);

        //                //aqui voy a almacenar la información
        //                DataTable tableUsuario = new DataTable();

        //                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        //                //adapter.SelectCommand = cmd;
        //                adapter.Fill(tableUsuario);

        //                if (tableUsuario.Rows.Count > 0)
        //                {
        //                    //DataRow row = new DataRow(tableUsuario.Rows);
        //                    DataRow row = tableUsuario.Rows[0];

        //                    ML.Usuario usuario = new ML.Usuario();
        //                    usuario.IdUsuario = int.Parse(row[0].ToString());
        //                    usuario.Nombre = row[1].ToString();
        //                    usuario.ApellidoPaterno = row[2].ToString();
        //                    usuario.ApellidoMaterno = row[3].ToString();
        //                    usuario.FechaNacimiento = row[4].ToString();
        //                    usuario.Sexo = row[5].ToString();
        //                    usuario.Telefono = row[6].ToString();
        //                    usuario.Email = row[7].ToString();
        //                    usuario.UserName = row[8].ToString();
        //                    usuario.Password = row[9].ToString();
        //                    usuario.Celular = row[10].ToString();
        //                    usuario.Curp = row[11].ToString();
        //                    usuario.Rol = new ML.Rol();
        //                    usuario.Rol.IdRol = int.Parse(row[12].ToString());


        //                    //boxing
        //                    //Almacenar cualquier tipo de dato en un dato object
        //                    result.Object = usuario;

        //                    result.Correct = true;
        //                }
        //                else
        //                {
        //                    result.Correct = false;
        //                }

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return result;
        //}

        public static ML.Result AddEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.MJuarezProgramacionNCapasEntities1 context = new DL_EF.MJuarezProgramacionNCapasEntities1())
                {
                    

                    var query = context.UsuarioAdd(usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.FechaNacimiento,
                        usuario.Sexo, usuario.Telefono, usuario.Email, usuario.UserName, usuario.Password, usuario.Celular, 
                        usuario.Curp,usuario.Imagen, usuario.Rol.IdRol,usuario.Direccion.Calle,usuario.Direccion.NumeroInterior,usuario.Direccion.NumeroExterior,
                        usuario.Direccion.Colonia.IdColonia,usuario.Status);


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

        public static ML.Result DeleteEF(int IdUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.MJuarezProgramacionNCapasEntities1 context = new DL_EF.MJuarezProgramacionNCapasEntities1())
                {

                    var query = context.UsuarioDelete(IdUsuario);
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

        public static ML.Result UpdateEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (DL_EF.MJuarezProgramacionNCapasEntities1 context = new DL_EF.MJuarezProgramacionNCapasEntities1())
                {
                    var updateResult = context.UsuarioUpdate(usuario.IdUsuario,usuario.Nombre,usuario.ApellidoPaterno,usuario.ApellidoMaterno, 
                        usuario.FechaNacimiento,usuario.Sexo,usuario.Telefono, usuario.Email,usuario.UserName,usuario.Password,
                        usuario.Celular,usuario.Curp,usuario.Imagen,usuario.Rol.IdRol,usuario.Direccion.Calle,usuario.Direccion.NumeroInterior,
                        usuario.Direccion.NumeroExterior,usuario.Direccion.Colonia.IdColonia);
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

        public static ML.Result GetAllEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.MJuarezProgramacionNCapasEntities1 context = new DL_EF.MJuarezProgramacionNCapasEntities1())
                {
                    usuario.Rol.IdRol = (usuario.Rol.IdRol == null) ? 0 : usuario.Rol.IdRol;
                    usuario.Nombre = (usuario.Nombre == null) ? "" : usuario.Nombre;
                    usuario.ApellidoPaterno = (usuario.ApellidoPaterno == null) ? "" : usuario.ApellidoPaterno;

                    var usuarios = context.UsuarioGetAll(usuario.Nombre,usuario.ApellidoPaterno,usuario.Rol.IdRol).ToList();

                    result.Objects = new List<object>();

                    if (usuarios != null)
                    {
                        foreach (var obj in usuarios)
                        {
                            ML.Usuario usuarioobj = new ML.Usuario();
                            usuarioobj.IdUsuario = obj.IdUsuario;
                            usuarioobj.Nombre = obj.Nombre;
                            usuarioobj.ApellidoPaterno = obj.ApellidoPaterno;
                            usuarioobj.ApellidoMaterno = obj.ApellidoMaterno;
                            usuarioobj.FechaNacimiento = obj.FechaNacimiento.ToString("dd-MM-yyyy");
                            usuarioobj.Sexo = obj.Sexo;
                            usuarioobj.Telefono = obj.Telefono;
                            usuarioobj.Email = obj.Email;
                            usuarioobj.UserName = obj.UserName;
                            usuarioobj.Password = obj.Password;
                            usuarioobj.Celular = obj.Celular;
                            usuarioobj.Imagen = obj.Imagen;
                            usuarioobj.Curp = obj.Curp;

                            usuarioobj.Rol = new ML.Rol();
                            usuarioobj.Rol.IdRol = obj.IdRol;
                            usuarioobj.Rol.Nombre = obj.RolNombre; 

                            usuarioobj.Direccion = new ML.Direccion();
                            usuarioobj.Direccion.IdDireccion = obj.IdDireccion;
                            usuarioobj.Direccion.Calle = obj.Calle;
                            usuarioobj.Direccion.NumeroInterior = obj.NumeroInterior;
                            usuarioobj.Direccion.NumeroExterior = obj.NumeroExterior;

                            usuarioobj.Direccion.Colonia = new ML.Colonia();
                            usuarioobj.Direccion.Colonia.IdColonia = obj.IdColonia.Value;
                            usuarioobj.Direccion.Colonia.Nombre = obj.ColoniaNombre;
                            usuarioobj.Direccion.Colonia.CosdigoPostal = obj.CodigoPostal;
                            usuarioobj.Direccion.Colonia.CosdigoPostal = obj.CodigoPostal;

                            usuarioobj.Direccion.Colonia.Municipio = new ML.Municipio();
                            usuarioobj.Direccion.Colonia.Municipio.IdMunicipio = obj.IdMunicipio.Value;
                            usuarioobj.Direccion.Colonia.Municipio.Nombre = obj.MunicipioNombre;

                            usuarioobj.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                            usuarioobj.Direccion.Colonia.Municipio.Estado.IdEstado = obj.IdEstado.Value;
                            usuarioobj.Direccion.Colonia.Municipio.Estado.Nombre = obj.EstadoNombre;

                            usuarioobj.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                            usuarioobj.Direccion.Colonia.Municipio.Estado.Pais.IdPais = obj.IdPais.Value;
                            usuarioobj.Direccion.Colonia.Municipio.Estado.Pais.Nombre = obj.PaisNombre;

                            usuarioobj.Status = obj.Status;

                            result.Objects.Add(usuarioobj);
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

        public static ML.Result GetByIdEF(int idUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MJuarezProgramacionNCapasEntities1 context = new DL_EF.MJuarezProgramacionNCapasEntities1())
                {

                    var objUsuario = context.UsuarioGetById(idUsuario).FirstOrDefault();

                    result.Objects = new List<object>();

                    if (objUsuario != null)
                    {

                        ML.Usuario usuario = new ML.Usuario();
                        usuario.IdUsuario = objUsuario.IdUsuario;
                        usuario.Nombre = objUsuario.Nombre;
                        usuario.ApellidoPaterno = objUsuario.ApellidoPaterno;
                        usuario.ApellidoMaterno = objUsuario.ApellidoMaterno;
                        usuario.FechaNacimiento = objUsuario.FechaNacimiento.ToString("dd-MM-yyyy");
                        usuario.Sexo = objUsuario.Sexo;
                        usuario.Telefono = objUsuario.Telefono;
                        usuario.Email = objUsuario.Email;
                        usuario.UserName = objUsuario.UserName;
                        usuario.Password = objUsuario.Password;
                        usuario.Celular = objUsuario.Celular;
                        usuario.Imagen = objUsuario.Imagen;
                        usuario.Curp = objUsuario.Curp;
                      

                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = objUsuario.IdRol;

                        usuario.Direccion = new ML.Direccion();
                        usuario.Direccion.IdDireccion = objUsuario.IdDireccion;
                        usuario.Direccion.Calle = objUsuario.Calle;
                        usuario.Direccion.NumeroInterior = objUsuario.NumeroInterior;
                        usuario.Direccion.NumeroExterior = objUsuario.NumeroExterior;
                        
                        usuario.Direccion.Colonia = new ML.Colonia();
                        usuario.Direccion.Colonia.IdColonia = objUsuario.IdColonia.Value;
                        usuario.Direccion.Colonia.Nombre = objUsuario.ColoniaNombre;
                        usuario.Direccion.Colonia.CosdigoPostal = objUsuario.CodigoPostal;
                        usuario.Direccion.Colonia.CosdigoPostal = objUsuario.CodigoPostal;

                        usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                        usuario.Direccion.Colonia.Municipio.IdMunicipio = objUsuario.IdMunicipio.Value;
                        usuario.Direccion.Colonia.Municipio.Nombre = objUsuario.MunicipioNombre;

                        usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                        usuario.Direccion.Colonia.Municipio.Estado.IdEstado = objUsuario.IdEstado.Value;
                        usuario.Direccion.Colonia.Municipio.Estado.Nombre = objUsuario.EstadoNombre;

                        usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = objUsuario.IdPais.Value;
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre = objUsuario.PaisNombre;



                        result.Object = usuario;


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

        //public static ML.Result AddEFLINQ(ML.Usuario usuario)
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        using (DL_EF.MJuarezProgramacionNCapasEntities1 context = new DL_EF.MJuarezProgramacionNCapasEntities1())
        //        {
        //            DL_EF.Usuario usuarioDL = new DL_EF.Usuario();

        //            usuarioDL.Nombre = usuario.Nombre;
        //            usuarioDL.ApellidoPaterno = usuario.ApellidoPaterno;
        //            usuarioDL.ApellidoMaterno = usuario.ApellidoMaterno;
        //            usuarioDL.FechaNacimiento = DateTime.Parse(usuario.FechaNacimiento);
        //            usuarioDL.Sexo = usuario.Sexo;
        //            usuarioDL.Telefono = usuario.Telefono;
        //            usuarioDL.Email = usuario.Email;
        //            usuarioDL.UserName = usuario.UserName;
        //            usuarioDL.Password = usuario.Password;
        //            usuarioDL.Celular = usuario.Celular;
        //            usuarioDL.Curp = usuario.Curp;
        //            usuarioDL.IdRol = usuario.Rol.IdRol;

        //            context.Usuarios.Add(usuarioDL);

        //            var query = context.SaveChanges();

        //            if (query > 0)
        //            {
        //                result.Correct = true;
        //            }
        //            else
        //            {
        //                result.Correct = false;
        //            }

        //        }
        //    }

        //    catch (Exception ex)
        //    {

        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //    }
        //    return result;
        //}

        //public static ML.Result DeleteEFLINQ(ML.Usuario usuario)
        //{
        //    ML.Result result = new ML.Result();

        //    try
        //    {
        //        using (DL_EF.MJuarezProgramacionNCapasEntities1 context = new DL_EF.MJuarezProgramacionNCapasEntities1())
        //        {
        //            var query = (from Usuario in context.Usuarios
        //                         where Usuario.IdUsuario == usuario.IdUsuario
        //                         select Usuario).SingleOrDefault();

        //            context.Usuarios.Remove(query);
        //            int resp = context.SaveChanges();

        //            if (resp > 0)
        //            {
        //                result.Correct = true;
        //            }
        //            else
        //            {
        //                result.Correct = false;
        //            }
        //        }
        //    }

        //    catch (Exception ex)
        //    {

        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //    }

        //    return result;
        //}

        //public static ML.Result UpdateEFLINQ(ML.Usuario usuario)
        //{
        //    ML.Result result = new ML.Result();

        //    try
        //    {
        //        using (DL_EF.MJuarezProgramacionNCapasEntities1 context = new DL_EF.MJuarezProgramacionNCapasEntities1())
        //        {
        //            var query = (from Usuario in context.Usuarios
        //                         where Usuario.IdUsuario == usuario.IdUsuario
        //                         select Usuario).SingleOrDefault();

        //            if (query != null)
        //            {
        //                query.Telefono = usuario.Telefono;
        //                query.Email = usuario.Email;

        //                context.SaveChanges();
        //                result.Correct = true;
        //            }

        //            else
        //            {
        //                result.Correct = false;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //    }

        //    return result;



        //}

        //public static ML.Result GetAllEFLINQ()
        //{
        //    ML.Result result = new ML.Result();

        //    try
        //    {
        //        using (DL_EF.MJuarezProgramacionNCapasEntities1 context = new DL_EF.MJuarezProgramacionNCapasEntities1())
        //        {
        //            var query = (from Usuario in context.Usuarios
        //                         select new {IdUsuario = Usuario.IdUsuario, Nombre=Usuario.Nombre, ApellidoPaterno=Usuario.ApellidoPaterno, ApellidoMaterno=Usuario.ApellidoMaterno, 
        //                             FechaNacimiento=Usuario.FechaNacimiento, Sexo=Usuario.Sexo, Telefono=Usuario.Telefono, Email = Usuario.Email,
        //                             UserName= Usuario.UserName, Password=Usuario.Password, Celular=Usuario.Celular, Curp=Usuario.Curp, IdRol=Usuario.IdRol});

        //            result.Objects = new List<object>();

        //            if (query != null && query.ToList().Count > 0)
        //            {
        //                foreach (var obj in query)
        //                {
        //                    ML.Usuario usuario = new ML.Usuario();
        //                    usuario.IdUsuario = obj.IdUsuario;
        //                    usuario.Nombre = obj.Nombre;
        //                    usuario.ApellidoPaterno = obj.ApellidoPaterno;
        //                    usuario.ApellidoMaterno = obj.ApellidoMaterno;
        //                    usuario.FechaNacimiento = obj.FechaNacimiento.ToString();
        //                    usuario.Sexo = obj.Sexo;
        //                    usuario.Telefono = obj.Telefono;
        //                    usuario.Email = obj.Email;
        //                    usuario.UserName = obj.UserName;
        //                    usuario.Password = obj.Password;
        //                    usuario.Celular = obj.Celular;
        //                    usuario.Curp = obj.Curp;

        //                    usuario.Rol = new ML.Rol();
        //                    usuario.Rol.IdRol = obj.IdRol;

        //                    result.Objects.Add(usuario);
        //                }
        //                result.Correct = true;
        //            }
        //            else
        //            {
        //                result.Correct = false;
        //                result.ErrorMessage = "No se encontraron registros";
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //    }
        //    return result;
        //}

        //public static ML.Result GetByIdLINQ(int idUsuario)
        //{
        //    ML.Result Result = new ML.Result();

        //    try
        //    {
        //        using (DL_EF.MJuarezProgramacionNCapasEntities1 Context = new DL_EF.MJuarezProgramacionNCapasEntities1())
        //        {
        //            var ResultQuery = (from usuario in Context.Usuarios
        //                               where usuario.IdUsuario == idUsuario
        //                               select new
        //                               {
        //                                   usuario.IdUsuario,
        //                                   usuario.Nombre,
        //                                   usuario.ApellidoPaterno,
        //                                   usuario.ApellidoMaterno,
        //                                   usuario.FechaNacimiento,
        //                                   usuario.Sexo,
        //                                   usuario.Telefono,
        //                                   usuario.Email,
        //                                   usuario.UserName,
        //                                   usuario.Password,
        //                                   usuario.Celular,
        //                                   usuario.Curp,
        //                                   usuario.IdRol
        //                               }).FirstOrDefault();

        //            if (ResultQuery != null)
        //            {

        //                ML.Usuario usuario = new ML.Usuario();
        //                usuario.IdUsuario = ResultQuery.IdUsuario;
        //                usuario.Nombre = ResultQuery.Nombre;
        //                usuario.ApellidoPaterno = ResultQuery.ApellidoPaterno;
        //                usuario.ApellidoMaterno = ResultQuery.ApellidoMaterno;
        //                usuario.FechaNacimiento = ResultQuery.FechaNacimiento.ToString();
        //                //DateTime.ParseExact(usuario.FechaNacimiento, "dd-MM-yyyy", null);
        //                usuario.Sexo = ResultQuery.Sexo;
        //                usuario.Telefono = ResultQuery.Telefono;
        //                usuario.Email = ResultQuery.Email;
        //                usuario.UserName = ResultQuery.UserName;
        //                usuario.Password = ResultQuery.Password;
        //                usuario.Celular = ResultQuery.Celular;
        //                usuario.Curp = ResultQuery.Curp;

        //                usuario.Rol = new ML.Rol();
        //                usuario.Rol.IdRol = ResultQuery.IdRol;

        //                Result.Object = usuario;
        //                Result.Correct = true;
        //            }
        //            else
        //            {
        //                Result.Correct = false;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Result.Correct = false;
        //        Result.ErrorMessage = ex.Message;
        //        Result.Ex = ex;
        //    }
        //    return Result;
        //}


    }
}
