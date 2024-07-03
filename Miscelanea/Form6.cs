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
    public partial class Form6 : Form
    {
        //Se declara una variable string y la asignamos como parámetro en el 
        //constructor
        public String doc;
        public Form6(string doc)
        {
            InitializeComponent();
            //Inicializamos la clase Cventas y el método mostrarventas
            //donde enviamos a dicho método el datagridview y la variable doc
            Clases.Cventas ven = new Clases.Cventas();
            ven.mostrarventa(misce, doc);
            //Inicializamos la clase Cconexion para poder asignarle al textbox 6
            //el valor del nombre y apellido que por busqueda son aquellos que corresponden
            //al documento traido en la variable
            Clases.CConexion c = new Clases.CConexion();
            T6.Text = Convert.ToString(c.Getnombre(doc)+" "+c.Getapellido(doc));
            //el valor traido del form anterior se le asigna a la variable doc
            this.doc = doc;
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Se inicializa la clase Cventas para llamar el método modificarVentas
            //Donde se envian los textbox mencionados y el método mostrarventa que necesita
            //la variable doc y el datagridview
            Clases.Cventas v = new Clases.Cventas();
            v.ModificarVenta(T1, T5, T7);
            v.mostrarventa(misce,doc);
        }

        private void misce_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Al dar doble click en cualquier celda del datagridview se usará el 
            //método seleccionarventas2 de Cventas donde se envian como parámetros
            //los textbox del form
            Clases.Cventas ven = new Clases.Cventas();
            ven.SeleccionarVentas2(misce,T5,T1,T7);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //Se inicializa el form4 y se muestra en pantalla
            Form4 f = new Form4(doc);
            f.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void T6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void misce_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
