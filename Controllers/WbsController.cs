using Microsoft.AspNetCore.Mvc;
using myte.Models;

namespace myte.Controllers
{
    public class WbsController : Controller
    {
        public IActionResult Index()
        {
            return View(Repository.TodasAsWbs);
        }

        public IActionResult CreateWbs()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateWbs(Wbs registroWbs)
        {
            if (ModelState.IsValid)
            {
                Repository.Inserir(registroWbs);
                return View("ConfirmacaoWbs", registroWbs);
            }
            else
            {
                return View();
            }
        }


        public IActionResult UpdateWbs(string id)
        {
            Wbs consulta = Repository.TodasAsWbs.Where((r) => r.Codigo == id).First();
            return View(consulta);
        }

        [HttpPost]
        public IActionResult Update(string id, Wbs wbsAlterada)
        {
            if (ModelState.IsValid)
            {
                var consulta = Repository.TodasAsWbs.Where((r) => r.Codigo == id).First();

                consulta.Nome = wbsAlterada.Nome;
                consulta.Descricao = wbsAlterada.Descricao;
                consulta.Tipo = wbsAlterada.Tipo;
                consulta.Codigo = wbsAlterada.Codigo;

                return View("Index");
            }
            return View("Update", wbsAlterada);

        }

        [HttpPost]
        public IActionResult Delete(string id)
        {
            Wbs consulta = Repository.TodasAsWbs.Where((r) => r.Codigo == id).First();
            Repository.Excluir(consulta);
            return RedirectToAction("Index");
        }
    }
}
