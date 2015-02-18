using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NewEggDeals.Utilities
{
  public static class Options
  {
    public static DateTime? LastRan { get; set; }
    public static bool OnlyNew { get; set; }

    public const string LastRanOption = "LastRan";
    public const string OnlyNewOption = "OnlyNew";

    private static readonly IDictionary<string, Func<object>> OptionMappings = new Dictionary<string, Func<object>>
    {
      {LastRanOption, () => LastRan},
      {OnlyNewOption, () => OnlyNew}
    };

    private static readonly RegistryEditor Reg = new RegistryEditor(false);

    public static void Save(string option)
    {
      Reg.Write(option, OptionMappings[option]());
    }

    public static void Load(string option)
    {
      var properties = typeof(Options).GetProperties();
      var property = properties.First(x => x.Name == option);

      if (property.PropertyType == typeof(DateTime?))
      {
        property.SetValue(null, Reg.ReadDateTime(option));
      }
      else if (property.PropertyType == typeof(bool))
      {
        var value = Reg.ReadBool(option);
        property.SetValue(null, value.HasValue && value.Value);
      }
    }

    public static void Load()
    {
      foreach (var option in OptionMappings.Keys)
      {
        Load(option);
      }
    }
  }
}
