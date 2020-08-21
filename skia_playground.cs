using System;
using System.IO;
using SkiaSharp;

namespace graphics_playground
{
  class Program
  {
    static void Main(string[] args)
    {
      var info = new SKImageInfo(256, 256);
      using var surface = SKSurface.Create(info);
      SKCanvas canvas = surface.Canvas;

      canvas.Clear(SKColors.White);

      // configure our brush
      var redBrush = new SKPaint
      {
        Color = new SKColor(0xff, 0, 0),
        IsStroke = true
      };
      var blueBrush = new SKPaint
      {
        Color = new SKColor(0, 0, 0xff),
        IsStroke = true
      };

      for (int i = 0; i < 64; i += 8)
      {
        var rect = new SKRect(i, i, 256 - i - 1, 256 - i - 1);
        canvas.DrawRect(rect, (i % 16 == 0) ? redBrush : blueBrush);
      }

      var img = surface.Snapshot();

      // encoding to PNG
      
      var data = img.Encode(SKEncodedImageFormat.Png, 80);
    
      var path = AppDomain.CurrentDomain.BaseDirectory + @"\";
      
      using (var stream = File.OpenWrite(Path.Combine(path, "1.png")))
      {
        // save the data to a stream
        data.SaveTo(stream);
      }
    }
  }
}
