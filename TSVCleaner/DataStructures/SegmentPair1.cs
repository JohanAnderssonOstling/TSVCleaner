using System;
using System.Collections.Generic;
using System.Text;

namespace TSVCleaner
{
    class SegmentPair : IComparable
    {
        public string sourceSegment { get; set; }
        public string targetSegment { get; set; }

        public SegmentPair(string sourceSegment, string targetSegment)
        {
            this.sourceSegment = sourceSegment;
            this.targetSegment = targetSegment;
        }

        public int CompareTo(Object obj)
        {
            SegmentPair otherPair = (SegmentPair)obj;
            return (sourceSegment.CompareTo(otherPair.sourceSegment));
        }
    }
    
}
