namespace Proyecto.Presentacion.Models
{
    public interface IVendedor
    {
        //Definir los métodos de mantenimiento de vendedor

        //-- LISTADOS
        IEnumerable<Vendedor> listadoVendedor();
        IEnumerable<VendedorO> listadoVendedorO();
        IEnumerable<Distrito> listadoDistrito();

        //-- REGISTRAR
        string nuevoVendedor(VendedorO objV);

        //-- ACTUALIZAR
        string modificarVendedor(VendedorO objV);

    }
}
