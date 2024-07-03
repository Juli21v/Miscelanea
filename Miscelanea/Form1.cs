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
    public partial class Form1 : Form
    {
        public Form1()
        {
            //Proyecto Samir Quintero y Julián Vargas
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Comando para inicializar el Form3
            Form3 f = new Form3();
            //Comando para decirle al form 3 que se muestre en pantalla
            f.Show();
            //Comando para ocultar el Form actual
            this.Hide();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            //Comando para inicializar el Form2
            Form2 f = new Form2();
            //Comando para decirle al form 2 que se muestre en pantalla
            f.Show();
            //Comando para decirle al form actual que se oculte
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
