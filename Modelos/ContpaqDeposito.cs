using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modulos.Modelos
{
    public class ContpaqDeposito
    {
        public DateTime diaDeposito { get; set; }
        public int idPrestamo { get; set; }
        public String codigoBanco { get; set; }
        public String movimiento { get; set; }
        public Double cargo { get; set; } = 0;
        public Double abonoCapital { get; set; } = 0;
        public Double abonoIntereses { get; set; } = 0;
        public Double abonoIVA { get; set; } = 0;
        public Double abonoMora { get; set; } = 0;
        public int referencia { get; set; } = 0;
        public String socio { get; set; }
        public String banco { get; set; }
        public String oficial { get; set; }
    }
}
