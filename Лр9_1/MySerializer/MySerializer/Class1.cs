using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using ProtoBuf;

namespace SerializersLibrary
{
    public abstract class MySerializer
    {
        public abstract T Read<T>(string filePath);
        public abstract void Write<T>(T obj, string filePath);
    }

    public class MyXmlSerializer: MySerializer
    {
        public override T Read<T>(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                return (T)serializer.Deserialize(fs);

            }
        }
        public override void Write<T>(T obj, string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, obj);
            }
        }
    }

    public class MyJSONSerializer : MySerializer
    {
        public override T Read<T>(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                return JsonSerializer.Deserialize<T>(fs);
            }
        }
        public override void Write<T>(T obj, string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize<T>(fs, obj);
            }
        }
    }
    public class MyBinSerializer : MySerializer
    {
        public override T Read<T>(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                return Serializer.Deserialize<T>(fs);
            }
        }

        public override void Write<T>(T obj, string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                Serializer.Serialize<T>(fs, obj);
            }
        }
    }


}
