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
    public partial class Form4 : Form
    {
        //Se declara una variable de tipo string
        public String doc;
        public Form4(string doc)
        {
            InitializeComponent();
            //Se inicializa la clase CProductos, y se pone en marcha el método
            //mostrarPoductos donde se envia como parámetro el datagridView
            Clases.CProductos med = new Clases.CProductos();
            med.mostrarProductos(misce);
            //El valor de la variable doc será la que se envió desde archivos 
            //anteriores
            this.doc = doc;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Se declara una variable entera que toma el valor del textbox 4
            int costo = Convert.ToInt32(T4.Text);
            //Se declara una variable entera que toma el valor del textbox 7
            int cantidad = Convert.ToInt32(T7.Text);
            //Se declara una variable entera que toma el valor de la suma de costo y cantidad
            int total = costo * cantidad;
            //Se declara una variable de tipo dateTime que corresponderá a la fecha 
            //actual del computador o de la acción realizada
            var fecha = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss");
            //Volver el texto del textbox 6 en formato...
            T6.Text = Convert.ToString("$" + total);
            //instanciamos la clase Cventas y el método de guardarVentas
            //y luego el método GenerarFactura donde se toman como parámetros
            //los textbox y variables.
            Clases.Cventas venta = new Clases.Cventas();
            venta.guardarVentas(doc, T5, T7, fecha, total);
            venta.GenerarFactura(doc, T1, T4, T6, T7, fecha, total);
        }

        private void misce_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //Instanciamos el form3 para poderlo mostrar en pantalla
            Form3 f = new Form3();
            f.Show();
            this.Hide();
        }

        private void misce_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Al hacer doble click en una celda del datagridview, podremos
            //traer los datos a los textbox
            Clases.CProductos med = new Clases.CProductos();
            med.SeleccionarProductos(misce, T1, T4, T5);
        }

        private void misce_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //Al hacer doble click en una celda del datagridview, podremos
            //traer los datos a los textbox
            Clases.CProductos med = new Clases.CProductos();
            med.SeleccionarProductos(misce, T1, T4, T5);
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            //Instanciamos el form3 para mostrarlo en pantalla
            Form3 f = new Form3();
            f.Show();
            this.Hide();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Instanciamos el form6 para mostrarlo en pantalla
            Form6 f = new Form6(doc);
            f.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormReporte rep = new FormReporte(doc);
            rep.Show();
            this.Hide();
        }
    }
}
