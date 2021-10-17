using CsvHelper;
using DummyDataGeneration.Domain;
using System.Collections.Generic;
using TSAPI.Public.Domain.Interviews;
using TSAPI.Public.Domain.Metadata;

namespace DummyDataGeneration.Data
{
    public class DummyInterviewGenerator
    {

        #region "Member Variables"
        private List<string> _fields = new List<string>
        {
            "[1] RESPONDENT_ID",
            "[2] Q1.a - Date of Visit",
            "[3] Q1.b - Time of visit",
            "[4] Q2  - Frequency of visit",
            "[5] Q3 - Attractions visited",
            "[5-os1] Q3 - Other 1",
            "[5-os1] Q3 - Other 2",
            "[5-os1] Q3 - Other 3",
            "[6] Q4 - Overall impression",
            "[7] Q5 - Two favourite attractions visited",
            "[8] Q6 - Miles travelled",
            "[9] Q7 - Would come again",
            "[10] Q8 - When is that most likely to be",
            "[11 - r1] - Q9 - Value for Money - Sherwood Forest",
            "[11 - r2] - Q9 - Value for Money - Nottingham Castle",
            "[11 - r3] - Q9 - Value for Money - \"Friar Tuck Restaurant\"",
            "[11 - r4] - Q9 - Value for Money - \"Maid Marion Café\"",
            "[11 - r5] - Q9 - Value for Money - Mining Museum",
            "[11 - r6] - Q9 - Value for Money - Other1",
            "[11 - r7] - Q9 - Value for Money - Other2",
            "[11 - r8] - Q9 - Value for Money - Other3",
            "[12 - r1] - Q9 - Fun - Sherwood Forest",
            "[12 - r2] - Q9 - Fun - Nottingham Castle",
            "[12 - r3] - Q9 - Fun - \"Friar Tuck Restaurant\"",
            "[12 - r4] - Q9 - Fun - \"Maid Marion Café\"",
            "[12 - r5] - Q9 - Fun - Mining Museum",
            "[12 - r6] - Q9 - Fun - Other1",
            "[12 - r7] - Q9 - Fun - Other2",
            "[12 - r8] - Q9 - Fun - Other3",
            "[13 - r1] - Q9 - Educational - Sherwood Forest",
            "[13 - r2] - Q9 - Educational - Nottingham Castle",
            "[13 - r3] - Q9 - Educational - \"Friar Tuck Restaurant\"",
            "[13 - r4] - Q9 - Educational - \"Maid Marion Café\"",
            "[13 - r5] - Q9 - Educational - Mining Museum",
            "[13 - r6] - Q9 - Educational - Other1",
            "[13 - r7] - Q9 - Educational - Other2",
            "[13 - r8] - Q9 - Educational - Other3",
            "[14 - r1] - Q9 - Boring - Sherwood Forest",
            "[14 - r2] - Q9 - Boring - Nottingham Castle",
            "[14 - r3] - Q9 - Boring - \"Friar Tuck Restaurant\"",
            "[14 - r4] - Q9 - Boring - \"Maid Marion Café\"",
            "[14 - r5] - Q9 - Boring - Mining Museum",
            "[14 - r6] - Q9 - Boring - Other1",
            "[14 - r7] - Q9 - Boring - Other2",
            "[14 - r8] - Q9 - Boring - Other3",
            "[15 - r1] - Q9 - Long Queues - Sherwood Forest",
            "[15 - r2] - Q9 - Long Queues - Nottingham Castle",
            "[15 - r3] - Q9 - Long Queues - \"Friar Tuck Restaurant\"",
            "[15 - r4] - Q9 - Long Queues - \"Maid Marion Café\"",
            "[15 - r5] - Q9 - Long Queues - Mining Museum",
            "[15 - r6] - Q9 - Long Queues - Other1",
            "[15 - r7] - Q9 - Long Queues - Other2",
            "[15 - r8] - Q9 - Long Queues - Other3",
            "[19] Q16-Loop",
            "[20]Q17 - Why was [Attraction] one of your favourites?",
            "[20] Q17 - Why was [Attraction] one of your favourites?",
            "[21] Q18 - How likely are you to come back to see [Attraction] again? - Answer 1",
            "[21] Q18 - How likely are you to come back to see [Attraction] again? - Answer 2",
            "[22] Language",
            "[99999] WT"
        };
        #endregion

        #region "Construction"
        public DummyInterviewGenerator() { }
        #endregion
        
        #region "Public Methods"
        public List<Interview> ReadFromFile(string path)
        {
            var interviews = new List<Interview>();
            var stream = new System.IO.StreamReader(path);
            var config = new CsvHelper.Configuration.CsvConfiguration(System.Threading.Thread.CurrentThread.CurrentCulture);
            var reader = new CsvReader(stream, config);

            while(reader.Read())
            {
                interviews.Add(MakeInterview((IDictionary<string, object>)reader.GetRecord<dynamic>()));
            }

            stream.Close();

            return interviews;
        }

        public List<Interview> GenerateInterviews(int numberOfInterviews)
        {
            var interviews = new List<Interview>();

            for(var i = 1; i <= numberOfInterviews; i++) {
                interviews.Add(GenerateInterview());
            }
            return interviews;
        }
        #endregion

        #region "Private Methods"
        private Interview GenerateInterview()
        {
            var interview = new Interview();
            
            return interview;
        }            

        private Interview MakeInterview(IDictionary<string, object> record)
        {
            var interview = new Interview();

            //Interview Id
            interview.Ident = record[_fields[0]].ToString();

            //"Q1.a"
            interview.DataItems.Add(new DataItem() { Ident = "2", Values = new List<string> { record[_fields[1]].ToString() } });

            //"Q1.b"
            interview.DataItems.Add(new DataItem() { Ident = "3", Values = new List<string> { record[_fields[2]].ToString() } });

            //"Q2"
            interview.DataItems.Add(new DataItem() { Ident = "4", Values = new List<string> { record[_fields[3]].ToString() } });


            return interview;
        }

        #endregion

    }
}
