using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Aseguradora
    {

        public static void Add()
        {
            //instancia de un objeto
            ML.Aseguradora aseguradora = new ML.Aseguradora();

            Console.WriteLine("Inserte El Nombre De La Aseguradora");
            aseguradora.Nombre = Console.ReadLine();

            //Console.WriteLine("Inserte El IdRol Del Usuario");
            //usuario.IdRol = int.Parse(Console.ReadLine());

            aseguradora.Usuario = new ML.Usuario();
            Console.WriteLine("Inserte El Id De Usuario De La Aseguradora");
            aseguradora.Usuario.IdUsuario = int.Parse(Console.ReadLine());

            ML.Result result = new ML.Result();
            //mandar la información al BL 
            result = BL.Aseguradora.AddEFLINQ(aseguradora);

            if (result.Correct == true)
            {
                Console.WriteLine("La Aseguradora se registro correctamente");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("La Aseguradora no se registro" + result.ErrorMessage);
                Console.ReadKey();
            }
        }

        public static void Delete()
        {
            //instancia de un objeto
            ML.Aseguradora aseguradora = new ML.Aseguradora();

            Console.WriteLine("Inserte El Id De La Aseguradora");
            aseguradora.IdAseguradora = int.Parse(Console.ReadLine());

            ML.Result result = new ML.Result();
            //mandar la información al BL 
            result = BL.Aseguradora.DeleteEFLINQ(aseguradora);

            if (result.Correct == true)
            {
                Console.WriteLine("La Aseguradora se Elimino correctamente");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("La Aseguradora no se Elimino " + result.ErrorMessage);
                Console.ReadKey();
            }


        }

        public static void Update()
        {
            //instancia de un objeto
            ML.Aseguradora aseguradora = new ML.Aseguradora();

            Console.WriteLine("Inserte El Id De La Aseguradora Que Quiere Actualizar");
            aseguradora.IdAseguradora = int.Parse(Console.ReadLine());

            Console.WriteLine("Inserte El Nombre De La Aseguradora");
            aseguradora.Nombre = Console.ReadLine();

            aseguradora.Usuario = new ML.Usuario();
            Console.WriteLine("Inserte El Nuevo Id Usuario De La Aseguradora");
            aseguradora.Usuario.IdUsuario = int.Parse(Console.ReadLine());

            ML.Result result = new ML.Result();
            //mandar la información al BL 
            result = BL.Aseguradora.UpdateEFLINQ(aseguradora);

            if (result.Correct == true)
            {
                Console.WriteLine("La Aseguradora se actualizo correctamente");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("La Aseguradora no se actualizo" + result.ErrorMessage);
                Console.ReadKey();
            }
        }

        public static void GetAll()
        {
            ML.Result result = BL.Aseguradora.GetAllEFLINQ();

            if (result.Correct)
            {
                foreach (ML.Aseguradora aseguradora in result.Objects)
                {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("El id la aseguradora es:" + aseguradora.IdAseguradora);
                    Console.WriteLine("El nombre de la aseguradora es:" + aseguradora.Nombre);
                    Console.WriteLine("La fecha de creacion de la aseguradora es:" + aseguradora.FechaCreacion);
                    Console.WriteLine("La fecha de modificacion de la aseguradora es:" + aseguradora.FechaModificacion);
                    Console.WriteLine("El Id Usuario De la aseguradora es:" + aseguradora.Usuario.IdUsuario);
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
            Console.WriteLine("Ingrese el id de la aseguradora que desea consultar");
            int idAseguradora = int.Parse(Console.ReadLine());

            ML.Result result = new ML.Result();
            result = BL.Aseguradora.GetByIdEFLINQ(idAseguradora);

            if (result.Correct)
            {
                ML.Aseguradora aseguradora = new ML.Aseguradora();

                //unboxing
                aseguradora = (ML.Aseguradora)result.Object;

                Console.WriteLine("-----------------------------------");
                Console.WriteLine("El id la aseguradora es:" + aseguradora.IdAseguradora);
                Console.WriteLine("El nombre de la aseguradora es:" + aseguradora.Nombre);
                Console.WriteLine("La fecha de creacion de la aseguradora es:" + aseguradora.FechaCreacion);
                Console.WriteLine("La fecha de modificacion de la aseguradora es:" + aseguradora.FechaModificacion);
                Console.WriteLine("El Id Usuario De la aseguradora es:" + aseguradora.Usuario.IdUsuario);
                Console.WriteLine("-----------------------------------");
            }
            else
            {
                Console.WriteLine("Ocurrio un error " + result.ErrorMessage);
            }
        }


    }
}
