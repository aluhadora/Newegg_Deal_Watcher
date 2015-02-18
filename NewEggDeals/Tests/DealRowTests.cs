using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NewEggDeals.Model;

namespace NewEggDeals.Tests
{
  [TestFixture]
  public class DealRowTests
  {
    [Test]
    public void ValuesFilledFromItemXml()
    {
      var row = new DealRow(Properties.Resources.SampleXml);

      Assert.That(row.Title, Is.EqualTo("$259.99 - ASUS Transformer Book T100TAF-B1-BF Intel Atom Z3735F (1.33GHz) 2GB Memory 32GB SSD 10.1\" Touchscreen 2-in-1 Tablet Windows 8.1 32-Bit"));
      Assert.That(row.Link, Is.EqualTo(@"http://www.newegg.com/Product/Product.aspx?Item=N82E16834232207&nm_mc=OTC-RSS&cm_sp=OTC-RSS-_-All%20Ultrabooks-_-ASUS-_-N82E16834232207"));
      Assert.That(row.Price, Is.EqualTo(259.99m));
      Assert.That(row.SavingsPercent, Is.EqualTo(.21m));
    }

    [Test]
    public void FullSampleXml()
    {
      XmlHelper.DealRows(Properties.Resources.FullXml);
    }
  }
}
