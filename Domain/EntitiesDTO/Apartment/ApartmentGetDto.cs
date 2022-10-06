﻿using Domain.EntitiesForManagement;

namespace Domain.EntitiesDTO.Apartment;

public class ApartmentGetDto
{
    public int ApartmentId { get; set; }
    public string Name { get; set; }
    public int AreaId { get; set; }
    public Area Area { get; set; }
}