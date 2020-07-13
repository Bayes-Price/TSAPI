using System.Collections.Generic;
using Domain.Survey;
using Domain.TripleS.V2;

namespace Data.Repos
{
    public class SP5201
    {
        #region "Metadata"
        public static SurveyMetadata ReadMetadata()
        {
            var metadata = new SurveyMetadata { Name = "SP5201-1", Title = "Historic House Exit Survey<br/>First Wave", InterviewCount = 3};

            //Respondent ID
            metadata.Variables.Add(new Variable
            {
                Ident = "1",
                Type = Variable.VariableType.Quantity.ToString(),
                Name = "RESPONDENT_ID",
                Label = new Label("Respondent ID"),
                Use = "serial",
                Values = new VariableValues
                {
                    Range = new ValueRange { From = "000001", To = "999999" }
                }
            });


            //Q1.a
            metadata.Variables.Add(new Variable
            {
                Ident = "2",
                Type = Variable.VariableType.Date.ToString(),
                Name = "Q1.a",
                Label = new Label("Date of visit"),
                Values = new VariableValues
                {
                    Range = new ValueRange { From = "20160101", To = "20161231" }
                }
            });

            //Q1.b
            metadata.Variables.Add(new Variable
            {
                Ident = "3",
                Type = Variable.VariableType.Time.ToString(),
                Name = "Q1.b",
                Label = new Label("Time of visit"),
                //implicit range from="000000" to="235959"
            });

            //Q2
            metadata.Variables.Add(new Variable
            {
                Ident = "4",
                Type = Variable.VariableType.Single.ToString(),
                Name = "Q2",
                Label = new Label("Frequency of visit",
                    new AltLabel { Mode = "Interview", Text = "Have you visited here before?" },
                    new AltLabel { Mode = "Analysis", Text = "Visited before" }),
                Values = new VariableValues
                {
                    Values = new List<Value>
                    {
                        new Value { Code = "0", Text = "No, this is the first visit" },
                        new Value { Code = "1", Text = "I visited before within the year" },
                        new Value { Code = "2", Text = "I visited before that" }
                    }
                }
            });


            //Q3
            metadata.Variables.Add(new Variable
            {
                Ident = "5",
                Type = Variable.VariableType.Multiple.ToString(),
                Name = "Q3",
                Label = new Label("Attractions visited"),
                Values = new VariableValues
                {
                    Values = new List<Value>
                    {
                        new Value { Code = "1", Text = "Sherwood Forest" },
                        new Value { Code = "2", Text = "Nottingham Castle" },
                        new Value { Code = "3", Text = "\"Friar Tuck\"; Restaurant" },
                        new Value { Code = "4", Text = "\"Maid Marion\" Cafe" },
                        new Value { Code = "5", Text = "Mining museum" },
                        new Value { Code = "9", Text = "Other" },
                    }
                }
            });

            //Q3.a
            metadata.Variables.Add(new Variable
            {
                Ident = "6",
                Type = Variable.VariableType.Character.ToString(),
                Name = "Q3.a",
                Label = new Label("Other attractions visited")
            });


            //Q4
            metadata.Variables.Add(new Variable
            {
                Ident = "7",
                Type = Variable.VariableType.Single.ToString(),
                Name = "Q4",
                Label = new Label("Overall impression"),
                Values = new VariableValues
                {
                    Values = new List<Value>
                    {
                        new Value { Code = "1", Score = 2, Text = "Very Good" },
                        new Value { Code = "2", Score = 1, Text = "Good" },
                        new Value { Code = "3", Score = 0, Text = "OK" },
                        new Value { Code = "4", Score = -1, Text = "Poor" },
                        new Value { Code = "5", Score = -2, Text = "Very poor" },
                        new Value { Code = "9", Text = "DK/NS" },
                    }
                }
            });


            //Q5
            metadata.Variables.Add(new Variable
            {
                Ident = "8",
                Type = Variable.VariableType.Multiple.ToString(),
                Name = "Q5",
                Label = new Label("Two favourite attractions visited"),
                Values = new VariableValues
                {
                    Values = new List<Value>
                    {
                        new Value { Code = "1", Text = "Sherwood Forest" },
                        new Value { Code = "2", Text = "Nottingham Castle" },
                        new Value { Code = "3", Text = "\"Friar Tuck\"; Restaurant" },
                        new Value { Code = "4", Text = "\"Maid Marion\" Cafe" },
                        new Value { Code = "5", Text = "Mining museum" },
                        new Value { Code = "9", Text = "Other" },
                    }
                }
            });


            //Q6
            metadata.Variables.Add(new Variable
            {
                Ident = "9",
                Type = Variable.VariableType.Quantity.ToString(),
                Name = "Q6",
                Label = new Label("Miles travelled"),
                Values = new VariableValues
                {
                    Range = new ValueRange { From = "1", To = "499" },
                    Values = new List<Value>
                    {
                        new Value { Code = "500", Text = "500 or more" },
                        new Value { Code = "999", Text = "Not stated" }
                    }
                }
            });


            //Q7
            metadata.Variables.Add(new Variable
            {
                Ident = "10",
                Type = Variable.VariableType.Logical.ToString(),
                Name = "Q7",
                Label = new Label("Would come again")
            });


            //Q8
            metadata.Variables.Add(new Variable
            {
                Ident = "11",
                Type = Variable.VariableType.Single.ToString(),
                Name = "Q8",
                Label = new Label("When is that most likely to be"),
                Filter = "Q7",
                Values = new VariableValues
                {
                    Values = new List<Value>
                    {
                        new Value { Code = "A", Text = "Within 3 months" },
                        new Value { Code = "B", Text = "Between 3 months and 1 year" },
                        new Value { Code = "C", Text = "More than 1 years time" },
                    }
                }
            });

            //WT
            metadata.Variables.Add(new Variable
            {
                Ident = "999999",
                Type = Variable.VariableType.Quantity.ToString(),
                Name = "WT",
                Label = new Label("Record weight"),
                Use = "weight",
                Values = new VariableValues
                {
                    Range = new ValueRange { From = "0.0000", To = "99.9999" }
                }
            });

            return metadata;
        }
        #endregion

        #region "Survey Data"
        public static List<Interview> LoadAllInterviews()
        {
            var interviews = new List<Interview>
            {
                MakeDummyInterview1(),
                MakeDummyInterview2(),
                MakeDummyInterview3()
            };

            return interviews;
        }

        private static Interview MakeDummyInterview1()
        {
            return new Interview
            {
                Ident = "520001",
                DataItems = new List<DataItem>
                {
                    new DataItem {Ident = "1", Values = new List<string> {"520001"}},
                    new DataItem {Ident = "2", Values = new List<string> {"20050504"}},
                    new DataItem {Ident = "3", Values = new List<string> {"112000"}},
                    new DataItem {Ident = "4", Values = new List<string> {"0"}},
                    new DataItem {Ident = "5", Values = new List<string> {"1", "3", "5", "9"}},
                    new DataItem {Ident = "6", Values = new List<string> {"Nottingham Goose Fair"}},
                    new DataItem {Ident = "7", Values = new List<string> {"2"}},
                    new DataItem {Ident = "8", Values = new List<string> {"5", "1"}},
                    new DataItem {Ident = "9", Values = new List<string> {"25"}},
                    new DataItem {Ident = "10", Values = new List<string> {"1"}},
                    new DataItem {Ident = "11", Values = new List<string> {"A"}},
                    new DataItem {Ident = "999999", Values = new List<string> {"1.131"}}
                }
            };
        }

        private static Interview MakeDummyInterview2()
        {
            return new Interview
            {
                Ident = "520002",
                DataItems = new List<DataItem>
                {
                    new DataItem {Ident = "1", Values = new List<string> {"520002"}},
                    new DataItem {Ident = "2", Values = new List<string> {"20050506"}},
                    new DataItem {Ident = "3", Values = new List<string> {"134300"}},
                    new DataItem {Ident = "4", Values = new List<string> {"2"}},
                    new DataItem {Ident = "5", Values = new List<string> {"1"}},
                    new DataItem {Ident = "6", Values = new List<string> {""}},
                    new DataItem {Ident = "7", Values = new List<string> {"9"}},
                    new DataItem {Ident = "8", Values = new List<string> {"2"}},
                    new DataItem {Ident = "9", Values = new List<string> {"100"}},
                    new DataItem {Ident = "10", Values = new List<string> {"0"}},
                    new DataItem {Ident = "11", Values = new List<string>()},
                    new DataItem {Ident = "999999", Values = new List<string> {"0.9921"}}
                }
            };
        }

        private static Interview MakeDummyInterview3()
        {
            return new Interview
            {
                Ident = "520003",
                DataItems = new List<DataItem>
                {
                    new DataItem {Ident = "1", Values = new List<string> {"520003"}},
                    new DataItem {Ident = "2", Values = new List<string> {"20050503"}},
                    new DataItem {Ident = "3", Values = new List<string> {"180500"}},
                    new DataItem {Ident = "4", Values = new List<string> {"1"}},
                    new DataItem {Ident = "5", Values = new List<string> {"1", "2", "9"}},
                    new DataItem {Ident = "6", Values = new List<string> {"\"Heritage\" Zone"}},
                    new DataItem {Ident = "7", Values = new List<string> {"1"}},
                    new DataItem {Ident = "8", Values = new List<string> {"9", "2"}},
                    new DataItem {Ident = "9", Values = new List<string> {"999"}},
                    new DataItem {Ident = "10", Values = new List<string> {"1"}},
                    new DataItem {Ident = "11", Values = new List<string> {"C"}},
                    new DataItem {Ident = "999999", Values = new List<string> {"1.0089"}}
                }
            };
        }

        #endregion

    }
}
