using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed; // 
    private Transform m_transform; // mouse transform variable

    // Start is called before the first frame update
    void Start()
    {
        m_transform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        LookAtMouse();
    }

    private void LookAtMouse()
    {
        // Converts Mouse position from screen to WorldView
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Transforms at the direction of the mouse
        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);

        //Transforms upwards
        transform.up = -direction;
    } 
}
