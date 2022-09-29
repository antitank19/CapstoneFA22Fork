using System.ComponentModel.DataAnnotations;

namespace Application.EntitiesStatus;

public enum WardEnum
{
    [Display(Name = "Phường 1")] Ward1,
    [Display(Name = "Phường 2")] Ward2,
    [Display(Name = "Phường 3")] Ward3
}