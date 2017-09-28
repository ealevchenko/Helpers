using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace libClass
{
    public static class HelpersClass
    {

        public static string GetFullFieldsAndValue(this object obj)
        {
            return String.Format("Class : {0} {1}", GetFieldsAndValue(obj));
        }

        public static string GetFieldsAndValue(this object obj)
        {
            string result="[";
            FieldInfo[] myFieldInfo;
            myFieldInfo = obj.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            for (int i = 0; i < myFieldInfo.Length; i++)
            {
                result += obj!=null ? String.Format(" {0} = {1}; ", myFieldInfo[i].Name.Split('k').First(), myFieldInfo[i].GetValue(obj)): "";
            }
            return result+="]";
        }
        /// <summary>
        /// Преобразовать объект в xml-сообщение
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToXMLString(this object obj)
        {
            //try
            //{
            if (obj == null) return "Null";
            var xmlSerializer = new XmlSerializer(obj.GetType());
            var stringWriter = new StringWriter();
            xmlSerializer.Serialize(stringWriter, obj);
            return stringWriter.ToString();
            //}
            //catch (Exception ex)
            //{
            //    return "error ToXMLString";
            //}
        }
        /// <summary>
        /// Преобразовать xml-сообщение в object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sourceString"></param>
        /// <returns></returns>
        public static T XMLStringToClass<T>(this string sourceString)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            var stringReader = new StringReader(sourceString);
            return (T)xmlSerializer.Deserialize(stringReader);
        }



        //public string ArrivalSostavToXML(int id)
        //{
        //    ArrivalSostav arrsostav = GetArrivalSostav(id);
        //    if (arrsostav == null) return null;

        //    XElement ArrSostav = new XElement("ArrivalSostav");
        //    XAttribute ID = new XAttribute("ID", arrsostav.ID);
        //    XElement IDArrival = new XElement("IDArrival", arrsostav.IDArrival);
        //    XElement FileName = new XElement("FileName", arrsostav.FileName);
        //    XElement CompositionIndex = new XElement("CompositionIndex", arrsostav.CompositionIndex);
        //    XElement DateTime = new XElement("DateTime", arrsostav.DateTime);
        //    XElement Operation = new XElement("Operation", arrsostav.Operation);
        //    XElement Create = new XElement("Create", arrsostav.Create);
        //    XElement Close = new XElement("Close", arrsostav.Close);
        //    XElement Arrival = new XElement("Arrival", arrsostav.Arrival);
        //    XElement ParentID = new XElement("ParentID", arrsostav.ParentID);
        //    ArrSostav.Add(ID);
        //    ArrSostav.Add(IDArrival);
        //    ArrSostav.Add(FileName);
        //    ArrSostav.Add(CompositionIndex);
        //    ArrSostav.Add(DateTime);
        //    ArrSostav.Add(Operation);
        //    ArrSostav.Add(Create);
        //    ArrSostav.Add(Close);
        //    ArrSostav.Add(Arrival);
        //    ArrSostav.Add(ParentID);
        //    // Добавитм вагоны
        //    ArrSostav.Add(ListArrivalCarsToXML(arrsostav.ArrivalCars.ToList()));
        //    return ArrSostav.ToString();
        //}

    }
}
