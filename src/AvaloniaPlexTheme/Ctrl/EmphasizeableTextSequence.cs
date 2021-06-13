using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using Avalonia.Data.Converters;

namespace AvaloniaPlexTheme
{
    public class EmphasizeableTextSequence : ObservableCollection<EmphasizeableTextSegment>
    {
        //static string EMPH_START_TAG => WindowTitleBar.TitleEmphasisStart; // = "[b]";
        //static readonly int EMPHASIS_START_LENGTH = EMPHASIS_START.Length;
        //static string EMPH_END_TAG => WindowTitleBar.TitleEmphasisEnd; // = "[/b]";
        //static readonly int EMPHASIS_END_LENGTH = EMPHASIS_END.Length;


        public static EmphasizeableTextSequence Parse(string parseIn)
        {
            EmphasizeableTextSequence retVal = new EmphasizeableTextSequence();

            /*if emphasis never starts or ends, we know the whole thing is
            non-emphasized, so may as well cut to the chase for sake of
            performance*/
            if (parseIn.Length < (WindowTitleBar.TitleEmphasisStart.Length + WindowTitleBar.TitleEmphasisEnd.Length)) //the string is shorter than the tags' combined length, so both tags literally CAN'T be present...thus whatever IS there must be non-bold text
            {
                retVal.Add(new EmphasizeableTextSegment(parseIn));
                return retVal;
            }
            else if ((!parseIn.Contains(WindowTitleBar.TitleEmphasisStart)) || (!parseIn.Contains(WindowTitleBar.TitleEmphasisEnd))) //at least one of the tags is not present at all, so the text must be all one non-bold segment
            {
                retVal.Add(new EmphasizeableTextSegment(parseIn));
                return retVal;
            }
            else
            {
                string subst = parseIn;

                if (subst.IndexOf(WindowTitleBar.TitleEmphasisStart) > subst.IndexOf(WindowTitleBar.TitleEmphasisEnd))
                {
                    throw new Exception("An emphasis end tag was found at '" + subst.IndexOf(WindowTitleBar.TitleEmphasisEnd) + "' without a preceding emphasis start tag.");
                }
                else if (subst.LastIndexOf(WindowTitleBar.TitleEmphasisStart) > subst.LastIndexOf(WindowTitleBar.TitleEmphasisEnd))
                {
                    throw new Exception("An emphasized segment at '" + subst.LastIndexOf(WindowTitleBar.TitleEmphasisStart) + "' was not ended.");
                }

                while (subst.Contains(WindowTitleBar.TitleEmphasisStart) && subst.Contains(WindowTitleBar.TitleEmphasisEnd))
                {
                    int emphStartTagStart = subst.IndexOf(WindowTitleBar.TitleEmphasisStart);
                    int emphStartTagEnd = emphStartTagStart + WindowTitleBar.TitleEmphasisStart.Length;
                    
                    if (emphStartTagEnd > 0)
                    {
                        retVal.Add(new EmphasizeableTextSegment(subst.Substring(0, emphStartTagStart), false));
                    }


                    int emphEndTagStart = subst.IndexOf(WindowTitleBar.TitleEmphasisEnd);
                    int emphEndTagEnd = emphEndTagStart + WindowTitleBar.TitleEmphasisEnd.Length;
                    retVal.Add(new EmphasizeableTextSegment(subst.Substring(emphStartTagEnd, emphEndTagStart - emphStartTagEnd), true));
                    subst = subst.Substring(emphEndTagEnd);
                }

                if (subst.Length > 0)
                    retVal.Add(new EmphasizeableTextSegment(subst, false));
            }

            if (false)
            {
                int parseInLength = parseIn.Length;
                
                bool wasBetweenEmphasisTags = false;
                string currentSegmentText = string.Empty;
                for (int charIndex = 0; charIndex < parseInLength; charIndex++)
                {
                    bool isBetweenEmphasisTags = false;
                    int tagLength = 0;

                    if (wasBetweenEmphasisTags)
                    {
                        if (IsSubstringTag(parseIn, charIndex, WindowTitleBar.TitleEmphasisEnd, out tagLength))
                            isBetweenEmphasisTags = false;
                    }
                    else
                    {
                        if (IsSubstringTag(parseIn, charIndex, WindowTitleBar.TitleEmphasisStart, out tagLength))
                            isBetweenEmphasisTags = true;
                    }

                    if (wasBetweenEmphasisTags != isBetweenEmphasisTags)
                    {
                        charIndex += tagLength;
                        Console.WriteLine((wasBetweenEmphasisTags ? "EMPHASIZED: " : "normal: ") + currentSegmentText);
                        retVal.Add(new EmphasizeableTextSegment(currentSegmentText, wasBetweenEmphasisTags));
                        wasBetweenEmphasisTags = isBetweenEmphasisTags;
                        currentSegmentText = string.Empty;
                    }
                    else
                        currentSegmentText += parseIn[charIndex];
                }
                /*if (parseIn.StartsWith(EMPHASIS_START))
                    emphasized = true;
                
                string[] strSegments = parseIn.Split(EMPHASIS_SEPARATOR);*/
            }
            return retVal;
        }

        static bool IsSubstringTag(string eval, int startIndex, string tag, out int jumpBy)
        {
            bool retVal = true;
            jumpBy = tag.Length;
            if (eval.Length - startIndex < jumpBy)
                return false;
            

            for (int tagCharIndex = 0; tagCharIndex < jumpBy; tagCharIndex++)
            {
                if (eval[startIndex + tagCharIndex] != tag[tagCharIndex])
                {
                    retVal = false;
                    break;
                }
            }

            //jumpBy--;
            return retVal;
        }

        public override string ToString()
        {
            string output = string.Empty;
            
            foreach (EmphasizeableTextSegment seg in this)
                output += seg.Text;
            
            return output;
        }

        public string DebugToString()
        {
            string output = string.Empty;
            
            if (Count > 0)
            {
                foreach (EmphasizeableTextSegment seg in this)
                {
                    output += ((seg.IsEmphasized ? "EMPHASIZED: " : "normal: ") + seg.Text + ", ");
                }

                if (output.Length > 2)
                    output = output.Substring(0, output.Length - 2);
            }
            else
                output = "EMPTY SEQUENCE";
            
            return output;
        }

        private EmphasizeableTextSequence() : base()
        { }
    }
}