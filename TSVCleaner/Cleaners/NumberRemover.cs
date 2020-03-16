using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSVCleaner.Cleaners
{
    class NumberRemover : ICleaner
    {
        public List<SegmentPair> CleanSentencePairs(List<SegmentPair> segmentPairs)
        {
            List<SegmentPair> digitsRemoved = new List<SegmentPair>();
            foreach(SegmentPair segmentPair in segmentPairs)
            {
                segmentPair.sourceSegment = removeNumbers(segmentPair.sourceSegment);
                segmentPair.targetSegment = removeNumbers(segmentPair.targetSegment);
            }
            return segmentPairs;
        }
        public string removeNumbers(string segment)
        {
            string cleanString = "";
            for(int i = 0; i < segment.Length; i++)
            {
                if (Char.IsDigit(segment[i]))
                {
                    for (i = i; i < segment.Length - 1; i++)
                    {
                        if(Char.IsLetter(segment[i]) || Char.IsWhiteSpace(segment[i]))
                        {
                            break;
                        }
                    }
                }
                cleanString = cleanString + segment.Substring(i, 1);
            }
            cleanString = cleanString.Trim();

            if (segment.Length > 2)
            {
                char lastChar = segment.Substring(segment.Length - 1, 1).ToCharArray()[0];
                if (char.IsDigit(lastChar))
                {
                    cleanString = cleanString.Substring(0, cleanString.Length - 1);
                }
            }
            return cleanString;
        }
    }
}
