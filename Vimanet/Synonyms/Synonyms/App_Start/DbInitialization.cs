using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Synonyms.Models;

namespace Synonyms.App_Start
{
    public class DbInitialization
    {
        public static void CreateDatabaseIfNotExists()
        {
            System.Data.Entity.Database.SetInitializer(new CreateDatabaseIfNotExists<SynonymsContext>());
        }
        public static void PrepareDummyData()
        {
            using (var synonymsContext = new SynonymsContext())
            {
                if (!synonymsContext.Synonyms.Any())
                {
                    synonymsContext.Synonyms.Add(new SynonymDto() {Term = "computer", Synonyms = "laptop,notebook"});
                    synonymsContext.SaveChanges();
                }
            }
        }
    }
}