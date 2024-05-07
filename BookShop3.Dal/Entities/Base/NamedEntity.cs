using System.ComponentModel.DataAnnotations;

namespace BookShop3.Dal.Entities.Base;

public abstract class NamedEntity : Entity
{
    [Required]
    public string Name { get; set; }
}