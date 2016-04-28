using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Synonyms.Models;

namespace Synonyms.Controllers.api
{
    public class SynonymsController : ApiController
    {
        // GET api/synonyms
        public IEnumerable<SynonymDto> Get()
        {
            return SynonymDto.GetSynonyms();
        }

        // POST api/synonyms
        public void Post([FromBody]SynonymDto value)
        {
            using (var context = new SynonymsContext())
            {
                context.Synonyms.Add(value);
                context.SaveChanges();
            }
        }
    }
}
