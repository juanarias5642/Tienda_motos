using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;             
using Microsoft.AspNetCore.Hosting;           
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace asp_presentacion.Pages.Ventanas
{
    public class MotocicletasModel : PageModel
    {
        private IMotocicletasPresentacion? iPresentacion = null;
        private IChasisesPresentacion? iChasisesPresentacion = null;
        private IReferenciasPresentacion? iReferenciasPresentacion = null;
        private ITiposPresentacion? iTiposPresentacion = null;
        private IMarcasPresentacion? iMarcasPresentacion = null;
        private readonly IWebHostEnvironment _env;  

        public MotocicletasModel(IMotocicletasPresentacion iPresentacion,
            IChasisesPresentacion iChasisesPresentacion,
            IReferenciasPresentacion iReferenciasPresentacion,
            ITiposPresentacion iTiposPresentacion,
            IMarcasPresentacion iMarcasPresentacion,


            IWebHostEnvironment env)            
        {
            try
            {
                this.iPresentacion = iPresentacion;
                this.iChasisesPresentacion = iChasisesPresentacion;
                this.iReferenciasPresentacion = iReferenciasPresentacion;
                this.iTiposPresentacion = iTiposPresentacion;
                this.iMarcasPresentacion = iMarcasPresentacion;
                this._env = env;                  
                Filtro = new Motocicletas();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        [BindProperty]
        public IFormFile? FormFile { get; set; }   
        [BindProperty] public Enumerables.Ventanas Accion { get; set; }
        [BindProperty] public Motocicletas? Actual { get; set; }
        [BindProperty] public Motocicletas? Filtro { get; set; }
        [BindProperty] public List<Motocicletas>? Lista { get; set; }
        [BindProperty] public List<Chasises>? Chasises { get; set; }
        [BindProperty] public List<Referencias>? Referencias { get; set; }
        [BindProperty] public List<Tipos>? Tipos { get; set; }
        [BindProperty] public List<Marcas>? Marcas { get; set; }

        public virtual void OnGet() { OnPostBtRefrescar(); }

        public void OnPostBtRefrescar()
        {
            try
            {
                var variable_session = HttpContext.Session.GetString("Usuario");
                if (String.IsNullOrEmpty(variable_session))
                {
                    HttpContext.Response.Redirect("/");
                    return;
                }

                Filtro!.Cod_moto = Filtro!.Cod_moto ?? "";

                Accion = Enumerables.Ventanas.Listas;

                var task = this.iPresentacion!.PorCodigo(Filtro!);
                task.Wait();
                Lista = task.Result;
                Actual = null;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        private void CargarCombox()
        {
            try
            {
                var task = this.iChasisesPresentacion!.Listar();
                var task2 = this.iReferenciasPresentacion!.Listar();
                var task3 = this.iMarcasPresentacion!.Listar();
                var task4 = this.iTiposPresentacion!.Listar();
                task.Wait();
                task2.Wait();
                task3.Wait();
                task4.Wait();
                Chasises = task.Result;
                Referencias = task2.Result;
                Marcas = task3.Result;
                Tipos = task4.Result;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtNuevo()
        {
            try
            {
                Accion = Enumerables.Ventanas.Editar;
                Actual = new Motocicletas();
                CargarCombox();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtModificar(string data)
        {
            try
            {
                OnPostBtRefrescar();
                CargarCombox();
                Accion = Enumerables.Ventanas.Editar;
                Actual = Lista!.FirstOrDefault(x => x.Id.ToString() == data);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtGuardar()
        {
            try
            {
                Accion = Enumerables.Ventanas.Editar;

                Task<Motocicletas>? task = null;
                if (Actual!.Id == 0)
                    task = this.iPresentacion!.Guardar(Actual!)!;
                else
                    task = this.iPresentacion!.Modificar(Actual!)!;
                task.Wait();
                Actual = task.Result;

                if (FormFile != null && FormFile.Length > 0)
                {
                    var carpeta = Path.Combine(_env.WebRootPath, "Imagenes");
                    if (!Directory.Exists(carpeta))
                        Directory.CreateDirectory(carpeta);

                    var ext = Path.GetExtension(FormFile.FileName);
                    var fileName = $"moto-{Actual.Id}{ext}";
                    var rutaFis = Path.Combine(carpeta, fileName);

                    using var fs = new FileStream(rutaFis, FileMode.Create);
                    FormFile.CopyTo(fs);

                    Actual.ImagenUrl = $"/Imagenes/{fileName}";
                    var updateTask = this.iPresentacion!.Modificar(Actual)!;
                    updateTask.Wait();
                }

                Accion = Enumerables.Ventanas.Listas;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtBorrarVal(string data)
        {
            try
            {
                OnPostBtRefrescar();
                Accion = Enumerables.Ventanas.Borrar;
                Actual = Lista!.FirstOrDefault(x => x.Id.ToString() == data);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtBorrar()
        {
            try
            {
                var task = this.iPresentacion!.Borrar(Actual!);
                Actual = task.Result;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtCancelar()
        {
            try
            {
                Accion = Enumerables.Ventanas.Listas;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtCerrar()
        {
            try
            {
                if (Accion == Enumerables.Ventanas.Listas)
                    OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
    }
}

