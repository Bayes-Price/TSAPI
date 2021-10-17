
using DummyDataGeneration.Data;

namespace DummyDataGeneration
{
    class Program
    {
        static void Main(string[] args)
        {
            //var repo = DemoApp.Data.Repos.SurveyRepo();
            var generator = new DummyInterviewGenerator();
            var interviews = generator.ReadFromFile(@"C:\Temp\TSAPIDummyData.csv");

            //Serialise to JSON file

        }
    }
}
