using System.ComponentModel.DataAnnotations;

namespace Parent_Aniamal
{
    public class Aniamal
    {
        [Required(ErrorMessage = "ID 不能为空")]
        public int UUid { get; set; }

        // [Required(ErrorMessage = "Name 不能为空")]
        public string? Name { get; set; }
        public int Age { get; set; }

        [Required(ErrorMessage = "类型不能为空")]
        public string? AniamalType { get; set; }

        public Aniamal() { }
        public Aniamal(int uuid, string name, int age, string aniamalType)
        {
            this.UUid = uuid;
            this.Name = name;
            this.Age = age;
            this.AniamalType = aniamalType;
        }
    }
}