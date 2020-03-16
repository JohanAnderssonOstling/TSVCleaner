using System;
using System.Collections.Generic;
using TSVCleaner.Cleaners;
using TSVCleaner.IO;

namespace TSVCleaner
{
    class Program
    {
        static string[] fileExtensions = { ".tsv" };
        static void Main(string[] args)
        {
            string[] exceptedWords = { "I", "a" , "i"};
            string[] replaceWords = { "  ", "   ", "    " };
            List<ICleaner> cleaners = new List<ICleaner>();
            cleaners.Add(new NumberRemover());
            cleaners.Add(new SmallWordRemover(1, exceptedWords));
            cleaners.Add(new WordReplacer(replaceWords));
            //cleaners.Add(new SegmentSplitter());
            cleaners.Add(new Trimmer());
            cleaners.Add(new IdenticalRemover());
            cleaners.Add(new DuplicateRemover());
            
            FolderParser folderParser = new FolderParser(fileExtensions);
            List<string> files = folderParser.parseFolder("G:\\Översättning\\en-US-sv-SE\\");
            TSVLoader loader = new TSVLoader("\t");
            Serializer serializer = new Serializer();
            foreach (string file in files)
            {
                SentenceFile sentenceFile = loader.loadTSV(file);
                foreach (ICleaner cleaner in cleaners)
                {
                    sentenceFile.sentencePairs = cleaner.CleanSentencePairs(sentenceFile.sentencePairs);
                }
                serializer.serialize(sentenceFile);
            }
        }
    }
}
