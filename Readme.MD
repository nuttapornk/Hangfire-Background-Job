
# Hangfire-Background-Job
ref: https://www.hangfire.io/

## Fire-and-Forget Jobs
- Run only-once and almost immediately after creation.
```c#
var jobId = BackgroundJob.Enqueue(
    () => Console.WriteLine("Fire-and-forget!"));
```

## Delayed Jobs
Delayed jobs are executed only once too, but not immediately, after a certain time interval.
```c#
var jobId = BackgroundJob.Schedule(
    () => Console.WriteLine("Delayed!"),
    TimeSpan.FromDays(7));
```

## Recurring Jobs
- many times on the specified CRON schedule.
```c#
RecurringJob.AddOrUpdate(
    "myrecurringjob",
    () => Console.WriteLine("Recurring!"),
    Cron.Daily);
```

## Continuations
Continuations are executed when its parent job has been finished.
```c#
BackgroundJob.ContinueJobWith(
    jobId,
    () => Console.WriteLine("Continuation!"));
```