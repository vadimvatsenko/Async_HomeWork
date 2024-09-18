using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

/*������� 1: ���������� ��������� �����
����
��� ������� ���������, �� ����������, ���� HTTP-����� ���������� ������������� � ��������� ���� Unity. ����� ��������, ��������� �������, ���� ��������� �� ������� ��������������.*/
public class MainThreadBlocking : MonoBehaviour
{
    
    void Start()
    {
        StartCoroutine(MoveCube());

        Debug.Log("����� �������...");
        Thread.Sleep(3000); // ����� ��������� �������� �����
        Debug.Log("����� ����������...");
    }

    private IEnumerator MoveCube()
    {
        while (true)
        {
            this.transform.position += Vector3.right * Time.deltaTime;
            yield return null;
        }
    }
}
