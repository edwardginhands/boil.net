

namespace Boiler
{
    public interface IBoilerStatusRepository
    {
        IBoilerStatus Save(IBoilerStatus boiler);
        IBoilerStatus Retrieve();
    }
}
