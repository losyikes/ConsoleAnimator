using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.Windows;

namespace ConsoleAnimator
{
    public class FileHandler
    {
        public string Path { get; set; }
        public FileHandler() { }
        public void SaveThumbnails(List<Thumbnail> thumbnailList, string fileName)
        {
            List<Frame> frameList = new List<Frame>();
            foreach(Thumbnail thumb in thumbnailList)
            {
                Frame frame = new Frame(thumb.PixelList);
                frameList.Add(frame);
            }
            WriteToJsonFile<List<Frame>>(fileName, frameList);
            MessageBox.Show("Frames Saved");
        }
        public void WriteToJsonFile<T>(string filePath, T objectToWrite)
        {
            TextWriter writer = null;
            try
            {
                var contentsToWriteToFile = JsonConvert.SerializeObject(objectToWrite, Formatting.Indented);
                writer = new StreamWriter(filePath);
                writer.Write(contentsToWriteToFile);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }

       
        public T ReadFromJsonFile<T>(string filePath) where T : new()
        {
            TextReader reader = null;
            try
            {
                reader = new StreamReader(filePath);
                var fileContents = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(fileContents);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }
    }
}
