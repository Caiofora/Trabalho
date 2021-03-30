using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Trabalho.Models;
using Trabalho.DAO;


namespace Trabalho.Controllers
{
    public class CadastroController : Controller
    {
        private readonly ILogger<CadastroController> _logger;

        public CadastroController(ILogger<CadastroController> logger)
        {
            _logger = logger;
        }

        public IActionResult CadastroPessoal()
        {
            return View();
        }

        public IActionResult CadastroFormacao()
        {
            return View();
        }
        public IActionResult CadastroExpProf()
        {
            return View();
        }
        public IActionResult CadastroIdiomas()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Edita(string id)
        {
            try
            {
                CurriculoDAO dao = new CurriculoDAO();
                CurriculoViewModel curriculo = dao.Consulta(id);
                if (curriculo == null)
                    return RedirectToAction("index");
                else
                    return View("CadastroPessoal", curriculo);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }
        public IActionResult Edita1(string id)
        {
            try
            {
                CurriculoDAO dao = new CurriculoDAO();
                CurriculoViewModel curriculo = dao.Consulta(id);
                if (curriculo == null)
                    return RedirectToAction("index");
                else
                    return View("CadastroEditarPessoal", curriculo);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }
        public IActionResult Edita2(string id)
        {
            try
            {
                CurriculoDAO dao = new CurriculoDAO();
                CurriculoViewModel curriculo = dao.Consulta(id);
                if (curriculo == null)
                    return RedirectToAction("index");
                else
                    return View("CadastroEditarFormacao", curriculo);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }
        public IActionResult Edita3(string id)
        {
            try
            {
                CurriculoDAO dao = new CurriculoDAO();
                CurriculoViewModel curriculo = dao.Consulta(id);
                if (curriculo == null)
                    return RedirectToAction("index");
                else
                    return View("CadastroEditarExpProf", curriculo);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

        public IActionResult Edita4(string id)
        {
            try
            {
                CurriculoDAO dao = new CurriculoDAO();
                CurriculoViewModel curriculo = dao.Consulta(id);
                if (curriculo == null)
                    return RedirectToAction("index");
                else
                    return View("CadastroEditarIdiomas", curriculo);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

        public IActionResult Salvar1(CurriculoViewModel curriculo)
        {
            try
            {
                CurriculoDAO dao = new CurriculoDAO();
                if (dao.Consulta(curriculo.cpf) == null)
                    dao.Inserir1(curriculo);
                else
                    dao.Alterar1(curriculo);
                return RedirectToAction("CadastroFormacao");
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }
        public IActionResult Salvar4(CurriculoViewModel curriculo)
        {
            try
            {
                CurriculoDAO dao = new CurriculoDAO();
                if (dao.Consulta(curriculo.cpf) == null)
                    dao.Inserir4(curriculo);
                else
                    dao.Alterar1(curriculo);
                return RedirectToAction("index");
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }
        public IActionResult Salvar3(CurriculoViewModel curriculo)
        {
            try
            {
                CurriculoDAO dao = new CurriculoDAO();
                if (dao.Consulta(curriculo.cpf) == null)
                    dao.Inserir3(curriculo);
                else
                    dao.Alterar1(curriculo);
                return RedirectToAction("index");
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }
        public IActionResult Salvar2(CurriculoViewModel curriculo, int id)
        {
            try
            {
                if (curriculo.cpf == null)
                    curriculo.cpf = id.ToString();
                
                CurriculoDAO dao = new CurriculoDAO();
                if (dao.Consulta(curriculo.cpf) == null)
                    dao.Inserir2(curriculo);
                else
                    dao.Alterar1(curriculo);
                return RedirectToAction("index");
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

        public IActionResult NovoCurriculo()
        {
            CurriculoViewModel curriculo = new CurriculoViewModel();
            return View("CadastroPessoal", curriculo);
        }

       

        /*  private void ValidaDados(CurriculoViewModel curriculo, string operacao)
          {
              CurriculoDAO dao = new CurriculoDAO();
              if (operacao == "I" && dao.Consulta(curriculo.Id) != null)
                  ModelState.AddModelError("Id", "Código já está em uso.");
              if (operacao == "A" && dao.Consulta(curriculo.Id) == null)
                  ModelState.AddModelError("Id", "Aluno não existe.");
              if (curriculo.Id <= 0)
                  ModelState.AddModelError("Id", "Id inválido!");

              if (string.IsNullOrEmpty(curriculo.Nome))
                  ModelState.AddModelError("Nome", "Preencha o nome.");
              if (curriculo.Mensalidade < 0)
                  ModelState.AddModelError("Mensalidade", "Campo obrigatório.");
              if (curriculo.CidadeId <= 0)
                  ModelState.AddModelError("CidadeId", "Informe o código da cidade.");
              if (curriculo.DataNascimento > DateTime.Now)
                  ModelState.AddModelError("DataNascimento", "Data inválida!");
          }

          private void ValidaDados(CurriculoViewModel curriculo, string operacao)
          {
              CurriculoDAO dao = new CurriculoDAO();
              if (ModelState.IsValid )
                  ModelState.AddModelError("Id", "Código já está em uso.");
          }*/

    }
}

