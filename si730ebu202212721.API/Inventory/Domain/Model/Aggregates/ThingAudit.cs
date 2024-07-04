using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace si730ebu202212721.API.Inventory.Domain.Model.Aggregates;

public partial class Thing : IEntityWithCreatedUpdatedDate
{
    public DateTimeOffset? CreatedDate { get; set; }
    public DateTimeOffset? UpdatedDate { get; set; }
}