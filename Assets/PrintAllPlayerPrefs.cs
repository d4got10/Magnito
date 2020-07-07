using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintAllPlayerPrefs : MonoBehaviour
{
    private void Awake()
    {
        PlayerPrefs.SetInt("Level_1_Stars_Count", 3);
        PlayerPrefs.SetInt("Level_1_Stars_0", 1);
        PlayerPrefs.SetInt("Level_1_Stars_1", 1);
        PlayerPrefs.SetInt("Level_1_Stars_2", 1);
    }
}
