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

        // though this is really not a good solution,
        // as I cannot come up with a good one at this moment,
        // we will use this for now.
        // The 'Die()' function of Enemy should be private
        if (CompareTag("Enemy"))
        {
            gameObject.GetComponent<Enemy>().Die();
        }
    }
}
