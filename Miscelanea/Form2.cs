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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Condicional para comparar las contraseñas y que correspondan a la misma
            if (T6.Text == T7.Text)
            {
                //Se inicializa la clase Cregistro para obtener sus métodos
                Clases.CRegistro registro = new Clases.CRegistro();
                //Se declara una variable rol de tipo entera
                int rol;
                //Swicth que compara las opciones del checklistbox
                switch (check.SelectedItem)
                {
                    //Si la opcion "Administrador se escoge entonces..."
                    case "Administrador":
                        //Rol toma el valor de 1 y se pone en marcha el metodo GuardarUsuarios
                        rol = 1;
                        registro.guardarUsuarios(combo, T1, T2, T3, T4, T5, T6, T7, rol);
                        break;
                    case "Cliente":
                        //Rol toma el valor de 2 y se pone en marcha el metodo GuardarUsuarios
                        rol = 2;
                        registro.guardarUsuarios(combo, T1, T2, T3, T4, T5, T6, T7, rol);
                        break;
                }

            }
            //Si las contraseñas no coinciden entonces arroja el siguiente mensaje...
            else
            {
                MessageBox.Show("Las contraseñas no coinciden, intentelo de nuevo");
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //Lineas de código que inicializan el Form1 y lo muestran en pantalla
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void T7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void T6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void check_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void combo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void T5_TextChanged(object sender, EventArgs e)
        {

        }

        private void T4_TextChanged(object sender, EventArgs e)
        {

        }

        private void T3_TextChanged(object sender, EventArgs e)
        {

        }

        private void T2_TextChanged(object sender, EventArgs e)
        {

        }

        private void T1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
