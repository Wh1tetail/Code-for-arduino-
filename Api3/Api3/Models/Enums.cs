namespace Api3.Models
{
    public enum ScheduleType
    {
        WeeklyTime = 0,
        MonthlyTime = 1,
        Odometer = 2
    }

    public enum PmStatus
    {
        Overdue = 0,
        DueToday = 1,
        Upcoming = 2,
        Completed = 3
    }
}
