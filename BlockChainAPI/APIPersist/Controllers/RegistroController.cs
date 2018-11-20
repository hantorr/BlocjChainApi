using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIPersist.Controllers
{
    public class RegistroController : ApiController
    {
        //https://www.c-sharpcorner.com/article/how-to-create-webapi-in-asp-net-mvc-with-c-sharp/
        private ModelBCDBContainer db = new ModelBCDBContainer();
        // GET api/<controller>
        public IEnumerable<RegistroET> Get()
        {
            return db.Registro.AsEnumerable();
        }

        // GET api/<controller>/5
        public RegistroET Get(int id)
        {
            RegistroET reg = db.Registro.Find(id);
            if (reg == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return reg;
        }

        // POST api/<controller>
        public HttpResponseMessage Post(RegistroET registro)
        {
            if (ModelState.IsValid)
            {
                db.Registro.Add(registro);
                db.SaveChanges();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, registro);
                response.Headers.Location = new Uri(Url.Link("DefaulApi", new
                {
                    id = registro.Id
                }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, RegistroET registro)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            if (id != registro.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(registro).State = System.Data.EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {

        }
    }
}