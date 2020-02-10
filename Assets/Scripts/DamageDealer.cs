using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this class is responsible for the collision between enemy and player
public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage = 500;

    public int GetDamage()
    {
        return damage;
    }

    public void Hit()
    {
        gameObject.GetComponent<Enemy>().Die();
    }
}
