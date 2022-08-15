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
    public class ValuesController : ApiController
    {
        private Model1 db = new Model1();
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpPost, ActionName("Delete")]
        public async Task<HttpResponseMessage> DeleteConfirmed(int id)
        {

            var student = await db.Lista_Canciones.FindAsync(id);
            if (student == null)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new
                {
                    success = false,
                    responseText = "Error no existe canción",
                    responseInt = 0
                });
            }

            try
            {
                db.Lista_Canciones.Remove(student);
                await db.SaveChangesAsync();
                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    success = true,
                    responseInt = 1,
                    responseText = "Cancion Eliminada Correctamente",
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
