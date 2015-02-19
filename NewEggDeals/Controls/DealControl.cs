using System;
using System.Text;
using System.Windows.Forms;
using NewEggDeals.Model;

namespace NewEggDeals.Controls
{
  public partial class DealControl : UserControl
  {
    private DealRow _row;

    public DealControl()
    {
      InitializeComponent();
    }

    public void Fill(DealRow row)
    {
      _row = row;
      titleLabel.Text = row.Title;
      priceLabel.Text = row.Price != null ? row.Price.Value.ToString("$0.00") : string.Empty;
      FillSavings(row);
      dateLabel.Text = row.PublishDate.ToString();
    }

    private void FillSavings(DealRow row)
    {
      var sb = new StringBuilder();
      if (row.SavingsPercent == null)
      {
        savingsLabel.Text = string.Empty;
        return;
      }
      sb.Append(row.SavingsPercent != null ? row.SavingsPercent.Value.ToString("p0") : string.Empty);
      savingsLabel.Text =
        sb.AppendFormat(" ({0})", (row.OriginalPrice*row.SavingsPercent).Value.ToString("$0.00")).ToString();
    }

    public void SetImage()
    {
      pictureBox.Click += PictureBoxOnClick;
      pictureBox.Image = null;
      pictureBox.BackgroundImage = _row.Image;
      pictureBox.BackgroundImageLayout = ImageLayout.Stretch;
    }

    private void PictureBoxOnClick(object sender, EventArgs e)
    {
      System.Diagnostics.Process.Start(_row.Link);
    }
  }
}
