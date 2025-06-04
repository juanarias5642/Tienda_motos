using lib_dominio.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_presentacion.Pages
{
    public class UsuarioModel : PageModel
    {
        public bool EstaLogueado = false;

        [BindProperty]
        public string? Email { get; set; }

        [BindProperty]
        public string? Contrasena { get; set; }

        public void OnGet()
        {
            var variable_session = HttpContext.Session.GetString("Usuario");
            if (!string.IsNullOrEmpty(variable_session))
            {
                EstaLogueado = true;
            }
        }

        public void OnPostBtClean()
        {
            try
            {
                Email = string.Empty;
                Contrasena = string.Empty;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtEnter()
        {
            try
            {
                if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Contrasena))
                {
                    OnPostBtClean();
                    return;
                }

                if (Contrasena != "123")
                {
                    OnPostBtClean();
                    return;
                }

                // Guardar en sesión
                HttpContext.Session.SetString("Usuario", Email!);
                EstaLogueado = true;

                // Redirigir según el tipo de usuario
                if (Email!.ToLower() == "admin")
                {
                    HttpContext.Response.Redirect("/Usuario");
                }
                else
                {
                    HttpContext.Response.Redirect("Ventanas/Usuario");
                }

                OnPostBtClean();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }


        public void OnPostBtClose()
        {
            try
            {
                HttpContext.Session.Clear();
                HttpContext.Response.Redirect("/");
                EstaLogueado = false;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
    }
}
