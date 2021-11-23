using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapSelect : MonoBehaviour
{
    public mapManager map;
    public setupSceneCamera setupCamera;
    public GameObject mapGounp;
    public GameObject selectEffect;
    public selectMenu menu;
    public GameObject menuBackground;

    public float activeTime;
    private float activeTimeCounter;
    void Start()
    {
        activeTimeCounter = 0;
    }

    void Update()
    {
        if (Input.mousePosition.x > 0 && Input.mousePosition.x < Screen.width&& Input.mousePosition.y > 0 && Input.mousePosition.y < Screen.height)
        {
            if (!menu.gameObject.activeSelf)
            {
                SelectMap();
            }
        }
        else
        {
            selectEffect.SetActive(false);
        }

        menuBackground.SetActive(menu.gameObject.activeSelf);
    }


    void SelectMap()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo) && activeTimeCounter <= 0.0f)
        {
            if (hitInfo.collider.transform.parent.parent.gameObject == mapGounp)
            {
                selectEffect.SetActive(true);
                selectEffect.transform.position = hitInfo.collider.transform.parent.transform.position;
                if (Input.GetMouseButtonDown(0))
                {
                    setupCamera.newPos = hitInfo.collider.transform.parent.transform.position;
                    activeTimeCounter = activeTime;
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.lockState = CursorLockMode.None;
                    menu.position = hitInfo.collider.transform.parent.transform.position;
                    menu.turnOn(hitInfo.collider.gameObject.transform.parent.gameObject.GetComponent<mapState>().vector);
                    
                }
            }
            else
            {
                selectEffect.SetActive(false);
            }
        }
        else
        {
            selectEffect.SetActive(false);
            if (activeTimeCounter > 0) activeTimeCounter -= Time.deltaTime;
        }
    }
}
