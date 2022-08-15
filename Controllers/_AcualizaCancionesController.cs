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
    public class _AcualizaCancionesController : ApiController
    {
        private Model1 db = new Model1();

        public async Task<HttpResponseMessage> AcualizaCanciones(Lista_Canciones datos)
        {
            try
            {
                var exitCanciones = db.Lista_Canciones.FirstOrDefault(f=> f.id_Cancion == datos.id_Cancion);
                exitCanciones.Titulo = datos.Titulo;
                exitCanciones.Grupo = datos.Grupo;
                exitCanciones.Ano = datos.Ano;
                exitCanciones.Genero = datos.Genero;

                await db.SaveChangesAsync();

                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    success = true,
                    responseInt = 1,
                    responseText = "Cancion actualizada Correctamente",

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