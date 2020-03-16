using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using TSVCleaner.Cleaners;

namespace TSVCleaner
{
    class DuplicateRemover : ICleaner
    {
        public List<SegmentPair> CleanSentencePairs(List<SegmentPair> segmentPairs)
        {
            List<SegmentPair> nonDuplicates = new List<SegmentPair>();
            segmentPairs.Sort();
            for (int i = 1; i < segmentPairs.Count; i++)
            {
                if (!Util.stringsAreIndentical(segmentPairs[i - 1].sourceSegment, segmentPairs[i].sourceSegment))
                {
                    nonDuplicates.Add(segmentPairs[i]);
                }
            }
            return nonDuplicates;
        }
    }
}
