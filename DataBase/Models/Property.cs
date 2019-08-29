using System.Collections.Generic;

namespace RealStateManager.DataBase.Models
{
  public class Property
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public decimal Value { get; set; }
    public string Family { get; set; }

    public IEnumerable<Payment> Payments { get; set; }
  }
}
