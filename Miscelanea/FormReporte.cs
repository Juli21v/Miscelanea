using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Miscelanea
{
    public partial class FormReporte : Form
    {
        public string doc;
        public FormReporte(string doc)
        {
            InitializeComponent();
            this.doc = doc;
        }
        Clases.Reporte objetoreporte = new Clases.Reporte();
        void listarReporte() {
            dataGridView1.DataSource = objetoreporte.Listaventa(doc).Tables[0];
        }
        private void FormReporte_Load(object sender, EventArgs e)
        {
            listarReporte();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            DataSet dt = objetoreporte.Listaventa(doc);
            if(dt.Tables[0].Rows.Count > 0)
            {
                CReporte objetoimprimir = new CReporte();
                objetoimprimir.SetDataSource(dt.Tables[0]);

                FormImprimir imp = new FormImprimir();
                imp.crystalReportViewer1.ReportSource = objetoimprimir;

                imp.Show();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
