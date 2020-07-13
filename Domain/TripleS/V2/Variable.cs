using System.Collections.Generic;
using System.Linq;

namespace Domain.TripleS.V2
{
    public class Variable 
    {
        public enum VariableType
        {
            Single,
            Multiple,
            Quantity,
            Character,
            Logical,
            Date,
            Time
        }

        public string Ident { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public Label Label { get; set; }
        public string Filter { get; set; }
        public string Use { get; set; }
        public VariableValues Values { get; set; }
    }

    public class VariableValues
    {
        public ValueRange Range { get; set; }
        public List<Value> Values { get; set; }
    }

    public class Value
    {
        public string Code { get; set; }
        public string Text { get; set; }
        public int? Score { get; set; }
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
        public string Mode { get; set; }
        public string Text { get; set; }
    }
}
