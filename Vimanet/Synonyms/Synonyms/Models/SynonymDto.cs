using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Synonyms.Models
{
    [Table("Synonyms")]
    public class SynonymDto
    {
        public int Id { get; set; }
        public string Term { get; set; }
        public string Synonyms { get; set; }


        /// <summary>
        /// Preparing a groups of synonyms from database
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<SynonymDto> GetSynonyms()
        {
            var context  = new SynonymsContext();
            var synonymsGroups = new List<SynonymDto>();
            foreach (var syn in context.Synonyms)
            {
                var existingSynonym = synonymsGroups.Where(it => it.Term == syn.Term);
                if (existingSynonym.Any())
                {
                    foreach (var ex in existingSynonym)
                    {
                        ex.Synonyms = ex.Synonyms+","+syn.Synonyms;
                    }
                }
                else
                {
                    synonymsGroups.Add(syn);
                }
                var synonyms = syn.Synonyms.Split(',');
                foreach (var itemS in synonyms)
                {
                    synonymsGroups.Add(new SynonymDto(){Term = itemS,Synonyms = syn.Term});
                }
            }
            return synonymsGroups;
        }
    }
}