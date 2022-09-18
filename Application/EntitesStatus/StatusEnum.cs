using System.ComponentModel.DataAnnotations;

namespace FOMO.Management.EntitesStatus;

public enum StatusEnum
{
    [Display(Name = "Active")] Active,
    [Display(Name = "Inactive")] Disabled,
    [Display(Name = "Full")] Full,
    [Display(Name = "Completed")] Completed,
    [Display(Name = "Cancelled")] Cancelled,
    [Display(Name = "Pending")] Pending
}