using System.Collections.Generic;

namespace TSAPI.Public.Domain.Metadata
{   
    ///<summary>Represents a logical section within a survey (e.g. Demographics)</summary>
    public class Section
    {
        public Label Label { get; set; }
        public List<Variable> Variables { get; set; } = new List<Variable>();
        public List<Grid> Grids { get; set; } = new List<Grid>();
    }
}