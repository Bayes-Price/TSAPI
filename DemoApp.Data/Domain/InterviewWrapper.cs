using System;
using TSAPI.Public.Domain.Interviews;

namespace DemoApp.Data.Domain
{
    public class InterviewWrapper
    {
        public DateTime DateLastChanged { get; set; }
        public bool Complete { get; set; }
        public Interview Interview { get; set; }
    }
}
