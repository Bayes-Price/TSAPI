using System.Collections.Generic;
using TSAPI.Public.Domain;
using TSAPI.Public.Domain.Metadata;

namespace DemoApp.Data.Repos
{
    public class TS001
    {
        #region "Metadata"
        public static SurveyMetadata ReadMetadata()
        {
            var metadata = new SurveyMetadata
            {
                Name = "TS-001",
                Title = "Customer Experience Survey",
                InterviewCount = 3000,
                Languages = new List<Language>
                {
                    new Language {Ident = "EN", Name = "English"}
                },
                NotAsked = "-66",
                NoAnswer = "-33",
                Sections = new List<Section>
                {
                    new Section() { Label = new Label("System") },
                    new Section() { Label = new Label("Demographics") },
                    new Section() { Label = new Label("Main Survey") }
                }
            };

            //Respondent ID
            metadata.Sections[0].Variables.Add(new Variable
            {
                Ident = "1",
                Type = "Quantity",
                Name = "RESPONDENT_ID",
                Label = new Label("Respondent ID"),
                Use = "Serial",
                Values = new VariableValues
                {
                    Range = new ValueRange { From = "1", To = "999999" }
                }
            });

            //Q1a
            metadata.Sections[1].Variables.Add(new Variable
            {
                Ident = "2",
                Type = "Date",
                Name = "Q1a",
                Label = new Label("Date of Visit",
                      new AltLabel { Mode = Enums.AltLabelMode.Interview, Text = "Please tell us the date of your most recent visit", LangIdent = "EN" }
                ),
                Values = new VariableValues
                {
                    Range = new ValueRange { From = "20220101", To = "20221231" }
                }
            });

            //Q1b
            metadata.Sections[1].Variables.Add(new Variable
            {
                Ident = "3",
                Type = "Time",
                Name = "Q1.b",
                Label = new Label("Time of Visit",
                    new AltLabel { Mode = Enums.AltLabelMode.Interview, Text = "What time of day was that?", LangIdent = "EN" }
                ),
                //implicit range from="000000" to="235959"
            });

            //Q2
            metadata.Sections[1].Variables.Add(new Variable
            {
                Ident = "4",
                Type = "Single",
                Name = "Q2",
                Label = new Label("Frequency of visit",
                    new AltLabel { Mode = Enums.AltLabelMode.Interview, Text = "Have you visited here before?", LangIdent = "EN" },
                    new AltLabel { Mode = Enums.AltLabelMode.Analysis, Text = "Visited before", LangIdent = "EN" }),
                Values = new VariableValues
                {
                    Values = new List<Value>
                    {
                        new Value { Ident = "0", Code = "0", Label = new Label
                            {
                                Text = "No, this is the first visit"
                            } 
                        },
                        new Value { Ident = "1", Code = "1", Label = new Label
                        {
                            Text = "I visited before within the year"
                        }},
                        new Value { Ident = "2", Code = "2", Label = new Label
                        {
                            Text = "I visited before that"
                        }}
                    }
                }
            });

            //Q3
            metadata.Sections[1].Variables.Add(new Variable
            {
                Ident = "5",
                Type = "Quantity",
                Name = "Q3",
                Label = new Label("Miles travelled",
                    new AltLabel { Mode = Enums.AltLabelMode.Interview, Text = "How far have you travelled to get here? ", LangIdent = "EN" })
            });

            //Q4
            metadata.Sections[2].Variables.Add(new Variable
            {
                Ident = "6",
                Type = "Single",
                Name = "Q4",
                Label = new Label("Overall impression",
                    new AltLabel { Mode = Enums.AltLabelMode.Interview, Text = "What was your impression of our wonderful made-up place overall? ", LangIdent = "EN" }
                ),
                Values = new VariableValues
                {
                    Values = new List<Value>
                    {
                        new Value { Ident = "1", Code = "1", Score = 2, Label = new Label  { Text = "Very Good" }},
                        new Value { Ident = "2", Code = "2", Score = 1, Label = new Label  { Text = "Good" }},
                        new Value { Ident = "3", Code = "3", Score = 0, Label = new Label  { Text = "OK" }},
                        new Value { Ident = "4", Code = "4", Score = -1, Label = new Label { Text = "Poor" }},
                        new Value { Ident = "5", Code = "5", Score = -2, Label = new Label { Text = "Very poor" }},
                        new Value { Ident = "6", Code = "9", Label = new Label { Text = "DK/NA" } }
                    }
                }
            });

            //Q5
            metadata.Sections[2].Variables.Add(new Variable
            {
                Ident = "7",
                Type = "Multiple",
                MaxResponses = 4,
                Name = "Q5",
                Label = new Label("Attractions visited",
                    new AltLabel { Mode = Enums.AltLabelMode.Interview, Text = "Which attractions have you visited today? ", LangIdent = "EN" }),
                Values = new VariableValues
                {
                    Values = new List<Value>
                    {
                        new Value {Ident = "1", Code = "1", Label = new Label {Text = "Museum"}},
                        new Value {Ident = "2", Code = "2", Label = new Label {Text = "Gift Shop"}},
                        new Value {Ident = "3", Code = "3", Label = new Label {Text = "Restaurant"}},
                        new Value {Ident = "98", Code = "98", Label = new Label {Text = "Other"}}
                    }
                },
                //Q5 - Other Specify
                OtherSpecifyVariables = new List<OtherSpecifyVariable>
                {
                    new OtherSpecifyVariable
                    {
                        Ident = "5other",
                        ParentValueIdent = "9",
                        Type = "Character",
                        Name = "Q5Other",
                        Label = new Label("Other attractions visited")
                    }
                }, 

                LoopedVariables = new List<Variable>
                {
                    new Variable
                    {
                        Ident = "8",
                        Type = "Multiple",
                        MaxResponses = 4,
                        Name = "Q6",
                        Label = new Label("Experience Elements",
                            new AltLabel { Mode = Enums.AltLabelMode.Interview, Text = "Which of these have you experienced in the [ATTRACTION AT Q5] today? ", LangIdent = "EN" }),
                        Values = new VariableValues
                        {
                            Values = new List<Value>
                            {
                                new Value {Ident = "1", Code = "1", Label = new Label {Text = "Staff Service"}},
                                new Value {Ident = "2", Code = "2", Label = new Label {Text = "Toilets"}},
                                new Value {Ident = "3", Code = "3", Label = new Label {Text = "Seating"}},
                                new Value {Ident = "4", Code = "4", Label = new Label {Text = "Payment Areas"}}
                            }
                        },

                        LoopedVariables = new List<Variable>
                        {
                            new Variable
                            {
                                Ident = "9",
                                Type = "Single",
                                MaxResponses = 4,
                                Name = "Q7_1",
                                Label = new Label("Experience Impression",
                                    new AltLabel { Mode = Enums.AltLabelMode.Interview, Text = "What was your impression of our the [Q6 EXPERIENCE] at the [Q5 ATTRACTION]? ", LangIdent = "EN" }),
                                Values = new VariableValues
                                {
                                    Values = new List<Value>
                                    {
                                        new Value {Ident = "1", Code = "1", Label = new Label {Text = "Very Good"}},
                                        new Value {Ident = "2", Code = "2", Label = new Label {Text = "Good"}},
                                        new Value {Ident = "3", Code = "3", Label = new Label {Text = "OK"}},
                                        new Value {Ident = "4", Code = "4", Label = new Label {Text = "Poor"}},
                                        new Value {Ident = "5", Code = "5", Label = new Label {Text = "Very Poor"}},
                                        new Value {Ident = "99", Code = "99", Label = new Label {Text = "Don't Know / not sure"}}
                                    }
                                }
                            },

                            new Variable
                            {
                                Ident = "10",
                                Type = "Single",
                                MaxResponses = 1,
                                Name = "Q7_2",
                                Label = new Label("Experience Recommend",
                                    new AltLabel { Mode = Enums.AltLabelMode.Interview, Text = "Would you recommend our venue based on your experience of the [Q6 EXPERIENCE] at the [Q5 ATTRACTION]?", LangIdent = "EN" }),
                                Values = new VariableValues
                                {
                                    Values = new List<Value>
                                    {
                                        new Value {Ident = "1", Code = "1", Label = new Label {Text = "Yes"}},
                                        new Value {Ident = "2", Code = "2", Label = new Label {Text = "No"}}
                                    }
                                }

                            }
                        }
                    }
                }
            });

            //Q8
            metadata.Sections[2].Variables.Add(new Variable
            {
                Ident = "11",
                Type = "Character",
                Name = "Q8",
                Label = new Label("Other Comments",
                     new AltLabel { Mode = Enums.AltLabelMode.Interview, Text = "Do you have any other comments?", LangIdent = "EN" }
               )            
            });

            metadata.Sections[2].Variables.Add(new Variable
            {
                Ident = "12",
                Type = "Logical",
                Name = "Q9",
                Label = new Label("Would come again?",
                     new AltLabel { Mode = Enums.AltLabelMode.Interview, Text = "", LangIdent = "EN" }
               ),
                Values = new VariableValues
                {
                    Values = new List<Value>
                    {
                        new Value { Ident = "1", Code = "1", Label = new Label  { Text = "Yes" }},
                        new Value { Ident = "2", Code = "2", Label = new Label  { Text = "No" }}
                    }
                }
            });

            return metadata;
        }
        #endregion
    }
}