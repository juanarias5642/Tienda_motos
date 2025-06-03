using asp_servicios.Nucleo;
using iTextSharp.text.pdf;
using iTextSharp.text;
using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MotocicletasController : ControllerBase
    {
        private IMotocicletasAplicacion? iAplicacion = null;
        private TokenController? tokenController = null;

        public MotocicletasController(IMotocicletasAplicacion? iAplicacion,
            TokenController tokenController)
        {
            this.iAplicacion = iAplicacion;
            this.tokenController = tokenController;
        }

        private Dictionary<string, object> ObtenerDatos()
        {
            var datos = new StreamReader(Request.Body).ReadToEnd().ToString();
            if (string.IsNullOrEmpty(datos))
                datos = "{}";
            return JsonConversor.ConvertirAObjeto(datos);
        }

        [HttpPost]
        public string Listar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();
                if (!tokenController!.Validate(datos))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }

                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion")!);
                respuesta["Entidades"] = this.iAplicacion!.Listar();

                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
        }

        [HttpPost]
        public string PorCodigo()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();
                if (!tokenController!.Validate(datos))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }

                var entidad = JsonConversor.ConvertirAObjeto<Motocicletas>(
                    JsonConversor.ConvertirAString(datos["Entidad"]));

                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion")!);
                respuesta["Entidades"] = this.iAplicacion!.PorCodigo(entidad);

                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
        }

        [HttpPost]
        public string Guardar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();
                if (!tokenController!.Validate(datos))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }

                var entidad = JsonConversor.ConvertirAObjeto<Motocicletas>(
                    JsonConversor.ConvertirAString(datos["Entidad"]));

                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion")!);
                entidad = this.iAplicacion!.Guardar(entidad);

                respuesta["Entidad"] = entidad!;
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
        }

        [HttpPost]
        public string Modificar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();
                if (!tokenController!.Validate(datos))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }

                var entidad = JsonConversor.ConvertirAObjeto<Motocicletas>(
                    JsonConversor.ConvertirAString(datos["Entidad"]));

                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion")!);
                entidad = this.iAplicacion!.Modificar(entidad);

                respuesta["Entidad"] = entidad!;
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
        }

        [HttpPost]
        public string Borrar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();
                if (!tokenController!.Validate(datos))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }

                var entidad = JsonConversor.ConvertirAObjeto<Motocicletas>(
                    JsonConversor.ConvertirAString(datos["Entidad"]));

                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion")!);
                entidad = this.iAplicacion!.Borrar(entidad);

                respuesta["Entidad"] = entidad!;
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
        }
        [HttpGet]
        public IActionResult ExportarPdf()
        {
            try
            {
                // 1. Configuramos la conexión y obtenemos la lista de Motocicletas
                iAplicacion.Configurar(Configuracion.ObtenerValor("StringConexion")!);
                List<Motocicletas> listaMotos = iAplicacion.Listar();

                // 2. Creamos el documento PDF en memoria
                using (var ms = new MemoryStream())
                {
                    // a) Creamos un documento iTextSharp con tamaño A4 y márgenes razonables
                    var document = new Document(PageSize.A4, 25, 25, 30, 30);
                    PdfWriter.GetInstance(document, ms);
                    document.Open();

                    // b) Agregamos un título en el PDF
                    var titulo = new Paragraph("Listado de Motocicletas")
                    {
                        Alignment = Element.ALIGN_CENTER,
                        SpacingAfter = 20f
                    };
                    document.Add(titulo);

                    // c) Creamos una tabla con X columnas (tantas como campos queramos mostrar)
                    //    En este ejemplo: Id, Código, Modelo, Cilindraje, Precio, Color, Tipo, Referencia, Marca, Chasis
                    //    (Si no te interesan los campos FK, puedes omitirlos o mostrarlos como número)
                    PdfPTable tabla = new PdfPTable(10)
                    {
                        WidthPercentage = 100f
                    };

                    // d) Agregamos los encabezados (cada celda de encabezado)
                    tabla.AddCell("Id");
                    tabla.AddCell("Código Moto");
                    tabla.AddCell("Modelo");
                    tabla.AddCell("Cilindraje");
                    tabla.AddCell("Precio");
                    tabla.AddCell("Color");
                    tabla.AddCell("Tipo (FK)");
                    tabla.AddCell("Referencia (FK)");
                    tabla.AddCell("Marca (FK)");
                    tabla.AddCell("Chasis (FK)");

                    // e) Rellenamos filas con los datos de cada motocicleta
                    foreach (var moto in listaMotos)
                    {
                        tabla.AddCell(moto.Id.ToString());
                        tabla.AddCell(moto.Cod_moto ?? "");
                        tabla.AddCell(moto.Modelo ?? "");
                        tabla.AddCell(moto.Cilindraje.ToString());
                        tabla.AddCell(moto.Precio.ToString("C2"));
                        tabla.AddCell(moto.Color ?? "");
                        tabla.AddCell(moto.Tipo.ToString());
                        tabla.AddCell(moto.Referencia.ToString());
                        tabla.AddCell(moto.Marca.ToString());
                        tabla.AddCell(moto.Chasis.ToString());
                    }

                    // f) Añadimos la tabla al documento y cerramos
                    document.Add(tabla);
                    document.Close();

                    // 3. Devolvemos el PDF para descarga
                    byte[] bytes = ms.ToArray();
                    string nombreArchivo = $"Motocicletas_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                    return File(
                        fileContents: bytes,
                        contentType: "application/pdf",
                        fileDownloadName: nombreArchivo
                    );
                }
            }
            catch (Exception ex)
            {
                // Si ocurre cualquier excepción, devolvemos un 500 con detalle
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}