using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Usuario //solicitar información, recompilar información, capturar información 
    {
        public static void Add()
        {
            //instancia de un objeto
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Inserte El Nombre Del Usuario");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Inserte El Apellido Paterno Del Usuario");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Inserte El Apellido Materno Del Usuario");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.WriteLine("Inserte La Fecha De Nacimiento Del Usuario");
            usuario.FechaNacimiento = Console.ReadLine();

            Console.WriteLine("Inserte El Sexo Del Usuario");
            usuario.Sexo = Console.ReadLine();

            Console.WriteLine("Inserte El Telefono Del Usuario");
            usuario.Telefono = Console.ReadLine();

            Console.WriteLine("Inserte El Email Del Usuario");
            usuario.Email = Console.ReadLine();

            Console.WriteLine("Inserte El UserName Del Usuario");
            usuario.UserName = Console.ReadLine();

            Console.WriteLine("Inserte El Password Del Usuario");
            usuario.Password = Console.ReadLine();

            Console.WriteLine("Inserte El Celular Del Usuario");
            usuario.Celular = Console.ReadLine();

            Console.WriteLine("Inserte El Curp Del Usuario");
            usuario.Curp = Console.ReadLine();

            //Console.WriteLine("Inserte El IdRol Del Usuario");
            //usuario.IdRol = int.Parse(Console.ReadLine());

            usuario.Rol = new ML.Rol();
            Console.WriteLine("Inserte el ID Del Rol del usuario");
            usuario.Rol.IdRol = int.Parse(Console.ReadLine());

            ML.Result result = new ML.Result();
            //mandar la información al BL 
            //result = BL.Usuario.AddEFLINQ(usuario);descomentar

            if (result.Correct == true)
            {
                Console.WriteLine("El Usuario se registro correctamente");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("El Usuario no se registro" + result.ErrorMessage);
                Console.ReadKey();
            }
        }

        public static void Delete(int IdUsuario)
        {
            //instancia de un objeto
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Inserte El Id Del Usuario");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            ML.Result result = new ML.Result();
            //mandar la información al BL 
            result = BL.Usuario.DeleteEF(IdUsuario);

            if (result.Correct == true)
            {
                Console.WriteLine("El Usuario se Elimino correctamente");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("El Usuario no se Elimino " + result.ErrorMessage);
                Console.ReadKey();
            }
        }

        public static void Update()
        {
            //instancia de un objeto
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Inserte El Id Del Usuario Que Quiere Actualizar");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            Console.WriteLine("Inserte El Nuevo Nombre Del Usuario");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Inserte El Nuevo Apellido Paterno Del Usuario");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Inserte El Nuevo Apellido Materno Del Usuario");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.WriteLine("Inserte la Nueva Fecha De Nacimiento Del Usuario");
            usuario.FechaNacimiento = Console.ReadLine();

            Console.WriteLine("Inserte El Nuevo Sexo Del Usuario");
            usuario.Sexo = Console.ReadLine();

            Console.WriteLine("Inserte El Nuevo Telefono Del Usuario");
            usuario.Telefono = Console.ReadLine();

            Console.WriteLine("Inserte El Nuevo Email Del Usuario");
            usuario.Email = Console.ReadLine();

            Console.WriteLine("Inserte El Nuevo UserName Del Usuario");
            usuario.UserName = Console.ReadLine();

            Console.WriteLine("Inserte El Nuevo Password Del Usuario");
            usuario.Password = Console.ReadLine();

            Console.WriteLine("Inserte El Nuevo Celular Del Usuario");
            usuario.Celular = Console.ReadLine();

            Console.WriteLine("Inserte El Nuevo Curp Del Usuario");
            usuario.Curp = Console.ReadLine();

            usuario.Rol = new ML.Rol();
            Console.WriteLine("Inserte El Nuevo Id Rol Del Usuario");
            usuario.Rol.IdRol = int.Parse(Console.ReadLine());

            ML.Result result = new ML.Result();
            //mandar la información al BL 
            result = BL.Usuario.UpdateEF(usuario);

            if (result.Correct == true)
            {
                Console.WriteLine("El Usuario se actualizo correctamente");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("El Usuario no se actualizo" + result.ErrorMessage);
                Console.ReadKey();
            }
        }


        public static void GetAll(ML.Usuario usuarios)
        {
            ML.Result result = BL.Usuario.GetAllEF(usuarios); 

            if (result.Correct)
            {
                foreach (ML.Usuario usuario in result.Objects)
                {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("El id del usuario es:" + usuario.IdUsuario);
                    Console.WriteLine("El nombre del usuario es:" + usuario.Nombre);
                    Console.WriteLine("El apellido paterno del usuario es:" + usuario.ApellidoPaterno);
                    Console.WriteLine("El Apellido Materno del usuario es:" + usuario.ApellidoMaterno);
                    Console.WriteLine("La fecha de nacimiento del usuario es:" + usuario.FechaNacimiento);
                    Console.WriteLine("El Sexo del Usiario es:" + usuario.Sexo);
                    Console.WriteLine("El Telefono del Usuario es:" + usuario.Telefono);
                    Console.WriteLine("El Email del Usuario es:" + usuario.Email);
                    Console.WriteLine("El UserName del Usuario es:" + usuario.UserName);
                    Console.WriteLine("El Password del Usuario es:" + usuario.Password);
                    Console.WriteLine("El Celular del Usuario es:" + usuario.Celular);
                    Console.WriteLine("El Curp del Usuario es:" + usuario.Curp);
                    Console.WriteLine("El IdRol del Usuario es:" + usuario.Rol.IdRol);
                    Console.WriteLine("-----------------------------------");

                }

            }
            else
            {
                Console.WriteLine("Ocurrio un error " + result.ErrorMessage);
            }
        }

        public static void GetById()
        {
            Console.WriteLine("Ingrese el id del alumno que desea consultar");
            int idUsuario = int.Parse(Console.ReadLine());

            ML.Result result = new ML.Result();
            result = BL.Usuario.GetByIdEF(idUsuario);

            if (result.Correct)
            {
                ML.Usuario usuario = new ML.Usuario();

                //unboxing
                usuario = (ML.Usuario)result.Object;

                Console.WriteLine("-----------------------------------");
                Console.WriteLine("El id del usuario es:" + usuario.IdUsuario);
                Console.WriteLine("El nombre del usuario es:" + usuario.Nombre);
                Console.WriteLine("El apellido paterno del usuario es:" + usuario.ApellidoPaterno);
                Console.WriteLine("El Apellido Materno del usuario es:" + usuario.ApellidoMaterno);
                Console.WriteLine("La Fecha De Nacimiento del usuario es:" + usuario.FechaNacimiento);
                Console.WriteLine("El Sexo del Usiario es:" + usuario.Sexo);
                Console.WriteLine("El Telefono del Usuario es:" + usuario.Telefono);
                Console.WriteLine("El Email del Usuario es:" + usuario.Email);
                Console.WriteLine("El UserName del Usuario es:" + usuario.UserName);
                Console.WriteLine("El Password del Usuario es:" + usuario.Password);
                Console.WriteLine("El Celular del Usuario es:" + usuario.Celular);
                Console.WriteLine("El Curp del Usuario es:" + usuario.Curp);
                Console.WriteLine("El IdRol del Usuario es:" + usuario.Rol.IdRol);
                Console.WriteLine("-----------------------------------");
            }
            else
            {
                Console.WriteLine("Ocurrio un error " + result.ErrorMessage);
            }
        }

    }
}
