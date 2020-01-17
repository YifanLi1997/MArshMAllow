using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage = 100;

    public int GetDamage()
    {
        return damage;
    }

    // after a hit/crash, the laser/bullet/enemy itself will be crashed
    public void Hit()
    {
        Destroy(gameObject);
    }
}
