﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 100;
    public GameObject powerupIndicator;
    [SerializeField] private Vector3 powerupIndicatorOffset = new Vector3(0, -0.5f, 0);

    private GameObject _focalPoint;
    private Rigidbody _playerRB;
    [SerializeField]
    private bool _hasPowerup = false;
    private float _powerupStrength = 20;
    private float _powerupTiming = 10;
    
    private void Start()
    {
        _playerRB = GetComponent<Rigidbody>();
        _focalPoint = GameObject.Find("Focal Point");
    }

    private void Update()
    {
        MovePlayer();
        powerupIndicator.transform.position = transform.position + powerupIndicatorOffset;
    }

    private void MovePlayer()
    {
        float _verticalInput = Input.GetAxis("Vertical");

        _playerRB.AddForce(_focalPoint.transform.forward * _verticalInput * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup") && !_hasPowerup)
        {
            _hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountDownRoutine());
            powerupIndicator.SetActive(true);
        }
    }

    IEnumerator PowerupCountDownRoutine()
    {
        yield return new WaitForSeconds(_powerupTiming);
        _hasPowerup = false;
        powerupIndicator.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && _hasPowerup)
        {
            Rigidbody _enemyRB = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 _bounceByPlayer = collision.transform.position - transform.position;

            _enemyRB.AddForce(_bounceByPlayer * _powerupStrength, ForceMode.Impulse);
        }
    }
}