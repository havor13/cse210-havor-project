public class WritingAssignment : Assignment
{
    private string _title;

    // Constructor with base class initialization
    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        // Set any variables specific to WritingAssignment
        _title = title;
    }

    // Method to display writing assignment information
    public string GetWritingInformation()
    {
        // Calling the getter because _studentName is private in the base class
        string studentName = GetStudentName();
        return $"{_title} by {studentName}";
    }
}
