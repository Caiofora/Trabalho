using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Trabalho.Models;

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

        private void ValidaDados(CurriculoViewModel curriculo, string operacao)
        {
            /*CurriculoDAO dao = new CurriculoDAO();
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
                ModelState.AddModelError("Id", "Código já está em uso.");*/
        }

    }
}

