using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SPlayerMovementController : MonoBehaviour
{
    public UnityAction OnMoving;
    public FloatingJoystick floatingJoystick;
    public Animator animator;
    private Vector2 joyStickDir;
    private Vector3 moveDirection;
    [HideInInspector] public PlayerProperties playerProperties;
    private float countValue;
    private float rotateAngle;
    private bool isRunning;
    public bool isCollidedWithUpWall, isCollidedWithDownWall;
    public bool isCollidedWithLeftWall, isCollidedWithRightWall;

    private void Reset()
    {
        floatingJoystick = Resources.Load<FloatingJoystick>( "Floating Joystick");
        animator = GetComponentInChildren<Animator>();
    }

    public void CreateJoystick(RectTransform joystickZone)
    {
        floatingJoystick = Instantiate(floatingJoystick, joystickZone);
    }

    // Update is called once per frame
    void Update()
    {
        joyStickDir = floatingJoystick.Direction;
        isRunning = MoveToDir(joyStickDir);
        animator.SetBool("IsRunning", isRunning);
    }

    private bool MoveToDir(Vector2 dir)
    {
        if (dir.sqrMagnitude < 0.1f) return false;

        rotateAngle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        if (rotateAngle < 0) rotateAngle += 360;
        transform.eulerAngles = Vector3.up * rotateAngle;
        CalculateDirection();
        transform.Translate(moveDirection * playerProperties.speed * Time.deltaTime, Space.World);
        OnMoving?.Invoke();
        return true;
    }

    private void CalculateDirection()
    {
        moveDirection = transform.forward;
        moveDirection.y = 0;
        if (isCollidedWithUpWall && moveDirection.z > 0) moveDirection.z = 0;
        if (isCollidedWithDownWall && moveDirection.z < 0) moveDirection.z = 0;
        if (isCollidedWithLeftWall && moveDirection.x < 0) moveDirection.x = 0;
        if (isCollidedWithRightWall && moveDirection.x > 0) moveDirection.x = 0;
    }
}
