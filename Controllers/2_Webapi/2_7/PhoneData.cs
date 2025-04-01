using Phone_Class;

namespace Phone_Data
{
    public class PhoneData
    {
        private List<Phone> phones = new List<Phone>()
        {
            new Phone(1,"Iphone","苹果手机"),
            new Phone(2,"MI","小米手机"),
            new Phone(3,"Vivo","步步高手机"),
            new Phone(4,"ReadMi","红米手机")
        };
        public List<Phone> GetPhones()
        {
            return new List<Phone>(phones);
        }
        public Phone SelectPhone(int id)
        {
            foreach (Phone item in phones)
            {
                if (item.Id == id) return item;
            }
            return new Phone();
        }
    }
}