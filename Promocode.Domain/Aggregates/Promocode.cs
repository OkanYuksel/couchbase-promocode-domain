namespace Promocode.Domain.Aggregates;

public class Promocode
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public long UserGroup { get; set; }
}