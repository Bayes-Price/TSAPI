using TSAPI.Public.Domain.Metadata;

namespace DummyDataGeneration.Domain
{
    public class SurveyMetadataItem
    {
        public enum Type
        {
            Grid = 1, 
            Variable = 2
        }

        public Type ItemType { get; set; }

        public int Index { get; set; }
        public Variable Variable { get; set; }
        public Grid Grid { get; set; }
    }
}
