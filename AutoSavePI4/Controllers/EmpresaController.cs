using AutoSavePI4.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace AutoSavePI4.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly Contexto contexto;

        public EmpresaController(Contexto contexto)
        {
            this.contexto = contexto;
        }
        public IActionResult CadastroEmpresa()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Salvar(Empresa collection)
        {
            try
            {
                if (collection.Codigo == 0)
                {
                    Empresa novo = new Empresa();
                    novo = collection;
                    contexto.EMPRESA.Add(collection);
                    contexto.SaveChanges();
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        contexto.EMPRESA.Update(collection);
                        contexto.SaveChanges();
                        return RedirectToAction("Index", "Fretes");
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
            return View("CadastroEmpresa", contexto.EMPRESA.Where(a => a.Codigo == cod).FirstOrDefault());
        }
    }
}
