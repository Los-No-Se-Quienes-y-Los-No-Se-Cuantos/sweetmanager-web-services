﻿using sweetmanager.API.Communication.Domain.Model.Commands;

namespace sweetmanager.API.Communication.Domain.Model.Aggregates.Alerts;

public partial class Alerts
{
    public int Id { get; private set; }
    
    public string Title { get; private set; }
    
    public string Description { get; private set; }
    
    public Alerts(string title, string description)
    {
        Title = title;
        Description = description;
    }
    
    public Alerts(CreateAlertsCommand command)
    {
        Title = command.Title;
        Description = command.Description;
    }
}