using System;
using System.Collections.Generic;
using System.Text;

namespace TSVCleaner.Cleaners
{
    class Trimmer : ICleaner
    {
        public List<SegmentPair> CleanSentencePairs(List<SegmentPair> segmentPairs)
        {
            foreach(SegmentPair segmentPair in segmentPairs)
            {
                //Console.WriteLine(segmentPair.sourceSegment + "\t" + segmentPair.targetSegment);
                
                segmentPair.sourceSegment = trimSentence(segmentPair.sourceSegment);
                segmentPair.targetSegment = trimSentence(segmentPair.targetSegment);
                
            }
            return segmentPairs;
        }

        private string trimSentence(string sentence)
        {
            
            if (sentence.Length < 1)
                return sentence;
            string line;
            int i;
            for(i = 0; i < sentence.Length; i++)
                if (!(Char.IsPunctuation(sentence[i]) || Char.IsWhiteSpace(sentence[i])))
                {
                    break;
                }

            sentence = sentence.Substring(i , sentence.Length - i);
            for (i = sentence.Length - 1; i >= 0; i--)
                if(!(Char.IsPunctuation(sentence[i]) || Char.IsWhiteSpace(sentence[i])))
                {
                    break;
                }
            sentence = sentence.Substring(0, i + 1);
            return sentence;
        }

        
    }
}
