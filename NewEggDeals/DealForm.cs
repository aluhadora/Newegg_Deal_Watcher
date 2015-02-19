using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using NewEggDeals.Controls;
using NewEggDeals.Model;
using NewEggDeals.Utilities;

namespace NewEggDeals
{
  public partial class DealForm : Form
  {
    private readonly Deals _model;

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
      SetHeight(70);

      var controls = new List<Control>();

      foreach (var dealRow in rows.Where(RowFilter).OrderByDescending(x => x.SavingsPercent))
      {
        var control = new DealControl
        {
          Left = 0,
          Top = top,
          Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top,
          Width = dealPanel.Width,
        };

        controls.Add(control);

        top += height;

        control.Fill(dealRow);

        AsyncDownloadImage(control, dealRow);

        SetHeight(Math.Min(Height + height, 800));
      }

      ClearDealPanel();
      foreach (var control in controls)
      {
        AddControlToDealPanel(control);
      }

      newCheckBox.Checked = Options.OnlyNew;
    }

    private void ClearDealPanel()
    {
      if (dealPanel.InvokeRequired)
      {
        dealPanel.Invoke(new Action(ClearDealPanel));
      }
      else
      {
        dealPanel.Controls.Clear();
      }
    }

    private void AddControlToDealPanel(Control control)
    {
      if (dealPanel.InvokeRequired)
      {
        dealPanel.Invoke(new Action<Control>(AddControlToDealPanel), control);
      }
      else
      {
        dealPanel.Controls.Add(control);
      }
    }

    private void SetHeight(int height)
    {
      if (InvokeRequired)
      {
        Invoke(new Action<int>(SetHeight), height);
      }
      else
      {
        Height = height;
      }
    }


    private bool RowFilter(DealRow x)
    {
      if (!x.Price.HasValue) return false;
      if (searchTextBox.Text == string.Empty) return true;

      return x.Title.ToUpper().Contains(searchTextBox.Text.ToUpper());
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

    private void searchTextBox_TextChanged(object sender, EventArgs e)
    {
      new Thread(() => FillDeals(sender, e)).Start();
    }

    private void searchTextBox_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Escape)
      {
        searchTextBox.Text = string.Empty;
      }
    }
  }
}
