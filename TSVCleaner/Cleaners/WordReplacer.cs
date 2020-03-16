using System;
using System.Collections.Generic;
using System.Text;

namespace TSVCleaner.Cleaners
{
    class WordReplacer : ICleaner
    {
        private string[] wordsToBeReplaced { get; set; }

        public WordReplacer(string[] wordsToBeReplaced)
        {
            this.wordsToBeReplaced = wordsToBeReplaced;
        }
        public List<SegmentPair> CleanSentencePairs(List<SegmentPair> segmentPairs)
        {
           foreach(SegmentPair segmentPair in segmentPairs)
            {
                segmentPair.sourceSegment = replaceWords(segmentPair.sourceSegment);
                segmentPair.targetSegment = replaceWords(segmentPair.targetSegment);
            }
            return segmentPairs;
        }
        private string replaceWords(string segment)
        {
            foreach(string wordToBeReplaced in wordsToBeReplaced)
            {
                segment = segment.Replace(wordToBeReplaced, String.Empty);
            }
            return segment;
        }
    }
}
