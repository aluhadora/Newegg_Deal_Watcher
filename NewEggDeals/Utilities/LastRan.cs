using System;

namespace NewEggDeals.Utilities
{
  public static class LastRan
  {
    public static void UpdateOptions()
    {
      Options.Load();
      UpdateOptions(new RegistryEditor(false));
    }

    private static void UpdateOptions(RegistryEditor reg)
    {
      reg.Write(Options.LastRanOption, DateTime.Now);
    }
  }
}
