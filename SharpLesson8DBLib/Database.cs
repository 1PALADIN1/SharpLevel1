using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

namespace SharpLesson8DBLib
{
    // Класс для хранения списка вопросов. А так же для сериализации в XML и десериализации из XML
    class Database {
        string fileName;
        List<Question> list;

        public List<Question> List {
            get { return list; }
            set { list = value; }
        }

        public string FileName {
            set { fileName = value; }
            get { return fileName; }
        }

        public Database(string fileName) {
            this.fileName = fileName;
            list = new List<Question>();
        }

        public void Save() {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Question>));
            Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            xmlFormat.Serialize(fStream, list);
            fStream.Close();
        }

        public void Load() {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Question>));
            Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            list = (List<Question>)xmlFormat.Deserialize(fStream);
            fStream.Close();
        }

        public int Count {
            get { return list.Count; }
        }
    }
}
