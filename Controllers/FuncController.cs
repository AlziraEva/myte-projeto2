﻿using Microsoft.AspNetCore.Mvc;
using myte.Models;
using System.Security.Cryptography.X509Certificates;

namespace Projeto.ASPNET.MVC.CRUD_MyTE.Controllers
{
    public class FuncController : Controller
    {
        public IActionResult ListaFuncionarios()
        {
            return View(RepositoryFunc.TodosOsFuncionarios);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Funcionario registroFunc)
        {
           

                RepositoryFunc.Inserir(registroFunc); //ação de inserção de dados na lista
                
                return Redirect("ListaFuncionarios"); // view message
     
          
            
        }
        //Atualizar (Update)       
        public IActionResult Update(string Identificador) // Primeiro método
        {           
            Funcionario consulta = RepositoryFunc.TodosOsFuncionarios.Where((r) => r.Nome == Identificador ).First();
            return View(consulta);
        }

        //Sobrecarga do Update
        [HttpPost]
        public IActionResult Update(string Identificador, Funcionario registroAlterado)
        {
            /*  if (ModelState.IsValid)
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
            */
                    
                  var consulta = RepositoryFunc.TodosOsFuncionarios.Where((r) => r.Nome ==
                  Identificador).First();
            consulta.Nome = registroAlterado.Nome;
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

                return Redirect("ListaFuncionarios");

            // return View(); 

        }

        [HttpPost]
        public IActionResult Delete(string Identificador)
        {
            //Definir a consulta exclusão
            Funcionario consulta = RepositoryFunc.TodosOsFuncionarios.Where((r) => r.Nome ==
            Identificador).First();
            // acessar o método Excluir - partir da classe Repository
            RepositoryFunc.Excluir(consulta);
            return RedirectToAction("ListaFuncionarios");

        }
    }
 }

