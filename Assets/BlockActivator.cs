using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class BlockActivator : MonoBehaviour
{
    [SerializeField] private bool _setup;
    private void Update()
    {
        if (_setup)
        {
            var magnets = FindObjectsOfType<Magnet>();
            foreach (var magnet in magnets)
            {
                magnet.Setup();
            }
            _setup = false;
        }
    }
}
