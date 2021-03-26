using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XYZ.Domain;

namespace XYZ.Models
{
    public class TemporadaViewModel
    {
        public Guid Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public string Tipo { get; set; }
        public IEnumerable<Temporada> ListTemporadas { get; set; }
    }
}
