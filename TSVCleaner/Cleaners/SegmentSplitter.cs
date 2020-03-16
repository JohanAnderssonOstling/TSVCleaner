using edu.stanford.nlp.ling;
using edu.stanford.nlp.pipeline;
using edu.stanford.nlp.process;
using java.io;
using java.util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TSVCleaner.Cleaners;

namespace TSVCleaner
{
    class SegmentSplitter : ICleaner
    {
        public List<SegmentPair> CleanSentencePairs(List<SegmentPair> segmentPairs)
        {
            List<SegmentPair> splitSentencePairs = new List<SegmentPair>();
            foreach(SegmentPair segmentPair in segmentPairs)
            {
                List<SegmentPair> splitSegment = parseSegment(segmentPair.sourceSegment, segmentPair.targetSegment);
                splitSentencePairs.AddRange(splitSegment);
            }
            return splitSentencePairs;
        }
        private List<string> Split(string sentence2)
        {
            var jarRoot = "stanford-corenlp-full-2018-10-05/stanford-corenlp-3.9.2-models";

            

            // Annotation pipeline configuration
            var props = new Properties();
            props.setProperty("annotators", "tokenize, ssplit, pos, lemma, ner, parse, dcoref");
            props.setProperty("sutime.binders", "0");

            // We should change current directory, so StanfordCoreNLP could find all the model files automatically 
            var curDir = Environment.CurrentDirectory;
            System.Console.WriteLine(curDir);
            Directory.SetCurrentDirectory(jarRoot);
            var pipeline = new StanfordCoreNLP(props);
            Directory.SetCurrentDirectory(curDir);

            // Annotation
            var annotation = new Annotation(sentence2);
            pipeline.annotate(annotation);

            // these are all the sentences in this document
            // a CoreMap is essentially a Map that uses class objects as keys and has values with custom types
            var sentences = annotation.get(typeof(CoreAnnotations.SentencesAnnotation));
            if (sentences == null)
            {
                return null; ;
            }
            foreach (Annotation sentence in sentences as ArrayList)
            {
                System.Console.WriteLine(sentence);
                
            }
            return null;
        }
        private List<SegmentPair> parseSegment(string sourceSegment, string targetSegment)
        {
            List<SegmentPair> segmentPairs = new List<SegmentPair>();
            if (!sourceSegment.Contains(".") || !targetSegment.Contains("."))
            {
                segmentPairs.Add(new SegmentPair(sourceSegment, targetSegment));
                //System.Console.WriteLine(sourceSegment + "\t" + targetSegment);
                return segmentPairs;
            }
            string[] sourceSegments = splitSegment(sourceSegment);
            string[] targetSegments = splitSegment(targetSegment);

            if (sourceSegments.Length != targetSegments.Length)
            {
                segmentPairs.Add(new SegmentPair(sourceSegment, targetSegment));
                System.Console.WriteLine(sourceSegment + "\t" + targetSegment + "r");
                return segmentPairs;
            }
            for (int i = 0; i < sourceSegments.Length; i++)
            {
                segmentPairs.Add(new SegmentPair(sourceSegments[i], targetSegments[i]));
                //System.Console.WriteLine(sourceSegments[i] + "\t" + targetSegments[i]);
            }
            return segmentPairs;
        }
        private string[] splitSegment(string segment)
        {
            List<int> indexes = getSentenceIndexes(segment);
            string[] sentences = new string[indexes.Count];

            for (int i = 0; i < indexes.Count - 1; i++)
            {
                sentences[i] = segment.Substring(indexes[i], indexes[i + 1] - indexes[i]);
            }
            return sentences;

        }
        private List<int> getSentenceIndexes(string segment)
        {
            List<int> indexes = new List<int>();
            for (int i = segment.IndexOf("."); i > -1; i = segment.IndexOf(".", i + 1)) // Loop through all dots in string
            {
                if (i - 1 > 0 && i + 1 < segment.Length) //Check if index of dot is not at start or end of segment
                {
                    if ((!Char.IsDigit(segment[i - 1]) || !Char.IsDigit(segment[i + 1])) && (Char.IsUpper(segment[i + 1]) || Char.IsUpper(segment[i + 2])))
                    {
                        indexes.Add(i);

                    }
                }
            }
            return indexes;
        }

        
    }
}

