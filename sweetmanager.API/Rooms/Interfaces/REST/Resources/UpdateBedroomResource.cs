﻿namespace sweetmanager.API.Rooms.Interfaces.REST.Resources;

public record UpdateBedroomResource(int Id, string TypeBedroom, int TotalBed,
                                    int TotalBathroom, int TotalTelevision, string State);