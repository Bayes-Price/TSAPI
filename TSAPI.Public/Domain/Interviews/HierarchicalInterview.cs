
namespace TSAPI.Public.Domain.Interviews
{
    /// <summary>Object represents a hierarchical interview with a main parent interview</summary>
    public class HierarchicalInterview : Interview
    {
        /// <summary>Indicates which level of the hierarchy an interview is associated with</summary>
        public Level Level { get; set; }
    }
}
