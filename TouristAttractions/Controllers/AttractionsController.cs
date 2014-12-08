using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Spatial;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using TouristAttractions.Models;

namespace TouristAttractions.Controllers
{
    public class AttractionsController : ApiController
    {
        private TourismContext db = new TourismContext();

        // GET api/Attractions
        public IEnumerable<TouristAttraction> GetTouristAttractions()
        {
            return db.TouristAttractions.AsEnumerable();
        }

        // GET api/Attractions/5
        public TouristAttraction GetTouristAttraction(int id)
        {
            TouristAttraction touristattraction = db.TouristAttractions.Find(id);
            if (touristattraction == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return touristattraction;
        }

        public TouristAttraction GetTouristAttraction(double longitude, double lastitude)
        {
            var location = DbGeography.FromText(
                string.Format("POINT ({0} {1})", longitude, lastitude));
            var query = from c in db.TouristAttractions
                        orderby c.Location.Distance(location)
                        select c;
            return query.FirstOrDefault();
        }
        // PUT api/Attractions/5
        public HttpResponseMessage PutTouristAttraction(int id, TouristAttraction touristattraction)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != touristattraction.TouristAttractionId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(touristattraction).State = EntityState.Modified;

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

        // POST api/Attractions
        public HttpResponseMessage PostTouristAttraction(TouristAttraction touristattraction)
        {
            if (ModelState.IsValid)
            {
                db.TouristAttractions.Add(touristattraction);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, touristattraction);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = touristattraction.TouristAttractionId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Attractions/5
        public HttpResponseMessage DeleteTouristAttraction(int id)
        {
            TouristAttraction touristattraction = db.TouristAttractions.Find(id);
            if (touristattraction == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.TouristAttractions.Remove(touristattraction);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, touristattraction);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}