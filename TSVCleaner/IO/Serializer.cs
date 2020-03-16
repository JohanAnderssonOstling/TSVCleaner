using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TSVCleaner.IO
{
    class Serializer
    {
        public void serialize(SentenceFile sentenceFile)
        {
            File.WriteAllText(sentenceFile.path, string.Empty);
            StreamWriter writer = new StreamWriter(sentenceFile.path);
            foreach(SegmentPair segmentPair in sentenceFile.sentencePairs)
            {
                if(!segmentPair.sourceSegment.Equals("") && !segmentPair.targetSegment.Equals(""))
                    writer.WriteLine(segmentPair.sourceSegment + "\t" + segmentPair.targetSegment);
            }
            writer.Close();
        }
    }
}
