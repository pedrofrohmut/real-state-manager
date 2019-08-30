using System;

namespace RealStateManager.DataBase.Models
{
  public class Payment
  {
    public string Id { get; set; }
    public decimal Value { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime DateOverdue { get; set; }
    public bool IsPaid { get; set; }

    public string PropertyId { get; set; }
    public Property Property { get; set; }
  }
}
