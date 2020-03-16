using System;
using System.Collections.Generic;
using System.Text;

namespace TSVCleaner.Cleaners
{
    interface ICleaner
    {
        public List<SegmentPair> CleanSentencePairs(List<SegmentPair> segmentPairs);
            
    }
}
