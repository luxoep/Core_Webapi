namespace Student_Class
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; } = string.Empty;
        public Student(int id, string name, int age, string gender)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }
    }
}