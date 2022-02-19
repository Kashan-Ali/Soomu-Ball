using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  MediumEnemy(Child) class inherite Enemy(Prant) class
public class MediumEnemy : Enemy
{
    [SerializeField] private int _rotation = 50;

    protected override void MoveTowardsDirection()
    {
        //  Basic Enemy Movement.
        _enemyRB.AddForce(_lookDirection * speed * Time.deltaTime);

        // Capsole Enemy Skill.
        _enemyRB.AddTorque(Vector3.up * _rotation * Time.deltaTime, ForceMode.Impulse);
    }
}
