using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class Tool
{
    public static IEnumerator LoadData(string filePath, Action<byte[]> data)
    {
        UnityWebRequest request = UnityWebRequest.Get(new Uri(filePath));
        request.timeout = 5;
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.Success)
        {
            data?.Invoke(request.downloadHandler.data);
        }
        else
        {
            data?.Invoke(null);
        }
        if (!string.IsNullOrEmpty(request.error))
        {
            Debug.LogError(request.error);
        }
        request.Dispose();
    }
    public static IEnumerator LoadString(string filePath, Action<string> data)
    {
        UnityWebRequest request = UnityWebRequest.Get(new Uri(filePath));
        request.timeout = 5;
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.Success)
        {
            data?.Invoke(request.downloadHandler.text);
        }
        else
        {
            data?.Invoke(null);
        }
        if (!string.IsNullOrEmpty(request.error))
        {
            Debug.LogError(request.error);
        }
        request.Dispose();
    }
}