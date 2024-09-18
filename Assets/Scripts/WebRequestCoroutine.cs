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
        // ��������� �������� ��� ������������ ������
        StartCoroutine(GetDataFromServer());
    }

    IEnumerator GetDataFromServer()
    {
        string url = "https://jsonplaceholder.typicode.com/posts/1";

        // ��������� �����
        UnityWebRequest request = UnityWebRequest.Get(url);

        // ������������� yield, ��� ������, ���� ����� �� �����������
        yield return request.SendWebRequest();

        // ���������� �� �� ������� �������
        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("�������: " + request.error);
        }
        else
        {
            // �������� ���������
            Debug.Log("��� � �������: " + request.downloadHandler.text);
        }
    }
}



