using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miscelanea.Clases
{
    internal class Reporte
    {
        CConexion conect = new CConexion();
        public DataSet Listaventa(String doc) {
            string query = "select CC as Documento,Nombre,Apellido,Telefono," +
                "Nom_prod as producto,Cantidad,costo as Costo_por_unidad,fecha_venta," +
                "Total_pagar from venta join personas on CC = Cliente " +
                "join productos on Cod_producto = producto where cliente = '"+doc+"'; ";
            MySqlDataAdapter da = new MySqlDataAdapter(query, conect.establecerConexion());
            DataSet dt = new DataSet();
            da.Fill(dt);
            conect.Cerrar_conexion();
            return dt;
        }
    }
}
