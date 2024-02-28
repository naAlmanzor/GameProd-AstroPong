using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Transform m_transform; // mouse transform variable
    public Camera _mainCam;
    bool _isStarting = false;

    // Start is called before the first frame update
    void Start()
    {
        m_transform = this.transform;
        _mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(WaitToStart());
        if(_isStarting == true)
        {
            LookAtMouse();
        }
    }

    private void LookAtMouse()
    {
        // Converts Mouse position from screen to WorldView
        Vector3 _mousePos = _mainCam.ScreenToWorldPoint(Input.mousePosition);
        
        //Transforms at the _direction of the mouse
        Vector2 _direction = new (_mousePos.x - transform.position.x, _mousePos.y - transform.position.y);

        //Transforms upwards
        m_transform.up = -_direction * Time.deltaTime;
    }

    IEnumerator WaitToStart()
    {
        yield return new WaitUntil(()=> Input.GetKeyDown(KeyCode.Space));
        _isStarting = true;
    }
}
