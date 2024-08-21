namespace Movies.Application.Models.Helpers;

public static class IdGenerator
{
    private static long _counter = 0;
    private static readonly object _lock = new object();

    public static long UniqueId()
    {
        lock (_lock)
        {
            var timestamp = DateTime.UtcNow.Ticks;
            _counter++;
            return timestamp + _counter;
        }
    }
}
