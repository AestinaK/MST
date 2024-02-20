namespace App.Setup.Dto;

public class ReminderDto
{
    public long CategoryId { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }
}