using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NewEggDeals.Utilities;

namespace NewEggDeals.Model
{
  public class Deals
  {
    private IList<DealRow> _deals; 
    public IList<DealRow> AllDeals
    {
      get
      {
        var client = new WebClient();

        return _deals ??
          (_deals =
            XmlHelper.DealRows(client.DownloadString("http://www.newegg.com/Product/RSS.aspx?Submit=RSSDailyDeals")));
      }
    }

    public IList<DealRow> DealRows
    {
      get 
      { 
        var newOnly = Options.OnlyNew;
        if (newOnly) return AllDeals.Where(x => x.PublishDate > Options.LastRan).ToList();
        return AllDeals;
      }
    }
  }
}
