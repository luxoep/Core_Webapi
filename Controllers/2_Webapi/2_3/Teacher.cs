using Student_Class;

namespace Teacher_Class
{
    public class Teacher : Student
    {
        public string Occupation { get; set; }
        public Teacher () { }
        public Teacher(int id, string name, int age, string gender, string occ) : base(id, name, age, gender)
        {
            this.Occupation = occ;
        }
    }
}