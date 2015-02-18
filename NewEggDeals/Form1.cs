using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewEggDeals.Controls;
using NewEggDeals.Model;

namespace NewEggDeals
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();

      panel1.AutoScroll = true;
      //vScrollBar1.Scroll += (sender, e) => { panel1.VerticalScroll.Value = vScrollBar1.Value; };
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      var client = new WebClient();

      const int height = 64;
      var top = 0;

      var rows = XmlHelper.DealRows(client.DownloadString("http://www.newegg.com/Product/RSS.aspx?Submit=RSSDailyDeals"));
      Height = 0;

      foreach (var dealRow in rows.Where(x => x.Price.HasValue).OrderByDescending(x => x.SavingsPercent))
      {
        var control = new DealControl
        {
          Left = 0,
          Top = top,
          Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top,
          Width = panel1.Width,
        };

        top += height;
        //vScrollBar1.Refresh();

        control.Fill(dealRow);

        panel1.Controls.Add(control);

        AsyncDownloadImage(control, dealRow);

        Height = Math.Min(Height + height, 800);
        ;
        //if (panel1.Controls.Count >= 10) return;
      }
    }

    private void AsyncDownloadImage(DealControl control, DealRow dealRow)
    {
      new Thread(() => Download(control, dealRow)).Start();
      //BeginInvoke(new Action<DealControl, DealRow>(Download), control, dealRow);
    }

    private void Download(DealControl control, DealRow dealRow)
    {
      dealRow.DownloadImage();
      SetImage(control, dealRow.Image);
    }

    private void SetImage(DealControl control, Image image)
    {
      if (InvokeRequired)
      {
        Invoke(new Action<DealControl, Image>(SetImage), control, image);
      }
      else
      {
        control.SetImage();
      }
    }
  }
}
