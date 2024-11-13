using RepForge.Domain.Shared;
using RepForge.Domain.Users;
using RepForge.Domain.Workouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepForge.Domain.UnitTests.TestConstants;
internal static class WorkoutConstants
{
    public static Workout Generate()
    {
        var userName = Name.Create("Bill");
        var user = User.Create(userName.Value);

        var workoutName = Name.Create("Full Body");

        var workout = Workout.Create(user.Id, workoutName.Value);

        return workout;
    }
}
