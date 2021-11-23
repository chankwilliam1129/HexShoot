using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullteMove2 : MonoBehaviour
{
    private EnemyBullteState state;
    private Rigidbody rb;
    private Vector3 target;

    public float speed;
    void Start()
    {
        state = GetComponent<EnemyBullteState>();
        rb = GetComponent<Rigidbody>();

        target = state.player.position;
    }

    void FixedUpdate()
    {
        float singleStep = speed * Time.fixedDeltaTime;

        Vector3 targetDirection = state.player.position - transform.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);

        rb.MovePosition(transform.position + transform.forward * state.speed * Time.fixedDeltaTime);
    }
    void Update()
    {

    }
}
