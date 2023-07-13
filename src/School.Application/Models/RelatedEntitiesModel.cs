namespace School.Application.Models;

public class RelatedEntitiesModel
{
    public IEnumerable<Guid> ItemsIds { get; set; } = new List<Guid>();
}
