//Traceutils assembly
//writen by Locky, 2009.
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ExpressProfiler
{
    [Serializable]
    public class CEvent
    {
        // ReSharper disable UnaccessedField.Global
        // ReSharper disable FieldCanBeMadeReadOnly.Global
        // ReSharper disable InconsistentNaming
        // ReSharper disable MemberCanBePrivate.Global
        [XmlAttribute]
        public long EventClass;
        [XmlAttribute]
        public long DatabaseID;
        [XmlAttribute]
        public long ObjectID;
        [XmlAttribute]
        public long RowCounts;
        public string TextData;
        [XmlAttribute]
        public string DatabaseName;
        [XmlAttribute]
        public string ObjectName;
        [XmlAttribute]
        public long Count, CPU, Reads, Writes, Duration, SPID, NestLevel;
        // ReSharper restore MemberCanBePrivate.Global
        // ReSharper restore InconsistentNaming
        // ReSharper restore FieldCanBeMadeReadOnly.Global
        // ReSharper restore UnaccessedField.Global

        public long AvgCPU
        {
            get { return Count == 0 ? 0 : CPU/Count; }
        }
        public long AvgReads
        {
            get{ return Count == 0 ? 0 : Reads / Count;}
        }
        public long AvgWrites
        {
            get { return Count == 0 ? 0 : Writes / Count;}
        }
        public long AvgDuration
        {
            get { return Count == 0 ? 0 : Duration / Count; }
        }
            

        //needed for serialization
// ReSharper disable UnusedMember.Global
        public CEvent() { }
// ReSharper restore UnusedMember.Global

        public CEvent(long aDatabaseID, string aDatabaseName, long aObjectID, string aObjectName, string aTextData)
        {
            DatabaseID = aDatabaseID;
            DatabaseName = aDatabaseName;
            ObjectID = aObjectID;
            ObjectName = aObjectName;
            TextData = aTextData;
        }

        public CEvent(long eventClass,long spid, long nestLevel, long aDatabaseID, string aDatabaseName, long aObjectID, string aObjectName, string aTextData, long duration, long reads, long writes,long cpu)
        {
            EventClass = eventClass;
            DatabaseID = aDatabaseID;
            DatabaseName = aDatabaseName;
            ObjectID = aObjectID;
            ObjectName = aObjectName;
            TextData = aTextData;
            Duration = duration;
            Reads = reads;
            Writes = writes;
            CPU = cpu;
            SPID = spid;
            NestLevel = nestLevel;
        }

        public string GetKey()
        {
            return String.Format("({0}).({1}).({2}).({3})", DatabaseID, ObjectID, ObjectName, TextData);
        }
    }

    public class SimpleEventList
    {
        public readonly SortedDictionary<string,CEvent> List;

        public SimpleEventList() 
        {
            List = new SortedDictionary<string, CEvent>(); 
        }

        public void SaveToFile(string filename) 
        {
            CEvent[] a = new CEvent[List.Count];
            List.Values.CopyTo(a, 0);
            XmlSerializer x = new XmlSerializer(typeof(CEvent[]));
            
            FileStream fs = new FileStream(filename, FileMode.Create);
            x.Serialize(fs, a);
            fs.Dispose();

        }
        public void AddEvent(long eventClass, long nestLevel, long databaseID,string databaseName,long objectID,string objectName, string textData, long cpu, long reads, long writes, long duration,long count,long rowcounts)
        { 
            CEvent evt;
            string key = String.Format("({0}).({1}).({2})",databaseID,objectID,textData);
            if(!List.TryGetValue(key,out evt))
            {
                evt = new CEvent(databaseID,databaseName,objectID,objectName,textData);
                List.Add(key, evt);
            }
            evt.NestLevel = nestLevel;
            evt.EventClass = eventClass;
            evt.Count += count;
            evt.CPU += cpu;
            evt.Reads += reads;
            evt.Writes += writes;
            evt.Duration += duration;
            evt.RowCounts += rowcounts;

        }        
    }

    public class CEventList
    {
        public readonly SortedDictionary<string, CEvent[]> EventList;
        public CEventList() { EventList = new SortedDictionary<string, CEvent[]>(); }

        public void AppendFromFile(int cnt, string filename, bool ignorenonamesp, bool transform)
        {
            XmlSerializer x = new XmlSerializer(typeof(CEvent[]));
            FileStream fs = new FileStream(filename, FileMode.Open);
            CEvent[] a = (CEvent[])x.Deserialize(fs);
            YukonLexer lex = new YukonLexer();
            foreach (CEvent e in a)
            {
                if (e.TextData.Contains("statman") || e.TextData.Contains("UPDATE STATISTICS")) continue;
                if (!ignorenonamesp || e.ObjectName.Length != 0)
                {
                    if (transform)
                    {

                        AddEvent(cnt, e.DatabaseID, e.DatabaseName
                                 , e.ObjectName.Length == 0 ? 0 : e.ObjectID
                                 , e.ObjectName.Length == 0 ? "" : e.ObjectName
                                 , e.ObjectName.Length == 0 ?
                                                                lex.StandardSql(e.TextData) : e.TextData, e.CPU, e.Reads, e.Writes, e.Duration, e.Count,e.RowCounts);
                    }
                    else
                    {
                        AddEvent(cnt, e.DatabaseID, e.DatabaseName, e.ObjectID, e.ObjectName, e.TextData, e.CPU, e.Reads, e.Writes, e.Duration, e.Count,e.RowCounts);
                    }
                }
            }
            fs.Dispose();

        }

        public void AddEvent(int cnt, long databaseID, string databaseName, long objectID, string objectName, string textData, long cpu, long reads, long writes, long duration, long count,long rowcounts)
        {
            CEvent[] evt;
            CEvent e;
            string key = String.Format("({0}).({1}).({2}).({3})", databaseID, objectID, objectName, textData);
            if (!EventList.TryGetValue(key, out evt))
            {
                evt = new CEvent[2];
                for (int k = 0; k < evt.Length; k++)
                {
                    evt[k] = new CEvent(databaseID, databaseName, objectID, objectName, textData);
                }
                EventList.Add(key, evt);
                e = evt[cnt];
            }
            else
            {
                e = evt[cnt];
            }

            e.Count += count;
            e.CPU += cpu;
            e.Reads += reads;
            e.Writes += writes;
            e.Duration += duration;
            e.RowCounts += rowcounts;
        }
    }
}