using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.IO;

class Program   // Programa
{
    static Aerolinea aerolinea = new Aerolinea();
    static void Main()
    {
        aerolinea.CargarDatos();
        string opcion;
        do
        {
            Console.Clear();
            Console.WriteLine("==========Menú del sistema==========");
            Console.WriteLine("\n1. Agregar vuelo");
            Console.WriteLine("2. Registrar pasajeros");
            Console.WriteLine("3. Calcular ocupación media");
            Console.WriteLine("4. Vuelo con mayor porcentaje de ocupación");
            Console.WriteLine("5. Buscar vuelo por código");
            Console.WriteLine("6. Listar vuelos por ocupación");
            Console.WriteLine("7. Guardar y salir");
            Console.Write("\nSeleccione una opción: ");
            opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":
                    aerolinea.AgregarVuelo();
                    break;
                case "2":
                    aerolinea.RegistrarPasajeros();
                    break;
                case "3":
                    aerolinea.CalcularOcupacionMedia();
                    break;
                case "4":
                    aerolinea.VueloConMayorOcupacion();
                    break;
                case "5":
                    aerolinea.BuscarVueloPorCodigo();
                    break;
                case "6":
                    aerolinea.ListarVuelosPorOcupacion();
                    break;
                case "7":
                    aerolinea.GuardarDatos();
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
            Console.WriteLine("\nPresione ENTER para continuar...");
            Console.ReadLine();
        } while (opcion != "7");   // Ciclo que muestra el menú principal constantemente para la comodidad del usuario
    }
}

