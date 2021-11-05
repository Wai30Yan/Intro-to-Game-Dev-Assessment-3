using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    bool rayRight;
    bool rayLeft;
    bool rayUp;
    bool rayDown;
    Vector3 moveUp = new Vector3(0, 1, 0);
    Vector3 moveDown = new Vector3(0, -1, 0);
    Vector3 moveRight = new Vector3(1, 0, 0);
    Vector3 moveLeft = new Vector3(-1, 0, 0);
    float rayCastLength = 0.26f;
    KeyCode lastInput;
    KeyCode currentInput;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {        
        RayCast();
        GetInput();
        Move(currentInput);


        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("last input: " + lastInput);
            Debug.Log("current input: " + currentInput);
            //Debug.Log("Right: " + rayRight);
            //Debug.Log("Left: " + rayLeft);
            //Debug.Log("Up: " + rayUp);
            //Debug.Log("Down: " + rayDown);
        }
    }

    void GetInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            currentInput = KeyCode.W;
            if (rayUp)
            {
                lastInput = KeyCode.W;
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            currentInput = KeyCode.A;
            if (rayLeft)
            {
                lastInput = KeyCode.A;
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            currentInput = KeyCode.S;
            if (rayDown)
            {
                lastInput = KeyCode.S;
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            currentInput = KeyCode.D;
            if (rayRight)
            {
                lastInput = KeyCode.D;
            }
        }
    } 


    void Move(KeyCode input)
    {
        if (currentInput == KeyCode.W && !rayUp)
        {           
            transform.position = Vector3.Lerp(transform.position, transform.position + moveUp, Time.deltaTime);             
        } 
        if (currentInput == KeyCode.D && !rayRight)
        {           
            transform.position = Vector3.Lerp(transform.position, transform.position + moveRight, Time.deltaTime);     
        }
        if (currentInput == KeyCode.S && !rayDown)
        {            
            transform.position = Vector3.Lerp(transform.position, transform.position + moveDown, Time.deltaTime);             
        }
        if (currentInput == KeyCode.A && !rayLeft)
        {           
            transform.position = Vector3.Lerp(transform.position, transform.position + moveLeft, Time.deltaTime);             
        }
    }

    void RayCast()
    {
        RayUp();
        RayDown();
        RayRight();
        RayLeft();
    }

    void RayUp()
    {       
        RaycastHit2D hitUp = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), rayCastLength);
        if (hitUp)
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.up) * rayCastLength, Color.red);
            rayUp = true;
        }
        else
        {
            rayUp = false;
            lastInput = KeyCode.W;
        }
    }

    void RayDown()
    {
        RaycastHit2D hitDown = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.down), rayCastLength);
        if (hitDown)
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.down) * rayCastLength, Color.red);
            rayDown = true;
        }
        else
        {
            rayDown = false;
            lastInput = KeyCode.S;
        }
    }

    void RayRight()
    {
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), rayCastLength);
        if (hitRight)
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.right) * rayCastLength, Color.red);
            rayRight = true;
        } 
        else
        {
            rayRight = false;
            lastInput = KeyCode.D;
        }
    }

    void RayLeft()
    {
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.left), rayCastLength);
        if (hitLeft)
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.left) * rayCastLength, Color.red);
            rayLeft = true;
        }
        else
        {
            rayLeft = false;
            lastInput = KeyCode.A;
        }
    }

}
