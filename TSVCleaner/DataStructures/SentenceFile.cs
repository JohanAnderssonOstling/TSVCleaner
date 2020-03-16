using System;
using System.Collections.Generic;
using System.Text;

namespace TSVCleaner
{
    class SentenceFile
    {
        public List<SegmentPair> sentencePairs { get; set; }
        public string path { get; set; }
        public string name { get; set; }

        public SentenceFile(List<SegmentPair> sentencePairs, string path, string name)
        {
            this.sentencePairs = sentencePairs;
            this.path = path;
            this.name = name;
        }
    }
}
