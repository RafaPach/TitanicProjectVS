namespace DeveloperPathways.Domain
{
    public class Passenger
    {
        public int PassengerId { get; set; }
        public bool? Survived { get; set; }
        public int? Pclass { get; set; }
        public string? Name { get; set; }
        public string? Sex { get; set; }
        public double? Age { get; set; }
        public int? SibSp { get; set; }
        public int? Parch { get; set; }
        public string? Ticket { get; set; }
        public double? Fare { get; set; }
        public string? Cabin { get; set; }
        public string? Embarked { get; set; }

        // constructor for required fields
        public Passenger (string name , int? pclass, bool? survived)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name is required");
            }

            Name = name;
            Pclass = pclass;
            Survived = survived;
        }

        private Passenger() { }

        public void UpdateDetails(string? sex, double? age, int? sibsp, int? parch, string? ticket, double? fare, string? cabin, string? embarked)
        {
            Sex = sex;
            Age = age;
            SibSp = sibsp;
            Parch = parch;
            Ticket = ticket;
            Fare = fare;
            Cabin = cabin;
            Embarked = embarked;
        }
    }
}
