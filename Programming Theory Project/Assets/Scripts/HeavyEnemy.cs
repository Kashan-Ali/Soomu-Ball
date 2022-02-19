using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  HeavyEnemy(Child) class inherite Enemy(Prant) class
public class HeavyEnemy : Enemy
{
    [SerializeField] private int _tumbleForce = 50;

    protected override void MoveTowardsDirection()
    {
        //  Basic Enemy Movement.
        _enemyRB.AddForce(_lookDirection * speed * Time.deltaTime);

        // Cube Enemy Skill.
        _enemyRB.AddTorque(Vector3.right * _tumbleForce * Time.deltaTime, ForceMode.Impulse);
    }
}
