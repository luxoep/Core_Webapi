
using EngParent;
using EngService;

namespace EngDataSource
{
    public class EngDataSource_Class : IEngineerService
    {
        private List<Engineered> _engineered = new List<Engineered>()
        {
            new Engineered(1, "Alice", "Mech", 101),
            new Engineered(2, "Bob", "Elec", 102),
            new Engineered(3, "Charlie", "Civ", 103),
            new Engineered(4, "David", "Chem", 104),
            new Engineered(5, "Eve", "Bio", 105),
            new Engineered(5, "cc", "cm", 106),
            new Engineered(5, "bb", "ap", 107),
            new Engineered(5, "dd", "vp", 108),
        };
        #region Get
        public List<Engineered> GetEngineereds()
        {
            return _engineered;
        }
        public Engineered? GetEngineeredById(int id)
        {

            foreach (Engineered item in _engineered)
            {
                if (item.EngID == id) return item;
            }

            return null;
        }
        public List<Engineered> GetMoreEngineereds(int id)
        {
            List<Engineered> newEng = new List<Engineered>();

            foreach (Engineered item in _engineered)
            {
                if (item.EngID == id)
                {
                    newEng.Add(item);
                };
            }

            return newEng;
        }
        #endregion

        #region Post
        public Engineered? AddEngineer(Engineered engineered)
        {
            Engineered? NotIsNullEng = GetEngineeredById(engineered.EngID);

            if (NotIsNullEng != null) return null;

            _engineered.Add(engineered);

            return engineered;

        }

        public Engineered? PostUpdateEngineer(Engineered engineered, int id)
        {
            Engineered? NotIsNullEng = GetEngineeredById(id);

            if (NotIsNullEng == null) return null;

            NotIsNullEng.Name = engineered.Name;
            NotIsNullEng.Occupation = engineered.Occupation;
            NotIsNullEng.IdentificationCard = engineered.IdentificationCard;

            return NotIsNullEng;

        }


        #endregion

        #region Put
        public Engineered? PutUpdateEnginner(Engineered engineered, int id)
        {

            Engineered? engineeredPut = GetEngineeredById(id);

            if (engineeredPut == null) return null;

            engineeredPut.Name = engineered.Name;
            engineeredPut.Occupation = engineered.Occupation;
            engineeredPut.IdentificationCard = engineered.IdentificationCard;

            return engineered;
        }
        #endregion

        #region Delete
        public List<Engineered> DeleteEngineer(int id)
        {
            if (GetEngineeredById(id) == null) return null;

            _engineered.Remove(GetEngineeredById(id));

            return GetEngineereds();
        }

        public List<Engineered> DeleteDoubleConditionsEngineer(int id, int card)
        {
            List<Engineered> removeEng = new List<Engineered>();

            foreach (Engineered item in _engineered)
            {
                if (item.EngID == id && item.IdentificationCard == card)
                {
                    removeEng.Add(item);
                }
            }

            foreach (Engineered item in removeEng)
            {
                _engineered.Remove(item);
            }

            return GetEngineereds();
        }
        #endregion
    }
}