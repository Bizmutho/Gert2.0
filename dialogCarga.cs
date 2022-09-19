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
    public partial class dialogCarga : Form
    {
        public Action funcion { get; set; }

        public dialogCarga(string texto, Action f)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            lblTexto.Text = texto;

            if (f == null)
                throw new ArgumentNullException();

            funcion = f;
        }

        private void dialogCarga_Load(object sender, EventArgs e)
        {
            Task.Factory.StartNew(funcion).ContinueWith(t => { this.Close(); }, TaskScheduler.FromCurrentSynchronizationContext());

        }
    }
}
