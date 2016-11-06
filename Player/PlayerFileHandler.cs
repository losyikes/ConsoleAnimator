using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Player
{
    class PlayerFileHandler
    {
        
        public PlayerFileHandler() { }
        //public void SaveThumbnails(List<Thumbnail> thumbnailList, string fileName)
        //{
        //    List<Frame> frameList = new List<Frame>();
        //    foreach (Thumbnail thumb in thumbnailList)
        //    {
        //        Frame frame = new Frame(thumb.PixelList);
        //        frameList.Add(frame);
        //    }
        //    WriteToJsonFile<List<Frame>>(fileName, frameList);
        //    MessageBox.Show("Frames Saved");
        //}
        //public void WriteToJsonFile<T>(string filePath, T objectToWrite)
        //{
        //    TextWriter writer = null;
        //    try
        //    {
        //        var contentsToWriteToFile = JsonConvert.SerializeObject(objectToWrite);
        //        writer = new StreamWriter(filePath);
        //        writer.Write(contentsToWriteToFile);
        //    }
        //    finally
        //    {
        //        if (writer != null)
        //            writer.Close();
        //    }
        //}

        /// <summary>
        /// Reads an object instance from an Json file.
        /// <para>Object type must have a parameterless constructor.</para>
        /// </summary>
        /// <typeparam name="T">The type of object to read from the file.</typeparam>
        /// <param name="filePath">The file path to read the object instance from.</param>
        /// <returns>Returns a new instance of the object read from the Json file.</returns>
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
