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
    public partial class ModificarU : Form
    {
        public ModificarU()
        {
            InitializeComponent();
            //Se inicializa el método mostrarUsuarios2 de Cregistro en el constructor
            //y mostrarusuarios donde en ambos casos se envia un datagridview distinto y una variable
            Clases.CRegistro reg = new Clases.CRegistro();
            reg.mostrarUsuarios2(dataGridView1);
            Clases.Cventas ven = new Clases.Cventas();
            ven.mostrarUsuarios(dataGridView2, T1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Al oprimir el botón se procede a...
            //se comparan los valores del textbox 2 y 3 y si son iguales entonces...
            if (T2.Text == T3.Text)
            {
                //Se inicializa el metodo modificarusuarios donde se envian los datos
                //de los textbox y además se realiza el método mostrarUsuarios2 donde se
                //envia el datagridview
                Clases.CRegistro mos = new Clases.CRegistro();
                mos.ModificarUsuarios(T1, T2, T3, T4, T5, T6, T7, T8, T9);
                mos.mostrarUsuarios2(dataGridView1);
            }
            else
            {
                //Si no se cumpla la condición entonces se envia el siguiente mensaje
                MessageBox.Show("Las contraseñas no coinciden, intentelo de nuevo");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //al oprimir el botón se inicializa la clase CRegistro donde se llama
            //el método eliminarUsuarios donde se envia el valor del textbox 1
            //además se muestra en el datagridview1 lo que se arroje del método
            //mostrarUsuarios2
            Clases.CRegistro mos = new Clases.CRegistro();
            mos.eliminarUsuarios(T1);
            mos.mostrarUsuarios2(dataGridView1);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Al dar doble click se inicializa el método seleccionarUsuarios
            //Donde se enviaron los datos de los textbox del form y posteriormente
            //se inicializa el método mostrarUsuarios y se envian el datagridview y el textbox 1
            Clases.CRegistro grid = new Clases.CRegistro();
            grid.SeleccionarUsuarios(dataGridView1, T1, T2, T3, T4, T5, T6, T7, T8, T9);
            Clases.Cventas ven = new Clases.Cventas();
            ven.mostrarUsuarios(dataGridView2, T1);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //Se inicializa el form5 y se muestra en pantalla
            Form5 f = new Form5();
            f.Show();
            this.Hide();
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Al dar doble click se inicializa el método seleccionarVentas donde
            //se envian el datagridview y el textbox TE
            Clases.Cventas ven = new Clases.Cventas();
            ven.SeleccionarVentas(dataGridView2, TE);
        }

        private void ModificarU_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Se inicializa el método eliminarVenta y se envia el valor del textbox TE
            //y adémas se realiza el método mostrarUsuarios donde se envian el datagridview
            //y el textbox 1
            Clases.Cventas el = new Clases.Cventas();
            el.eliminarventa(TE);
            el.mostrarUsuarios(dataGridView2,T1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
