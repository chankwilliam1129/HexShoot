using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public playerManager player;

    public Camera mainCamera;

    public float speed;
    public float moveRotation;

    private Vector2 moveInput;


    private Rigidbody rb;
    private Vector3 cameraOffset;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cameraOffset = mainCamera.transform.position;
    }

    void FixedUpdate()
    {
        moveInput = Vector2.zero;
        if (Input.GetKey(KeyCode.W)) moveInput.y += 1;
        if (Input.GetKey(KeyCode.S)) moveInput.y -= 1;
        if (Input.GetKey(KeyCode.A)) moveInput.x -= 1;
        if (Input.GetKey(KeyCode.D)) moveInput.x += 1;
        moveInput = moveInput.normalized * Time.fixedDeltaTime * speed;


        Vector3 move;
        move.x = moveInput.x;
        move.y = 0.0f;
        move.z = moveInput.y;

        rb.MovePosition(rb.position + move);
        player.position = transform.position;
    }

    void Update()
    {
        if (getMousePosistion(new Vector3(1, 0, 1)) != Vector3.zero)
        {
            rb.transform.LookAt(getMousePosistion(new Vector3(1, 0, 1)));
        }

        mainCamera.transform.position = transform.position + cameraOffset;

        if (Vector3.Distance(transform.position, Vector3.zero) > 40.0f)
        {
            transform.position = transform.position.normalized * 40.0f;
        }
    }

    Vector3 getMousePosistion(Vector3 offset)
    {
        Ray rayMouse;
        RaycastHit hit;
        rayMouse = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(rayMouse.origin, rayMouse.direction, out hit))
        {
            Vector3 posistion = hit.point;
            posistion.x *= offset.x;
            posistion.y *= offset.y;
            posistion.z *= offset.z;

            return posistion;
        }
        else return Vector3.zero;
    }
}
