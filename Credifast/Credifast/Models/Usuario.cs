using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Credifast.Models
{
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Gmail { get; set; }
        public string NumeroTelefono { get; set; }
        public string Domicilio { get; set; }
        public float Cantidad_prestada { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Final { get; set; }
        public float Interes { get; set; }
        public float PagoAlMes { get; set; }
        

    }
}