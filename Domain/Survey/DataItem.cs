using System.Collections.Generic;

namespace Domain.Survey
{
    public class DataItem
    {
        public string Ident { get; set; }
        public List<string> Values { get; set; } = new List<string>();
    }
}
