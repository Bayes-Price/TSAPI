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
        private SurveyMetadata _metaData;
        private List<SurveyMetadataItem> _metadataItems; 
        #endregion

        #region "Construction"
        public DummyInterviewGenerator(SurveyMetadata metaData)
        {
            _metaData = metaData;
        }
        #endregion
        
        #region "Public Methods"
        public List<Interview> ReadFromFile(string path)
        {
            var interviews = new List<Interview>();
            var stream = new System.IO.StreamReader(path);
            var config = new CsvHelper.Configuration.CsvConfiguration(System.Threading.Thread.CurrentThread.CurrentCulture);
            var reader = new CsvReader(stream, config);

            while (reader.Read())
            {
                interviews.Add(MakeInterview(reader.GetRecord<List<string>>()));
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

        private Interview MakeInterview(List<string> record)
        {
            var interview = new Interview();

            //Interview Id
            interview.Ident = record[0];

            //"Q1.a"
            interview.DataItems.Add(new DataItem() { Ident = "2", Values = new List<string> { record[1] }});

            //"Q1.b"
            interview.DataItems.Add(new DataItem() { Ident = "3", Values = new List<string> { record[2] } });

            //"Q2"
            interview.DataItems.Add(new DataItem() { Ident = "4", Values = new List<string> { record[3] } });


            return interview;
        }

        #endregion

    }
}
