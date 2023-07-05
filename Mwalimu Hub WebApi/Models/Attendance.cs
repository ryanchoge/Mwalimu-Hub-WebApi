namespace Mwalimu_Hub_WebApi.Models
{
    public class Attendance
    {
        public Attendance(int id, int scheduleId, string day, string time, string studentNo, string status)
        {
            Id = id;
            ScheduleId = scheduleId;
            Day = day;
            Time = time;
            StudentNo = studentNo;
            Status = status;
        }

        public int Id { get; set; }
        public int ScheduleId { get; set; }
        public string StudentNo { get; set; }
	    public string Time { get; set; }
	    public string Day { get; set; }
        public string Status { get; set; }
        
    }
}
