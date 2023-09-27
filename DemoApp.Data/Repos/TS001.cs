﻿using System.Collections.Generic;
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
                    new Language {LanguageId = "EN", Name = "English"}
                },
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
                VariableId = "1",
                Type = "quantity",
                Name = "RESPONDENT_ID",
                Label = new Label("Respondent ID"),
                Use = "serial",
                Values = new VariableValues
                {
                    Range = new ValueRange { From = "1", To = "999999" }
                }
            });

            //Q1a
            metadata.Sections[1].Variables.Add(new Variable
            {
                VariableId = "2",
                Type = "date",
                Name = "Q1a",
                Label = new Label("Date of Visit",
                      new AltLabel { Mode = "interview", Text = "Please tell us the date of your most recent visit", LanguageId = "EN" }
                ),
                Values = new VariableValues
                {
                    Range = new ValueRange { From = "20220101", To = "20221231" }
                }
            });

            //Q1b
            metadata.Sections[1].Variables.Add(new Variable
            {
                VariableId = "3",
                Type = "time",
                Name = "Q1.b",
                Label = new Label("Time of Visit",
                    new AltLabel { Mode = "interview", Text = "What time of day was that?", LanguageId = "EN" }
                ),
                //implicit range from="000000" to="235959"
            });

            //Q2
            metadata.Sections[1].Variables.Add(new Variable
            {
                VariableId = "4",
                Type = "single",
                Name = "Q2",
                Label = new Label("Frequency of visit",
                    new AltLabel { Mode = "interview", Text = "Have you visited here before?", LanguageId = "EN" },
                    new AltLabel { Mode = "analysis", Text = "Visited before", LanguageId = "EN" }),
                Values = new VariableValues
                {
                    Values = new List<Value>
                    {
                        new Value { ValueId = "0", Code = "0", Label = new Label
                            {
                                Text = "No, this is the first visit"
                            } 
                        },
                        new Value { ValueId = "1", Code = "1", Label = new Label
                        {
                            Text = "I visited before within the year"
                        }},
                        new Value { ValueId = "2", Code = "2", Label = new Label
                        {
                            Text = "I visited before that"
                        }}
                    }
                }
            });

            //Q3
            metadata.Sections[1].Variables.Add(new Variable
            {
                VariableId = "5",
                Type = "quantity",
                Name = "Q3",
                Label = new Label("Miles travelled",
                    new AltLabel { Mode = "interview", Text = "How far have you travelled to get here? ", LanguageId = "EN" })
            });

            //Q4
            metadata.Sections[2].Variables.Add(new Variable
            {
                VariableId = "6",
                Type = "single",
                Name = "Q4",
                Label = new Label("Overall impression",
                    new AltLabel { Mode = "interview", Text = "What was your impression of our wonderful made-up place overall? ", LanguageId = "EN" }
                ),
                Values = new VariableValues
                {
                    Values = new List<Value>
                    {
                        new Value { ValueId = "1", Code = "1", Score = 2, Label = new Label  { Text = "Very Good" }},
                        new Value { ValueId = "2", Code = "2", Score = 1, Label = new Label  { Text = "Good" }},
                        new Value { ValueId = "3", Code = "3", Score = 0, Label = new Label  { Text = "OK" }},
                        new Value { ValueId = "4", Code = "4", Score = -1, Label = new Label { Text = "Poor" }},
                        new Value { ValueId = "5", Code = "5", Score = -2, Label = new Label { Text = "Very poor" }},
                        new Value { ValueId = "6", Code = "9", Label = new Label { Text = "DK/NA" } }
                    }
                }
            });

            //Q5
            metadata.Sections[2].Variables.Add(new Variable
            {
                VariableId = "7",
                Type = "multiple",
                MaxResponses = 4,
                Name = "Q5",
                Label = new Label("Attractions visited", new AltLabel { Mode = "interview", Text = "Which attractions have you visited today? ", LanguageId = "EN" }),
                Values = new VariableValues
                {
                    Values = new List<Value>
                    {
                        new Value {ValueId = "1", Code = "1", Label = new Label {Text = "Museum"}},
                        new Value {ValueId = "2", Code = "2", Label = new Label {Text = "Gift Shop"}},
                        new Value {ValueId = "3", Code = "3", Label = new Label {Text = "Restaurant"}},
                        new Value {ValueId = "98", Code = "98", Label = new Label {Text = "Other"}}
                    }
                }, //Q5 - Other Specify
                OtherSpecifyVariables = new List<OtherSpecifyVariable>
                {
                    new OtherSpecifyVariable
                    {
                        VariableId = "7other",
                        ParentValueId = "98",
                        Type = "character",
                        Name = "Q5Other",
                        Label = new Label("Other attractions visited")
                    }
                }, 

                LoopedVariables = new List<Variable>
                {
                    new Variable
                    {
                        VariableId = "8",
                        Type = "multiple",
                        MaxResponses = 4,
                        Name = "Q6",
                        Label = new Label("Experience Elements",
                            new AltLabel { Mode = "interview", Text = "Which of these have you experienced in the [ATTRACTION AT Q5] today? ", LanguageId = "EN" }),
                        Values = new VariableValues
                        {
                            Values = new List<Value>
                            {
                                new Value {ValueId = "1", Code = "1", Label = new Label {Text = "Staff Service"}},
                                new Value {ValueId = "2", Code = "2", Label = new Label {Text = "Toilets"}},
                                new Value {ValueId = "3", Code = "3", Label = new Label {Text = "Seating"}},
                                new Value {ValueId = "4", Code = "4", Label = new Label {Text = "Payment Areas"}}
                            }
                        },

                        LoopedVariables = new List<Variable>
                        {
                            new Variable
                            {
                                VariableId = "9",
                                Type = "single",
                                MaxResponses = 4,
                                Name = "Q7_1",
                                Label = new Label("Experience Impression",
                                    new AltLabel { Mode = "interview", Text = "What was your impression of our the [Q6 EXPERIENCE] at the [Q5 ATTRACTION]? ", LanguageId = "EN" }),
                                Values = new VariableValues
                                {
                                    Values = new List<Value>
                                    {
                                        new Value {ValueId = "1", Code = "1", Label = new Label {Text = "Very Good"}},
                                        new Value {ValueId = "2", Code = "2", Label = new Label {Text = "Good"}},
                                        new Value {ValueId = "3", Code = "3", Label = new Label {Text = "OK"}},
                                        new Value {ValueId = "4", Code = "4", Label = new Label {Text = "Poor"}},
                                        new Value {ValueId = "5", Code = "5", Label = new Label {Text = "Very Poor"}},
                                        new Value {ValueId = "99", Code = "99", Label = new Label {Text = "Don't Know / not sure"}}
                                    }
                                }
                            },

                            new Variable
                            {
                                VariableId = "10",
                                Type = "single",
                                MaxResponses = 1,
                                Name = "Q7_2",
                                Label = new Label("Experience Recommend",
                                    new AltLabel { Mode = "interview", Text = "Would you recommend our venue based on your experience of the [Q6 EXPERIENCE] at the [Q5 ATTRACTION]?", LanguageId = "EN" }),
                                Values = new VariableValues
                                {
                                    Values = new List<Value>
                                    {
                                        new Value {ValueId = "1", Code = "1", Label = new Label {Text = "Yes"}},
                                        new Value {ValueId = "2", Code = "2", Label = new Label {Text = "No"}}
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
                VariableId = "11",
                Type = "character",
                Name = "Q8",
                Label = new Label("Other Comments",
                     new AltLabel { Mode = "interview", Text = "Do you have any other comments?", LanguageId = "EN" }
               )            
            });

            return metadata;
        }
        #endregion
    }
}