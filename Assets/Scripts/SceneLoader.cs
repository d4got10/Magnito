using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }

    public void LoadSceneDelayed(int sceneId, float time)
    {
        StartCoroutine(LoadSceneDelayedCoroutine(sceneId, time));
    }

    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadNextSceneDelayed(float time)
    {
        StartCoroutine(LoadNextSceneDelayedCoroutine(time));
    }

    IEnumerator LoadSceneDelayedCoroutine(int sceneId, float time)
    {
        yield return new WaitForSeconds(time);
        LoadScene(sceneId);
    }

    IEnumerator LoadNextSceneDelayedCoroutine(float time)
    {
        yield return new WaitForSeconds(time);
        LoadNextScene();
    }
}
