using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modulos
{
    public partial class ActualizarOficial : Form
    {
        public ActualizarOficial()
        {
            InitializeComponent();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Clases.ActualizarOficial_Controller aoc = new Clases.ActualizarOficial_Controller();

            aoc.actualizar(rtbContratos.Text, tbOficialId.Text);
        }
    }
}
