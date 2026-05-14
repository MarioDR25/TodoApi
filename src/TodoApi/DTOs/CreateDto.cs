using System.ComponentModel.DataAnnotations;
namespace TodoApi.DTOs;


public class CreateDto
{
    [Required(ErrorMessage = "Label is required.")]
    [StringLength(50, ErrorMessage = "Label cannot exceed 50 characters.")]
    public string Label { get; set; } = string.Empty;
}


