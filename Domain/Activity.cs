namespace Domain;

public class Activity
{
    public String Id { get; set; } = Guid.NewGuid().ToString();
    public required String Title { get; set; }
    public DateTime Date { get; set; }
    public required String Description { get; set; }
    public required String Category { get; set; }
    public Boolean IsCancelled { get; set; }
    public required String City { get; set; }
    public required String Venue {get; set; }
    public Double Longtitude { get; set; }
    public Double Latitude { get; set; }
    
}