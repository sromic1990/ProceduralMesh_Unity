﻿﻿﻿﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;

namespace Sourav.Utilities.EditorUtils
{
    public class FileMatching
    {
        public FileInfoAsPerLine ReadFileAndCheckForLineOfString(string filePath, string matchLine = "", bool decomposeIntoWords = false)
        {
            int lineNumber = 1;

            FileInfoAsPerLine fileInfo = new FileInfoAsPerLine();
            fileInfo.FilePath = filePath;
            fileInfo.LineToMatch = matchLine;

            if(File.Exists(filePath))
            {
                fileInfo.FileDoesExist = true;
                StreamReader objReader = new StreamReader(filePath, false);
                int spaces = 0;

                do
                {
                    //Reading line
                    string line = objReader.ReadLine();
                    //Seprating words of a line and storing them

                    if(string.IsNullOrEmpty(line))
                    {
                        spaces++; 
                    }
                    else
                    {
                        if(spaces > 2)
                        {
                            for (int i = spaces - 1; i > 0; i--)
                            {
                                fileInfo.LinesContainingUnnecessarySpace.Add(lineNumber - i);
                            }
                        }
                        spaces = 0;
                    }

                    if(decomposeIntoWords)
                    {
                        fileInfo.AddWords(line);
                    }
                    //Checking for matched file
                    if(line.Equals(matchLine))
                    {
                        fileInfo.HasLine = true;
                        fileInfo.LineNumbersOfMatchedLine.Add(lineNumber);
                    }
                    //line += Environment.NewLine;
                    //Adding line to list of lines in the file
                    fileInfo.LinesInFile.Add(line);
                    lineNumber++;
                }
                while (objReader.Peek() != -1);

                objReader.Close();
            }
            else
            {
                fileInfo.FileDoesExist = false;
                Debug.Log("File does not exist");
            }

            return fileInfo;
        }

        public string GetNameOfFile(string filePath)
        {
            string name = "";

            string[] data = filePath.Split('/');
            name = data[data.Length - 1];

            return name;
        }

        public void RemoveLinesAndSpacesFromFile(string line, string filePath)
        {
            FileInfoAsPerLine fileInfo = ReadFileAndCheckForLineOfString(filePath, line);
            fileInfo.LinesInFile = RemoveLinesAndSpacesFromFileInternal(fileInfo.LinesInFile, fileInfo.LineNumbersOfMatchedLine, fileInfo.LinesContainingUnnecessarySpace);
            WriteFile(fileInfo, overwriteFile: true, removeLineFromFile: true);

        }

        public void WriteLineToFile(string line, string filePath)
        {
            FileInfoAsPerLine fileInfo = ReadFileAndCheckForLineOfString(filePath);
            if(fileInfo.FileDoesExist)
            {
                OverwriteFile(fileInfo.FilePath, line);
                WriteFile(fileInfo);
            }
        }

        private void OverwriteFile(string path, string line = "")
        {
            using (StreamWriter sw = File.CreateText(path))
            {
                if(!string.IsNullOrEmpty(line))
                {
                    sw.WriteLine(line);
                }
            }
        }

        private void AppendToTheFile(string path, string line)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(line);
            }
        }

        private void WriteFile(FileInfoAsPerLine fileInfo, bool overwriteFile = false, bool removeLineFromFile = false)
        {
            if(fileInfo.FileDoesExist)
            {
                if (overwriteFile)
                {
                    OverwriteFile(fileInfo.FilePath);
                }

                for (int i = 0; i < fileInfo.LinesInFile.Count; i++)
                {
                    AppendToTheFile(fileInfo.FilePath, fileInfo.LinesInFile[i]);
                }
            }
        }

        private List<string> RemoveLinesAndSpacesFromFileInternal(List<string> Lines, List<int> LinesToBeRemoved, List<int> LinesContainingExtraSpace)
        {
            List<string> temp = new List<string>();
            for (int i = 0; i < Lines.Count; i++)
            {
                int j = i + 1;
                if(LinesToBeRemoved.Contains(j) || LinesContainingExtraSpace.Contains(j))
                {
                    continue;
                }
                //Debug.Log(Lines[i]);
                temp.Add(Lines[i]);
            }
            return temp;
        }
    }

    [Serializable]
    public class FileInfoAsPerLine
    {
        public string FilePath { get; set; }
        public bool FileDoesExist { get; set; }
        public string LineToMatch { get; set; }
        public bool HasLine { get; set; }
        public List<int> LineNumbersOfMatchedLine { get; set; }
        public List<int> LinesContainingUnnecessarySpace { get; set; }
        public List<string> LinesInFile { get; set; }
        public List<WordsInALine> WordsInALine { get; set; }

        public FileInfoAsPerLine()
        {
            LineNumbersOfMatchedLine = new List<int>();
            LinesInFile = new List<string>();
            WordsInALine = new List<WordsInALine>();
            LinesContainingUnnecessarySpace = new List<int>();
        }

        public void AddWords(string line)
        {
            WordsInALine wordsInALine = new WordsInALine();
            string[] words = line.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                //Debug.Log(words[i]);
                wordsInALine.wordsInALine.Add(words[i]);
            }
            WordsInALine.Add(wordsInALine);
        }
    }

    [Serializable]
    public class WordsInALine
    {
        public List<string> wordsInALine;

        public WordsInALine()
        {
            wordsInALine = new List<string>();
        }

        public bool HasWord(string word)
        {
            if(wordsInALine.Contains(word))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
