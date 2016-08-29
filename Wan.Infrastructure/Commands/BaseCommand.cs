namespace Wan.Infrastructure.Commands
{
    public class BaseCommand<T>
    {
        public string Sql { get; protected set; }

        public T Obj { get; protected set; }

    }
}
