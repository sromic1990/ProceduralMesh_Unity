using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Sourav.Utilities.Scripts
{
    public static class FileIO
    {
        public static void WriteData(string dataStream)
        {
            File.WriteAllText(Application.persistentDataPath+"/gameData.sou", dataStream);
        }

        public static string ReadData()
        {
            if (FileExists())
            {
                string str = File.ReadAllText(Application.persistentDataPath + "/gameData.sou");
                return str;
            }
            else
            {
                return "";
            }
        }

        public static bool FileExists()
        {
            if(File.Exists(Application.persistentDataPath + "/gameData.sou"))
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