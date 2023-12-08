using AutoSavePI4.Entidades;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AutoSavePI4.Controllers
{
    public class LoginController : Controller
    {
        private readonly Contexto contexto;

        public LoginController(Contexto contexto)
        {
            this.contexto = contexto;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Entrar(string email, string senha)
        {
            Usuario usuarioLogado = contexto.USUARIO.Where(a => a.Email == email && a.Senha == senha).FirstOrDefault();


            var claims = new List<Claim>();
            if (usuarioLogado == null)
            {
                Empresa empresaLogado = contexto.EMPRESA.Where(a => a.Email == email && a.Senha == senha).FirstOrDefault();

                if (empresaLogado == null)
                {
                    TempData["erro"] = "Usuário e/ou senha inválidos";
                    return View("Index");
                }
                else
                {
                    
                    claims.Add(new Claim(ClaimTypes.Name, empresaLogado.Nome));
                    claims.Add(new Claim(ClaimTypes.Sid, empresaLogado.Codigo.ToString()));
                }
            }
            else
            {
                
                claims.Add(new Claim(ClaimTypes.Name, usuarioLogado.Nome));
                claims.Add(new Claim(ClaimTypes.Sid, usuarioLogado.Codigo.ToString()));
            }

            var userIdentity = new ClaimsIdentity(claims, "Acesso");

            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
            await HttpContext.SignInAsync("CookieAuthentication", principal, new AuthenticationProperties());

            

            return Redirect("/Fretes/index");
        }
        
        public async Task<IActionResult> Logoff()
        {
            
            await HttpContext.SignOutAsync("CookieAuthentication");
            return Redirect("Index");
        }
    }
}
