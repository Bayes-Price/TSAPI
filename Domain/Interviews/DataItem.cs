using System.Collections.Generic;

namespace Domain.Interviews
{
    public class DataItem
    {
        public string Ident { get; set; }
        public List<string> Values { get; set; } = new List<string>();
        public ParentRef ParentIdent { get; set; }
    }

    public class ParentRef
    {
        public string ParentVariableIdent { get; set; }
        public string ParentValueIdent { get; set; }
    }

}
