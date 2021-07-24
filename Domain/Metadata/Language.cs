using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Metadata
{
    public class Language
    {
        public string Ident { get; set; }
        public string Name { get; set; }
        public List<Language> SubLanguages { get; set; }
    }
}
