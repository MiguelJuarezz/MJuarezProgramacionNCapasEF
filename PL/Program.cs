using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("=======Ingresa EL Numero De La Accion A Realizar=========");
            Console.WriteLine("                 1. Ingresar Usuario");
            Console.WriteLine("                 2. Eliminar Usuario");
            Console.WriteLine("           3. Actualizar Usuario (Telefono y Email)");
            Console.WriteLine("           4. Consultar Usuarios");
            Console.WriteLine("           5. Consultar Usuarios Por Su ID");

            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    PL.Usuario.Add();
                    Console.ReadKey();
                    break;
                case 2:
                    PL.Aseguradora.Delete();
                    Console.ReadKey();
                    break;
                case 3:
                    PL.Usuario.Update();
                    Console.ReadKey();
                    break;
                case 4:
                    PL.Aseguradora.GetAll();
                    Console.ReadKey();  
                    break;
                case 5:
                    PL.Aseguradora.GetById();
                    Console.ReadKey();
                    break;
                default:
                    Console.Write("Se ingreso un valor fuera de rango");
                    break;
            }


        }
    }
}
