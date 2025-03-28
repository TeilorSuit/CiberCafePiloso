using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Caja
{
    public class CajaListing
    {
        public int IdCaja { get; set; }
        public DateTime FechaApertura { get; set; }
        public decimal MontoApertura { get; set; }
        public DateTime? FechaCierre { get; set; }
        public decimal? MontoCierre { get; set; }
        public int IdUsuarioApertura { get; set; }
        public int? IdUsuarioCierre { get; set; }
        public bool Estado { get; set; }
        public decimal TotalIngresos { get; set; }
        public decimal TotalGastos { get; set; }
        public string Notas { get; set; }
        // Se eliminó la propiedad PcIp, ya que no existe en la tabla Caja.
    }
}
