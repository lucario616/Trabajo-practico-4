using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Vuelo   // Clase vuelo 
{
    public string RazonSocial { get; set; }
    public string Telefono { get; set; }
    public string Domicilio { get; set; }
    public string Codigo { get; set; }
    public DateTime FechaHoraSalida { get; set; }
    public DateTime FechaHoraLlegada { get; set; }
    public string Piloto { get; set; }
    public string Copiloto { get; set; }
    public int Capacidad { get; set; }
    public int Pasajeros { get; set; }
    public double PorcentajeOcupacion => (double)Pasajeros / Capacidad * 100;
}
