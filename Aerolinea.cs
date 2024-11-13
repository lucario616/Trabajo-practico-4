using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

public class Aerolinea   // Clase aerolínea para la gestión de los vuelos
{
    public List<Vuelo> Vuelos { get; set; } = new List<Vuelo>();
    public void AgregarVuelo()   // Función para agregar un vuelo al sistema
    {
        Vuelo nuevoVuelo = new Vuelo();
        Console.Write("Código de vuelo: ");
        nuevoVuelo.Codigo = Console.ReadLine();
        Console.Write("Fecha y hora de salida (YYYY-MM-DD HH:MM): ");
        nuevoVuelo.FechaHoraSalida = DateTime.Parse(Console.ReadLine());
        while (nuevoVuelo.FechaHoraSalida <= DateTime.Now)   // Ciclo que corrobora que la fecha ingresada sea mayor a la actual
        {
            Console.Write("La fecha y hora no son válidas. Inténtelo de nuevo: ");
            nuevoVuelo.FechaHoraSalida = DateTime.Parse(Console.ReadLine());
        }
        Console.Write("Fecha y hora de llegada (YYYY-MM-DD HH:MM): ");
        nuevoVuelo.FechaHoraLlegada = DateTime.Parse(Console.ReadLine());
        while (nuevoVuelo.FechaHoraLlegada <= nuevoVuelo.FechaHoraSalida)   // Ciclo que corrobora que la fecha ingresada sea mayor a la de salida
        {
            Console.Write("La fecha y hora no son válidas. Inténtelo de nuevo: ");
            nuevoVuelo.FechaHoraLlegada = DateTime.Parse(Console.ReadLine());
        }
        Console.Write("Nombre del piloto: ");
        nuevoVuelo.Piloto = Console.ReadLine();
        Console.Write("Nombre del copiloto: ");
        nuevoVuelo.Copiloto = Console.ReadLine();
        Console.Write("Capacidad máxima: ");
        nuevoVuelo.Capacidad = int.Parse(Console.ReadLine());
        Console.Write("Teléfono: ");
        nuevoVuelo.Telefono = Console.ReadLine();
        Console.Write("Razón social: ");
        nuevoVuelo.RazonSocial = Console.ReadLine();
        Console.Write("Domicilio: ");
        nuevoVuelo.Domicilio = Console.ReadLine();
        Vuelos.Add(nuevoVuelo);
        Console.WriteLine("\nVuelo agregado con éxito.");
    }
    public void RegistrarPasajeros()   // Función para registrar a los pasajeros de un vuelo
    {
        Console.Write("Código del vuelo: ");
        string codigoIngresado = Console.ReadLine();
        Vuelo vuelo = null;
        foreach (var v in Vuelos)   // Ciclo que corrobora si el código ingresado es válido
        {
            if (v.Codigo == codigoIngresado)
            {
                vuelo = v;
                break;
            }
        }
        if (vuelo != null)
        {
            Console.Write($"Capacidad del vuelo: {vuelo.Capacidad}. Ingrese el número de pasajeros: ");
            int pasajeros = int.Parse(Console.ReadLine());
            while (pasajeros > vuelo.Capacidad)
            {
                Console.Write("La cantidad de pasajeros excede la capacidad. Inténtelo de nuevo: ");
                pasajeros = int.Parse(Console.ReadLine());
            }
            vuelo.Pasajeros = pasajeros;
            Console.WriteLine("Pasajeros registrados con éxito.");
        }
        else
        {
            Console.WriteLine("Código de vuelo no encontrado.");
        }
    }
    public void CalcularOcupacionMedia()   //   Función para calcular la ocupación media de la flota
    {
        if (Vuelos.Count == 0)
        {
            Console.WriteLine("No hay vuelos registrados.");
            return;
        }
        double ocupacionTotal = 0;
        foreach (var vuelo in Vuelos)
        {
            ocupacionTotal += vuelo.PorcentajeOcupacion;
        }
        double ocupacionMedia = ocupacionTotal / Vuelos.Count;
        Console.WriteLine($"Ocupación media de la flota: {ocupacionMedia:F2}%");
    }
    public void VueloConMayorOcupacion()   // Función que devuelve el vuelo con mayor porcentaje de ocupación
    {
        if (Vuelos.Count == 0)
        {
            Console.WriteLine("No hay vuelos registrados.");
            return;
        }
        Vuelo vueloMayorOcupacion = Vuelos[0];
        foreach (var vuelo in Vuelos)
        {
            if (vuelo.PorcentajeOcupacion > vueloMayorOcupacion.PorcentajeOcupacion)
            {
                vueloMayorOcupacion = vuelo;
            }
        }
        Console.WriteLine($"Vuelo con mayor ocupación: {vueloMayorOcupacion.Codigo} - {vueloMayorOcupacion.PorcentajeOcupacion:F2}%");
    }
    public void BuscarVueloPorCodigo()   // Función que permite buscar un vuelo por su código y mostrar sus datos
    {
        Console.Write("Ingrese el código del vuelo: ");
        string codigo = Console.ReadLine();
        Vuelo vuelo = null;
        foreach (var v in Vuelos)
        {
            if (v.Codigo == codigo)
            {
                vuelo = v;
                break;
            }
        }
        if (vuelo != null)
        {
            Console.WriteLine($"\nCódigo: {vuelo.Codigo}, Ocupación: {vuelo.PorcentajeOcupacion:F2}%, Salida: {vuelo.FechaHoraSalida}, Llegada: {vuelo.FechaHoraLlegada}");
            Console.WriteLine($"Piloto: {vuelo.Piloto}, Copiloto: {vuelo.Copiloto}, Capacidad: {vuelo.Capacidad}, Pasajeros: {vuelo.Pasajeros}");
            Console.WriteLine($"Teléfono: {vuelo.Telefono}, Razón Social: {vuelo.RazonSocial}, Domicilio: {vuelo.Domicilio}");
        }
        else
        {
            Console.WriteLine("Vuelo no encontrado.");
        }
    }
    public void ListarVuelosPorOcupacion()  // Funcion que muestra los datos de todos los vuelos ordenados por su porcentaje de ocupación
    {
        List<Vuelo> vuelosOrdenados = new List<Vuelo>(Vuelos);
        for (int i = 0; i < vuelosOrdenados.Count - 1; i++)
        {
            for (int j = i + 1; j < vuelosOrdenados.Count; j++)
            {
                if (vuelosOrdenados[i].PorcentajeOcupacion < vuelosOrdenados[j].PorcentajeOcupacion)
                {
                    var temp = vuelosOrdenados[i];
                    vuelosOrdenados[i] = vuelosOrdenados[j];
                    vuelosOrdenados[j] = temp;
                }
            }
        }
        Console.WriteLine("Vuelos ordenados por su porcentaje de ocupación:");
        foreach (Vuelo vuelo in vuelosOrdenados)
        {
            Console.WriteLine($"\nCódigo: {vuelo.Codigo}, Ocupación: {vuelo.PorcentajeOcupacion:F2}%, Salida: {vuelo.FechaHoraSalida}, Llegada: {vuelo.FechaHoraLlegada}");
            Console.WriteLine($"Piloto: {vuelo.Piloto}, Copiloto: {vuelo.Copiloto}, Capacidad: {vuelo.Capacidad}, Pasajeros: {vuelo.Pasajeros}");
            Console.WriteLine($"Teléfono: {vuelo.Telefono}, Razón Social: {vuelo.RazonSocial}, Domicilio: {vuelo.Domicilio}");
        }
    }
    public void GuardarDatos()   // Función para guardar los datos registrados en el sistema
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Vuelo>));
        using (FileStream fs = new FileStream("vuelos.xml", FileMode.Create))
        {
            serializer.Serialize(fs, Vuelos);
        }
        Console.WriteLine("Datos guardados correctamente.");
    }
    public void CargarDatos()   // Función que carga los datos anteriormente guardados
    {
        if (File.Exists("vuelos.xml"))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Vuelo>));
            using (FileStream fs = new FileStream("vuelos.xml", FileMode.Open))
            {
                Vuelos = (List<Vuelo>)serializer.Deserialize(fs);
            }
            Console.WriteLine("Datos cargados correctamente.");
        }
        else
        {
            Console.WriteLine("No hay datos guardados para cargar.");
        }
    }
}
