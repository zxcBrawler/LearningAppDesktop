namespace LearningApp.Models;

public class UserCourse
{
    public User? User { get; set; }
    public Course? Course { get; set; }
    public bool IsFinished { get; set; }
    public float CourseProgress { get; set; }
}