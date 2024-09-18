using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

/*Сценарій 3: Використання Task.Run
Опис
Цей сценарій демонструє правильний підхід до виконання тривалих операцій у Unity. 
Ми використовуємо Task.Run, щоб виконати запит в окремому треді, уникаючи блокування головного треду.*/

public class TaskRunExample : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(MoveCube());

        Task.Run(() => FakeHttpRequestAsync());
    }

    private async Task FakeHttpRequestAsync()
    {
        Debug.Log("Запит почався");
        await Task.Delay(3000);
        Debug.Log("Запит закінчився");
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
