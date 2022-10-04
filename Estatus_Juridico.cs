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
            Console.WriteLine(comboLawyer.SelectedIndex.ToString());
            int lawindex = comboLawyer.SelectedIndex;   
            EstatusJuridico_Controller ejc = new EstatusJuridico_Controller();
            dataGridProcesos.DataSource = ejc.procesList(list[lawindex].Item1);
        }
    }
}
