using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using TSVCleaner.Cleaners;

namespace TSVCleaner
{
    class IdenticalRemover : ICleaner
    {
        public List<SegmentPair> CleanSentencePairs(List<SegmentPair> segmentPairs)
        {
            List<SegmentPair> nonIdentical = new List<SegmentPair>();
            foreach(SegmentPair sentencePair in segmentPairs)
            {
                if (!Util.stringsAreIndentical(sentencePair.sourceSegment, sentencePair.targetSegment)){
                    nonIdentical.Add(sentencePair);
                }
            }
            return nonIdentical;
        }

        
    }
}
