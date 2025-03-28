using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Caja
{
    public class CajaChart
    {
        public DateTime Dia { get; set; }
        public decimal SumaIngresos { get; set; }
        public decimal SumaGastos { get; set; }
    }
}
