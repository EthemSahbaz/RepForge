using RepForge.SharedKernel;

namespace RepForge.Domain.Shared;
public sealed record Duration
{
    private Duration(DateTime start, DateTime end)
    {
        Start = start;
        End = end;
    }

    public DateTime Start { get; init; }

    public DateTime End { get; init; }

    public TimeSpan GetDuration() => End - Start;

    public static Result<Duration> Create(DateTime start, DateTime end)
    {
        if (start >= end)
        {
            return Result.Failure<Duration>(new Error("Duration.StartDatePrecedesEndDate", "Start time preceds end time."));
        }

        var duration = new Duration(start, end);

        return duration;
    }
}
