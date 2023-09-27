using System.Collections.Generic;

namespace TSAPI.Public.Domain.Metadata
{
    /// <summary>A variable or question within a survey</summary>
    public class Variable 
    {
        /// <summary>Unique identifier for this variable</summary>
        public string VariableId { get; set; }
        /// <summary>The order of this variable within the overall survey</summary>
        public int Ordinal { get; set; }
        /// <summary>The type of variable (e.g. Open, closed, loop etc..)</summary>
        public string Type { get; set; }
        /// <summary>Human-readable name for this variable</summary>
        public string Name { get; set; }
        /// <summary>Label or question text for the variable</summary>
        public Label Label { get; set; }
        /// <summary>Special use type (e.g. language, weighting) for this variable</summary>
        public string Use { get; set; }
        /// <summary>Any pre-defined responses for this variable</summary>
        public VariableValues Values { get; set; }
        /// <summary>Maximum number of responses that can be given for this variable</summary>
        public int MaxResponses { get; set; }
        /// <summary>Looped child variables for this variable (when type = Loop)</summary>
        public List<Variable> LoopedVariables { get; set; }
        /// <summary>List of other specify child variables for this variable (when type = Single or Multiple)</summary>
        public List<OtherSpecifyVariable> OtherSpecifyVariables { get; set; }
    }

    public class VariableValues
    {
        public ValueRange Range { get; set; }
        public List<Value> Values { get; set; }
    }

    public class Value
    {
        public string ValueId { get; set; }
        public string Code { get; set; }
        public Label Label { get; set; }
        public float? Score { get; set; }

        /// <summary>(Optional) Links this value to a value in another variable, to express "Shared" or "Linked" responses between questions</summary>
       // public ValueRef Ref { get; set; }
    }

    public class ValueRange
    {
        public string From { get; set; }
        public string To { get; set; }
    }

   
}
