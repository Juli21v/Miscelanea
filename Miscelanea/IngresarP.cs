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
    public partial class IngresarP : Form
    {
        public IngresarP()
        {
            InitializeComponent();
            //Se inicializa la clase CProductos donde se llama el método mostrarProductos
            //que se envia como parámetro el datagridview
            Clases.CProductos med = new Clases.CProductos();
            med.mostrarProductos(misce);
        }

        private void IngresarP_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //al oprimir el botón se inicializa los metodos de la clase Cproductos
            //donde se requieren los textbox y el datagridview
            Clases.CProductos med = new Clases.CProductos();
            med.guardarProductos(T1, T4);
            med.mostrarProductos(misce);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //al oprimir el botón se inicializa los metodos de la clase Cproductos
            //donde se requieren los textbox y el datagridview
            Clases.CProductos med = new Clases.CProductos();
            med.ModificarProductos(T1, T4, T5);
            med.mostrarProductos(misce);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //al oprimir el botón se inicializa los metodos de la clase Cproductos
            //donde se requieren el textbox y el datagridview
            Clases.CProductos med = new Clases.CProductos();
            med.eliminarProductos(T5);
            med.mostrarProductos(misce);
        }

        private void misce_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Al dar doble click en cualquier celda del datagridview
            //Se inicializa el metodo seleccionarProductos de Cproductos
            //donde los parámetros corresponden a los textbox y el datagridview
            Clases.CProductos med = new Clases.CProductos();
            med.SeleccionarProductos(misce, T1, T4, T5);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Al oprimir este botón el valor del textbox 5 corresponde a un espacio vacio
            T5.Text = "";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // Se inicializa el form5 para mostrar en pantalla
            Form5 f = new Form5();
            f.Show();
            this.Hide();
        }
    }
}
