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
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Sobre()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Index()
        {
            //CurriculoDAO dao = new CurriculoDAO();
           // List<CurriculoViewModel> lista = dao.Listagem();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ListaBD()
        {
            CurriculoDAO dao = new CurriculoDAO();
            List<CurriculoViewModel> lista = dao.Listagem();
            return View(lista);
        }

        public IActionResult Edit(string id)
        {
            try
            {
                CurriculoDAO dao = new CurriculoDAO();
                CurriculoViewModel curriculo = dao.Consulta(id);
                if (curriculo == null)
                    return RedirectToAction("index");
                else
                    return View("Form", curriculo);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }
        public IActionResult NovoCurriculo()
        {
            CurriculoViewModel curriculo = new CurriculoViewModel();
            return View("Form", curriculo);
        }

        /* public IActionResult Salvar1(CurriculoViewModel curriculo)
         {
             try
             {
                 CurriculoDAO dao = new CurriculoDAO();
                 if (dao.Consulta(int.Parse(curriculo.cpf)) == null)
                     dao.Inserir1(curriculo);
                /* else
                     dao.Alterar1(curriculo);
                 return RedirectToAction("index");
             }
             catch (Exception erro)
             {
                 return View("Error", new ErrorViewModel(erro.ToString()));
             }
         }
        */
    }
}
