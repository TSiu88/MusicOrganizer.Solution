using System;
using System.Collections.Generic;

namespace musicOrganizer.Models
{
  public class Cd
  {
      public string Title { get; set; }
      public int Id { get; }
      public static List<Cd> _instances = new List<Cd> {};
      public Cd(string title)
      {
        Title = title;
        _instances.Add(this);
        Id = _instances.Count;
      }

      public static List<Cd> GetAll()
      {
        return _instances;
      }

      public static void ClearAll()
      {
        _instances.Clear();
      }

      public static Cd Find(int searchId)
      {
        return _instances[searchId-1];
      }

  }
}