using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Finish : MonoBehaviour
{
    public UnityEvent OnFinishReached;
    public UnityEvent OnLevelCompleted;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnFinishReached.Invoke();
            collision.GetComponent<PlayerFinishLevel>().FinishLevel(transform.position);
            StartCoroutine(DelayedInvokeCoroutine(2));
        }
    }

    IEnumerator DelayedInvokeCoroutine(float time)
    {
        yield return new WaitForSeconds(time);
        OnLevelCompleted.Invoke();
    }
}
