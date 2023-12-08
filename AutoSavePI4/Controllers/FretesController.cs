using AutoSavePI4.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoSavePI4.Controllers
{
    [Authorize(AuthenticationSchemes = "CookieAuthentication")]
    public class FretesController : Controller
    {        
        private readonly Contexto contexto;

        public FretesController(Contexto contexto)
        {
            this.contexto = contexto;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CadastrarFretes()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Salvar(Fretes collection)
        {
            try
            {
                if (collection.Codigo == 0)
                {
                    Fretes novo = new Fretes();
                    novo = collection;
                    contexto.FRETES.Add(collection);
                    contexto.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        contexto.FRETES.Update(collection);
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
    }
}
