using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

public class Chronometer : IChronometer
{
    private Stopwatch stopwatch;
    private List<string> laps;
    private bool isRunning;

    public Chronometer()
    {
        this.stopwatch = new Stopwatch();
        this.laps = new List<string>();
        this.isRunning = false;
    }

    public string GetTime
    {
        get
        {
            var elapsed = this.stopwatch.Elapsed;
            return $"{elapsed.Minutes:D2}:{elapsed.Seconds:D2}:{elapsed.Milliseconds:D3}";
        }
    }

    public IReadOnlyList<string> Laps => this.laps.AsReadOnly();

    public void Start()
    {
        if (!isRunning)
        {
            isRunning = true;
            this.stopwatch.Start();
        }
    }

    public void Stop()
    {
        this.stopwatch.Stop();
        this.isRunning = false;
    }

    public string Lap()
    {
        var currentTime = this.GetTime;
        this.laps.Add(currentTime);
        return currentTime;
    }

    public void Reset()
    {
        this.stopwatch.Reset();
        this.laps.Clear();
        this.isRunning = false;
    }
}
