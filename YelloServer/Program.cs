using Infrastructure;

namespace YelloServer;

class Program
{
    public static void Main(string[] args)
    {
        DependencyInjection dependencies = new DependencyInjection();
        dependencies.Init(args);
    }
}