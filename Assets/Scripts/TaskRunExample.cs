using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

/*������� 3: ������������ Task.Run
����
��� ������� ��������� ���������� ����� �� ��������� �������� �������� � Unity. 
�� ������������� Task.Run, ��� �������� ����� � �������� ����, �������� ���������� ��������� �����.*/

public class TaskRunExample : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(MoveCube());

        Task.Run(() => FakeHttpRequestAsync());
    }

    private async Task FakeHttpRequestAsync()
    {
        Debug.Log("����� �������");
        await Task.Delay(3000);
        Debug.Log("����� ���������");
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
