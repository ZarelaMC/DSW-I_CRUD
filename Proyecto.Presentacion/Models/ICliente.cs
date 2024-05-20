namespace Proyecto.Presentacion.Models
{
    public interface ICliente
    {
        //LISTADO
        IEnumerable<Cliente> listadoClientes();
        IEnumerable<ClienteO> listadoClientesO();
        IEnumerable<Distrito> listadoDistritos();

        //INSERCIÓN
        string registroCliente(ClienteO objCliO);

        //ACTUALIZACIÓN 
        string actualizacionCliente(ClienteO objCliO);
    }
}
