using System.Collections.Generic;
using System.Linq;

namespace TSAPI.Public.Domain.Metadata
{
    /// <summary>Object representing a text label within a survey</summary>
    public class Label
    {
        public Label() { }
        public Label(string text) { Text = text; }
        public Label(string text, params AltLabel[] altLabels) { Text = text; AltLabels = altLabels.ToList(); }

        /// <summary>The main/default text used as a label</summary>
        public string Text { get; set; }
        /// <summary>List of alternative labels use that can be used instead of Text value in certain circumstances</summary>
        public List<AltLabel> AltLabels { get; set; } = new List<AltLabel>();
    }

    /// <summary>Object representing an alternative text label</summary>
    public class AltLabel
    {
        /// <summary>Signals whether a text should be used during interviewing and/or analysis. Two explicit modes are available: “interview” and “analysis”. In the absence of a mode specification, the appropriate text is assumed to be used in both modes. Allowable values are "interview" and "analysis" </summary>
        public string Mode { get; set; }
        /// <summary>Text value to use as an alternative label</summary>
        public string Text { get; set; }
        /// <summary>Indicates that an alt label should be used when interviewing in a given language</summary>
        public string LanguageId { get; set; }
    }
}
