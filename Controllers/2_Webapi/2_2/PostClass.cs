using Student_Class;

namespace PostClass
{
    public class _Post
    {
        public static int Num = 0;
        private static List<Student> _people = new List<Student>();

        public List<Student> Post_Add(string name, int age, string gender)
        {
            _people.Add(new Student(Num += 1, name, age, gender));

            return _people;
        }
    }
}