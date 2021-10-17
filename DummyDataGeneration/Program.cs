using DemoApp.

namespace DummyDataGeneration
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = DemoApp.Data.Repos.SurveyRepo();
            var generator = new DummyDataGeneration();

        }
    }
}
