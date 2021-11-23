using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyBullteState : MonoBehaviour
{
    public playerManager player;
    public GameObject explosionEffect;

    public float speed;
    public float damage;

    private bool hittable;
    void Start()
    {
        hittable = true;
    }


    public void explosion()
    {
        if (explosionEffect != null) Instantiate(explosionEffect, transform.position, transform.rotation);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (hittable && col.gameObject.GetComponent<playerMove>() != null) 
        {
            player.takeDamage(damage);
            Instantiate(explosionEffect, col.gameObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position), transform.rotation);
            hittable = false;
            Destroy(gameObject, 0.1f);
        }
    }
}
