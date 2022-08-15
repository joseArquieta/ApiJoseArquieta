using ApiJoseArquieta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ApiJoseArquieta.Controllers
{
    public class _CrearProductoController : ApiController
    {
        private Model1 db = new Model1();

        public async Task<HttpResponseMessage> PostCreaCancion(Lista_Canciones header)
        {
            try
            {
                var agreeCanciones = new List<Lista_Canciones>();
                agreeCanciones.Add(new Lista_Canciones()
                {
                    Titulo = header.Titulo,
                    Grupo = header.Grupo,
                    Ano = header.Ano,
                    Genero = header.Genero
                });

                var productInsert = db.Lista_Canciones.AddRange(agreeCanciones);
                await db.SaveChangesAsync();
            
                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    success = true,
                    responseInt = 1,
                    responseText = "Cancion Agregada Correctamente",

                });

            }
            catch (Exception exc)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, new
                {
                    success = false,
                    responseText = exc.Message,
                    responseInt = 0
                });
            }

        }
    }
}