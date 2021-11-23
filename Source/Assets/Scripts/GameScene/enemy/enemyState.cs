using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyState : MonoBehaviour
{
    public enemyManager manager;

    public GameObject body;
    public GameObject healthBar;

    public enemyType type;
    public int level;
    public float healthCounter;

    public float reloadCounter;

    public int moveStateCounter;
    public float moveStateTimeCounter;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveStateCounter = Random.Range(0, manager.enemyList[(int)type].moveStates.Length);
        moveStateTimeCounter = Random.Range(0.0f, manager.enemyList[(int)type].moveStates[moveStateCounter].time);
        reloadCounter = 0;
        body.GetComponent<MeshRenderer>().material.SetColor("_EdgeColor", manager.enemyList[(int)type].color);
        healthCounter = manager.enemyList[(int)type].getHealth(level);


    }

    private void FixedUpdate()
    {
        move();
        attack();

        moveStateTimeCounter -= Time.fixedDeltaTime;
        if(moveStateTimeCounter<=0)
        {
            moveStateCounter++;
            if (moveStateCounter >= manager.enemyList[(int)type].moveStates.Length)
            {
                moveStateCounter = 0;
            }
            moveStateTimeCounter = manager.enemyList[(int)type].moveStates[moveStateCounter].time;
        }

    }

    void Update()
    {
        gameObject.GetComponentInChildren<SpriteRenderer>().material.SetFloat("_Offset", healthCounter / manager.enemyList[(int)type].getHealth(level));

        if (healthCounter <= 0)
        {
            Destroy(gameObject);
            manager.player.getExperience(manager.enemyList[(int)type].getExperience(level));
            manager.player.getExperience(manager.player.data.nowItem[(int)itemType.ColddownSpeed] * (int)manager.gameScene.item.itemList[(int)itemType.ColddownSpeed].value);
            manager.player.data.healthCounter += manager.player.data.nowItem[(int)itemType.HealPerKill] * manager.gameScene.item.itemList[(int)itemType.HealPerKill].value;
            manager.gameScene.enemyCounter--;
        }
        if (Vector3.Distance(transform.position, Vector3.zero) > 40.0f)
        {
            transform.position = transform.position.normalized * 40.0f;
        }
    }

    public void getDamage(float damage)
    {
        healthCounter -= damage;
    }


    public void move()
    {
        float singleStep = manager.enemyList[(int)type].moveStates[moveStateCounter].rotateValue * Time.fixedDeltaTime;
        float moveSpeed = manager.enemyList[(int)type].moveStates[moveStateCounter].moveValue * Time.fixedDeltaTime;

        switch (manager.enemyList[(int)type].moveStates[moveStateCounter].move)
        {
            case enemyMove.Stay:
                break;

            case enemyMove.Track:
                {
                    Vector3 targetDirection = manager.getPlayerPos() - transform.position;
                    Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
                    transform.rotation = Quaternion.LookRotation(newDirection);

                    if (moveSpeed != 0)
                    {
                        rb.MovePosition(transform.position + transform.forward * moveSpeed);
                    }
                    break;
                }
            case enemyMove.Forecast:
                {
                    Vector3 targetPos = manager.getPlayerPos();

                    Vector2 moveInput = Vector2.zero;
                    if (Input.GetKey(KeyCode.W)) moveInput.y += 1;
                    if (Input.GetKey(KeyCode.S)) moveInput.y -= 1;
                    if (Input.GetKey(KeyCode.A)) moveInput.x -= 1;
                    if (Input.GetKey(KeyCode.D)) moveInput.x += 1;
                    moveInput = moveInput.normalized * 40f * Vector3.Distance(targetPos, transform.position) * Time.fixedDeltaTime;
                    targetPos.x += moveInput.x;
                    targetPos.z += moveInput.y;
                    Vector3 targetDirection = targetPos - transform.position;
                    Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
                    transform.rotation = Quaternion.LookRotation(newDirection);
                    break;
                }

            case enemyMove.Turn:
                transform.Rotate(0.0f, singleStep, 0.0f);
                break;
        }


        if (moveSpeed != 0)
        {
            rb.MovePosition(transform.position + transform.forward * moveSpeed);
        }
    }
    public void attack()
    {
        if (manager.enemyList[(int)type].moveStates[moveStateCounter].attack == enemyBullteType.Total) return;

        if (reloadCounter <= 0)
        {
            EnemyBullteState obj;
            obj = Instantiate(manager.enemyBullte.enemyBullteList[(int)manager.enemyList[(int)type].moveStates[moveStateCounter].attack], transform.position, transform.rotation);
            obj.damage = manager.enemyList[(int)type].getAttackPower(level) * manager.enemyList[(int)type].moveStates[moveStateCounter].attackPowerScale;

            reloadCounter = manager.enemyList[(int)type].moveStates[moveStateCounter].reloadTime;
        }

        if(reloadCounter >0)
        {
            reloadCounter -= Time.fixedDeltaTime * manager.enemyList[(int)type].getReloadSpeed(level);
        }
    }

    void die()
    {
        DestroyImmediate(gameObject);
    }

}
