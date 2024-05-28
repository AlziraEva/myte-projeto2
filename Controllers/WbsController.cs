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
                

                TempData["SuccessMessage"] = "Wbs cadastrada com sucesso!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ErrorMessage"] = "Não é possivel prosseguir com a ação";
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

                return Redirect("Index");
            }
            return View();

        }

        [HttpPost]
        public IActionResult Delete(string id)
        {
            
            try
            {
                Wbs consulta = Repository.TodasAsWbs.Where((r) => r.Codigo == id).First();
                Repository.Excluir(consulta);
                TempData["SuccessMessageDelete"] = "exclusao realizada com sucesso!";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["ErrorMessageDelete"] = "Não é possivel prosseguir com a ação";
                return Redirect("Index");
            }
        }
    }
}
