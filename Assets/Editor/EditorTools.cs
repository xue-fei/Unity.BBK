﻿using UnityEditor;
using UnityEngine;

public class EditorTools : MonoBehaviour
{
    [MenuItem("工具/打开沙盒文件夹")]
    static void OpenPersistentDataPath()
    {
        System.Diagnostics.Process.Start(@Application.persistentDataPath);
    }
}