using RepForge.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepForge.Domain.Users;
public static class UserErrors
{
    public static readonly Error NotFound = new(
    "UserErrors.NotFound",
    "Can not find an user with provided identifier.");

    public static readonly Error WorkoutAlreadyAdded = new(
        "UserErrors.WorkoutAlreadyAdded",
        "Can not add the same workout");

    public static readonly Error ExcerciseAlreadyAdded = new(
    "UserErrors.ExcerciseAlreadyAdded",
    "Can not add the same Excercise");
}
