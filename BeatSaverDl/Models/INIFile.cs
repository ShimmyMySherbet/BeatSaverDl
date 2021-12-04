using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatSaverDl.Models
{
    public class INIFile
    {
        private List<IniLine> Data = new List<IniLine>();
        private string LoadFile = "";

        public INIFile(string file = "")
        {
            LoadFile = file;
            if (!string.IsNullOrEmpty(file) && File.Exists(file))
            {
                var ioinf = new FileInfo(file);
                file = ioinf.FullName;
                foreach (string line in File.ReadAllLines(file))
                {
                    if (!line.StartsWith("#") & !string.IsNullOrEmpty(line) & line.Contains("="))
                    {
                        string Key = line.Split('=')[0];
                        string Value = line.Remove(0, Key.Length + 1);
                        Data.Add(new IniLine()
                        {
                            Key = Key,
                            Value = Value,
                            IsDataEntry = true,
                            Line = ""
                        });
                    }
                    else
                    {
                        Data.Add(new IniLine()
                        {
                            IsDataEntry = false,
                            Line = line
                        });
                    }
                }
            }
        }

        public Dictionary<string, string> DataDictionary
        {
            get
            {
                var dict = new Dictionary<string, string>();
                foreach (var x in Data)
                {
                    if (x.IsDataEntry)
                    {
                        dict.Add(x.Key, x.Value);
                    }
                }

                return dict;
            }
        }

        public List<string> Keys
        {
            get
            {
                var res = new List<string>();
                Data.ForEach(x => { if (x.IsDataEntry) { res.Add(x.Key); } });
                return res;
            }
        }

        public List<string> Values
        {
            get
            {
                var res = new List<string>();
                Data.ForEach(x => { if (x.IsDataEntry) { res.Add(x.Value); } });
                return res;
            }
        }

        public void Enforce(string key, string value)
        {
            if (!KeySet(key))
            {
                this[key] = value;
            }
        }

        public string this[string Key]
        {
            get
            {
                return Data.Where(x => { if (x.IsDataEntry) { return (x.Key.ToLower() ?? "") == (Key.ToLower() ?? ""); } else { return false; } }).First().Value;
            }
            set
            {
                bool found = false;
                foreach (var x in Data)
                {
                    if (x.IsDataEntry)
                    {
                        if ((x.Key.ToLower() ?? "") == (Key.ToLower() ?? ""))
                        {
                            x.Value = value;
                            found = true;
                            break;
                        }
                    }
                }

                if (!found)
                {
                    Data.Add(new IniLine()
                    {
                        IsDataEntry = true,
                        Key = Key,
                        Value = value,
                        Line = ""
                    });
                }
            }
        }

        public bool KeySet(string Key)
        {
            bool ret = false;
            foreach (var x in Data)
            {
                if (x.IsDataEntry)
                {
                    if ((x.Key.ToLower() ?? "") == (Key.ToLower() ?? ""))
                    {
                        ret = true;
                    }
                }
            }

            return ret;
        }

        public void Save(string File = "", bool Overwrite = true)
        {
            if (string.IsNullOrEmpty(File))
            {
                if (!string.IsNullOrEmpty(LoadFile))
                {
                    File = LoadFile;
                }
                else
                {
                    throw new Exception("Cannot save; no specified file or load file.");
                }
            }

            if (Overwrite)
            {
                System.IO.File.WriteAllText(File, ToINIString());
            }
            else
            {
                System.IO.File.AppendAllLines(File, IniLines());
            }
        }

        public void Save(Stream Stream, Encoding Encoding = null)
        {
            if (Encoding == null)
            {
                Encoding = Encoding.UTF8;
            }

            var Bytes = Encoding.GetBytes(ToINIString());
            Stream.Write(Bytes, 0, Bytes.Count());
        }

        public string ToINIString()
        {
            var Lines = new List<string>();
            foreach (var entry in Data)
            {
                if (entry.IsDataEntry)
                {
                    Lines.Add($"{entry.Key}={entry.Value}");
                }
                else
                {
                    Lines.Add(entry.Line);
                }
            }

            return string.Join(Environment.NewLine, Lines);
        }

        public void WriteComment(string Comment)
        {
            Data.Add(new IniLine() { IsDataEntry = false, Line = "#" + Comment });
        }

        public void WriteLine(string Line = "")
        {
            Data.Add(new IniLine() { IsDataEntry = false, Line = Line });
        }
        private List<string> IniLines()
        {
            var Lines = new List<string>();
            foreach (var entry in Data)
            {
                if (entry.IsDataEntry)
                {
                    Lines.Add($"{entry.Key}={entry.Value}");
                }
                else
                {
                    Lines.Add(entry.Line);
                }
            }

            return Lines;
        }

        private partial class IniLine
        {
            public bool IsDataEntry = false;
            public string Key = "";
            public string Line = "";
            public string Value = "";
        }
    }
}
