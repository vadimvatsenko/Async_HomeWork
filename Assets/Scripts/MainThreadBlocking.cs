using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

/*Сценарій 1: Блокування головного треду
Опис
Цей сценарій демонструє, що відбувається, коли HTTP-запит виконується безпосередньо в головному треді Unity. Через затримку, викликану запитом, весь рендеринг та анімація призупиняються.*/
public class MainThreadBlocking : MonoBehaviour
{
    
    void Start()
    {
        StartCoroutine(MoveCube());

        Debug.Log("Запит почався...");
        Thread.Sleep(3000); // будет прерывать основной поток
        Debug.Log("Запит завершився...");
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
