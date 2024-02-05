using System.ComponentModel.DataAnnotations;

namespace WebUI.Models;

public class Item
{
    public int Id { get; set; }

    // [Required] attribute to indicate that a property must have a value.
    [Required]
    public string? Name { get; set; }
    public ItemSize Size { get; set; }
    public bool IsGlutenFree { get; set; }

    // [Range] attribute to constrain a value to a specific range.
    [Range(0.01, 9999.99)]
    public decimal Price { get; set; }
}

public enum ItemSize { Small, Medium, Large }