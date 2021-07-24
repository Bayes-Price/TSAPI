//using System.Collections.Generic;
//using Domain.Interviews;
//using Domain.Metadata;

//namespace Data.Repos
//{
//    public class PR9012_HOUSEHOLD
//    {
//        public static SurveyMetadata ReadMetadata()
//        {

//            var metadata = new SurveyMetadata { Name = "PR9012-HOUSEHOLD", Title = "Regional Travel Survey<br/>Households", InterviewCount = 3 };

//            //hnumber
//            metadata.Variables.Add(new Variable
//            {
//                Ident = "1",
//                Type = Variable.VariableType.Quantity,
//                Name = "hnumber",
//                Label = new Label("Household"),
//                Use = "serial",
//                VariableValues = new VariableValues
//                {
//                    Range = new ValueRange { From = "000001", To = "999999" }
//                }
//            });

//            //House type
//            metadata.Variables.Add(new Variable
//            {
//                Ident = "2",
//                Type = Variable.VariableType.Single,
//                Name = "htype",
//                Label = new Label("House type"),
//                VariableValues = new VariableValues
//                {
//                    VariableValues = new List<Value>
//                        {
//                            new Value { Code = "1", Text = "Flat or Maisonette" },
//                            new Value { Code = "2", Text = "Terraced House" },
//                            new Value { Code = "3", Text = "Semi-detached House" },
//                            new Value { Code = "4", Text = "Detached House" }
//                        }
//                }
//            });

//            //House location
//            metadata.Variables.Add(new Variable
//            {
//                Ident = "3",
//                Type = Variable.VariableType.Single,
//                Name = "hlocation",
//                Label = new Label("House location"),
//                VariableValues = new VariableValues
//                {
//                    VariableValues = new List<Value>
//                        {
//                            new Value { Code = "1", Text = "North" },
//                            new Value { Code = "2", Text = "South" },
//                            new Value { Code = "3", Text = "East" },
//                            new Value { Code = "4", Text = "West" }
//                        }
//                }
//            });

//            AppendPersonHiearchy(metadata);
//            AppendTripHiearchy(metadata);

//            return metadata;
//        }


//        private static void AppendPersonHiearchy(SurveyMetadata root)
//        {
//            var personMetadata = new Hierarchy
//            {
//                Ident = "person",
//                Parent = new ParentDetails { Level = "hhold", LinkVar = "hnumber", Ordered = true },
//                Metadata = { Name = "PR9012-PERSON", Title = "Regional Travel Survey<br/>Persons" }
//            };


//            //hnumber
//            personMetadata.Metadata.Variables.Add(new Variable
//            {
//                Ident = "1",
//                Type = Variable.VariableType.Quantity,
//                Name = "hnumber",
//                Label = new Label("Household"),
//                VariableValues = new VariableValues
//                {
//                    Range = new ValueRange { From = "000001", To = "999999" }
//                }
//            });

//            //pnumber
//            personMetadata.Metadata.Variables.Add(new Variable
//            {
//                Ident = "2",
//                Type = Variable.VariableType.Quantity,
//                Name = "pnumber",
//                Label = new Label("Person"),
//                Use = "Serial",
//                VariableValues = new VariableValues
//                {
//                    Range = new ValueRange { From = "000001", To = "999999" }
//                }
//            });

//            //Gender
//            personMetadata.Metadata.Variables.Add(new Variable
//            {
//                Ident = "3",
//                Type = Variable.VariableType.Single,
//                Name = "pgender",
//                Label = new Label("Gender"),
//                VariableValues = new VariableValues
//                {
//                    VariableValues = new List<Value>
//                    {
//                        new Value { Code = "1", Text = "Male" },
//                        new Value { Code = "2", Text = "Female" }
//                    }
//                }
//            });

//            //Age
//            personMetadata.Metadata.Variables.Add(new Variable
//            {
//                Ident = "4",
//                Type = Variable.VariableType.Single,
//                Name = "page",
//                Label = new Label("Age"),
//                VariableValues = new VariableValues
//                {
//                    VariableValues = new List<Value>
//                    {
//                        new Value { Code = "1", Text = "Under 21" },
//                        new Value { Code = "2", Text = "21 to 45" },
//                        new Value { Code = "3", Text = "46 to 65" },
//                        new Value { Code = "4", Text = "Over 65" }
//                    }
//                }
//            });

//            root.Hierarchies.Add(personMetadata);
//        }

//        private static void AppendTripHiearchy(SurveyMetadata root)
//        {
//            var tripMetadata = new Hierarchy { Ident = "trip", Parent = new ParentDetails { Level = "person", LinkVar = "pnumber", Ordered = true } };

//            tripMetadata.Metadata.Name = "PR9012-TRIP";
//            tripMetadata.Metadata.Title = "Regional Travel Survey<br/>Trips";

//            //pnumber
//            tripMetadata.Metadata.Variables.Add(new Variable
//            {
//                Ident = "1",
//                Type = Variable.VariableType.Quantity,
//                Name = "pnumber",
//                Label = new Label("Person"),
//                VariableValues = new VariableValues
//                {
//                    Range = new ValueRange { From = "000001", To = "99999919" }
//                }
//            });

//            //tpurpose
//            tripMetadata.Metadata.Variables.Add(new Variable
//            {
//                Ident = "2",
//                Type = Variable.VariableType.Single,
//                Name = "tpurpose",
//                Label = new Label("Trip purpose"),
//                VariableValues = new VariableValues
//                {
//                    VariableValues = new List<Value>
//                    {
//                        new Value { Code = "1", Text = "Social, domestic, pleasure" },
//                        new Value { Code = "2", Text = "To or from place of work" },
//                        new Value { Code = "3", Text = "Business" }
//                    }
//                }
//            });

//            //tmode
//            tripMetadata.Metadata.Variables.Add(new Variable
//            {
//                Ident = "3",
//                Type = Variable.VariableType.Single,
//                Name = "tmode",
//                Label = new Label("Modes of travel"),
//                VariableValues = new VariableValues
//                {
//                    VariableValues = new List<Value>
//                    {
//                        new Value { Code = "1", Text = "Car or van driver" },
//                        new Value { Code = "2", Text = "Car or van passenger" },
//                        new Value { Code = "3", Text = "Bus" },
//                        new Value { Code = "4", Text = "Train" },
//                        new Value { Code = "5", Text = "Cycle" },
//                        new Value { Code = "6", Text = "Other" }
//                    }
//                }
//            });

//            root.Hierarchies.Add(tripMetadata);
//        }

//        public static List<Interview> LoadAllInterviews()
//        {
//            var interviews = new List<Interview>
//            {
//                MakeDummyInterview1(),
//                MakeDummyInterview2(),
//                MakeDummyInterview3()
//            };

//            return interviews;
//        }

//        private static Interview MakeDummyInterview1()
//        {
//            return new Interview
//            {
//                Ident = "010001",  //Household 1
//                DataItems = new List<DataItem>
//                {
//                    new DataItem {Ident = "1", VariableValues = new List<string> {"010001"}},
//                    new DataItem {Ident = "2", VariableValues = new List<string> {"2"}},
//                    new DataItem {Ident = "3", VariableValues = new List<string> {"3"}}
//                },
//                HierarchicalInterviews = new List<HierarchicalInterview>
//                {
//                    new HierarchicalInterview
//                    {
//                        Ident = "01000101",  //Household 1, Person 1
//                        Level = new Level {  Ident = "person" },
//                        DataItems = new List<DataItem>
//                        {
//                            new DataItem { Ident = "1", VariableValues = new List<string> { "010001" }},
//                            new DataItem { Ident = "2", VariableValues = new List<string> { "01000101" }},
//                            new DataItem { Ident = "3", VariableValues = new List<string> { "2" }},
//                            new DataItem { Ident = "4", VariableValues = new List<string> { "2" }}
//                        },
//                        HierarchicalInterviews = new List<HierarchicalInterview>
//                        {
//                            new HierarchicalInterview
//                            {
//                                Ident = "010001011",  //Household 1, Person 1, Trip 1
//                                Level = new Level { Ident = "trip" },
//                                DataItems = new List<DataItem>
//                                {
//                                    new DataItem { Ident = "1", VariableValues = new List<string> { "01000101" }},
//                                    new DataItem { Ident = "2", VariableValues = new List<string> { "1" }},
//                                    new DataItem { Ident = "3", VariableValues = new List<string> { "3" }}
//                                }
//                            },
//                            new HierarchicalInterview
//                            {
//                                Ident = "010001012",  //Household 1, Person 1, Trip 2
//                                Level = new Level { Ident = "trip" },
//                                DataItems = new List<DataItem>
//                                {
//                                    new DataItem { Ident = "1", VariableValues = new List<string> { "01000102" }},
//                                    new DataItem { Ident = "2", VariableValues = new List<string> { "1" }},
//                                    new DataItem { Ident = "3", VariableValues = new List<string> { "2" }}
//                                }
//                            }
//                        }
//                    },
//                    new HierarchicalInterview
//                    {
//                        Ident = "01000102",  //Household 1, Person 2
//                        Level = new Level {  Ident = "person" },
//                        DataItems = new List<DataItem>
//                        {
//                            new DataItem { Ident = "1", VariableValues = new List<string> { "010001" }},
//                            new DataItem { Ident = "2", VariableValues = new List<string> { "01000102" }},
//                            new DataItem { Ident = "3", VariableValues = new List<string> { "1" }},
//                            new DataItem { Ident = "4", VariableValues = new List<string> { "2" }}
//                        },
//                        HierarchicalInterviews = new List<HierarchicalInterview>
//                        {
//                            new HierarchicalInterview
//                            {
//                                Ident = "010001021",  //Household 1, Person 2, Trip 1
//                                Level = new Level { Ident = "trip" },
//                                DataItems = new List<DataItem>
//                                {
//                                    new DataItem { Ident = "1", VariableValues = new List<string> { "01000102" }},
//                                    new DataItem { Ident = "2", VariableValues = new List<string> { "2" }},
//                                    new DataItem { Ident = "3", VariableValues = new List<string> { "4" }}
//                                }
//                            },
//                            new HierarchicalInterview
//                            {
//                                Ident = "010001022",  //Household 1, Person 2, Trip 2
//                                Level = new Level { Ident = "trip" },
//                                DataItems = new List<DataItem>
//                                {
//                                    new DataItem { Ident = "1", VariableValues = new List<string> { "01000102" }},
//                                    new DataItem { Ident = "2", VariableValues = new List<string> { "3" }},
//                                    new DataItem { Ident = "3", VariableValues = new List<string> { "2" }}
//                                }
//                            },
//                            new HierarchicalInterview
//                            {
//                                Ident = "010001023",  //Household 1, Person 2, Trip 3
//                                Level = new Level { Ident = "trip" },
//                                DataItems = new List<DataItem>
//                                {
//                                    new DataItem { Ident = "1", VariableValues = new List<string> { "01000102" }},
//                                    new DataItem { Ident = "2", VariableValues = new List<string> { "2" }},
//                                    new DataItem { Ident = "3", VariableValues = new List<string> { "4" }}
//                                }
//                            },
//                            new HierarchicalInterview
//                            {
//                                Ident = "010001024",  //Household 1, Person 2, Trip 4
//                                Level = new Level { Ident = "trip" },
//                                DataItems = new List<DataItem>
//                                {
//                                    new DataItem { Ident = "1", VariableValues = new List<string> { "01000102" }},
//                                    new DataItem { Ident = "2", VariableValues = new List<string> { "1" }},
//                                    new DataItem { Ident = "3", VariableValues = new List<string> { "1" }}
//                                }
//                            }
//                        }
//                    }

//                }
//            };
//        }

//        private static Interview MakeDummyInterview2()
//        {
//            return new Interview
//            {
//                Ident = "010002",  //Household 2
//                DataItems = new List<DataItem>
//                {
//                    new DataItem {Ident = "1", VariableValues = new List<string> {"010002"}},
//                    new DataItem {Ident = "2", VariableValues = new List<string> {"3"}},
//                    new DataItem {Ident = "3", VariableValues = new List<string> {"2"}}
//                },
//                HierarchicalInterviews = new List<HierarchicalInterview>
//                {
//                    new HierarchicalInterview
//                    {
//                        Ident = "01000201",  //Household 2, Person 1
//                        Level = new Level {  Ident = "person" },
//                        DataItems = new List<DataItem>
//                        {
//                            new DataItem { Ident = "1", VariableValues = new List<string> { "010002" }},
//                            new DataItem { Ident = "2", VariableValues = new List<string> { "01000201" }},
//                            new DataItem { Ident = "3", VariableValues = new List<string> { "1" }},
//                            new DataItem { Ident = "4", VariableValues = new List<string> { "4" }}
//                        },
//                        HierarchicalInterviews = new List<HierarchicalInterview>
//                        {
//                            new HierarchicalInterview
//                            {
//                                Ident = "01000201",  //Household 2, Person 1, Trip 1
//                                Level = new Level { Ident = "trip" },
//                                DataItems = new List<DataItem>
//                                {
//                                    new DataItem { Ident = "1", VariableValues = new List<string> { "01000201" }},
//                                    new DataItem { Ident = "2", VariableValues = new List<string> { "2" }},
//                                    new DataItem { Ident = "3", VariableValues = new List<string> { "1" }}
//                                }
//                            },
//                            new HierarchicalInterview
//                            {
//                                Ident = "01000201",  //Household 2, Person 1, Trip 2
//                                Level = new Level { Ident = "trip" },
//                                DataItems = new List<DataItem>
//                                {
//                                    new DataItem { Ident = "1", VariableValues = new List<string> { "01000201" }},
//                                    new DataItem { Ident = "2", VariableValues = new List<string> { "2" }},
//                                    new DataItem { Ident = "3", VariableValues = new List<string> { "1" }}
//                                }
//                            },
//                            new HierarchicalInterview
//                            {
//                                Ident = "01000201",  //Household 2, Person 1, Trip 3
//                                Level = new Level { Ident = "trip" },
//                                DataItems = new List<DataItem>
//                                {
//                                    new DataItem { Ident = "1", VariableValues = new List<string> { "01000201" }},
//                                    new DataItem { Ident = "2", VariableValues = new List<string> { "1" }},
//                                    new DataItem { Ident = "3", VariableValues = new List<string> { "1" }}
//                                }
//                            }
//                        }
//                    },
//                    new HierarchicalInterview
//                    {
//                        Ident = "01000202",  //Household 2, Person 2
//                        Level = new Level {  Ident = "person" },
//                        DataItems = new List<DataItem>
//                        {
//                            new DataItem { Ident = "1", VariableValues = new List<string> { "010002" }},
//                            new DataItem { Ident = "2", VariableValues = new List<string> { "01000202" }},
//                            new DataItem { Ident = "3", VariableValues = new List<string> { "2" }},
//                            new DataItem { Ident = "4", VariableValues = new List<string> { "3" }}
//                        }
//                        //No trip data for Person 2
//                    },
//                    new HierarchicalInterview
//                    {
//                        Ident = "01000203",  //Household 2, Person 1
//                        Level = new Level {  Ident = "person" },
//                        DataItems = new List<DataItem>
//                        {
//                            new DataItem { Ident = "1", VariableValues = new List<string> { "010002" }},
//                            new DataItem { Ident = "2", VariableValues = new List<string> { "01000203" }},
//                            new DataItem { Ident = "3", VariableValues = new List<string> { "1" }},
//                            new DataItem { Ident = "4", VariableValues = new List<string> { "1" }}
//                        },
//                        HierarchicalInterviews = new List<HierarchicalInterview>
//                        {
//                            new HierarchicalInterview
//                            {
//                                Ident = "01000203",  //Household 2, Person 3, Trip 1
//                                Level = new Level { Ident = "trip" },
//                                DataItems = new List<DataItem>
//                                {
//                                    new DataItem { Ident = "1", VariableValues = new List<string> { "01000203" }},
//                                    new DataItem { Ident = "2", VariableValues = new List<string> { "1" }},
//                                    new DataItem { Ident = "3", VariableValues = new List<string> { "1" }}
//                                }
//                            }
//                        }
//                    },
//                }
//            };
//        }

//        private static Interview MakeDummyInterview3()
//        {
//            return new Interview
//            {
//                Ident = "010003",  //Household 3
//                DataItems = new List<DataItem>
//                {
//                    new DataItem {Ident = "1", VariableValues = new List<string> {"010003"}},
//                    new DataItem {Ident = "2", VariableValues = new List<string> {"1"}},
//                    new DataItem {Ident = "3", VariableValues = new List<string> {"3"}}
//                },
//                HierarchicalInterviews = new List<HierarchicalInterview>
//                {
//                    new HierarchicalInterview
//                    {
//                        Ident = "01000301",  //Household 3, Person 1
//                        Level = new Level {  Ident = "person" },
//                        DataItems = new List<DataItem>
//                        {
//                            new DataItem { Ident = "1", VariableValues = new List<string> { "010003" }},
//                            new DataItem { Ident = "2", VariableValues = new List<string> { "01000301" }},
//                            new DataItem { Ident = "3", VariableValues = new List<string> { "2" }},
//                            new DataItem { Ident = "4", VariableValues = new List<string> { "2" }}
//                        },
//                        HierarchicalInterviews = new List<HierarchicalInterview>
//                        {
//                            new HierarchicalInterview
//                            {
//                                Ident = "01000301",  //Household 3, Person 1, Trip 1
//                                Level = new Level { Ident = "trip" },
//                                DataItems = new List<DataItem>
//                                {
//                                    new DataItem { Ident = "1", VariableValues = new List<string> { "01000301" }},
//                                    new DataItem { Ident = "2", VariableValues = new List<string> { "2" }},
//                                    new DataItem { Ident = "3", VariableValues = new List<string> { "3" }}
//                                }
//                            }
//                        }
//                    }
//                }
//            };
//        }
//    }
//}
