

namespace Boiler
{
    public interface IBoilerRepository
    {
        Boiler Save(Boiler boiler);
        Boiler Retrieve();
    }
}