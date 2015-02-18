using System;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using NewEggDeals.Controls;
using NewEggDeals.Model;
using NewEggDeals.Utilities;

namespace NewEggDeals
{
  public partial class DealForm : Form
  {
    private Deals _model;

    public DealForm()
    {
      InitializeComponent();

      dealPanel.AutoScroll = true;
      
      if (Options.LastRan.HasValue)
      {
        Text += string.Format(" (Last Ran: {0})", Options.LastRan.Value);        
      }

      _model = new Deals();
    }

    private void FillDeals(object sender, EventArgs e)
    {
      const int height = 64;
      var top = 0;

      var rows = _model.DealRows;
      Height = 70;

      dealPanel.Controls.Clear();

      foreach (var dealRow in rows.Where(x => x.Price.HasValue).OrderByDescending(x => x.SavingsPercent))
      {
        var control = new DealControl
        {
          Left = 0,
          Top = top,
          Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top,
          Width = dealPanel.Width,
        };

        top += height;

        control.Fill(dealRow);

        dealPanel.Controls.Add(control);

        AsyncDownloadImage(control, dealRow);

        Height = Math.Min(Height + height, 800);
      }

      newCheckBox.Checked = Options.OnlyNew;
    }

    private void AsyncDownloadImage(DealControl control, DealRow dealRow)
    {
      new Thread(() => Download(control, dealRow)).Start();
      //Download(control,dealRow);
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

    private void newCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      Options.OnlyNew = newCheckBox.Checked;
      Options.Save(Options.OnlyNewOption);

      FillDeals(sender, e);
    }
  }
}
