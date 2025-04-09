using EngParent;

namespace EngService
{
    public interface IEngineerService
    {
        List<Engineered> GetEngineereds();
        List<Engineered> GetMoreEngineereds(int id);
        Engineered? GetEngineeredById(int id);
        Engineered? AddEngineer(Engineered engineered);
        Engineered? PostUpdateEngineer(Engineered engineered, int id);
        Engineered? PutUpdateEnginner(Engineered engineered, int id);
        List<Engineered> DeleteEngineer(int id);
        List<Engineered> DeleteDoubleConditionsEngineer(int id, int card);
    }
}