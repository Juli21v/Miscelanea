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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Se inicializa la clase Cregistro
            Clases.CRegistro registro = new Clases.CRegistro();
            //Se llama al metodo inicio de sesion donde se envian los valores de
            //los textbox
            registro.IniciodeSesion(T1, T2);
            //Al terminar el proceso, cierra el form actual
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //Linea de código que inicializa el form 1 y lo muestra en pantalla
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
