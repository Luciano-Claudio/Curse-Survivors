using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerController control;
    public float moveSpeed;

    private Rigidbody2D _rig;
    private Vector2 movement;

    [SerializeField] private bool mouseWalk = false;
    [SerializeField] private Vector3 mousePos;
    [SerializeField] private Vector3 screenPoint;


    void Awake()
    {
        control = GetComponent<PlayerController>();
        _rig = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        movement = new Vector2();
    }

    void Update()
    {
        moveSpeed = control.Speed;
        if (Input.GetMouseButton(0))
        {
            mouseWalk = true;
            mousePos = Input.mousePosition;
            screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        }
        if (Input.GetMouseButtonUp(0))
            mouseWalk = false;


        movement.x = MovementX();
        movement.y = MovementY();
    }
    void FixedUpdate()
    {
        movement = Vector2.ClampMagnitude(movement, 1);
        movement = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);
        _rig.velocity = movement;
    }

    float MovementX()
    {
        float x = Input.GetAxisRaw("Horizontal");
        if (x != 0)
            return x;
        if (mouseWalk)
        {
            if (mousePos.x > screenPoint.x + 10)
                return 1;
            else if (mousePos.x < screenPoint.x - 10)
                return -1;
        }
        return 0;
    }
    float MovementY()
    {
        float x = Input.GetAxisRaw("Vertical");
        if (x != 0)
            return x;
        if (mouseWalk)
        {
            if (mousePos.y > screenPoint.y + 15)
                return 1;
            else if (mousePos.y < screenPoint.y - 15)
                return -1;
        }
        return 0;
    }

}
