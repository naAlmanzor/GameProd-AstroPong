using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Transform m_transform; // mouse transform variable
    public Camera mainCam;
    bool isStarting = false;

    // Start is called before the first frame update
    void Start()
    {
        m_transform = this.transform;
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(WaitToStart());
        if(isStarting == true)
        {
            LookAtMouse();
        }
    }

    private void LookAtMouse()
    {
        // Converts Mouse position from screen to WorldView
        Vector3 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        
        //Transforms at the direction of the mouse
        Vector2 direction = new (mousePos.x - transform.position.x, mousePos.y - transform.position.y);

        //Transforms upwards
        m_transform.up = -direction * Time.deltaTime;
    }

    IEnumerator WaitToStart()
    {
        yield return new WaitUntil(()=> Input.GetKeyDown(KeyCode.Space));
        isStarting = true;
    }
}
