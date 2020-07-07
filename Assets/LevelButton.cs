using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private SceneLoader _sceneLoader;
    [Space]
    [SerializeField] private int _levelId;
    [SerializeField] private GameObject[] _stars;
    
    private void Awake()
    {
        if (PlayerPrefs.HasKey($"Level_{_levelId}_Stars_Amount"))
        {
            for (int i = 0; i < 3; i++)
            {
                _stars[i].SetActive(PlayerPrefs.GetInt($"Level_{_levelId}_Stars_{i}") > 0);
            }
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                PlayerPrefs.SetInt($"Level_{_levelId}_Stars_{i}", 0);
                _stars[i].SetActive(false);
            }
            PlayerPrefs.SetInt($"Level_{_levelId}_Stars_Amount", 0);
        }
        PlayerPrefs.Save();
    }

    public void LoadLevel()
    {
        _sceneLoader.LoadSceneDelayed(_levelId + LevelManager.LevelScenesStartIndex - 1, 2);
    }
}
