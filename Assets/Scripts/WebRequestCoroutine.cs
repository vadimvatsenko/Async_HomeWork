using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.Networking;

[Serializable]
public class WebRequestCoroutine : MonoBehaviour
{
    void Start()
    {
        // Викликаємо корутину для асинхронного запиту
        StartCoroutine(GetDataFromServer());
    }

    IEnumerator GetDataFromServer()
    {
        string url = "https://jsonplaceholder.typicode.com/posts/1";

        // Створюємо запит
        UnityWebRequest request = UnityWebRequest.Get(url);

        // Використовуємо yield, щоб чекати, поки запит не завершиться
        yield return request.SendWebRequest();

        // Перевіряємо чи не виникла помилка
        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Помилка: " + request.error);
        }
        else
        {
            // Отримуємо результат
            Debug.Log("Дані з сервера: " + request.downloadHandler.text);
        }
    }
}



