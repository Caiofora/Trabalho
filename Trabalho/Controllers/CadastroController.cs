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

        private void ValidaDados(CurriculoViewModel curriculo, string operacao)
        {
            //Validação das informações pessoais
            if (!ValidaCPF(curriculo.cpf))
                ModelState.AddModelError("Cpf", "CPF invalido");
            if (string.IsNullOrEmpty(curriculo.nome))
                ModelState.AddModelError("Nome", "Nome invalido");
            if (curriculo.celular.Length < 0 && curriculo.celular.Length != 12)
                ModelState.AddModelError("Celular", "Número de celular invalido");
            if (string.IsNullOrEmpty(curriculo.email))
                ModelState.AddModelError("Email", "Email invalido");
            if (string.IsNullOrEmpty(curriculo.cargoPretendido))
                ModelState.AddModelError("Cargo Prentendido", "Cargo pretendido invalido");

            //Validação das informações de endereço
            if (string.IsNullOrEmpty(curriculo.cep))
                ModelState.AddModelError("CEP", "CEP invalido");
            if ((string.IsNullOrEmpty(curriculo.rua)))
                ModelState.AddModelError("Rua", "Rua invalida");
            if ((string.IsNullOrEmpty(curriculo.numeroEnd)))
                ModelState.AddModelError("Numero", "Numero invalido");
            if ((string.IsNullOrEmpty(curriculo.bairro)))
                ModelState.AddModelError("Bairro", "Bairro invalido");
            if ((string.IsNullOrEmpty(curriculo.complementoEnd)))
                ModelState.AddModelError("Complemento de Endereço", "Complemento de Endereço invalido");


        }


        public static bool ValidaCPF(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }



    }
}

