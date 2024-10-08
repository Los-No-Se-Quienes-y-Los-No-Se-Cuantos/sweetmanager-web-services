﻿using sweetmanager.API.Rooms.Domain.Model.Aggregates;

namespace sweetmanager.API.Rooms.Domain.Model.ValueObjects;

public record BedroomInformation(int TotalBed, int TotalBathroom, int TotalTelevision, string Description, decimal Price)
{
    public BedroomInformation() : this(0, 0, 0, "", 0) { }
    public BedroomInformation(int totalBed, int totalBathroom, int totalTelevision) : this(totalBed, totalBathroom, totalTelevision, "", 0){ }
    
    public string Resources() => "TotalBed: " + TotalBed + "\nTotalBathRoom: " + TotalBathroom + "\nTotalTelevision: " + TotalTelevision;
}