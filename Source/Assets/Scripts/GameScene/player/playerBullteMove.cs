using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBullteMove: MonoBehaviour
{
    public float damage;
    public float speed;
    public float lifeTime;
    public GameObject explosionEffect;
    Vector3 previousLocation;

    private Rigidbody rb;

    void Start()
    {
        Destroy(gameObject, lifeTime);
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        previousLocation = transform.position;

        Vector3 moveSpeed = transform.forward * speed;
        rb.velocity = moveSpeed;
    }
    void Update()
    {
    }

    void OnCollisionEnter(Collision col)
    {
        enemyState enemy = col.gameObject.GetComponent<enemyState>();
        if (enemy == null) return;

        enemy.getDamage(damage);

        rb.velocity = Vector3.zero;
        transform.position = previousLocation;

        Instantiate(explosionEffect, transform.position, rb.rotation);
        Destroy(gameObject);
        return;
    }


}
