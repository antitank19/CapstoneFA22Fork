using System.ComponentModel.DataAnnotations;

namespace FOMO.Management.Enums;

public enum CityEnum
{
    [Display(Name = "Ho Chi Minh")] HaChiMinh,
    [Display(Name = "Ha Noi")] HaNoi,
    [Display(Name = "Da Nang")] DaNang,
    [Display(Name = "Can Tho")] CanTho
}