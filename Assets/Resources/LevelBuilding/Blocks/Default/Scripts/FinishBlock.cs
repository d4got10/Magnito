using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class FinishBlock : Block
{
    public event Action OnLevelComplete;

    public override int GetId()
    {
        return (int)Blocks.Finish;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerFinishLevel>().FinishLevel(PositionInGrid);
            StartCoroutine(LevelCompleteCoroutine());
        }
    }

    IEnumerator LevelCompleteCoroutine()
    {
        LevelComplete();
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void LevelComplete()
    {
        OnLevelComplete?.Invoke();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
