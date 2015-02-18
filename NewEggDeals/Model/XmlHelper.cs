using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace NewEggDeals.Model
{
  public class XmlHelper
  {
    public static IList<DealRow> DealRows(string xml)
    {
      var doc = new HtmlDocument();
      doc.LoadHtml(xml);

      var rows = new List<DealRow>();

      foreach (var node in  doc.DocumentNode.ChildNodes[2].ChildNodes[1].ChildNodes)
      {
        if (node.Name == "item") rows.Add(new DealRow(node.OuterHtml));
      }

      return rows;
    }
  }
}
