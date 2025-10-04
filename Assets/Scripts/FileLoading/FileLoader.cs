using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace FileSystem
{
    public static class FileLoader
    {
        public static List<string> LoadFiles(string path)
        {
            List<string> returnFileList = new List<string>();
            string[] directories = Directory.GetDirectories(path);
            for (int i = 0; i < directories.Length; i++)
            {
                returnFileList = CombineList(returnFileList, LoadFiles(directories[i]));
            }
            string[] files = Directory.GetFiles(path, "*.json");
            for (int i = 0; i < files.Length; i++)
            {
                returnFileList.Add(files[i]);
            }
            return returnFileList;
        }

        private static List<string> CombineList(List<string> list1, List<string> list2)
        {
            foreach (string str in list2)
            {
                list1.Add(str);
            }
            return list1;
        }
    }
}
