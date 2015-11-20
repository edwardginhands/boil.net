

namespace Boiler
{
    public interface IBoilerRepository
    {
        IBoiler Save(IBoiler boiler);
        IBoiler Retrieve();
    }
}