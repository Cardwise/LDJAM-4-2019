using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public FiniteTimer durationTimer = new FiniteTimer(0, .5f);
    public int damage;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = speed * transform.right;
        durationTimer.updateTimer(Time.deltaTime);
        if (durationTimer.isComplete())
            expolode();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damagable damagee = collision.GetComponent<Damagable>();
        if (damagee != null) {
            damagee.takeDamage(damage);
            expolode();
        }
    }

    public void expolode() {
        Destroy(gameObject);
    }

}
