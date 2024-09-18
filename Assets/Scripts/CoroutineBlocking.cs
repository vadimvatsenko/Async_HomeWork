using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

/*������� 2: ������������ �������
����
� ����� ������ �� ������������� �������� ��� ��������� ������. ����� �������� �����, 
�������� �� ����� �������� ���������� �����, ���� � �� ���������������� �������� ������.*/
public class CoroutineBlocking : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(FakeHttpRequest());
        StartCoroutine(MoveCube());
    }

    private IEnumerator FakeHttpRequest()
    {
        Debug.Log("����� �������");
        Thread.Sleep(3000);
        Debug.Log("����� ����������");
        yield return null;
        
    }

    private IEnumerator MoveCube()
    {
        while (true)
        {
            this.transform.position = Vector3.right * Time.deltaTime;
            yield return null;
        }
    }

}
