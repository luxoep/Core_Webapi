using Person_Class;
namespace _Get_Class
{
    public class GetClass
    {
        public string Get_1()
        {
            return "Get";
        }
        public Dictionary<string, object> Get_2()
        {
            Dictionary<string, object> get_1 = new Dictionary<string, object>()
            {
                {"id",1},
                {"name","张三"},
                {"age",19},
                {"gender",'男'}
            };

            return get_1;
        }
        public List<Person> Get_3()
        {
            List<Person> per = new List<Person>()
            {
                new Person(1,"张三",12,'男'),
                new Person(2,"王五",19,'男')
            };
            return per;
        }
    }
}