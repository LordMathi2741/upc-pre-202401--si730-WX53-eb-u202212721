using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace si730ebu202212721.API.Observability.Domain.Model.Aggregates;

/// <summary>
///   - Represents the auditable columns of a ThingState.
/// - This class is used to add the auditable columns to the ThingState aggregate root
/// </summary>
/// <remarks>
///    - Author: U202212721 Mathias Jave Diaz
///    - Version: 1.0.0
/// </remarks>
public partial class ThingState : IEntityWithCreatedUpdatedDate
{
    public DateTimeOffset? CreatedDate { get; set; }
    public DateTimeOffset? UpdatedDate { get; set; }
}