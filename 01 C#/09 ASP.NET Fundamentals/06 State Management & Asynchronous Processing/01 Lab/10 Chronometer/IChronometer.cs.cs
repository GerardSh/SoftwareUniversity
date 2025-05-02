public interface IChronometer
{
    string GetTime { get; }

    IReadOnlyList<string> Laps { get; }

    void Start();

    void Stop();

    string Lap();

    void Reset();
}
