using System;
using System.Collections.Generic;

namespace musicOrganizer.Models
{
    public class Artist
    {
      public string Name { get; set; }
      public int Id { get; }
      private static List<Artist> _instances = new List<Artist> {};
      public List<Cd> Cds { get; set; }

      public Artist(string name)
      {
          Name = name;
          _instances.Add(this);
          Id = _instances.Count;
          Cds = new List<Cd> {};
      }

      public static List<Artist> GetAll()
      {
          return _instances;
      }

      public static void ClearAll()
      {
          _instances.Clear();
      }

      public static Artist Find(int searchId)
      {
          return _instances[searchId-1];
      }

      public void AddCd(Cd cd)
      {
          Cds.Add(cd);
      }
    }
}
