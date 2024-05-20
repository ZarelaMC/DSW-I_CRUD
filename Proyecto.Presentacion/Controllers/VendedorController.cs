using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

//Referencia
using Proyecto.Presentacion.Models;

namespace Proyecto.Presentacion.Controllers
{
    public class VendedorController : Controller
    {
        private IVendedor procesosVendedor;

        public VendedorController()
        {
            procesosVendedor = new RepositorioVendedor();
        }

        public IActionResult Index()
        {
            return View();
        }

        //Listado de Vendedores
        public IActionResult ListadoVendedores()
        {
            return View(procesosVendedor.listadoVendedor());
        }

        //Registrar nuevo Vendedor
        [HttpGet]
        public IActionResult NuevoVendedor()
        {
            ViewBag.distrito = new SelectList(procesosVendedor.listadoDistrito(), "ide_dis", "nom_dis");
            return View(new VendedorO());
        }

        [HttpPost]
        public IActionResult NuevoVendedor(VendedorO objV)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.distrito = new SelectList(procesosVendedor.listadoDistrito(), "ide_dis", "nom_dis");
                return View(objV);
            }
            ViewBag.distrito = new SelectList(procesosVendedor.listadoDistrito(), "ide_dis", "nom_dis");
            ViewBag.mensaje = procesosVendedor.nuevoVendedor(objV);
            return View(objV);
        }
    }
}
