using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Asteroids : MonoBehaviour
{   
    public Sprite[] sprites;
    private SpriteRenderer spriteRenderer;

    public float speed = 0.5f;
    public float lifeTime = 30f;

    private Rigidbody2D rb;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
        this.transform.eulerAngles = new Vector3(0f, 0f, Random.value * 360f);

        Destroy(this.gameObject, lifeTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet")) {
        
        if (this.transform.localScale.x > 0.5f){
        Split();
        }
        Gamestate gamestate = FindObjectOfType<Gamestate>();
        gamestate.AddScore(100, this);
        Destroy(this.gameObject); //Destory after use not BEFORE!!!!!!
        
        }
    }

    public void SetTrajectory(Vector2 direction)
    {
        rb.velocity = direction * speed;

    }
    private void Split()
    {
            for (int i = 0; i < 2; i++)
            {
                Asteroids newAsteroid = Instantiate(this, this.transform.position, this.transform.rotation);
                newAsteroid.transform.localScale = this.transform.localScale * 0.5f;
                newAsteroid.SetTrajectory(Random.insideUnitCircle.normalized);
            }
    }
}
