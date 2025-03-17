using Microsoft.AspNetCore.Mvc;
using Parent_Aniamal;

namespace Childs_Cat
{
    public class Cat : Aniamal
    {
        public string? Feature { get; set; }
        public Cat() { }
        public Cat(int uuid, string name, int age, string aniamalType, string feature) : base(uuid, name, age, aniamalType)
        {
            this.Feature = feature;
        }

        private static List<Cat> cats = new List<Cat>()
        {
            new Cat(1,"布偶",12,"猫科","能上树"),
            new Cat(2, "加菲猫", 8, "猫科", "懒惰"),
            new Cat(3, "暹罗猫", 10, "猫科", "好奇"),
            new Cat(4, "英短蓝猫", 5, "猫科", "温顺"),
            new Cat(5, "波斯猫", 7, "猫科", "优雅"),
            new Cat(6, "橘猫", 3, "猫科", "贪吃"),
        };
        public List<Cat> GetCats()
        {
            // 防止外部修改
            return new List<Cat>(cats);
        }
        public Cat? RequiredCatId(int uuid)
        {
            foreach (Cat item in cats)
            {
                if (item.UUid == uuid) return item;
            }

            return null;
        }
        public List<Cat>? AddNew(Cat newCat)
        {
            foreach (Cat item in cats)
            {
                if (item.UUid == newCat.UUid) return null;
            }
            cats.Add(newCat);

            return cats;
        }
        public Cat? ResultUpdateCat(Cat newCat)
        {
            Cat cat = new Cat();
            Cat? ReqCat = cat.RequiredCatId(newCat.UUid);
            if (ReqCat == null) return null;

            ReqCat.UUid = newCat.UUid;
            ReqCat.Name = newCat.Name;
            ReqCat.Age = newCat.Age;
            ReqCat.AniamalType = newCat.AniamalType;
            ReqCat.Feature = newCat.Feature;
            return ReqCat;
        }

        public List<Cat>? ResultUpdateCatList(Cat newCat)
        {
            Cat cat = new Cat();
            Cat? ReqCat = cat.RequiredCatId(newCat.UUid);
            if (ReqCat == null) return null;

            ReqCat.UUid = newCat.UUid;
            ReqCat.Name = newCat.Name;
            ReqCat.Age = newCat.Age;
            ReqCat.AniamalType = newCat.AniamalType;
            ReqCat.Feature = newCat.Feature;
            return cats;
        }

        public Cat? ResultSelectUpdateCatUUid(int uuid, Cat newCat)
        {
            Cat cat = new Cat();
            Cat? ReqCat = cat.RequiredCatId(uuid);
            if (ReqCat == null) return null;

            ReqCat.UUid = uuid;
            ReqCat.Name = newCat.Name;
            ReqCat.Age = newCat.Age;
            ReqCat.AniamalType = newCat.AniamalType;
            ReqCat.Feature = newCat.Feature;
            return ReqCat;
        }

        public Cat? ResultSelectUpdateCatUUid_A(int uuid, Cat newCat)
        {
            Cat cat = new Cat();
            Cat? ReqCat = cat.RequiredCatId(uuid);

            if (ReqCat == null) return null;

            ReqCat.UUid = uuid;
            ReqCat.Name = newCat.Name;
            ReqCat.Age = newCat.Age;
            ReqCat.AniamalType = newCat.AniamalType;
            ReqCat.Feature = newCat.Feature;
            return ReqCat;
        }
    }
}