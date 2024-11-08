using FluentAssertions;
using RepForge.Domain.Excercises;
using RepForge.Domain.Shared;
using RepForge.Domain.Users;
using RepForge.Domain.Workouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepForge.Domain.UnitTests.Workouts;
public class WorkoutTests
{
    [Fact]
    public void AddExcerciseSetToWorkout_ShouldIncreaseExcerciseSetCount()
    {
        var userName = Name.Create("Bill");
        var user = User.Create(userName.Value);

        var workoutName = Name.Create("Full Body");

        var workout = new Workout(Guid.NewGuid(), workoutName.Value);
        var excercise = Excercise.Create(user.Id, userName.Value);
        var setCount = SetCount.Create(5);

        workout.AddExcerciseSet(excercise.Id, setCount.Value);

        workout.ExcerciseSets.Should().HaveCountGreaterThan(0);
    }
}
