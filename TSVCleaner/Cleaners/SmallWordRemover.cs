using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSVCleaner.Cleaners
{
    class SmallWordRemover : ICleaner
    {
        private int minLength { get; set; }
        private string[] exceptedWords { get; set; }
        public SmallWordRemover(int minLength, string[] exceptedWords)
        {
            this.minLength = minLength;
            this.exceptedWords = exceptedWords;
        }
        public List<SegmentPair> CleanSentencePairs(List<SegmentPair> segmentPairs)
        {
            foreach (SegmentPair segmentPair in segmentPairs)
            {
                segmentPair.sourceSegment = removeWords(segmentPair.sourceSegment);
                segmentPair.targetSegment = removeWords(segmentPair.targetSegment);
            }
            return segmentPairs;
        }
        public string removeWords(string segment)
        {
            string cleanSegment = "";
            if (minLength >= segment.Length)
                return "";
            if (Char.IsLetter(segment[1]) || exceptedWords.Any(segment[0].Equals))
                cleanSegment = cleanSegment + segment.Substring(0, 1);

            for (int i = 1; i < segment.Length - 1; i++)
            {
                if (Char.IsLetter(segment[i - 1]) || Char.IsLetter(segment[i + 1]) || exceptedWords.Any(segment[i].Equals))
                    cleanSegment = cleanSegment + segment.Substring(i, 1);
            }
            if (Char.IsLetter(segment[segment.Length - 2]) || exceptedWords.Any(segment[segment.Length - 1].Equals))
                cleanSegment = cleanSegment + segment.Substring(segment.Length - 1, 1);

            if (!cleanSegment.Equals(segment))
            {
                cleanSegment = removeWords(cleanSegment);
            }
            return cleanSegment;


            }
        }
    }


