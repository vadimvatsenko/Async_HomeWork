using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

/*Сценарій 2: Використання корутин
Опис
У цьому сценарії ми використовуємо корутину для виконання запиту. Попри поширену думку, 
корутина не вирішує проблему блокування треду, якщо у ній використовуються блокуючі методи.*/
public class CoroutineBlocking : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(FakeHttpRequest());
        StartCoroutine(MoveCube());
    }

    private IEnumerator FakeHttpRequest()
    {
        Debug.Log("Запит почався");
        Thread.Sleep(3000);
        Debug.Log("Запит завершився");
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
