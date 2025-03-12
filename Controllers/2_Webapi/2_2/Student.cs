using System.ComponentModel.DataAnnotations;
namespace Student_Class
{
    public class Student
    {
        [Required(ErrorMessage = "ID 不能为空")]
        public int Id { get; set; }
        [Required(ErrorMessage = "用户名不能为空")]
        [StringLength(10, ErrorMessage = "用户名长度不能超过 10 个字符")]
        public string? Name { get; set; }
        public int Age { get; set; }
        [Required(ErrorMessage = "性别不能为空")]
        [StringLength(1, ErrorMessage = "性别不能超过 1 个字符")]
        public string Gender { get; set; } = string.Empty;
        public Student() { }
        public Student(int id, string name, int age, string gender)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }
    }
}