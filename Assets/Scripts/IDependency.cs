namespace Cube2048
{
    public interface IDependency<T> where T : class
    {
        void Inject(T dependency);
    }
}