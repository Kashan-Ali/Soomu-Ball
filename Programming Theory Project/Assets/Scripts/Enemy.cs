using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 50;

    private Rigidbody _enemyRB;
    private GameObject _player;

    private SpawnManager _SpawnManager;

    // Start is called before the first frame update
    private void Start()
    {
        _enemyRB = GetComponent<Rigidbody>();
        _player = GameObject.FindGameObjectWithTag("Player");

        _SpawnManager = FindObjectOfType<SpawnManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        MoveTowardsDirection();
        OffTheGround();
    }

    private void MoveTowardsDirection()
    {

        if (_player == null)
            return;

        // Distance Direction Calculation.
        Vector3 _lookDirection = (_player.transform.position - transform.position).normalized;
        _enemyRB.AddForce(_lookDirection * speed * Time.deltaTime);
    }

    private void OffTheGround()
    {
        if (transform.position.y < -7)
        {
            Destroy(gameObject);
            _SpawnManager.score++;
        }
    }
}
