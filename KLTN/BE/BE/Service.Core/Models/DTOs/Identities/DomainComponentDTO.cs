using System;

public class DomainComponentDTO
{
    public Guid Id { get; set; }
    public string ComponentName { get; set; }
    public string ComponentEndpoint { get; set; }
    public string ComponentLogo { get; set; }
    public double Price { get; set; }
    public bool IsFree => Price == 0;
}