namespace TSAPI.Public.Domain.Metadata
{
    /// <summary>Represents a hierarchical sub-questionnaire within a main survey</summary>
    public class Hierarchy
    {
        /// <summary>Unique identifier of a hierarchy item</summary>
        public string HierarchyId { get; set; }

        /// <summary>One or more parent elements may be defined for each level element. </summary>
        public ParentDetails Parent { get; set; } = new ParentDetails();

        /// <summary>The metadata (list of questions and variables) for a hierarchy item</summary>
        public SurveyMetadataBase Metadata { get; set; } = new SurveyMetadataBase();
    }

    public class ParentDetails
    {
        /// <summary>
        /// The level_ident of the associated parent level. For example, in a household-person hierarchy, the
        /// parent_level_ident of the person level would be the level_ident of the
        /// household level.
        /// </summary>
        public string Level { get; set; }
        /// <summary>
        /// The LinkVar is the name of the linking variable that appears in
        ///both child and parent data sets.It must be a quantity or character type
        ///variable. This variable must have the same name in the different (parent and
        ///child) data sets.The variable used as the linking variable must, at the “parent”
        ///level, have unique and unduplicated data values in each record (that is, no two
        ///records can have the same value). 
        /// </summary>
        public string LinkVar { get; set; }
        /// <summary>
        /// The Ordered is optional and identifies whether the data in the
        ///corresponding level is ordered or not. It must be one of:
        ///   - yes data in the parent level is ordered
        ///   - no data in the parent level should be treated as unordered
        ///If Ordered is not explicitly specified the value "no" is assumed.
        /// </summary>
        public bool Ordered { get; set; }
    }
}
