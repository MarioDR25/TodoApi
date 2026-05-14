namespace TodoApi.DTOs;

public class TodoResponseDto
{
    public int Id { get; set; }
    public string Label { get; set; } = string.Empty;
    public bool IsComplete { get; set; } 
    public DateTime CreatedAt { get; set; } 
}


