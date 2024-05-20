using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;

namespace Proyecto.Presentacion.Models
{
    public class RepositorioCliente : ICliente
    {
        private string cadena;

        public RepositorioCliente()
        {
            cadena = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("cn");
        }

        IEnumerable<Cliente> ICliente.listadoClientes()
        {
            List<Cliente> aCliente = new List<Cliente>();

            SqlConnection cn = new SqlConnection(cadena);

            cn.Open();

            SqlCommand cmd = new SqlCommand("SP_MOSTRAR_CLIENTES", cn);

            cmd.CommandType = System.Data.CommandType.Text;

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                aCliente.Add(new Cliente()
                {
                    ide_cli = int.Parse(dr[0].ToString()),
                    rso_cli = dr[1].ToString(),
                    con_cli = dr[2].ToString(),
                    tlf_cli = dr[3].ToString(),
                    dir_cli = dr[4].ToString(),
                    ruc_cli = dr[5].ToString(),
                    nom_dis = dr[6].ToString(),
                    fec_reg = DateTime.Parse(dr[7].ToString()),
                   
                });
            }
            cn.Close();

            return aCliente;
        }

        IEnumerable<ClienteO> ICliente.listadoClientesO()
        {
            List<ClienteO> aClienteO = new List<ClienteO>();

            SqlConnection cn = new SqlConnection(cadena);

            cn.Open();

            SqlCommand cmd = new SqlCommand("SP_LISTARparaREGISTRAR_CLIENTES", cn);

            cmd.CommandType = System.Data.CommandType.Text;

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                aClienteO.Add(new ClienteO()
                {
                    ide_cli = int.Parse(dr[0].ToString()),
                    rso_cli = dr[1].ToString(),
                    con_cli = dr[2].ToString(),
                    tlf_cli = dr[3].ToString(),
                    dir_cli = dr[4].ToString(),
                    ruc_cli = dr[5].ToString(),
                    ide_dis = int.Parse(dr[6].ToString()),
                    fec_reg = DateTime.Parse(dr[7].ToString()),
                });
            }
            cn.Close();

            return aClienteO;
        }

        IEnumerable<Distrito> ICliente.listadoDistritos()
        {
            List<Distrito> aDistritos = new List<Distrito>();
            SqlConnection cn = new SqlConnection(cadena);
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTADO_DISTRITOS", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                aDistritos.Add(new Distrito()
                {
                    ide_dis = int.Parse(dr[0].ToString()),  
                    nom_dis = dr[1].ToString(),
                });
            }
            cn.Close();
            return aDistritos;
        }

        string ICliente.registroCliente(ClienteO objCliO)
        {
            string mensaje = "";
            SqlConnection cn = new SqlConnection(cadena);
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_MERGE_CLIENTE", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDE_CLI", objCliO.ide_cli);
                cmd.Parameters.AddWithValue("@RSO_CLI", objCliO.rso_cli);
                cmd.Parameters.AddWithValue("@DIR_CLI", objCliO.dir_cli);
                cmd.Parameters.AddWithValue("@TLF_CLI", objCliO.tlf_cli);
                cmd.Parameters.AddWithValue("@RUC_CLI", objCliO.ruc_cli);
                cmd.Parameters.AddWithValue("@IDE_DIS", objCliO.ide_dis);
                cmd.Parameters.AddWithValue("@FEC_REG", objCliO.fec_reg);
                cmd.Parameters.AddWithValue("@CON_CLI", objCliO.con_cli);
                int n = cmd.ExecuteNonQuery();
                mensaje = n.ToString() + " Cliente registrado satisfactoriamente";
            } catch (Exception e){ 
                mensaje = "Algo falló al registrar "+ e.Message;
            }
            cn.Close();
            return mensaje;
        }

        string ICliente.actualizacionCliente(ClienteO objCliO)
        {
            string mensaje = "";
            SqlConnection cn = new SqlConnection(cadena);
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_MERGE_CLIENTE", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDE_CLI", objCliO.ide_cli);
                cmd.Parameters.AddWithValue("@RSO_CLI", objCliO.rso_cli);
                cmd.Parameters.AddWithValue("@DIR_CLI", objCliO.dir_cli);
                cmd.Parameters.AddWithValue("@TLF_CLI", objCliO.tlf_cli);
                cmd.Parameters.AddWithValue("@RUC_CLI", objCliO.ruc_cli);
                cmd.Parameters.AddWithValue("@IDE_DIS", objCliO.ide_dis);
                cmd.Parameters.AddWithValue("@FEC_REG", objCliO.fec_reg);
                cmd.Parameters.AddWithValue("@CON_CLI", objCliO.con_cli);
                int n = cmd.ExecuteNonQuery();
                mensaje = n.ToString() + " Cliente modificado satisfactoriamente";
            }
            catch (Exception e)
            {
                mensaje = "Algo falló al actualizar!!! " + e.Message;
            }
            cn.Close();
            return mensaje;
        }
    }
}
