namespace TSAPI.Public.Domain.Metadata
{
    /// <summary>Object representing an “other specify” variable within a closed-end variable </summary>
    public class OtherSpecifyVariable : Variable
    {
        /// <summary>Defines the id of the closed end response that an other-specify is attached to</summary>
        public string ParentValueId { get; set; }
    }
}
