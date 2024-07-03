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
    internal class CProductos
    {
        //Método que guarda los productos en la tabla productos d ela base de datos
        public void guardarProductos(TextBox T1, TextBox T4)
        {
            try
            {
                //Se inicializa la clase CConexion y se realiza el query que se implica
                //en la variable query y si se realiza adecuadamente entonces se arroja un mensaje
                //donde se confirma que registraron los datos
                CConexion objetoConexion = new CConexion();
                String query = "insert into productos(Nom_prod," +
                    "costo) values('" + T1.Text + "','" + T4.Text + "')";
                MySqlCommand myCommand = new MySqlCommand(query, objetoConexion.establecerConexion());
                MySqlDataReader reader = myCommand.ExecuteReader();
                MessageBox.Show("Se registró el producto");
                while (reader.Read())
                {

                }
                objetoConexion.Cerrar_conexion();
            }
            catch (Exception ex)
            {
                //Si no se logra el proceso se envia el siguiente mensaje: 
                MessageBox.Show("No se guardó el producto, error: " + ex);
            }
        }
        //Método que muestra los productos cuando se llama y los refleja en el datagridview enviado
        public void mostrarProductos(DataGridView tablapropie)
        {
            try
            {
                CConexion objetoConexion = new CConexion();
                string query2 = "select * from productos";
                tablapropie.DataSource = null;
                MySqlDataAdapter adapter = new MySqlDataAdapter(query2, objetoConexion.establecerConexion());
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                tablapropie.DataSource = dt;
                objetoConexion.Cerrar_conexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se mostraron los productos de la base de datos, error: " + ex.ToString());
            }
        }
        //Método que reemplaza el valor de los textbox enviados como parámetros y que se muestran en el datagridview
        public void SeleccionarProductos(DataGridView TablaUsuarios, TextBox T1, TextBox T4, TextBox T5)
        {
            try
            {
                T1.Text = TablaUsuarios.CurrentRow.Cells[1].Value.ToString();
                T4.Text = TablaUsuarios.CurrentRow.Cells[2].Value.ToString();
                T5.Text = TablaUsuarios.CurrentRow.Cells[0].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se Logró seleccionar los Productos, error: " + ex);
            }
        }
        //Método que modifica los productos de la base de datos por los valores dados en los 
        //textbox que se envian como parámetro
        public void ModificarProductos(TextBox T1, TextBox T4, TextBox T5)
        {
            try
            {
                CConexion objetoConexion = new CConexion();
                String query = "update productos set Nom_prod='" + T1.Text + "', " +
                    "Costo='" + T4.Text + "' where Cod_producto='" + T5.Text + "'";
                MySqlCommand myCommand = new MySqlCommand(query, objetoConexion.establecerConexion());
                MySqlDataReader reader = myCommand.ExecuteReader();
                MessageBox.Show("Se modificaron los Productos");
                while (reader.Read())
                {

                }
                objetoConexion.Cerrar_conexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se actualizaron los productos, error: " + ex);
            }
        }
        //Método que elimina los productos dependiendo del dato traido en el textbox
        //y realiza el query poniendo el dato como condición
        public void eliminarProductos(TextBox T5)
        {
            try
            {
                CConexion objetoConexion = new CConexion();
                String query = "delete from productos where Cod_producto ='" + T5.Text + "'";
                MySqlCommand myCommand = new MySqlCommand(query, objetoConexion.establecerConexion());
                MySqlDataReader reader = myCommand.ExecuteReader();
                MessageBox.Show("Se eliminó el producto");
                while (reader.Read())
                {

                }
                objetoConexion.Cerrar_conexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se eliminó el producto, error: " + ex);
            }
        }
    }
}
