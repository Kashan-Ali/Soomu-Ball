using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  LightEnemy(Child) class inherite Enemy(Prant) class
public class LightEnemy : Enemy
{
    protected override void MoveTowardsDirection()
    {
        //  Basic Enemy Movement.
        _enemyRB.AddForce(_lookDirection * speed * Time.deltaTime);
    }
}
