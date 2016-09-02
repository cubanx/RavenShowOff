using System.Collections.Generic;

namespace RavenShowOff
{
    public class Person
    {
        public class PhoneNumber
        {
            public PhoneNumber(int areaCode, string restOfNumber)
            {
                AreaCode = areaCode;
                RestOfNumber = restOfNumber;
            }

            public int AreaCode { get; private set; }
            public string RestOfNumber { get; private set; }

            public string FullNumber()
            {
                return $"({AreaCode}) {RestOfNumber}";
            }
        }

        public Person(string name)
        {
            Name = name;
            PhoneNumbers = new List<PhoneNumber>();
        }

        public string Id { get; private set; }
        public string Name { get; private set; }
        public List<PhoneNumber> PhoneNumbers { get; set; }
        
    }
}