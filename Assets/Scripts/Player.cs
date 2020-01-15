using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float projectileSpeed = 50f;
    [SerializeField] float timeBetweenShoot = 0.3f;
    [SerializeField] float xPadding = 0.5f;
    [SerializeField] float yPadding = 0.5f;
    [SerializeField] GameObject laserPrefab;

    Camera m_MainCamera;

    float xMin;
    float xMax;
    float yMin;
    float yMax;

    // Start is called before the first frame update
    void Start()
    {
        m_MainCamera = Camera.main;
        SetCameraSpace();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Shoot();
    }

    private void Shoot()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(ShootLasers());
        }

        if(Input.GetButtonUp("Fire1"))
        {
            StopAllCoroutines();
        }
    }

    private IEnumerator ShootLasers()
    {
        while (true) { 
            GameObject laser = Instantiate(
                    laserPrefab,
                    transform.position,
                    transform.rotation) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            yield return new WaitForSeconds(timeBetweenShoot);
        }
    }

    private void Move()
    {
        var xMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        var yMovement = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        var currentPos = transform.position;
        currentPos.x = Mathf.Clamp(currentPos.x + xMovement, xMin, xMax);
        currentPos.y = Mathf.Clamp(currentPos.y + yMovement, yMin, yMax);
        transform.position = currentPos;
    }

    private void SetCameraSpace()
    {
        xMin = m_MainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + xPadding;
        xMax = m_MainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - xPadding;
        yMin = m_MainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + yPadding;
        yMax = m_MainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - yPadding;
    }
}
