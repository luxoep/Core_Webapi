namespace Person_Class
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }

        public Person(int id, string name, int age, char gender)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }
    }
}