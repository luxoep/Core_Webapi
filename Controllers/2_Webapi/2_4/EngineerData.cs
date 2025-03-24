using Eng;

namespace EngData
{
    public class EngineerData
    {
        private static List<Engineer> engs = new List<Engineer>()
        {
            new Engineer(1,"张三",45,"男"),
            new Engineer(2,"李四",56,"男"),
            new Engineer(3,"王五",35,"男"),
            new Engineer(4,"黄六",41,"男"),
            new Engineer(5,"刘七",39,"男"),
        };

        public List<Engineer> engineers()
        {
            return new List<Engineer>(engs);
        }
        public Engineer? resEng(int id)
        {
            foreach (Engineer item in engs)
            {
                if (item.Id == id) return item;
            }
            return null;
        }
        public List<Engineer> RemoveEng(int id)
        {
            EngineerData engineerData = new EngineerData();
            if (resEng(id) != null)
            {
                engs.Remove(engineerData.resEng(id));
                return engineerData.engineers();
            }
            return new List<Engineer>();
        }

    }
}