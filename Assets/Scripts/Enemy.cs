using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Health")]
    [SerializeField] int health = 500;
    [SerializeField] int explosionPoint = 100;
    [SerializeField] int hitPoint = 20;
    [SerializeField] GameObject enemyExplosionVFXPrefab;
    [SerializeField] float durationOfExplosion = 1f;

    [Header("Projectile")]
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float verticalProjectileSpeed;
    [SerializeField] float horizontalProjectileSpeed;
    [SerializeField] float timeBetweenShoot;
    [SerializeField] float mixTimeBetweenShoot = 5f;
    [SerializeField] float maxTimeBetweenShoot = 10f;

    [Header("Sound Effect")]
    [SerializeField] AudioClip deathSFX;
    [SerializeField] AudioClip shootingSFX;
    [SerializeField] [Range(0, 1)] float deathVolume = 0.75f;
    [SerializeField] [Range(0, 1)] float shootingVolume = 0.5f;

    GameStatus m_gameStatus;

    private void Start()
    {
        m_gameStatus = FindObjectOfType<GameStatus>();
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
            // VFX
            GameObject laser = Instantiate(
                laserPrefab,
                transform.position,
                transform.rotation) as GameObject;

            verticalProjectileSpeed = UnityEngine.Random.Range(-10f, -1f);
            horizontalProjectileSpeed = UnityEngine.Random.Range(-10f, 10f);

            laser.GetComponent<Rigidbody2D>().velocity =
                new Vector2(0f, verticalProjectileSpeed);
            timeBetweenShoot =
                UnityEngine.Random.Range(mixTimeBetweenShoot, maxTimeBetweenShoot);

            // SFX
            AudioSource.PlayClipAtPoint(shootingSFX, Camera.main.transform.position, shootingVolume);
        }
    }

    // mind the shredders
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Projectile projectile =
            collision.gameObject.GetComponent<Projectile>();
        if (!projectile) { return; }
        ProcessHit(projectile);
    }

    private void ProcessHit(Projectile projectile)
    {
        health -= projectile.GetDamage();
        m_gameStatus.AddToScore(hitPoint);
        projectile.Hit();
        if (health <= 0)
        {
            Die();
        }
    }

    // this should be private,
    // but for the reason described in DamageDealer.cs
    // we implement this for now
    public void Die()
    {
        // Destory Enemy itself
        Destroy(gameObject);

        // Update score
        m_gameStatus.AddToScore(explosionPoint);

        // VFX
        GameObject enemyExplosion = Instantiate(
            enemyExplosionVFXPrefab,
            transform.position,
            transform.rotation);
        Destroy(enemyExplosion, durationOfExplosion);

        // SFX
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathVolume);
    }
}
