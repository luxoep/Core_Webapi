using Student_Class;

namespace PostClass
{
    public class _Post
    {

        private static List<Student> _people = new List<Student>();
        public static int Num = _people.Count();
        public List<Student> Post_Add(string name, int age, string gender)
        {
            _people.Add(new Student(Num += 1, name, age, gender));

            return _people;
        }
        public List<Student> Post_Add_A(Student s)
        {
            _people.Add(new Student(Num += 1, s.Name, s.Age, s.Gender));

            return _people;
        }
        public Student Post_Add_B(Student s)
        {
            return new Student(Num += 1, s.Name, s.Age, s.Gender);
        }
    }
}