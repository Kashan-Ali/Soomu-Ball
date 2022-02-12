using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 50;

    private Rigidbody _enemyRB;
    private GameObject _player;

    // Start is called before the first frame update
    private void Start()
    {
        _enemyRB = GetComponent<Rigidbody>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    private void Update()
    {
        MoveTowardsDirection();
    }

    private void MoveTowardsDirection()
    {
        // Distance Direction Calculation.
        Vector3 _lookDirection = (_player.transform.position - transform.position).normalized;
        _enemyRB.AddForce(_lookDirection * speed * Time.deltaTime);
    }
}
