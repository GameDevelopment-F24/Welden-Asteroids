using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
 public float speed = 500f;
 public float lifeTime = 10f;
 private Rigidbody2D rb;

 private void Awake()
 {
     rb = GetComponent<Rigidbody2D>();
 }

 public void Fire(Vector2 direction)
 {
    rb.AddForce(direction * this.speed);
    Destroy(this.gameObject, this.lifeTime);
 }

 private void OnCollisionEnter2D(Collision2D collision)
 {
     Destroy(this.gameObject);
 }
}
