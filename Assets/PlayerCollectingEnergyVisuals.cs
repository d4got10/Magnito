using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectingEnergyVisuals : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;

    private void Update()
    {
        float size = _playerMovement.Energy;
        transform.localScale = new Vector3(size, size, 1);
    }
}
