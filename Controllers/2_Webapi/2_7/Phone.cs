namespace Phone_Class
{
    public class Phone
    {
        public int Id { get; set; }
        public string? PhoneType { get; set; }
        public string? PhoneName { get; set; }
        public Phone() { }
        public Phone(int id, string phoneType, string PhoneName)
        {
            this.Id = id;
            this.PhoneType = phoneType;
            this.PhoneName = PhoneName;
        }
    }
}