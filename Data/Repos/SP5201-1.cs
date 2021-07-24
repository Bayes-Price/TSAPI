using System.Collections.Generic;
using Domain.Metadata;
using Domain;
using Domain.Interviews;

namespace Data.Repos
{
    public class Sp5201
    {
        #region "Metadata"
        public static SurveyMetadata ReadMetadata()
        {
            var metadata = new SurveyMetadata
            {
                Name = "SP5201-1",
                Title = "Historic House Exit Survey<br/>First Wave",
                InterviewCount = 3,
                Languages = new List<Language>
                {
                    new Language {Ident = "FR", Name = "French"}, 
                    new Language {Ident = "EN", Name = "English"}
                },
                NotAsked = "-66",
                NoAnswer = "-33"
                //Numeric, Open, Dates
            };

            //Available languages 

            //Respondent ID
            metadata.Variables.Add(new Variable
            {
                Ident = "1",
                Type = Enums.VariableType.Quantity,
                Name = "RESPONDENT_ID",
                Label = new Label("Respondent ID"),
                Use = Enums.UseType.Serial,
                VariableValues = new VariableValues
                {
                    Range = new ValueRange { From = "000001", To = "999999" }
                }
            });


            //Q1.a
            metadata.Variables.Add(new Variable
            {
                Ident = "2",
                Type = Enums.VariableType.Date,
                Name = "Q1.a",
                Label = new Label("Date of visit"),
                VariableValues = new VariableValues
                {
                    Range = new ValueRange { From = "20160101", To = "20161231" }
                }
            });

            //Q1.b
            metadata.Variables.Add(new Variable
            {
                Ident = "3",
                Type = Enums.VariableType.Time,
                Name = "Q1.b",
                Label = new Label("Time of visit"),
                //implicit range from="000000" to="235959"
            });

            //Q2
            metadata.Variables.Add(new Variable
            {
                Ident = "4",
                Type = Enums.VariableType.Single,
                Name = "Q2",
                Label = new Label("Frequency of visit",
                    new AltLabel { Mode = Enums.AltLabelMode.Interview, Text = "Have you visited here before?", LangIdent = "EN" },
                    new AltLabel { Mode = Enums.AltLabelMode.Analysis, Text = "Visited before", LangIdent = "EN" },
                    new AltLabel { Mode = Enums.AltLabelMode.Interview, Text = "Avez-vous déjà visité ici?", LangIdent = "FR" },
                    new AltLabel { Mode = Enums.AltLabelMode.Analysis, Text = "Visité avant", LangIdent = "FR" }),
                VariableValues = new VariableValues
                {
                    Values = new List<Value>
                    {
                        new Value { Ident = "0", Code = "0", Label = new Label
                        {
                            Text = "No, this is the first visit",
                            AltLabels = new List<AltLabel>
                            {
                                new AltLabel { LangIdent = "FR", Mode = Enums.AltLabelMode.Interview, Text = "Non, c'est la première visite" }
                            }

                        } },
                        new Value { Ident = "1", Code = "1", Label = new Label
                        {
                            Text = "I visited before within the year",
                            AltLabels = new List<AltLabel>
                            {
                                new AltLabel { LangIdent = "FR", Mode = Enums.AltLabelMode.Interview, Text = "J'ai visité avant dans l'année" }
                            }
                        }},
                        new Value { Ident = "2", Code = "2", Label = new Label
                        {
                            Text = "I visited before that",
                            AltLabels = new List<AltLabel>
                            {
                                new AltLabel { LangIdent = "FR", Mode = Enums.AltLabelMode.Interview, Text = "J'ai visité avant ça" }
                            }
                        }}
                    }
                }
            });


            //Q3
            metadata.Variables.Add(new Variable
            {
                Ident = "5",
                Type = Enums.VariableType.Multiple,
                MaxResponses = 8,
                Name = "Q3",
                Label = new Label("Attractions visited"),
                VariableValues = new VariableValues
                {
                    Values = new List<Value>
                    {
                        new Value {Ident = "1", Code = "1", Label = new Label {Text = "Sherwood Forest"}},
                        new Value {Ident = "2", Code = "2", Label = new Label {Text = "Nottingham Castle"}},
                        new Value {Ident = "3", Code = "3", Label = new Label {Text = "\"Friar Tuck\"; Restaurant"}},
                        new Value {Ident = "4", Code = "4", Label = new Label {Text = "\"Maid Marion\" Cafe"}},
                        new Value {Ident = "5", Code = "5", Label = new Label {Text = "Mining museum"}},
                        new Value {Ident = "9", Code = "9", Label = new Label {Text = "Other"}},
                        new Value {Ident = "10", Code = "10", Label = new Label {Text = "Other"}},
                        new Value {Ident = "11", Code = "11", Label = new Label {Text = "Other"}}
                    }
                },
                //Q3.a
                Questions = new List<Variable>
                {
                    new Variable
                    {
                        Ident = "6",
                        Type = Enums.VariableType.Character,
                        ParentType = Enums.ParentType.OtherSpecify,
                        MaxResponses = 3,
                        Name = "Q3.a",
                        Label = new Label("Other attractions visited")
                    }
                }
            });
           


            //Q4
            metadata.Variables.Add(new Variable
            {
                Ident = "7",
                Type = Enums.VariableType.Single,
                Name = "Q4",
                Label = new Label("Overall impression"),
                VariableValues = new VariableValues
                {
                    Values = new List<Value>
                    {
                        new Value { Ident = "1", Code = "1", Score = 2, Label = new Label  { Text = "Very Good" }},
                        new Value { Ident = "2", Code = "2", Score = 1, Label = new Label  { Text = "Good" }},
                        new Value { Ident = "3", Code = "3", Score = 0, Label = new Label  { Text = "OK" }},
                        new Value { Ident = "4", Code = "4", Score = -1, Label = new Label { Text = "Poor" }},
                        new Value { Ident = "5", Code = "5", Score = -2, Label = new Label { Text = "Very poor" }},
                        new Value { Ident = "6", Code = "9", Label = new Label { Text = "DK/NS" } }
                    }
                }
            });


            //Q5
            metadata.Variables.Add(new Variable
            {
                Ident = "8",
                Type = Enums.VariableType.Multiple,
                MaxResponses = 2,
                Name = "Q5",
                Label = new Label("Two favourite attractions visited"),
                VariableValues = new VariableValues
                {
                    Values = new List<Value>
                    {
                        new Value { Ident = "1", Code = "1", Label = new Label {Text = "Sherwood Forest" }},
                        new Value { Ident = "2", Code = "2", Label = new Label {Text = "Nottingham Castle" }},
                        new Value { Ident = "3", Code = "3", Label = new Label {Text = "\"Friar Tuck\"; Restaurant" }},
                        new Value { Ident = "4", Code = "4", Label = new Label {Text = "\"Maid Marion\" Cafe" }},
                        new Value { Ident = "5", Code = "5", Label = new Label {Text = "Mining museum" }},
                        new Value { Ident = "9", Code = "9", Label = new Label {Text = "Other" }},
                        new Value { Ident = "10", Code = "10", Label = new Label { Text = "Other" }},
                        new Value { Ident = "11", Code = "11", Label = new Label { Text = "Other" }}
                    }
                }
            });


            //Q6
            metadata.Variables.Add(new Variable
            {
                Ident = "9",
                Type = Enums.VariableType.Quantity,
                Name = "Q6",
                Label = new Label("Miles travelled"),
                VariableValues = new VariableValues
                {
                    Range = new ValueRange { From = "1", To = "499" },
                    Values = new List<Value>
                    {
                        new Value { Ident = "500", Code = "500", Label = new Label { Text = "500 or more" }},
                        new Value { Ident = "999", Code = "999", Label = new Label { Text = "Not stated" }}
                    }
                }
            });


            //Q7
            metadata.Variables.Add(new Variable
            {
                Ident = "10",
                Type = Enums.VariableType.Logical,
                Name = "Q7",
                Label = new Label("Would come again")
            });


            //Q8
            metadata.Variables.Add(new Variable
            {
                Ident = "11",
                Type = Enums.VariableType.Single,
                Name = "Q8",
                Label = new Label("When is that most likely to be"),
                //Filter = "Q7",
                VariableValues = new VariableValues
                {
                    Values = new List<Value>
                    {
                        new Value { Ident = "A", Code = "A", Label = new Label  {Text = "Within 3 months" }},
                        new Value { Ident = "B", Code = "B", Label = new Label {Text = "Between 3 months and 1 year" }},
                        new Value { Ident = "C", Code = "C", Label = new Label {Text = "More than 1 years time" }},
                    }
                }
            });


            //Q9 - Grid
            metadata.Variables.Add(new Variable
            {
                Ident = "12",
                Type = Enums.VariableType.Single,
                Name = "Q9",
                Label = new Label("Grid"),
                VariableValues = new VariableValues
                {
                    Values = new List<Value>
                    {
                        new Value { Ident = "1", Code = "1", Label = new Label {Text = "Sherwood Forest" }},
                        new Value { Ident = "2", Code = "2", Label = new Label {Text = "Nottingham Castle" }},
                        new Value { Ident = "3", Code = "3", Label = new Label {Text = "\"Friar Tuck\"; Restaurant" }},
                        new Value { Ident = "4", Code = "4", Label = new Label {Text = "\"Maid Marion\" Cafe" }},
                        new Value { Ident = "5", Code = "5", Label = new Label {Text = "Mining museum" }},
                        new Value { Ident = "9", Code = "9", Label = new Label {Text = "Other" }},
                        new Value { Ident = "10", Code = "10", Label = new Label { Text = "Other" }},
                        new Value { Ident = "11", Code = "11", Label = new Label { Text = "Other" }}
                    }
                },

                Questions = new List<Variable>
                {
                    //Q10
                    new Variable
                    {
                        Ident = "13",
                        Type = Enums.VariableType.Single,
                        ParentType = Enums.ParentType.Grid,
                        Name = "Q10",
                        Label = new Label("Overall Favourite")
                    },
                    //Q11
                    new Variable
                    {
                        Ident = "14",
                        Type = Enums.VariableType.Single,
                        ParentType = Enums.ParentType.Grid,
                        Name = "Q11",
                        Label = new Label("Value for Money"),
                        VariableValues = new VariableValues
                        {
                            Values = new List<Value>
                            {
                                new Value { Ident = "1", Code = "1", Label = new Label {Text = "Very Good" }, Score = 2},
                                new Value { Ident = "2", Code = "2", Label = new Label {Text = "Good" }, Score = 1},
                                new Value { Ident = "3", Code = "3", Label = new Label {Text = "Average" }, Score = 0},
                                new Value { Ident = "4", Code = "4", Label = new Label {Text = "Poor" }, Score = -1},
                                new Value { Ident = "5", Code = "5", Label = new Label {Text = "Very Poor" }, Score = -2}
                            }
                        }
                    },
                    //Q12
                    new Variable
                    {
                        Ident = "15",
                        Type = Enums.VariableType.Multiple,
                        ParentType = Enums.ParentType.Grid,
                        MaxResponses = 9,
                        Name = "Q12",
                        Label = new Label("Fun")
                    },
                    //Q13
                    new Variable
                    {
                        Ident = "16",
                        Type = Enums.VariableType.Multiple,
                        ParentType = Enums.ParentType.Grid,
                        MaxResponses = 9,
                        Name = "Q13",
                        Label = new Label("Educational")
                    },
                    //Q14
                    new Variable
                    {
                        Ident = "17",
                        Type = Enums.VariableType.Multiple,
                        ParentType = Enums.ParentType.Grid,
                        MaxResponses = 9,
                        Name = "Q14",
                        Label = new Label("Boring")
                    },
                    //Q15
                    new Variable
                    {
                        Ident = "18",
                        Type = Enums.VariableType.Multiple,
                        ParentType = Enums.ParentType.Grid,
                        MaxResponses = 9,
                        Name = "Q15",
                        Label = new Label("Long Queues")
                    }

                }
            });

            //Q16 - Loop
            metadata.Variables.Add(new Variable
            {
                Ident = "19",
                Type = Enums.VariableType.Loop,
                Name = "Q16",
                Label = new Label("Loop"),
                VariableValues = new VariableValues
                {
                    Values = new List<Value>
                    {
                        new Value { Ident = "1", Code = "1", Label = new Label {Text = "Sherwood Forest" }},
                        new Value { Ident = "2", Code = "2", Label = new Label {Text = "Nottingham Castle" }},
                        new Value { Ident = "3", Code = "3", Label = new Label {Text = "\"Friar Tuck\"; Restaurant" }},
                        new Value { Ident = "4", Code = "4", Label = new Label {Text = "\"Maid Marion\" Cafe" }},
                        new Value { Ident = "5", Code = "5", Label = new Label {Text = "Mining museum" }},
                        new Value { Ident = "9", Code = "9", Label = new Label {Text = "Other" }},
                        new Value { Ident = "10", Code = "10", Label = new Label { Text = "Other" }},
                        new Value { Ident = "11", Code = "11", Label = new Label { Text = "Other" }}
                    }
                },
                Questions = new List<Variable>
                {
                    //Q17
                    new Variable
                    {
                        Ident = "20",
                        Type = Enums.VariableType.Character,
                        ParentType = Enums.ParentType.Loop,
                        Name = "Q17",
                        Label = new Label("Why was [Attraction] one of your favourites?")
                    },

                    //Q18
                    new Variable
                    {
                        Ident = "21",
                        Type = Enums.VariableType.Single,
                        ParentType = Enums.ParentType.Loop,
                        Name = "Q18",
                        Label = new Label("Q18 How likely are you to come back to see [Attraction] again?"),
                        VariableValues = new VariableValues
                        {
                            Values = new List<Value>
                            {
                                new Value { Ident = "1", Code = "1", Label = new Label {Text = "Very Likely" }, Score = 2},
                                new Value { Ident = "2", Code = "2", Label = new Label {Text = "Likely" }, Score = 1},
                                new Value { Ident = "3", Code = "3", Label = new Label {Text = "Neither" }, Score = 0},
                                new Value { Ident = "4", Code = "4", Label = new Label {Text = "Unlikely" }, Score = -1},
                                new Value { Ident = "5", Code = "5", Label = new Label {Text = "Very Unlikely" }, Score = -2}
                            }
                        }
                    }
                }

            });


            //Language
            metadata.Variables.Add(new Variable
            {
                Ident = "22",
                Type = Enums.VariableType.Single,
                Use = Enums.UseType.Language,
                Name = "Language",
                Label = new Label("Language"),
                VariableValues = new VariableValues
                {
                    Values = new List<Value>
                    {
                        new Value {Ident = "FR", Code = "FR", Label = new Label {Text = "French"}},
                        new Value {Ident = "EN", Code = "EN", Label = new Label {Text = "English"}}
                    }
                }
            });


            //WT
            metadata.Variables.Add(new Variable
            {
                Ident = "999999",
                Type = Enums.VariableType.Quantity,
                Name = "WT",
                Label = new Label("Record weight"),
                Use = Enums.UseType.Weight,
                VariableValues = new VariableValues
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
                MakeDummyInterview1()
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
                    new DataItem {Ident = "6", Values = new List<string> {"Nottingham Goose Fair"}, ParentIdent = new ParentRef { ParentVariableIdent = "5", ParentValueIdent = "9" }},
                    new DataItem {Ident = "7", Values = new List<string> {"2"}},
                    new DataItem {Ident = "8", Values = new List<string> {"5", "1"}},
                    new DataItem {Ident = "9", Values = new List<string> {"25"}},
                    new DataItem {Ident = "10", Values = new List<string> {"1"}},
                    new DataItem {Ident = "11", Values = new List<string> {"A"}},
                    //Grid [12]
                    new DataItem {Ident = "13", Values = new List<string> {"5"}},
                    new DataItem {Ident = "14", Values = new List<string> {"1", "2", "1", "3", "", "2", "1", "-33", "-66" }},
                    new DataItem {Ident = "15", Values = new List<string> {"1", "3", "4" }},
                    new DataItem {Ident = "16", Values = new List<string> {"4", "2", "1" }},
                    new DataItem {Ident = "17", Values = new List<string> {"5"}},
                    new DataItem {Ident = "18", Values = new List<string> {"1", "4"}},
                    //Loop [19]
                    new DataItem {Ident = "20", Values = new List<string> {"I just love learning about mining!"}, ParentIdent = new ParentRef { ParentVariableIdent = "8", ParentValueIdent = "5" }},
                    new DataItem {Ident = "20", Values = new List<string> {"I'm a big fan of Robin Hood."}, ParentIdent = new ParentRef { ParentVariableIdent = "8", ParentValueIdent = "1" }},
                    new DataItem {Ident = "21", Values = new List<string> {"1"}, ParentIdent = new ParentRef { ParentVariableIdent = "8", ParentValueIdent = "5" }},
                    new DataItem {Ident = "21", Values = new List<string> {"2"}, ParentIdent = new ParentRef { ParentVariableIdent = "8", ParentValueIdent = "1" }},

                    new DataItem {Ident = "22", Values = new List<string> {"EN"}},

                    new DataItem {Ident = "999999", Values = new List<string> {"1.131"}}
                }
            };
        }


        /*
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
        */
        #endregion

    }
}
