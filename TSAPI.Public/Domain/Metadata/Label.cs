using System.Collections.Generic;
using System.Linq;

namespace TSAPI.Public.Domain.Metadata
{
    public class Label
    {
        public Label() { }
        public Label(string text) { Text = text; }
        public Label(string text, params AltLabel[] altLabels) { Text = text; AltLabels = altLabels.ToList(); }

        public string Text { get; set; }
        public List<AltLabel> AltLabels { get; set; } = new List<AltLabel>();
    }

    public class AltLabel
    {
        public Enums.AltLabelMode Mode { get; set; }
        public string Text { get; set; }
        public string LangIdent { get; set; }

    }
}
