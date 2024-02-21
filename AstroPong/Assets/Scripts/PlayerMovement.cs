using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Vector3 mousePos;
    public float speed;
    private Transform m_transform;

    // Start is called before the first frame update
    void Start()
    {
        m_transform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {

        LookAtMouse();
        // if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        // {
        //     transform.Rotate(Vector3.forward, -speed * Time.deltaTime);
        // }
        
        // if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        // {
        //     transform.Rotate(Vector3.forward, speed * Time.deltaTime);
        // }

        // mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
        Debug.Log(Camera.main.ScreenToWorldPoint (Input.mousePosition));

    }

    private void LookAtMouse()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);

        transform.up = -direction;


        // float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;

        // Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        // m_transform.rotation = rotation;
    } 
}
