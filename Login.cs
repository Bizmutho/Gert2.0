using Moratorios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modulos
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            txbContra.PasswordChar = '*';

            if (Properties.Settings.Default.recordar)
            {
                cbRecordar.Checked = true;
                txbUsuario.Text = Properties.Settings.Default.nUsuario;
                txbContra.Select();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clases.Login_Controller lo = new Clases.Login_Controller();
            int log = lo.iniciarSesion(txbUsuario.Text.ToUpper(), txbContra.Text.ToUpper());
            if (log == 1)
            {
                Properties.Settings.Default.recordar = cbRecordar.Checked;
                if (cbRecordar.Checked)
                {
                    Properties.Settings.Default.nUsuario = txbUsuario.Text;
                }
                Properties.Settings.Default.Save();
                Inicio ini = new Inicio();
                ini.Show();
                 
                this.Dispose();
            } else if (log == 2)
            {
                Console.WriteLine("Usuario incorrecto");
            }
            
            
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Clases.Login_Controller lo = new Clases.Login_Controller();
                int log = lo.iniciarSesion(txbUsuario.Text.ToUpper(), txbContra.Text.ToUpper());
                if (log == 1)
                {
                    Properties.Settings.Default.recordar = cbRecordar.Checked;
                    if (cbRecordar.Checked)
                    {
                        Properties.Settings.Default.nUsuario = txbUsuario.Text;
                    }
                    Properties.Settings.Default.Save();
                    Inicio ini = new Inicio();
                    ini.Show();
                    
                    this.Dispose();
                }
                else if (log == 2)
                {
                    Console.WriteLine("Usuario incorrecto");
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cbRecordar_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txbUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbContra_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
