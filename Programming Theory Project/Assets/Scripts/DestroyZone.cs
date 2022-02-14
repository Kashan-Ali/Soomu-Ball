using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    UIManager _UIManager;

    private void OnEnable()
    {
        _UIManager = FindObjectOfType<UIManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);

        if (other.gameObject.CompareTag("Player"))
        {
            _UIManager.GameOver();
        }
    }
}
