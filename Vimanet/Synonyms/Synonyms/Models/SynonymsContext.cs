using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Synonyms.Models
{
    public class SynonymsContext:DbContext
    {
        public DbSet<SynonymDto> Synonyms { get; set; }
    }
}