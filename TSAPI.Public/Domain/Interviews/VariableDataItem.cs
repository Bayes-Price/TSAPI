using System.Collections.Generic;

namespace TSAPI.Public.Domain.Interviews
{
    /// <summary>Object representing a data value or response for a variable in an interview</summary>
    public class VariableDataItem
    {
        /// <summary>A specified variable response</summary>
        public string Value { get; set; }

        /// <summary>
        /// (Optional) state of a response. Permitted values are "selected", "notSelected", "notShown"
        /// Used to provide information about exactly which closed end responses were shown/selected/unselected in a given iterview
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// (Optional) Data for looped variables which are child responses connected to a VariableDataItem
        /// </summary>
        public List<VariableData> LoopedVariableData { get; set; }
    }
}
