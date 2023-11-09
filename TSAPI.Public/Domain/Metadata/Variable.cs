using System.Collections.Generic;

namespace TSAPI.Public.Domain.Metadata
{
    /// <summary>A variable or question within a survey</summary>
    public class Variable 
    {
        #region "Member Variables"
        private string _type { get; set; }
        private string _use { get; set; }
        #endregion

        ///<summary>Unique identifier for this variable</summary>
        public string VariableId { get; set; }
        ///<summary>The order of this variable within the overall survey</summary>
        public int Ordinal { get; set; }
        ///<summary>The type of variable. Value values are: "single", "multiple", "quantity", "character", "logical", "date", "time"</summary>
        public string Type { get { return _type; }  
            set {
                if (string.IsNullOrEmpty(value))
                    throw new System.ArgumentException($"Variable Type is mandatory and cannot be blank");

                switch (value.ToLower())
                {
                    case "single":
                    case "multiple":
                    case "quantity":
                    case "character":
                    case "logical":
                    case "date":
                    case "time":
                        _type = value;
                        break;
                    default:
                        throw new System.ArgumentException($"Invalid 'Type' value specified. Valid values are 'single', 'multiple', 'quantity', 'character', 'logical', 'date', 'time'");
                }
            } 
        }
        ///<summary>Human-readable name for this variable</summary>
        public string Name { get; set; }
        ///<summary>Label or question text for the variable</summary>
        public Label Label { get; set; }
        ///<summary>Special use type for this variable. Valid values are: "serial", "weight", "language", "wave", "translation"</summary>
        public string Use { 
            get { 
                return _use;  
            }   
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    switch (value.ToLower())
                    {
                        case "serial":
                        case "weighting":
                        case "language":
                        case "wave":
                        case "translation":
                            _use = value;
                            break;
                        default:
                            throw new System.ArgumentException($"Invalid 'Use' value specified. Valid values are 'serial', 'weight', 'language', 'wave', 'translation'");
                    }
                }
            }
        }
        /// <summary>List of closed-end responses for this variable</summary>
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
        /// <summary>Identifier for this list of variable values. Can be used to identify value lists that are shared between variables</summary>
        public string ValueListId { get; set; }
        /// <summary>Defines an overall range of legal values for a variable</summary>
        public ValueRange Range { get; set; }
        /// <summary>Defines a set of response values for closed-end variables</summary>
        public List<Value> Values { get; set; }
    }

    public class Value
    {
        /// <summary>Unique identifier for this response value</summary>
        public string ValueId { get; set; }
        /// <summary>Entry code for this response value</summary>
        public string Code { get; set; }
        /// <summary>The human readable label for this response value</summary>
        public Label Label { get; set; }
        /// <summary>
        /// The optional score attribute can only be used when the variable is of type single.
        /// It allows score values to be assigned to the individual code values to be used for computing statistics such as Mean, Standard Deviation etc.
        /// The score_value must be a number, and may be positive, negative or zero, with or without a decimal point and decimal places.The omission of a score
        /// implies that records having that value code should be omitted from the base for any statistical computation for that variable. 
        /// </summary>
        public float? Score { get; set; }
    }

    public class ValueRange
    {
        /// <summary>Defines the lower band of a range value. Must be lower than or equal to the "To" value</summary>
        public string From { get; set; }
        /// <summary>Defines the upper band of range value. Must be greater than or equal to the "From" value</summary>
        public string To { get; set; }
    }
}
