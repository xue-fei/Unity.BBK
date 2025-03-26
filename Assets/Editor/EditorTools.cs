using System.IO;
using System;
using UnityEditor;
using UnityEngine;
using NUnit.Framework;
using System.Collections.Generic;

public class EditorTools : MonoBehaviour
{
    [MenuItem("工具/打开沙盒文件夹")]
    static void OpenPersistentDataPath()
    {
        System.Diagnostics.Process.Start(@Application.persistentDataPath);
    }

    [MenuItem("工具/生成游戏列表")]
    static void CreatGameListJson()
    {
        string path = Application.streamingAssetsPath + "/Game";
        DirectoryInfo root = new DirectoryInfo(path);
        GameList gameList = new GameList();
        foreach (FileInfo f in root.GetFiles())
        {
            if (f.FullName.Contains(".meta"))
            {
                continue;
            }
            string name = Path.GetFileNameWithoutExtension(f.FullName);
            gameList.Names.Add(name);
            Debug.Log(name);
        }
        string json = JsonUtility.ToJson(gameList);
        File.WriteAllText(Application.streamingAssetsPath + "/gamelist.json", json);
    }
}