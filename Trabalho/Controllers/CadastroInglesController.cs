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
    public class CadastroInglesController : Controller
    {
        private readonly ILogger<CadastroController> _logger;

        public CadastroInglesController(ILogger<CadastroController> logger)
        {
            _logger = logger;
        }

        public IActionResult VerificarIdioma(string idioma)
        {


            return View();
        }

    }
}
