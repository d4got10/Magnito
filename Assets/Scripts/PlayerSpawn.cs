using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public void SpawnPlayer()
    {
        var startPosition = FindObjectOfType<StartPositionBlock>()?.transform;
        if (startPosition != null)
            transform.position = startPosition.position;
        else
            Debug.LogError("No starting position");
    }
}
