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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //Instanciamos el form3 para mostrarlo en pantalla
            Form3 f = new Form3();
            f.Show();
            this.Hide();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            //Instanciamos el form modificarU para mostrarlo en pantalla
            ModificarU m = new ModificarU();
            m.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Instanciamos el form IngresarP para mostrarlo en pantalla
            IngresarP i = new IngresarP();
            i.Show();
            this.Hide();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
