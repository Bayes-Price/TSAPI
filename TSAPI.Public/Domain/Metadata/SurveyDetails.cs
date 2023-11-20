namespace TSAPI.Public.Domain.Metadata
{
    /// <summary>Object representing an available survey within the API system</summary>
    public class SurveyDetail
    {
        ///<summary>The unique Id that the API system uses internally to identify a given survey</summary>
        public string Id { get; set; }
        ///<summary>The human readable identifer assigned to the survey within the API system. For example, this may contain an internal job number such as "TS-002"</summary>
        public string Name { get; set; }
        /// <summary>The human-readable name assigned to the survey within the API system. For example, "Restaurant Satisfaction Survey"</summary>
        public string Title { get; set; }
    }
}
