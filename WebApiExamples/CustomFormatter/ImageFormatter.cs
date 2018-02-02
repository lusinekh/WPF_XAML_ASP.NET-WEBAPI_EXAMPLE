using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CustomFormatter.Models;

namespace CustomFormatter
{
    public class ImageFormatter : MediaTypeFormatter
    {
        public ImageFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("image/png"));
        }
        public override bool CanReadType(Type type)
        {
            return false;
        }
        public override bool CanWriteType(Type type)
        {
            return type == typeof(Author);
        }
        public override Task WriteToStreamAsync(Type type, object value, Stream
        writeStream, HttpContent content, TransportContext transportContext)
        {
            return Task.Factory.StartNew(() => WriteToStream(type, value,
            writeStream, content));
        }
        public void WriteToStream(Type type, object value, Stream stream,
        HttpContent content)
        {
            Author author = (Author)value;
            using (WebClient webClient = new WebClient())
            {
                byte[] data = webClient.DownloadData(author.PhotoUrl);

                using (MemoryStream mem = new MemoryStream(data))
                using (var image = Image.FromStream(mem))
                {
                    image.Save($@"C:\Users\HP\Desktop\Test\{author.Name}", ImageFormat.Png);
                }
            }
            Image photo = Image.FromFile($@"C:\Users\HP\Desktop\Test\{author.Name}");
            photo.Save(stream, ImageFormat.Png);
            photo.Dispose();
        }
    }
}