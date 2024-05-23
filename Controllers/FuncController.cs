using Microsoft.AspNetCore.Mvc;
using myte.Models;
using System.Security.Cryptography.X509Certificates;

namespace Projeto.ASPNET.MVC.CRUD_MyTE.Controllers
{
    public class FuncController : Controller
    {
        public IActionResult Index()
        {
            return View(RepositoryFunc.TodosOsFuncionarios);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Funcionario registroFunc, IFormFile foto)
        {
            if(ModelState.IsValid)
            {
                if(foto != null) // Foto funcionário
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        foto.CopyTo(memoryStream);
                        registroFunc.Foto = memoryStream.ToArray();
                    }
                }


                RepositoryFunc.Inserir(registroFunc); //ação de inserção de dados na lista
                
                return Redirect("Index"); // view message
            }
            else
            {
                // Caso, algum problema ocorro a view de inserção permanecerá ativa e carregada no browser
                return View();

            }
            
        }
        //Atualizar (Update)       
        public IActionResult Update(String Identificador) // Primeiro método
        {           
            Funcionario consulta = RepositoryFunc.TodosOsFuncionarios.Where((r) => r.Nome == Identificador ).First();
            return View(consulta);
        }
        //Sobrecarga do Update
        [HttpPost]
        public ActionResult Update(string Identificador, Funcionario registroAlterado, IFormFile foto)
        {
            if (ModelState.IsValid)
            {
                //Alteração da prop Sobrenome
                var consulta = RepositoryFunc.TodosOsFuncionarios.Where((r) => r.Nome ==
                Identificador).First();

                if (foto != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        foto.CopyTo(memoryStream);
                        registroAlterado.Foto = memoryStream.ToArray();
                    }
                }

                consulta.Sobrenome = registroAlterado.Sobrenome;
                consulta.DataDeNascimento = registroAlterado.DataDeNascimento;
                consulta.Email = registroAlterado.Email;
                consulta.DataDeContratacao = registroAlterado.DataDeContratacao;
                consulta.Genero = registroAlterado.Genero;
                consulta.Senioridade = registroAlterado.Senioridade;
                consulta.Cargo = registroAlterado.Cargo;
                consulta.Departamento = registroAlterado.Departamento;                
                consulta.Acesso = registroAlterado.Acesso;
                consulta.Foto = registroAlterado.Foto;

                return RedirectToAction("Index");

            }
            return View();            

        }
        [HttpPost]
        public IActionResult Delete(string Identificador)
        {
            //Definir a consulta exclusão
            Funcionario consulta = RepositoryFunc.TodosOsFuncionarios.Where((r) => r.Nome ==
            Identificador).First();
            // acessar o método Excluir - partir da classe Repository
            RepositoryFunc.Excluir(consulta);
            return RedirectToAction("Index");
        }
    }
}
