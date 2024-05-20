using Microsoft.Data.SqlClient;

//Implementar
using Microsoft.Data;
using System.Data;

namespace Proyecto.Presentacion.Models
{
    public class RepositorioVendedor : IVendedor
    {

        private string cadena;

        public RepositorioVendedor()
        {
            cadena = new ConfigurationBuilder().AddJsonFile("appsettings.json")
                .Build().GetConnectionString("cn");
        }


        //Implementar todos los métodos definidos en la interfaz
        IEnumerable<Distrito> IVendedor.listadoDistrito()
        {
            List<Distrito> aDistritos = new List<Distrito>();
            SqlConnection cn = new SqlConnection(cadena);
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTADO_DISTRITOS", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                aDistritos.Add(new Distrito
                {
                    ide_dis = int.Parse(dr[0].ToString()),
                    nom_dis = dr[1].ToString()
                });
            }
            cn.Close();
            return aDistritos;
        }

        IEnumerable<Vendedor> IVendedor.listadoVendedor()
        {
            List<Vendedor> aVendedores = new List<Vendedor>();
            SqlConnection cn = new SqlConnection(cadena);
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTADO_VENDEDORES_VISTA_CLIENTE", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                aVendedores.Add(new Vendedor
                {
                    ide_ven = int.Parse(dr[0].ToString()),
                    ven = dr[1].ToString(),
                    sue_ven = double.Parse(dr[2].ToString()),
                    fec_ing = DateTime.Parse(dr[3].ToString()),
                    nom_dis = dr[4].ToString()
                });
            }
            cn.Close();
            return aVendedores;
        }

        IEnumerable<VendedorO> IVendedor.listadoVendedorO()
        {
            List<VendedorO> aVendedoresO = new List<VendedorO>();
            SqlConnection cn = new SqlConnection(cadena);
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTADO_VENDEDORES_ORIGINAL", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                aVendedoresO.Add(new VendedorO
                {
                    ide_ven = int.Parse(dr[0].ToString()),
                    nom_ven = dr[1].ToString(),
                    ape_ven = dr[2].ToString(),
                    sue_ven = double.Parse(dr[3].ToString()),
                    fec_ing = DateTime.Parse(dr[4].ToString()),
                    ide_dis = int.Parse(dr[5].ToString())
                });
            }
            cn.Close();
            return aVendedoresO;
        }

        string IVendedor.modificarVendedor(VendedorO objV)
        {
            string mensaje = "";
            SqlConnection cn = new SqlConnection(cadena);
            cn.Open() ;
            try
            {
                SqlCommand cmd = new SqlCommand("SP_MERGE_VENDEDOR", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDE_VEN", objV.ide_ven);
                cmd.Parameters.AddWithValue("@NOM_VEN", objV.nom_ven);
                cmd.Parameters.AddWithValue("@APE_VEN", objV.ape_ven);
                cmd.Parameters.AddWithValue("@SUE_VEN", objV.sue_ven);
                cmd.Parameters.AddWithValue("@FEC", objV.fec_ing);
                cmd.Parameters.AddWithValue("@DIS", objV.ide_dis);
                int n = cmd.ExecuteNonQuery();    //DEVUELVE 1 o 0 
                mensaje = n.ToString() + " Vendedor actualizado...!!!";
            }
            catch (Exception ex)
            {
                mensaje = "Error al actualizar...!!!" + ex.Message;
            }
            cn.Close() ;
            return mensaje;
        }

        string IVendedor.nuevoVendedor(VendedorO objV)
        {
            string mensaje = "";
            SqlConnection cn = new SqlConnection(cadena);
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_MERGE_VENDEDOR", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDE_VEN", objV.ide_ven);
                cmd.Parameters.AddWithValue("@NOM_VEN", objV.nom_ven);
                cmd.Parameters.AddWithValue("@APE_VEN", objV.ape_ven);
                cmd.Parameters.AddWithValue("@SUE_VEN", objV.sue_ven);
                cmd.Parameters.AddWithValue("@FEC_ING", objV.fec_ing);
                cmd.Parameters.AddWithValue("@IDE_DIS", objV.ide_dis);
                int n = cmd.ExecuteNonQuery();    //DEVUELVE 1 o 0 
                mensaje = n.ToString() + " Vendedor registrado...!!!";
            }
            catch (Exception ex)
            {
                mensaje = "Error al registrar...!!!" + ex.Message;
            }
            cn.Close();
            return mensaje;
        }
    }
}
