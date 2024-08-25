using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace sweetmanager.API.IAM.Domain.Model.Entities.Credential;

public partial class ManagerCredential : IEntityWithCreatedUpdatedDate
{
    [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }
    
    [Column("UpdatedAt")]  public DateTimeOffset? UpdatedDate { get; set; }
}