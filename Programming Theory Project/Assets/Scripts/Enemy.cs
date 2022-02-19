using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public float speed = 50;

    protected Vector3 _lookDirection;
    protected Rigidbody _enemyRB;

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
        LookAtDirection();
        OffTheGround();
    }

    private void FixedUpdate()
    {
        MoveTowardsDirection();
    }

    private void LookAtDirection()
    {

        if (_player == null)
            return;

        // Distance Direction Calculation.
        _lookDirection = (_player.transform.position - transform.position).normalized;
    }

    protected virtual void MoveTowardsDirection()
    {
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
