using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Miscelanea.Clases
{
    internal class CRegistro
    {
        //Método que se encarga de guardar los datos del usuario estableciendo estos datos
        //como los valores dados por los textbox y el combobox
        public void guardarUsuarios(ComboBox combo, TextBox T1, TextBox T2, TextBox T3, TextBox T4, TextBox T5, TextBox T6, TextBox T7, int rol)
        {
            try
            {
                CConexion objetoConexion = new CConexion();
                String doc = objetoConexion.GetDoc(T1.Text);
                String contra = objetoConexion.GetContra(T6.Text);
                if (doc != T1.Text)
                {
                    if (contra != T6.Text)
                    {
                        String query = "insert into personas(CC,Tipo_documento," +
                           "Nombre,Apellido,Direccion,Telefono,rol,Contraseña) values('" + T1.Text + "','" + combo.Text + "',"
                            + "'" + T2.Text + "','" + T3.Text + "','" + T4.Text + "','" + T5.Text + "','" + rol + "','" + T6.Text + "')";
                        MySqlCommand myCommand = new MySqlCommand(query, objetoConexion.establecerConexion());
                        MySqlDataReader reader = myCommand.ExecuteReader();
                        MessageBox.Show("Se registrarón los datos");
                        while (reader.Read())
                        {

                        }
                        objetoConexion.Cerrar_conexion();
                        T1.Text = "";
                        T2.Text = "";
                        T3.Text = "";
                        T4.Text = "";
                        T5.Text = "";
                        T6.Text = "";
                        T7.Text = "";
                        combo.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("La contraseña ya fue utilizada, intentelo de nuevo");
                    }
                }
                else
                {
                    MessageBox.Show("El documento digitado ya se encuentra registrado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se guardaron los datos, error: " + ex);
            }
        }
        //Método que realiza una consulta para hacer la verificación de los datos
        //y si existen entonces permite pasar al siguiente form
        public void IniciodeSesion(TextBox T1, TextBox T2)
        {
            CConexion objetoConexion = new CConexion();
            String query = "select CC,Contraseña from `personas` where CC = '" + T1.Text + "' AND Contraseña = '" + T2.Text + "';";
            MySqlCommand myCommand = new MySqlCommand(query, objetoConexion.establecerConexion());
            MySqlDataReader reader = myCommand.ExecuteReader();
            //Mientras el query sea leido entonces...
            if (reader.Read())
            {
                //se le asigna a la varibale rol lo que se obtenga del metodo getrol
                int rol = objetoConexion.Getrol(T1.Text, T2.Text);
                switch (rol)
                {
                    //Si el rol es 1 entonces va al form 5 y envia el siguiente mensaje:
                    case 1:
                        MessageBox.Show("Bienvenido admin");
                        Form5 f = new Form5();
                        f.Show();
                        break;
                    //Si el rol es 2 entonces va al form 4, envia como parámetro el valor
                    //del textbox 1 y envia el siguiente mensaje:
                    case 2:
                        MessageBox.Show("Bienvenido cliente");
                        Form4 fr = new Form4(T1.Text);
                        fr.Show();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Datos incorrectos, intentelo de nuevo");
                Form3 ft = new Form3();
                ft.Show();
            }
            objetoConexion.Cerrar_conexion();
        }
        //Método que muestra los usuarios en el datagridview que se requiere como
        //parámetro y los organiza en forma de tabla
        public void mostrarUsuarios(DataGridView tablapropie)
        {
            try
            {
                CConexion objetoConexion = new CConexion();
                string query2 = "select * from personas ";
                tablapropie.DataSource = null;
                MySqlDataAdapter adapter = new MySqlDataAdapter(query2, objetoConexion.establecerConexion());
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                tablapropie.DataSource = dt;
                objetoConexion.Cerrar_conexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se mostraron los datos de la base de datos, error: " + ex.ToString());
            }
        }
        //Método que muestra los usuarios pero unicamente aquellos que su rol
        //corresponda a 2 sean clientes en la base de datos y los organiza en una
        //tabla
        public void mostrarUsuarios2(DataGridView tablapropie)
        {
            try
            {
                CConexion objetoConexion = new CConexion();
                string query2 = "select * from personas where rol= 2";
                tablapropie.DataSource = null;
                MySqlDataAdapter adapter = new MySqlDataAdapter(query2, objetoConexion.establecerConexion());
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                tablapropie.DataSource = dt;
                objetoConexion.Cerrar_conexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se mostraron los datos de la base de datos, error: " + ex.ToString());
            }
        }
        //Método que asigna en los textbox como texto los datos que se encuentran en el
        //datgridview
        public void SeleccionarUsuarios(DataGridView TablaUsuarios, TextBox T1, TextBox T2, TextBox T3, TextBox T4, TextBox T5, TextBox T6, TextBox T7, TextBox T8, TextBox T9)
        {
            try
            {
                T1.Text = TablaUsuarios.CurrentRow.Cells[0].Value.ToString();
                T2.Text = TablaUsuarios.CurrentRow.Cells[6].Value.ToString();
                T3.Text = TablaUsuarios.CurrentRow.Cells[6].Value.ToString();
                T4.Text = TablaUsuarios.CurrentRow.Cells[1].Value.ToString();
                T5.Text = TablaUsuarios.CurrentRow.Cells[2].Value.ToString();
                T6.Text = TablaUsuarios.CurrentRow.Cells[3].Value.ToString();
                T7.Text = TablaUsuarios.CurrentRow.Cells[5].Value.ToString();
                T8.Text = TablaUsuarios.CurrentRow.Cells[4].Value.ToString();
                T9.Text = TablaUsuarios.CurrentRow.Cells[7].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se Logró seleccionar los datos, error: " + ex);
            }
        }
        //Método que modifica los usuarios a partir del documento, a partir de los valores
        //de textbox y los reemplaza con estos
        public void ModificarUsuarios(TextBox T1, TextBox T2, TextBox T3, TextBox T4, TextBox T5, TextBox T6, TextBox T7, TextBox T8, TextBox T9)
        {
            try
            {
                CConexion objetoConexion = new CConexion();
                String query = "update personas set Tipo_documento='" + T4.Text + "', " +
                    "Nombre='" + T5.Text + "', Apellido='" + T6.Text + "', " +
                    "Direccion='" + T7.Text + "', Telefono='" + T8.Text + "', rol='" + T9.Text + "', " +
                    "contraseña='" + T2.Text + "' where CC='" + T1.Text + "'";
                MySqlCommand myCommand = new MySqlCommand(query, objetoConexion.establecerConexion());
                MySqlDataReader reader = myCommand.ExecuteReader();
                MessageBox.Show("Se modificaron los datos");
                while (reader.Read())
                {

                }
                objetoConexion.Cerrar_conexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se actualizaron los datos, error: " + ex);
            }
        }
        //método que elimina los usuarios a partir del documento de cada usuario
        //dado por el textbox requerido como parámetro
        public void eliminarUsuarios(TextBox T1)
        {
            try
            {
                CConexion objetoConexion = new CConexion();
                String query = "delete from personas where CC ='" + T1.Text + "'";
                MySqlCommand myCommand = new MySqlCommand(query, objetoConexion.establecerConexion());
                MySqlDataReader reader = myCommand.ExecuteReader();
                MessageBox.Show("Se eliminó el usuario");
                while (reader.Read())
                {

                }
                objetoConexion.Cerrar_conexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se eliminaron los datos, error: " + ex);
            }
        }
    }
}
