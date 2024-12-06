using System.Collections.Generic;
using TSAPI.Public.Domain.Metadata;

namespace DemoApp.Data.Repos
{
    public class TS002
    {
        #region "Metadata"
        public static SurveyMetadata ReadMetadata()
        {
            var metadata = new SurveyMetadata
            {
                Id = "a4bd7eed-88df-4a57-86d6-396e3698022e",
                Name = "TS-002",
                Title = "Cereal Awareness Survey",
                InterviewCount = 10,
                Languages = new List<Language>
                {
                    new Language {LanguageId = "EN", Name = "English"}
                },
                Sections = new List<Section>
                {
                    new Section() { Label = new Label("System") },
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

            //Prompted Brand Awareness
            metadata.Sections[1].Variables.Add(new Variable
            {
                VariableId = "2",
                Type = "multiple",
                Name = "Q1",
                Label = new Label("Awareness",
                    new AltLabel { Mode = "interview", Text = "Which of these brands of breakfast cereal have you heard of? ", LanguageId = "EN" }
                ),

                Values = new VariableValues
                {
                    Values = new List<Value>
                    {
                        new Value { ValueId = "1", Code = "1", Label = new Label { Text = "Coco Pops" } },
                        new Value { ValueId = "2", Code = "2", Label = new Label { Text = "Rice Krispies" } },
                        new Value { ValueId = "3", Code = "3", Label = new Label { Text = "Frosties" } },
                        new Value { ValueId = "4", Code = "4", Label = new Label { Text = "Shredded Wheat" } },
                        new Value { ValueId = "5", Code = "5", Label = new Label { Text = "Lucky Charms" } },

                    }
                }
            });

            //Purchasing
            metadata.Sections[1].Variables.Add(new Variable
            {
                VariableId = "3",
                Type = "multiple",
                Name = "Q2",
                Label = new Label("Purchase",
                    new AltLabel { Mode = "interview", Text = "Which of these brands of breakfast cereal have you ever bought? ", LanguageId = "EN" }
                ),
                Values = new VariableValues
                {
                    Values = new List<Value>
                    {
                        new Value { ValueId = "1", Code = "1", Label = new Label { Text = "Coco Pops" } },
                        new Value { ValueId = "2", Code = "2", Label = new Label { Text = "Rice Krispies" } },
                        new Value { ValueId = "3", Code = "3", Label = new Label { Text = "Frosties" } },
                        new Value { ValueId = "4", Code = "4", Label = new Label { Text = "Shredded Wheat" } },
                        new Value { ValueId = "5", Code = "5", Label = new Label { Text = "Lucky Charms" } },

                    }
                }
            });

            return metadata;

        }
        #endregion

    }
}