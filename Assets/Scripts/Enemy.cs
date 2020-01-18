using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Health")]
    [SerializeField] int health = 500;

    [Header("Projectile")]
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float verticalProjectileSpeed;
    [SerializeField] float horizontalProjectileSpeed;
    [SerializeField] float timeBetweenShoot;
    [SerializeField] float mixTimeBetweenShoot = 5f;
    [SerializeField] float maxTimeBetweenShoot = 10f;

    private void Start()
    {
        timeBetweenShoot =
                UnityEngine.Random.Range(mixTimeBetweenShoot, maxTimeBetweenShoot);
    }

    private void Update()
    {
        Shoot();
    }

    private void Shoot()  {
       timeBetweenShoot -= Time.deltaTime;
       if (timeBetweenShoot <= 0)
       {
            GameObject laser = Instantiate(
                laserPrefab,
                transform.position,
                transform.rotation) as GameObject;

            verticalProjectileSpeed = UnityEngine.Random.Range(-10f, -1f);
            horizontalProjectileSpeed = UnityEngine.Random.Range(-10f, 10f);

            laser.GetComponent<Rigidbody2D>().velocity =
                new Vector2(horizontalProjectileSpeed, verticalProjectileSpeed);
            timeBetweenShoot =
                UnityEngine.Random.Range(mixTimeBetweenShoot, maxTimeBetweenShoot);
        }
    }

    // mind the shredders
    public void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer =
            collision.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
