﻿using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace sweetmanager.API.IAM.Domain.Model.Aggregates;

public partial  class User : IEntityWithCreatedUpdatedDate
{
    [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }
    
    [Column("UpdatedAt")]  public DateTimeOffset? UpdatedDate { get; set; }
}