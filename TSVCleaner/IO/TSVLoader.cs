using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TSVCleaner
{
    class TSVLoader
    {
        public string delimeter { get; set; } = "\t";
        public TSVLoader(string delimeter)
        {
            this.delimeter = delimeter;
        }
        public SentenceFile loadTSV(string path)
        {
            List<SegmentPair> sentencePairs = new List<SegmentPair>();
            StreamReader reader = new StreamReader(path);
            string line;
            while((line = reader.ReadLine()) != null)
            {
                string[] sentences = line.Split(delimeter);
                sentencePairs.Add(new SegmentPair(sentences[0], sentences[1]));
            }
            reader.Close();
            return new SentenceFile(sentencePairs, path, extractName(path));
        }
        private string extractName(string path)
        {
            return path.Substring(path.LastIndexOf("\\"), path.Length - path.LastIndexOf("\\"));
        }
    }
}
