using System;

namespace Common.Application
{
  public class User : IEntity
  {
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public int TotalResult { get; set; }
  }
}