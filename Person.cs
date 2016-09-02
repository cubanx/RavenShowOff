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

        public Person()
        {
            PhoneNumbers = new List<PhoneNumber>();
        }

        public Person(string firstName, string lastName) : this()
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleInitial { get; set; }
        public string Hometown { get; set; }
        public List<PhoneNumber> PhoneNumbers { get; set; }
    }
}