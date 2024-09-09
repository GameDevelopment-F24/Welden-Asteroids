using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamestate : MonoBehaviour
{
    public Player player;

    public int lives = 3;
    public int score = 0;
    public float respawnTime = 3f;
    public int imortalTime = 3;

    public ParticleSystem crash;

    public void PlayerDied()
    {
        this.lives--;
        this.crash.transform.position = this.player.transform.position;
        this.crash.Play();

        Invoke(nameof(Respawn), this.respawnTime);
    }

    private void Respawn()
    {
        if (this.lives > 0)
        {
            this.player.transform.position = Vector3.zero;

            this.player.gameObject.SetActive(true);
            this.player.gameObject.layer = LayerMask.NameToLayer("Imortal");
            this.Invoke(nameof(mortal), this.imortalTime);
        }
        else
        {
            GameOver();
        }
    }
    private void mortal()
    {
        this.player.gameObject.layer = LayerMask.NameToLayer("Player");
    }
    private void GameOver()
    {
        this.lives = 3;
        this.score = 0;

        Invoke(nameof(Respawn), this.respawnTime);
    }
    public void AddScore(int score, Asteroids asteroid)
    {
        this.crash.transform.position = asteroid.transform.position;
        this.crash.Play();
        this.score += score;
    }
}
