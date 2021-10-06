namespace TSAPI.Public.Domain
{
    public class Enums
    {
        public enum VariableType
        {
            Single = 1,
            Multiple = 2,
            Quantity = 3,
            Character = 4,
            Logical = 5,
            Date = 6,
            Time = 7,
            Loop = 8
        }

        public enum UseType
        {
            None = 0,
            Serial = 1, 
            Weight = 2,
            System = 3,
            Language = 4
        }

        public enum AltLabelMode
        {
            Interview = 1,
            Analysis = 2
        }

        public enum ResultCode
        {
            Ok = 0
        }
    }
}
