using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Miscelanea.Clases
{
    internal class CConexion
    {
        //Linea de codigo del connect de Mysql donde se asigna a una variable
        MySqlConnection conex = new MySqlConnection();
        //Líneas de código donde se asignan las caracteristicas del servidor y la
        //base de datos en mysql a variables de tipo string
        static string servidor = "localhost";
        static string bd = "Miscelanea";
        static string usuario = "root";
        static string password = "6y7u89pp";
        static string puerto = "3306";

        //variable string que contiene la cadena de conexion con todos los datos del servidor
        String cadenaConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + password + ";" + "database=" + bd + ";";

        //Método que establece la conexión con la base de datos
        public MySqlConnection establecerConexion()
        {
            //Se intenta realizar la conexión junto con la cadena de conexion
            //y se deja la conexion abierta
            try
            {
                conex.ConnectionString = cadenaConexion;
                conex.Open();
                //MessageBox.Show("Se logró conectar a la base de datos correctamente");
            }

            catch (MySqlException e)
            {
                //Si no se logra la conexión entonces se atrapa el error en la variable e
                //y se arroja el siguiente mensaje en pantalla: 
                MessageBox.Show("No se pudo conectar a la base de datos, error:" + e.ToString());
            }
            //Se envia la conexion en una varible para que pueda ser usada
            return conex;
        }
        //Método que cierra la conexión 
        public void Cerrar_conexion()
        {
            conex.Close();
        }
        //Método que trae el valor del documento y retorna al usarlo
        //adicional como parametro se debe enviar un dato que corresponde al documento
        public String GetDoc(String doc)
        {
            String Doc;
            string query = "select CC from `personas` where CC='" + doc + "';";
            conex.Close();
            MySqlCommand myCommand = new MySqlCommand(query, establecerConexion());
            Doc = Convert.ToString(myCommand.ExecuteScalar());
            conex.Close();
            return Doc;
        }
        //Método que trae el valor de la contraseña y retorna al usarlo
        //adicional como parametro se debe enviar un dato que corresponde a dicha contraseña
        public String GetContra(String con)
        {
            String Contra;
            string query = "select contraseña from personas where contraseña='" + con + "';";
            conex.Close();
            MySqlCommand myCommand = new MySqlCommand(query, establecerConexion());
            Contra = Convert.ToString(myCommand.ExecuteScalar());
            conex.Close();
            return Contra;
        }
        //Método que trae el valor del rol y retorna al usarlo
        //adicional como parametro se debe enviar dos datos que corresponden al documento
        //y a la contraseña
        public int Getrol(String documento, String contraseña)
        {
            int rol;
            string query = "select rol from `personas` where CC='" + documento + "'AND contraseña='" + contraseña + "';";
            conex.Close();
            MySqlCommand myCommand = new MySqlCommand(query, establecerConexion());
            rol = Convert.ToInt32(myCommand.ExecuteScalar());
            conex.Close();
            return rol;
        }
        //Método que trae el valor del tipo de documento y retorna al usarlo
        //adicional como parametro se debe enviar un dato que corresponde al documento
        public String GetTipo(String doc)
        {
            String Tipo;
            string query = "select Tipo_documento from `personas` where CC='" + doc + "';";
            conex.Close();
            MySqlCommand myCommand = new MySqlCommand(query, establecerConexion());
            Tipo = Convert.ToString(myCommand.ExecuteScalar());
            conex.Close();
            return Tipo;
        }
        //Método que trae el valor del nombre y retorna al usarlo
        //adicional como parametro se debe enviar un dato que corresponde al documento
        public String Getnombre(String doc)
        {
            String nom;
            string query = "select Nombre from `personas` where CC='" + doc + "';";
            conex.Close();
            MySqlCommand myCommand = new MySqlCommand(query, establecerConexion());
            nom = Convert.ToString(myCommand.ExecuteScalar());
            conex.Close();
            return nom;
        }
        //Método que trae el valor del apellido y retorna al usarlo
        //adicional como parametro se debe enviar un dato que corresponde al documento
        public String Getapellido(String doc)
        {
            String apellido;
            string query = "select Apellido from `personas` where CC='" + doc + "';";
            conex.Close();
            MySqlCommand myCommand = new MySqlCommand(query, establecerConexion());
            apellido = Convert.ToString(myCommand.ExecuteScalar());
            conex.Close();
            return apellido;
        }
        //Método que trae el valor de la dirección y retorna al usarlo
        //adicional como parametro se debe enviar un dato que corresponde al documento
        public String Getdireccion(String doc)
        {
            String direccion;
            string query = "select Direccion from `personas` where CC='" + doc + "';";
            conex.Close();
            MySqlCommand myCommand = new MySqlCommand(query, establecerConexion());
            direccion = Convert.ToString(myCommand.ExecuteScalar());
            conex.Close();
            return direccion;
        }
        //Método que trae el valor del telefono y retorna al usarlo
        //adicional como parametro se debe enviar un dato que corresponde al documento
        public String Gettelefono(String doc)
        {
            String telefono;
            string query = "select Telefono from `personas` where CC='" + doc + "';";
            conex.Close();
            MySqlCommand myCommand = new MySqlCommand(query, establecerConexion());
            telefono = Convert.ToString(myCommand.ExecuteScalar());
            conex.Close();
            return telefono;
        }
        //Método que trae el valor del costo y retorna al usarlo
        //adicional como parametro se debe enviar un dato que corresponde al nombre del producto
        public String Getcosto(String nom) {
            String costo;
            String query = "select costo from `productos` where Nom_prod='" + nom + "';";
            conex.Close();
            MySqlCommand myCommand = new MySqlCommand(query, establecerConexion());
            costo = Convert.ToString(myCommand.ExecuteScalar());
            conex.Close();
            return costo;
        }
    }
}
