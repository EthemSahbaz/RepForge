﻿using RepForge.SharedKernel;

namespace RepForge.Domain.Excercises;
/// <summary>
/// Setting for a workout, representing how often an exercise needs
/// to be completed in a workout.
/// </summary>
public sealed class ExcerciseWorkoutSet : Entity
{
    public ExcerciseWorkoutSet(
        Guid id,
        Guid workoutId,
        Guid excerciseId,
        SetCount setCount) : base(id)
    {
        WorkoutId = workoutId;
        ExcerciseId = excerciseId;
        SetCount = setCount;
    }
    /// <summary>
    /// Id of belonging Workout.
    /// </summary>
    public Guid WorkoutId { get; }
    /// <summary>
    /// Id of the belonging Exercise.
    /// </summary>
    public Guid ExcerciseId { get; }
    /// <summary>
    /// Count of how many Exercise-Session needs be completed.
    /// </summary>
    public SetCount SetCount { get; }
}
