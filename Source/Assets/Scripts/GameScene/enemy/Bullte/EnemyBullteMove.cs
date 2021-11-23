using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullteMove : MonoBehaviour
{
    private EnemyBullteState state;
    private Rigidbody rb;

    void Start()
    {
        state = GetComponent<EnemyBullteState>();
        rb = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        rb.MovePosition(transform.position + transform.forward * state.speed * Time.deltaTime);
    }

    void Update()
    {

    }

}
