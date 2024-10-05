using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.IO;

namespace Server.Classes.Streaming
{
    public class ScreenStreaming
    {
        public ScreenStreaming() { }

        /// <summary>
        /// Take screenshot from the primary screen
        /// </summary>
        /// <returns></returns>
        public Stream TakeScreenshot()
        {
            var stream = new MemoryStream();

            var bounds = Screen.PrimaryScreen.Bounds;

            using (var bitmap = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppArgb))
            {
                using (var g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                }

                bitmap.Save(stream, ImageFormat.Jpeg);

                stream.Position = 0;
            }

            return stream;
        }
    }
}
