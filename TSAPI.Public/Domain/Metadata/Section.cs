using System.Collections.Generic;

namespace TSAPI.Public.Domain.Metadata
{
    ///<summary>Object representing a section within a survey. Sections are used to partition variables together into logical groups (e.g. Screener, System, Demographics, Main Survey etc…)</summary>
    public class Section
    {
        /// <summary>Human readable label used to name to a section</summary>
        public Label Label { get; set; }

        /// <summary>List of variables </summary>
        public List<Variable> Variables { get; set; } = new List<Variable>();

        /// <summary>List of sub-sections (if any) within this section</summary>
        public List<Section> Sections { get; set; }
    }
}