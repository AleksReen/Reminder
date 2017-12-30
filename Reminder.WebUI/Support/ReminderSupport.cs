using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml.Serialization;

namespace Reminder.WebUI.Support
{
    public static class ReminderSupport
    {
        public static string GetImagePath(HttpPostedFileBase Image, string name)
        {
            var imagePath = "";

            if (Image != null)
            {
                return imagePath = Path.Combine("/Images/" + name);
            }

            return imagePath = "/Images/No-image-found.jpg";
        }

        public static bool ChechExtImg(HttpPostedFileBase Image)
        {

            var exFormat = new string[] { ".jpg", ".jpeg", ".gif", ".png" };
            var ex = Path.GetExtension(Image.FileName);

            if (exFormat.Contains(ex))
            {
                return true;
            }
            return false;
        }

        public static string GetNewImageName(HttpPostedFileBase Image)
        {
            if (Image != null)
            {
                var ex = Path.GetExtension(Image.FileName);
                var name = Path.GetFileNameWithoutExtension(Image.FileName);
                var nameRandom = new Random().Next(1, 1000000).ToString();

                return name + nameRandom + ex;
            }
            return null;
        }
        public static string GetActions(IEnumerable<string> list)
        {
            var filter = list.Where(x => !string.IsNullOrEmpty(x));

            if (filter.Any())
            {
                var actions = ToXmlString(filter.ToArray());
                return actions;
            }
            return null;
        }

        public static string ToXmlString(string[] list)
        {
            XmlSerializer xs = new XmlSerializer(typeof(string[]));
            MemoryStream ms = new MemoryStream();
            xs.Serialize(ms, list);
            return Encoding.UTF8.GetString(ms.ToArray());
        }
    }
}