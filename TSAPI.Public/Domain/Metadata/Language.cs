using System.Collections.Generic;

namespace TSAPI.Public.Domain.Metadata
{
    public class Language
    {
        public string Ident { get; set; }
        public string Name { get; set; }
        public List<Language> SubLanguages { get; set; }
    }
}
