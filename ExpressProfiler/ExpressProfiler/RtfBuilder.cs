//Traceutils assembly
//writen by Locky, 2009. 
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Text;

namespace ExpressProfiler
{
    class RTFBuilder
    {

        private readonly StringBuilder m_Sb = new StringBuilder();
        private readonly List<Color> m_Colortable = new List<Color>();
        private readonly StringCollection m_Fonttable = new StringCollection();
        private Color m_Forecolor;
        public Color ForeColor
        {
            set
            {
                if (!m_Colortable.Contains(value)) { m_Colortable.Add(value); }
                if (value != m_Forecolor)
                {
                    m_Sb.Append(String.Format("\\cf{0} ", m_Colortable.IndexOf(value) + 1));
                }
                m_Forecolor = value;
            }
        }


        private Color m_Backcolor;
        public Color BackColor
        {
            set
            {
                if (!m_Colortable.Contains(value)) { m_Colortable.Add(value); }
                if (value != m_Backcolor)
                {
                    m_Sb.Append(String.Format("\\highlight{0} ", m_Colortable.IndexOf(value) + 1));
                }
                m_Backcolor = value;
            }
        }


        public RTFBuilder()
        {
            ForeColor = Color.FromKnownColor(KnownColor.WindowText);
            BackColor = Color.FromKnownColor(KnownColor.Window);
            m_DefaultFontSize = 20F;
        }

        public void AppendLine()
        {
            m_Sb.AppendLine("\\line");
        }

        public void Append(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                value = CheckChar(value);
                if (value.IndexOf(Environment.NewLine) >= 0)
                {
                    string[] lines = value.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                    foreach (string line in lines)
                    {
                        m_Sb.Append(line);
                        m_Sb.Append("\\line ");
                    }
                }
                else
                {
                    m_Sb.Append(value);
                }

            }
        }
        private static readonly char[] Slashable = new[] { '{', '}', '\\' };
        private readonly float m_DefaultFontSize;

        private static string CheckChar(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (value.IndexOfAny(Slashable) >= 0)
                {
                    value = value.Replace("{", "\\{").Replace("}", "\\}").Replace("\\", "\\\\");
                }
                bool replaceuni = false;
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i] > 255)
                    {
                        replaceuni = true;
                        break;
                    }
                }
                if (replaceuni)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < value.Length; i++)
                    {
                        if (value[i] <= 255)
                        {
                            sb.Append(value[i]);
                        }
                        else
                        {
                            sb.Append("\\u");
                            sb.Append((int)value[i]);
                            sb.Append("?");
                        }
                    }
                    value = sb.ToString();
                }
            }


            return value;
        }

        public new string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang3081");
            result.Append("{\\fonttbl");
            for (int i = 0; i < m_Fonttable.Count; i++)
            {
                try
                {
                    result.Append(string.Format(m_Fonttable[i], i));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            result.AppendLine("}");
            result.Append("{\\colortbl ;");
            foreach (Color item in m_Colortable)
            {
                result.AppendFormat("\\red{0}\\green{1}\\blue{2};", item.R, item.G, item.B);
            }
            result.AppendLine("}");
            result.Append("\\viewkind4\\uc1\\pard\\plain\\f0");
            result.AppendFormat("\\fs{0} ", m_DefaultFontSize);
            result.AppendLine();
            result.Append(m_Sb.ToString());
            result.Append("}");
            return result.ToString();
        }
    }
}