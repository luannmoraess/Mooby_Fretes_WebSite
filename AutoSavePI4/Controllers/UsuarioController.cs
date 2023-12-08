using Microsoft.AspNetCore.Mvc;
using AutoSavePI4.Entidades;

namespace AutoSavePI4.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly Contexto contexto;

        public UsuarioController(Contexto contexto)
        {
            this.contexto = contexto;
        }
        public IActionResult CadastroCaminhoneiro()
        {
            return View();
        }
        public IActionResult CadastroVeiculo()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Salvar(Usuario collection)
        {
            try
            {
                if (collection.Codigo == 0)
                {
                    Usuario novo = new Usuario();
                    novo = collection;
                    contexto.USUARIO.Add(novo);
                    contexto.SaveChanges();
                    return RedirectToAction("CadastroVeiculo");
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        contexto.USUARIO.Update(collection);
                        contexto.SaveChanges();
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        return View(collection);
                    }
                }

            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult SalvarCaminhao(Caminhao collection)
        {
            try
            {
                if (collection.Codigo == 0)
                {
                    Caminhao novo = new Caminhao();
                    novo = collection;
                    contexto.CAMINHAO.Add(novo);
                    contexto.SaveChanges();
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        contexto.CAMINHAO.Update(collection);
                        contexto.SaveChanges();
                        return RedirectToAction("Fretes/Index");
                    }
                    else
                    {
                        return View(collection);
                    }
                }

            }
            catch
            {
                return View();
            }
        }
        public IActionResult Editar(int cod)
        {
            return View("CadastroCaminhoneiro", contexto.USUARIO.Where(a => a.Codigo == cod).FirstOrDefault());
        }
    }
}
