namespace Mwalimu_Hub_WebApi.Models
{
    public class Timetable
    {
        public int ClassCode { get; set; }
        public string ClassType { get; set; } = string.Empty;
        public int ClassLevel { get; set; }
        public string StreamName { get; set; } = string.Empty;
        public string Day { get; set; } = string.Empty;
        public string Time { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;  
        public string SubjectID { get; set; } = string.Empty;
        public string TeacherID { get; set; } = string.Empty;
    }
}
