using Microsoft.AspNetCore.Mvc;
using CRUDNETBDD.Datos;
using CRUDNETBDD.Models;

namespace CRUDNETBDD.Controllers
{
    public class CRUDController : Controller
    {
        ClientesDatos clientesDatos = new ClientesDatos();

        public IActionResult Listar()
        {
            return View();
        }

        public IActionResult GuardarForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GuardarForm(ModelCliente oCliente)
        {
            if ( !ModelState.IsValid)
            {
                return View();
            }

            var respuesta = clientesDatos.Guardar(oCliente);

            if(respuesta)
            {
                return RedirectToAction("Listar");
            }

            return View();
        }
    }
}
