namespace Domain.TripleS.V2
{
    public class Hierarchy
    {
        public string Ident { get; set; }
        public ParentDetails Parent { get; set; } = new ParentDetails();
        public SurveyMetadataBase Metadata { get; set; } = new SurveyMetadataBase();
    }

    public class ParentDetails
    {
        public string Level { get; set; }
        public string LinkVar { get; set; }
        public bool Ordered { get; set; }
    }
}
