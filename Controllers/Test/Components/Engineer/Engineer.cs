using System.ComponentModel.DataAnnotations;

namespace EngParent
{
    public class Engineered
    {
        [Required(ErrorMessage = "EngID 不能为空")]
        public int EngID { get; set; }

        [Required(ErrorMessage = "Name 不能为空")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Occupation 不能为空")]
        public string? Occupation { get; set; }

        [Required(ErrorMessage = "Identification Crd 不能为空")]
        public int IdentificationCard { get; set; }

        public Engineered() { }
        public Engineered(int engid, string name, string occ, int card)
        {
            this.EngID = engid;
            this.Name = name;
            this.Occupation = occ;
            this.IdentificationCard = card;
        }
    }
}