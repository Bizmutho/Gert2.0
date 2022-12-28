using Modulos.Clases;
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
    public partial class Estatus_Juridico : Form
    {
        EstatusJuridico_Controller est = new EstatusJuridico_Controller();
        List<(int, string)> list = new List<(int, string)> ();

        public Estatus_Juridico()
        {
            InitializeComponent();
            list = est.LawyerList(); 
            for(int i = 0; i < list.Count; i++)
            {
                comboLawyer.Items.Add (list[i].Item2);
            
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine(comboLawyer.SelectedIndex+1);
            int lawindex = comboLawyer.SelectedIndex+1;   
            EstatusJuridico_Controller ejc = new EstatusJuridico_Controller();
            adgvJuridico.DataSource = ejc.procesList(lawindex);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProcesoJuridico pr = new ProcesoJuridico(1);
            pr.NoContrato.Text = adgvJuridico.CurrentRow.Cells["CREDITO"].Value.ToString();
            string fecha = adgvJuridico.CurrentRow.Cells["FECHA OFICIO"].Value.ToString();
            DateTime auxDate = DateTime.Parse(fecha);
            pr.fechaOficio.Value = auxDate;
            pr.totalDemanda.Text = adgvJuridico.CurrentRow.Cells["TOTAL DEMANDA"].Value.ToString();
            pr.listAbogado.Enabled = false;
            string status = adgvJuridico.CurrentRow.Cells["ESTATUS"].Value.ToString();
            string obs = adgvJuridico.CurrentRow.Cells["OBSERVACIONES"].Value.ToString();
            pr.listStatus.SelectedItem = status;
            pr.txtObsBox.Text = obs;
            pr.Visible = true;
            
        }

        private void adgvJuridico_FilterStringChanged(object sender, EventArgs e)
        {
            ((DataView)adgvJuridico.DataSource).RowFilter = adgvJuridico.FilterString;
        }


        private void adgvJuridico_SortStringChanged_1(object sender, EventArgs e)
        {
            ((DataView)adgvJuridico.DataSource).Sort = adgvJuridico.SortString;
        }
    }
}
