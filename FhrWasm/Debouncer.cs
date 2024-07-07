namespace FhrWasm;
public class Debouncer<T>(Action<T> action, int delay = 200)
{
    CancellationTokenSource? source;
    public void Debounce(T value)
    {
        source?.Cancel();
        source = new CancellationTokenSource();
        Task.Delay(delay, source.Token)
            .ContinueWith(task =>
            {
                if (task.IsCompletedSuccessfully)
                {
                    action(value);
                }
            }, TaskScheduler.Default);
    }
}