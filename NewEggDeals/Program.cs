using System;
using System.Windows.Forms;
using NewEggDeals.Utilities;

namespace NewEggDeals
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      ImageCache.CreateDatabase();
      LastRan.UpdateOptions();

      Application.Run(new DealForm());
    }
  }
}
