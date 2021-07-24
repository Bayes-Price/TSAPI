using System.Collections.Generic;
using System.Linq;

namespace Domain.Metadata
{
    public class Variable 
    {
        public string Ident { get; set; }
        public Enums.VariableType Type { get; set; }
        public int MaxResponses { get; set; }
        public string Name { get; set; }
        public Label Label { get; set; }
        public Enums.UseType Use { get; set; }
        public VariableValues VariableValues { get; set; }
        public Enums.ParentType ParentType { get; set; }
        public List<Variable> Variables { get; set; } = new List<Variable>();

        //public string Filter { get; set; }
        //public Enums.Format Format { get; set; }
        //public string ParentIdent { get; set; }
    }

    public class VariableValues
    {
        public ValueRange Range { get; set; }
        public List<Value> Values { get; set; }
    }

    public class Value
    {
        public string Ident { get; set; }
        public string Code { get; set; }
        public Label Label { get; set; }
        public float? Score { get; set; }
    }

    public class ValueRange
    {
        public string From { get; set; }
        public string To { get; set; }
    }

    public class Label
    {
        public Label() { } 
        public Label(string text) {Text = text; }
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
