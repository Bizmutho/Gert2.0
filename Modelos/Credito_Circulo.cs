using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modulos.Modelos
{
    public class Credito_Circulo
    {
        public String cuentaActual { get; set; } = "";
        public String paterno { get; set; } = "";
        public String materno { get; set; } = "";
        public String nombre { get; set; } = "";
        public String fechaNac { get; set; } = "";
        public String RFC { get; set; } = "";
        public int estadoCivil { get; set; }
        public int sexo { get; set; }
        public String direccion { get; set; } = "";
        public String colonia { get; set; } = "";
        public String localidad { get; set; } = "";
        public String ciudad { get; set; } = "";
        public String CP { get; set; } = "";
        public int pagos { get; set; }
        public String monto { get; set; } = "";
        public DateTime apertura { get; set; }
        public DateTime cierre { get; set; }
        public float capital { get; set; }
        public float pagoNormal { get; set; }
        public float saldoActual { get; set; }
        public float vencido { get; set; }
        public float insoluto { get; set; }
        public int pagoActual { get; set; }
        public DateTime fechaUltimoPago { get; set; }
        public float montoUltimoPago { get; set; }
    }
}
