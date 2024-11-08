using RepForge.Domain.Shared;
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
        var workout = new Workout(Guid.NewGuid(), Name.Create("Full Body").Value);

        return workout;
    }
}
