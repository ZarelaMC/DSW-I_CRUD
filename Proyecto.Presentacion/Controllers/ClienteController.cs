using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecto.Presentacion.Models;

namespace Proyecto.Presentacion.Controllers
{
    public class ClienteController : Controller
    {
        private ICliente metodosICliente;

        public ClienteController()
        {
            metodosICliente = new RepositorioCliente();
        }

        public IActionResult Index()
        {
            return View();
        }

        //Listado de clientes FrontEnd
        public IActionResult ListadoClientesFrontEnd()
        {
            return View(metodosICliente.listadoClientes());
        }

        //REGISTRO clientes
        [HttpGet]
        public IActionResult RegistrarCliente()
        {
            ViewBag.distritos = new SelectList(metodosICliente.listadoDistritos(), "ide_dis", "nom_dis");
            return View(new ClienteO());
        }

        [HttpPost]
        public IActionResult RegistrarCliente(ClienteO objCliO)
        {
            //Si NO es válido
            if (!ModelState.IsValid)
            {
                ViewBag.distritos = new SelectList(metodosICliente.listadoDistritos(), "ide_dis", "nom_dis");
                return View(objCliO);
            }
            else
            {
                //Si SÍ es válido
                ViewBag.distritos = new SelectList(metodosICliente.listadoDistritos(), "ide_dis", "nom_dis");
                ViewBag.msjConfirmacion = metodosICliente.registroCliente(objCliO);
                return View(objCliO);
            }
        }
    }
}
