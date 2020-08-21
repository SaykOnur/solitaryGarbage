using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb; //reference rb to child obj
    public float moveForce;

    bool canDoubleJump;

    public LayerMask groundMask;

    Collider col;

    private void Awake()
    {
        col = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();

       
    }

    private void Update()
    {
        if (isOnGround())
            canDoubleJump = true;


        if (isOnGround())
        {
            if (Input.GetMouseButtonDown(0))
            {
                initialTouchPosition = Input.mousePosition;
            }
            if (Input.GetMouseButtonUp(0))
            {
                endTouchPosition = Input.mousePosition;
                dragDir = endTouchPosition - initialTouchPosition; //not normalized drag vector
                AddForceToDir(dragDir.x, dragDir.y);
            }
        }
        else
        {
            if (canDoubleJump)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    initialTouchPosition = Input.mousePosition;
                }
                if (Input.GetMouseButtonUp(0))
                {
                    endTouchPosition = Input.mousePosition;
                    dragDir = endTouchPosition - initialTouchPosition; //not normalized drag vector
                    AddForceToDir(dragDir.x, dragDir.y);
                    canDoubleJump = false;
                }
            }
        }
    }


    Vector2 initialTouchPosition;
    Vector2 endTouchPosition;
    Vector2 dragDir;

    void AddForceToDir(float x, float y)
    {
        float absoluteX = Mathf.Abs(x);
        float absoluteY = Mathf.Abs(y);
        if (absoluteX > 1 / 10 * ((Screen.currentResolution.width + Screen.currentResolution.height) / 2) || absoluteY > ((Screen.currentResolution.width + Screen.currentResolution.height) / 2))
        {
            Vector3 dir = new Vector3(x, y).normalized;
            rb.AddForce(-dir.x * moveForce, -dir.y * moveForce, 0);
        }
    }

    #region GroundCheck
    Collider[] overlapColliders;
    bool isOnGround()
    {
        overlapColliders = Physics.OverlapSphere(col.bounds.center,col.bounds.size.x/2, groundMask);
        if (overlapColliders.Length != 0) return true;else return false;
    }
    #endregion





}
