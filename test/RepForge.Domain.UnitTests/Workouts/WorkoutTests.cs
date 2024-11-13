using FluentAssertions;
using RepForge.Domain.Excercises;
using RepForge.Domain.Shared;
using RepForge.Domain.UnitTests.TestConstants;

namespace RepForge.Domain.UnitTests.Workouts;
public class WorkoutTests
{
    [Fact]
    public void AddExcerciseSetToWorkout_ShouldIncreaseExcerciseSetCount()
    {

        var workout = WorkoutConstants.Generate();
        var excerciseName = Name.Create("Push Ups");

        var excercise = Excercise.Create(workout.UserId, excerciseName.Value);

        var setCount = SetCount.Create(5);

        workout.AddExcerciseSet(excercise.Id, setCount.Value);

        workout.ExcerciseSets.Should().HaveCountGreaterThan(0);
    }
}
