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

        public IActionResult CadastroFormacao(CurriculoViewModel curriculo)
        {
            return View(curriculo);
        }

        public IActionResult CadastroExpProf(CurriculoViewModel curriculo)
        {
            return View(curriculo);
        }
        public IActionResult CadastroIdiomas(CurriculoViewModel curriculo)
        {
            return View(curriculo);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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

        public IActionResult Salvar1(CurriculoViewModel curriculo, string id)
        {
            try
            {
                CurriculoDAO dao = new CurriculoDAO();
                
                if (curriculo.cpf == null)
                {
                    curriculo.cpf = id;
                }

               // ValidaDadosPessoal(curriculo.cpf);


                if (curriculo.complementoEnd == null)
                {
                    curriculo.complementoEnd = "";
                }

                if (dao.Consulta(curriculo.cpf) == null)
                {
                    dao.Inserir1(curriculo);
                    CurriculoViewModel Select = dao.Consulta(curriculo.cpf);
                    return RedirectToAction("CadastroFormacao", Select);
                }

                else
                {
                    dao.Alterar1(curriculo);
                    CurriculoViewModel Select = dao.Consulta(curriculo.cpf);
                    return View("CadastroEditarFormacao", Select);
                }  
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }
        public IActionResult Salvar4(CurriculoViewModel curriculo, string id)
        {
            try
            {
                if (curriculo.idioma1 == null)
                {
                    curriculo.idioma1 = "";
                }

                if (curriculo.idioma2 == null)
                {
                    curriculo.idioma2 = "";
                }
                if (curriculo.idioma3 == null)
                {
                    curriculo.idioma3 = "";
                }
           
                CurriculoDAO dao = new CurriculoDAO();
                if (curriculo.cpf == null)
                {
                    curriculo.cpf = id;
                }

                    dao.Inserir4(curriculo);

                return View("CadastroConfirma");
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }
        public IActionResult Salvar3(CurriculoViewModel curriculo, string id)
        {
            try
            {
                if (curriculo.experiencia1Ate == null)
                {
                    curriculo.experiencia1Ate = "";
                }

                if (curriculo.experiencia1Desde == null)
                {
                    curriculo.experiencia1Desde = "";
                }
                if (curriculo.experiencia2Ate == null)
                {
                    curriculo.experiencia2Ate = "";
                }
                if (curriculo.experiencia2Desde == null)
                {
                    curriculo.experiencia2Desde = "";
                }
                if (curriculo.experiencia3Ate == null)
                {
                    curriculo.experiencia3Ate = "";
                }
                if (curriculo.experiencia3Desde == null)
                {
                    curriculo.experiencia3Desde = "";
                }
                if (curriculo.experiencia2 == null)
                {
                    curriculo.experiencia2 = "";
                }
                if (curriculo.experiencia3 == null)
                {
                    curriculo.experiencia3 = "";
                }
                if (curriculo.experiencia1 == null)
                {
                    curriculo.experiencia1 = "";
                }

                CurriculoDAO dao = new CurriculoDAO();
                if (curriculo.cpf == null)
                {
                    curriculo.cpf = id;
                }

                if (dao.Consulta(curriculo.cpf) == null)
                {
                    dao.Inserir3(curriculo);
                    CurriculoViewModel Select = dao.Consulta(id);
                    return View("CadastroIdiomas", Select);
                }

                else
                {
                    dao.Inserir3(curriculo);
                    CurriculoViewModel Select = dao.Consulta(id);
                    return View("CadastroEditarIdiomas", Select);
                }
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }
        public IActionResult Salvar2(CurriculoViewModel curriculo, string id)
        {
            try
            {
                CurriculoDAO dao = new CurriculoDAO();

                if (curriculo.curso1 == null)
                {
                    curriculo.curso1 = "";
                }
                if (curriculo.curso2 == null)
                {
                    curriculo.curso2 = "";
                }
                if (curriculo.curso3 == null)
                {
                    curriculo.curso3 = "";
                }
                if (curriculo.curso4 == null)
                {
                    curriculo.curso4 = "";
                }
                if (curriculo.curso5 == null)
                {
                    curriculo.curso5 = "";
                }
                if (curriculo.cpf == null)
                {
                    curriculo.cpf = id;
                }

                if (dao.Consulta(curriculo.cpf) == null)
                {
                    dao.Inserir2(curriculo);
                    CurriculoViewModel Select = dao.Consulta(id);
                    return View("CadastroEditarExpProf", Select);
                    //return RedirectToAction("CadastroExpProf", curriculo);
                }

                else
                {
                    dao.Inserir2(curriculo);
                    CurriculoViewModel Select = dao.Consulta(id);
                    return View("CadastroEditarExpProf", Select);
                    //return RedirectToAction("CadastroEditarExpProf", curriculo);
                }
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

        //private void ValidaDadosPessoal(CurriculoViewModel curriculo, string operacao)
        //{
        //    //Validação das informações pessoais
        //    if (!ValidaCPF(curriculo.cpf))
        //        ModelState.AddModelError("cpf", "CPF invalido");
        //    if (string.IsNullOrEmpty(curriculo.nome))
        //        ModelState.AddModelError("nome", "Nome invalido");
        //    if (curriculo.celular.Length < 0 && curriculo.celular.Length != 12)
        //        ModelState.AddModelError("celular", "Número de celular invalido");
        //    if (string.IsNullOrEmpty(curriculo.email))
        //        ModelState.AddModelError("email", "Email invalido");
        //    if (string.IsNullOrEmpty(curriculo.cargoPretendido))
        //        ModelState.AddModelError("cargo Prentendido", "Cargo pretendido invalido");

        //    //Validação das informações de endereço
        //    if (string.IsNullOrEmpty(curriculo.cep))
        //        ModelState.AddModelError("CEP", "CEP invalido");
        //    if ((string.IsNullOrEmpty(curriculo.rua)))
        //        ModelState.AddModelError("Rua", "Rua invalida");
        //    if ((string.IsNullOrEmpty(curriculo.numeroEnd)))
        //        ModelState.AddModelError("Numero", "Numero invalido");
        //    if ((string.IsNullOrEmpty(curriculo.bairro)))
        //        ModelState.AddModelError("Bairro", "Bairro invalido");
        //}


        //public static bool ValidaCPF(string cpf)
        //{
        //    int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        //    int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        //    string tempCpf;
        //    string digito;
        //    int soma;
        //    int resto;
        //    if (cpf.Length != 11)
        //        return false;
        //    tempCpf = cpf.Substring(0, 9);
        //    soma = 0;

        //    for (int i = 0; i < 9; i++)
        //        soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
        //    resto = soma % 11;
        //    if (resto < 2)
        //        resto = 0;
        //    else
        //        resto = 11 - resto;
        //    digito = resto.ToString();
        //    tempCpf = tempCpf + digito;
        //    soma = 0;
        //    for (int i = 0; i < 10; i++)
        //        soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
        //    resto = soma % 11;
        //    if (resto < 2)
        //        resto = 0;
        //    else
        //        resto = 11 - resto;
        //    digito = digito + resto.ToString();
        //    return cpf.EndsWith(digito);
        //}
    }
}

