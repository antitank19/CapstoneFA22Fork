﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.EntitiesForManagement;

public class FlatType
{
    public FlatType()
    {
        Flats = new HashSet<Flat>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int FlatTypeId { get; set; }

    public int Capacity { get; set; }
    public string? Status { get; set; }
    public virtual ICollection<Flat> Flats { get; set; }
}