using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ResourceHubLauncher
{
    static class RTHF
    {
        public static List<int> AllIndexesOf(string str, string value) {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentException("the string to find may not be empty", "value");
            List<int> indexes = new List<int>();
            for (int index = 0; ; index += value.Length) {
                index = str.IndexOf(value, index);
                if (index == -1)
                    return indexes;
                indexes.Add(index);
            }
        }
    }
    
    class RichTextHtmlElement
    {
        public string fontName;
        public FontStyle style;
        public float fontSize;
        public string start;
        public string end;
        public List<int> startTags;
        public List<int> endTags;

        public void ClearTags() {
            startTags.Clear();
            endTags.Clear();
        }

        public void MoveBack(int toCheck,int howMuch) {
            for(int i=0;i< startTags.Count;i++) {
                if(startTags[i]> toCheck) {
                    startTags[i] -= howMuch;
                }
            }

            for (int i = 0; i < endTags.Count; i++) {
                if (endTags[i] > toCheck) {
                    endTags[i] -= howMuch;
                }
            }
        }

        public void GetTagsPos(string str) {
            startTags = RTHF.AllIndexesOf(str, start);
            endTags = RTHF.AllIndexesOf(str, end);
        }

        public void ApplyTag(ref RichTextBox toApply) {
            for(int i=0;i< startTags.Count&& i < endTags.Count;i++) {
                toApply.Select(startTags[i], endTags[i] - startTags[i]);
                float newSize=0;
                if(fontSize>0) {
                    newSize = fontSize;
                } else {
                    newSize = toApply.SelectionFont.Size;
                }
                toApply.SelectionFont = new Font(fontName, newSize, toApply.SelectionFont.Style | style);
            }
            
        }
        public RichTextHtmlElement(string start_, string end_, string fontName_, float fontSize_, FontStyle style_) {
            fontName = fontName_;
            fontSize = fontSize_;
            style = style_;
            start = start_;
            end = end_;
        }
    }
    class RichTextHtml
    {
        List<RichTextHtmlElement> tags;
        
        public RichTextHtml() {
            tags = new List<RichTextHtmlElement>();
        }

        void ClearTags() {
            foreach (RichTextHtmlElement tag in tags) {
                tag.ClearTags();
            }
        }

        string RemoveTags(string str) {
            foreach (RichTextHtmlElement tag in tags) {
                str = str.Replace(tag.start, "");
                str = str.Replace(tag.end, "");
            }
            return str;
        }

        void MoveBackEveryTag(int toCheck, int howMuch) {
            foreach (RichTextHtmlElement tag2 in tags) {
                tag2.MoveBack(toCheck, howMuch);
            }
        }
        public void Add(string tag, string fontFamily, float fontSize=0,FontStyle style= FontStyle.Regular) {
            
            tags.Add(new RichTextHtmlElement("<"+ tag+">", "</"+tag+">", fontFamily, fontSize, style));
            
            
        }
        
        public void Apply(ref RichTextBox toApply) {

            foreach(RichTextHtmlElement tag in tags) {
                tag.GetTagsPos(toApply.Text);
            }

            /*foreach (RichTextHtmlElement tag in tags) {
                foreach (int pos in tag.startTags) {
                    MoveBackEveryTag(pos, tag.start.Length);
                }
                foreach (int pos in tag.endTags) {
                    MoveBackEveryTag(pos, tag.end.Length);
                }
            }*/

            foreach (RichTextHtmlElement tag in tags) {
                for(int i=0;i< tag.startTags.Count;i++) {
                    MoveBackEveryTag(tag.startTags[i], tag.start.Length);
                }
                for (int i = 0; i < tag.endTags.Count; i++) {
                    MoveBackEveryTag(tag.endTags[i], tag.end.Length);
                }
            }

            toApply.Text = RemoveTags(toApply.Text);

            foreach (RichTextHtmlElement tag in tags) {
                tag.ApplyTag(ref toApply);
            }

            toApply.Select(0, 0);
        }
        
        
    }
}
