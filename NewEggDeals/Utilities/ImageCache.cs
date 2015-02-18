using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace NewEggDeals.Utilities
{
  public static class ImageCache
  {
    private const string DatabaseFileName = "ImageCache.sqlite";
    private const string TableName = "ImageCache";
    private const string UrlColumnName = "Url";
    private const string ImageColumnName = "Image";

    public static void CreateDatabase()
    {
      var con = NewConnection();

      try
      {
        var cmd = con.CreateCommand();
        cmd.CommandText = string.Format("SELECT * FROM {0} WHERE 1 = 0", TableName);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
      }
      catch (Exception)
      {
        con.Close();
        SQLiteConnection.CreateFile(DatabaseFileName);

        CreateCacheTable();
      }
    }

    private static void CreateCacheTable()
    {
      var sql = string.Format("create table {0} ({1} varchar(60), {2} BLOB)", TableName, UrlColumnName, ImageColumnName);

      var con = NewConnection();
      con.Open();
      var command = new SQLiteCommand(sql, con);
      command.ExecuteNonQuery();
      con.Close();
    }

    private static SQLiteConnection NewConnection()
    {
      var con = new SQLiteConnection(string.Format("Data Source={0};Version=3;", DatabaseFileName));
      return con;
    }

    public static byte[] ImageToByte(Image image, ImageFormat format)
    {
      using (var ms = new MemoryStream())
      {
        image.Save(ms, format);
        byte[] imageBytes = ms.ToArray();
        return imageBytes;
      }
    }

    public static Image ByteToImage(byte[] imageBytes)
    {
      using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
      {
        ms.Write(imageBytes, 0, imageBytes.Length);
        Image image = new Bitmap(ms);
        return image;
      }
    }

    public static void SaveImage(string url, Image image)
    {
      var con = NewConnection();
      var cmd = con.CreateCommand();

      cmd.CommandText = String.Format("INSERT INTO {0} ({1}, {2}) VALUES (@0, @1);", TableName, UrlColumnName, ImageColumnName);
      cmd.Parameters.Add(new SQLiteParameter("@0", DbType.String) { Value = url });
      cmd.Parameters.Add(new SQLiteParameter("@1", DbType.Binary) {Value = ImageToByte(image, ImageFormat.Png)});
      con.Open();

      try
      {
        cmd.ExecuteNonQuery();
      }
      catch (Exception e)
      {
        MessageBox.Show(e.Message);
      }

      con.Close();
    }

    public static Image LoadImage(string url)
    {
      var con = NewConnection();
      var query = string.Format("SELECT {0} FROM {1} WHERE {2}='{3}';", ImageColumnName, TableName, UrlColumnName, url);
      
      var cmd = con.CreateCommand();
      cmd.CommandText = query;

      Image image = null;

      con.Open();
      try
      {
        try
        {
          using (var reader = cmd.ExecuteReader())
          {
            while (reader.Read())
            {
              const int CHUNK_SIZE = 2 * 1024;
              byte[] buffer = new byte[CHUNK_SIZE];
              long bytesRead;
              long fieldOffset = 0;
              using (var stream = new MemoryStream())
              {
                while ((bytesRead = reader.GetBytes(0, fieldOffset, buffer, 0, buffer.Length)) > 0)
                {
                  stream.Write(buffer, 0, (int)bytesRead);
                  fieldOffset += bytesRead;
                }
                image = ByteToImage(stream.ToArray());
              }
            }
          }

        }
        catch (Exception e)
        {
        }
      }
      catch (Exception e)
      {
      }
      con.Close();

      return image;
    }
  }
}
