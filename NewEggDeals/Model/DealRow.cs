using System;
using System.Drawing;
using System.Globalization;
using System.Net;
using System.Web;
using HtmlAgilityPack;
using NewEggDeals.Utilities;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace NewEggDeals.Model
{
  public class DealRow
  {
    public string Title { get; set; }
    public string Link { get; set; }
    public string Description { get; set; }
    public DateTime PublishDate { get; set; }

    //Parsed from description
    public string ImageURL { get; private set; }
    public Image Image { get; set; }
    public decimal? Price { get; private set; }
    public decimal? SavingsPercent { get; private set; }
    public decimal? OriginalPrice { get; private set; }

    public void ParseDescription(string description)
    {
      
    }

    public DealRow(string xml)
    {
      xml = HttpUtility.HtmlDecode(xml);
      var doc = new HtmlDocument();
      doc.LoadHtml(xml);

      var documentNode = doc.DocumentNode;
      HtmlNode lastNode = null;
      foreach (var node in documentNode.ChildNodes[0].SelectNodes("//text()[normalize-space(.) != '']"))
      {
        if (node.ParentNode.Name == "title") Title = NodeText(node);
        else if (node.PreviousSibling != null && node.PreviousSibling.Name == "link") Link = NodeText(node);
        else if (lastNode != null && NodeText(lastNode) == "Price:") Price = ParsePriceNode(node);
        else if (lastNode != null && NodeText(lastNode) == "Save:") SavingsPercent = ParsePriceNode(node);
        else if (node.ParentNode.Name == "pubdate") PublishDate = ParseDate(node);

        lastNode = node;
      }

      RecurseForImageNode(documentNode);
      if (Price.HasValue && SavingsPercent.HasValue)
      {
        OriginalPrice = (Price)/(1m - SavingsPercent);
        if (OriginalPrice.HasValue) OriginalPrice = Math.Round(OriginalPrice.Value, 2);
      }
    }

    private void RecurseForImageNode(HtmlNode node)
    {
      if (!string.IsNullOrEmpty(ImageURL)) return;
      if (node.Name == "img")
      {
        var src = node.Attributes["src"];
        ImageURL = src.Value;
        //Image = DownloadRemoteImageFile(ImageURL);
      }
      else
      {
        foreach (var childNode in node.ChildNodes)
        {
          RecurseForImageNode(childNode);          
        }
      }
    }

    public void DownloadImage()
    {
      var cachedImage = ImageCache.LoadImage(ImageURL);
      if (cachedImage == null)
      {
        Image = DownloadRemoteImageFile(ImageURL);
        ImageCache.SaveImage(ImageURL, Image);
      }
      else
      {
        Image = cachedImage;
      }
    }

    //private static Image DownloadRemoteImageFile(string uri)
    //{
    //  lock (Class1.Thing)
    //  {
    //    var request = (HttpWebRequest)WebRequest.Create(uri);
    //    var response = (HttpWebResponse)request.GetResponse();

    //    // Check that the remote file was found. The ContentType
    //    // check is performed since a request for a non-existent
    //    // image file might be redirected to a 404-page, which would
    //    // yield the StatusCode "OK", even though the image was not
    //    // found.
    //    if ((response.StatusCode == HttpStatusCode.OK ||
    //      response.StatusCode == HttpStatusCode.Moved ||
    //      response.StatusCode == HttpStatusCode.Redirect) &&
    //      response.ContentType.StartsWith("image", StringComparison.OrdinalIgnoreCase))
    //    {

    //      // if the remote file was found, download oit
    //      using (Stream stream = response.GetResponseStream())
    //      {
    //        if (stream == null) return null;
    //        return Image.FromStream(stream);
    //      }
    //    }
    //    return null;
    //  }
    //}

    private static Image DownloadRemoteImageFile(string imageUrl)
    {
      WebRequest requestPic = WebRequest.Create(imageUrl);

      WebResponse responsePic = requestPic.GetResponse();

      return Image.FromStream(responsePic.GetResponseStream()); // Error

      //webImage.Save("D:\\Images\\Book\\" + fileName + ".jpg");
    }

    private DateTime ParseDate(HtmlNode node)
    {
      var text = NodeText(node);
      return DateTime.Parse(text);
    }

    private decimal? ParsePriceNode(HtmlNode node)
    {
      var text = NodeText(node);
      decimal d;
      if (decimal.TryParse(text, NumberStyles.Currency, CultureInfo.CurrentCulture, out d))
      {
        return d;
      }
      if (decimal.TryParse(text.TrimEnd(new [] { '%'}), out d))
      {
        return d / 100m;
      }
      return null;
    }

    private string NodeText(HtmlNode node)
    {
      var text = node.InnerText.Trim();
      return HttpUtility.HtmlDecode(text);
    }
  }
}
