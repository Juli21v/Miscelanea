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
    internal class Cventas
    {
        //Método que guarda los registros de las compras y sus datos dentro de la base de datos
        //con los textbox que se envian como parámetro
        public void guardarVentas(String doc, TextBox T5, TextBox T7, String fecha, int total)
        {
            try
            {
                CConexion objetoConexion = new CConexion();
                String query = "insert into venta(Cliente,Producto,Cantidad," +
                    "Fecha_venta,Total_pagar) values('" + doc + "',"
                     + "'" + T5.Text + "','" + T7.Text + "','" + fecha + "','" + total + "')";
                MySqlCommand myCommand = new MySqlCommand(query, objetoConexion.establecerConexion());
                MySqlDataReader reader = myCommand.ExecuteReader();
                MessageBox.Show("Factura hecha");
                while (reader.Read())
                {

                }
                objetoConexion.Cerrar_conexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se guardó la venta, error: " + ex);
            }
        }
        //Método que se encarga de traer los datos del usuario por medio de la clase CConexion
        //por medio de métodos de get que se asignan a variables y que luego se organizan en un 
        //mensaje a modo de factura
        public void GenerarFactura(String doc, TextBox T1, TextBox T4, TextBox T6, TextBox T7, String fecha, int total)
        {
            try
            {
                CConexion objetoConexion = new CConexion();
                String Tipo = objetoConexion.GetTipo(doc);
                String nombre = objetoConexion.Getnombre(doc);
                String apellido = objetoConexion.Getapellido(doc);
                String direccion = objetoConexion.Getdireccion(doc);
                String telefono = objetoConexion.Gettelefono(doc);
                MessageBox.Show("Factura de compra: \n" +
                    "Nombre cliente: " + nombre + " " + apellido + "\n" +
                    "" + Tipo + ": " + doc + "\n" +
                    "Dirección: " + direccion + "\n" +
                    "Telefono: " + telefono + "\n" +
                    "--------------------Producto----------------\n" +
                    "Nombre del Producto: " + T1.Text + "\n" +
                    "Costo por unidad: " + T4.Text + "\n" +
                    "Cantidad compradas: " + T7.Text + "\n" +
                    "Fecha de la compra: " + fecha + "\n" +
                    "Total a pagar: " + T6.Text + "");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron traer los datos del cliente: " + ex);
            }
        }
        //Método que se encarga de mostrar los usuarios en un datagridview y los busca por medio de 
        //un dato que corresponde al documento del usuario y los organiza en tablas
        public void mostrarUsuarios(DataGridView tablapropie, TextBox T1)
        {
            try
            {
                CConexion objetoConexion = new CConexion();
                string query2 = "select * from venta where Cliente='" + T1.Text + "' ";
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
        //Método que elimina las ventas por medio de un dato que se trae como parámetro por medio
        //del textbox y que corresponde al id de la venta hecha
        public void eliminarventa(TextBox TE)
        {
            try
            {
                CConexion objetoConexion = new CConexion();
                String query = "delete from venta where Id_venta ='" + TE.Text + "'";
                MySqlCommand myCommand = new MySqlCommand(query, objetoConexion.establecerConexion());
                MySqlDataReader reader = myCommand.ExecuteReader();
                MessageBox.Show("Se eliminó la venta");
                while (reader.Read())
                {

                }
                objetoConexion.Cerrar_conexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se eliminó la venta, error: " + ex);
            }
        }
        //Método que se encarga de asignar al textbox el valor de la variable en posición 0
        //en el datagridview que es traido en los parámetros
        public void SeleccionarVentas(DataGridView TablaUsuarios, TextBox TE)
        {
            try
            {
                TE.Text = TablaUsuarios.CurrentRow.Cells[0].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se Logró seleccionar la venta, error: " + ex);
            }
        }
        //Método que se encarga de mostrar los datos de la tabla de venta y que asi mismo se traen
        //datos de a tabla productos dentro de un datagridview y que que se buscan por medio de la variable doc
        public void mostrarventa(DataGridView T, string doc)
        {
            try
            {
                CConexion objetoConexion = new CConexion();
                string query2 = "select Id_venta,cantidad,Nom_prod as producto,cliente from venta join productos on Cod_producto = producto where cliente ='" + doc+"';";
                T.DataSource = null;
                MySqlDataAdapter adapter = new MySqlDataAdapter(query2, objetoConexion.establecerConexion());
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                T.DataSource = dt;
                objetoConexion.Cerrar_conexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se mostraron los datos de la base de datos, error: " + ex.ToString());
            }
        }
        //Método que se encarga de asignar el valor de los textbox como los datos de cada posicion
        //del datagridview que muestra datos de la venta 
        public void SeleccionarVentas2(DataGridView TablaUsuarios, TextBox T5, TextBox T1, TextBox T7)
        {
            try
            {
                T5.Text = TablaUsuarios.CurrentRow.Cells[0].Value.ToString();
                T7.Text = TablaUsuarios.CurrentRow.Cells[1].Value.ToString();
                T1.Text = TablaUsuarios.CurrentRow.Cells[2].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se Logró seleccionar la venta, error: " + ex);
            }
        }
        //Método que se encarga de modificar los datos dentro de la tabla ventas,
        //donde se reciben los datos del producto y de la venta, para poder modificarlos
        //a travez de los textbox del form
        public void ModificarVenta(TextBox T1, TextBox T5, TextBox T7)
        {
            try
            {
                CConexion objetoConexion = new CConexion();
                int costo = Convert.ToInt32(objetoConexion.Getcosto(T1.Text));
                int cantidad = Convert.ToInt32(T7.Text);
                int total = costo * cantidad;
                String query = "update venta set producto=(select Cod_producto from productos where Nom_prod = '" + T1.Text+"')," +
                    " cantidad = '"+T7.Text+"',Total_pagar='"+total+"' where Id_venta = '"+T5.Text+"'; ";
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
    }
}
