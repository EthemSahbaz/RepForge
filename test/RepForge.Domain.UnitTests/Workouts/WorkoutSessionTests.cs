using FluentAssertions;
using RepForge.Domain.UnitTests.TestConstants;
using RepForge.Domain.Workouts;
using RepForge.Domain.Workouts.Errors;

namespace RepForge.Domain.UnitTests.Workouts;
public class WorkoutSessionTests
{

    [Fact]
    public void StartSession_ShouldSetStateToStarted()
    {
        var workout = WorkoutConstants.Generate();
        var workoutSession = WorkoutSession.StartSession(workout.Id,DateTime.Now);

        workoutSession.State.Should().Be(WorkoutState.Started);
    }
    [Fact]
    public void FinishSession_ShouldSetStateToFinished()
    {
        var workout = WorkoutConstants.Generate();

        var workoutSession = WorkoutSession.StartSession(workout.Id, DateTime.Now);

        workoutSession.FinishSession(DateTime.Now + TimeSpan.FromSeconds(10));

        workoutSession.State.Should().Be(WorkoutState.Finished);
    }

    [Fact]
    public void FinishingWorkoutSession_WithStartTimeGreaterThanEndTime_ShouldReturnFailureResult()
    {
        var workout = WorkoutConstants.Generate();

        var workoutSession = WorkoutSession.StartSession(workout.Id, DateTime.Now + TimeSpan.FromSeconds(10));

        var finishResult = workoutSession.FinishSession(DateTime.Now);

        finishResult.IsFailure.Should().BeTrue();
        finishResult.Error.Should().Be(WorkoutSessionErrors.StartTimeProcedesEndTime);
    }
}
