using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] AudioClip shootSFX;
    private Camera mainCam;
    private Vector3 mousePos;
    public Transform firePoint;
    public GameObject bulletPrefab;
    SpriteRenderer gunSprites;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;

    public float bulletForce = 20f;
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        gunSprites = GameObject.Find("Gun").GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float angle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);
        
        FlipSprites();

        if(!canFire)
        {
            timer += Time.deltaTime;
            if(timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }

        if(Input.GetMouseButton(0) && canFire)
        {
            canFire = false;
            Shoot();
        }
    }

    void Shoot()
    {
        AudioSource.PlayClipAtPoint(shootSFX, Camera.main.transform.position);
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    void FlipSprites()
    {
        Vector3 rotation = mousePos - transform.position;

        float angle = Mathf.Atan2(rotation.y, rotation.x);

        if (-1.5 < angle && angle < 1.5)
        {
            gunSprites.flipY = false;
        }
        else if (angle > -1.5 && angle > 1.5)
        {
            gunSprites.flipY = true;
        }
    }
}
