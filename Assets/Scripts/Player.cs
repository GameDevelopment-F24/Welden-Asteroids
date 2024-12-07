using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    public Bullet bulletPrefab;

    public float boostSpeed = 10f;
    public float rotationSpeed = 2f;
    public bool boosting;
    private float turnDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        boosting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            turnDirection = 1f;
        } else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            turnDirection = -1f;
        } else {
            turnDirection = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            Shoot();
        }


    }

    private void FixedUpdate()
    {
         if (boosting) {
            rb.AddForce(this.transform.up * this.boostSpeed);
        }

        if (turnDirection != 0f) {
            rb.AddTorque(this.rotationSpeed * this.turnDirection);
        }

    }

    private void Shoot()
    {
        Bullet bullet = Instantiate(this.bulletPrefab, this.transform.position, this.transform.rotation);
        bullet.Fire(this.transform.up);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid")) {
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;

        this.gameObject.SetActive(false);

        Gamestate gamestate = FindObjectOfType<Gamestate>();

        gamestate.PlayerDied();
}
        

    }
}
