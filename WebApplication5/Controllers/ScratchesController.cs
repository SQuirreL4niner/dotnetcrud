using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication5.DAL;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class ScratchesController : ApiController
    {
        private ScratchContext db = new ScratchContext();
        private AuthorRepository _authorRepo = new AuthorRepository();


        // GET: api/Scratches
        public List<Scratch> GetScratchItems()
        {
            return _authorRepo.GetAuthors(10, "ASC");
        }

        // GET: api/Scratches/n
        [ResponseType(typeof(Scratch))]
        public IHttpActionResult GetScratch(int id)
        {
            Scratch scratch = _authorRepo.GetSingleAuthor(id);
            if (scratch == null)
            {
                return NotFound();
            }

            return Ok(scratch);
        }

        // PUT: api/Scratches/n
        [ResponseType(typeof(void))]
        public IHttpActionResult PutScratch(int id, Scratch scratch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != scratch.Id)
            {
                return BadRequest();
            }

            _authorRepo.UpdateAuthor(id, scratch);

            return StatusCode(HttpStatusCode.Accepted);
        }

        // POST: api/Scratches
        [ResponseType(typeof(Scratch))]
        public IHttpActionResult PostScratch(Scratch scratch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _authorRepo.InsertAuthor(scratch);

            return Ok(scratch);
        }

        // DELETE: api/Scratches/n
        [ResponseType(typeof(Scratch))]
        public IHttpActionResult DeleteScratch(int id)
        {
            Scratch scratch = _authorRepo.GetSingleAuthor(id);
            if (scratch == null)
            {
                return NotFound();
            }
            _authorRepo.DeleteAuthor(id);

            return Ok(scratch.FirstName + " Deleted");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ScratchExists(int id)
        {
            return db.ScratchItems.Count(e => e.Id == id) > 0;
        }
    }
}