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
    public partial class Autorizar : Form
    {
        public Autorizar()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
        public Boolean validar()
        {
            this.Show();
            return false;
        }

        private void tbCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tbCodigo.Text.Equals("92514638"))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                } else
                {
                    this.DialogResult = DialogResult.No;
                    this.Close();
                }
            } else if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }
}
