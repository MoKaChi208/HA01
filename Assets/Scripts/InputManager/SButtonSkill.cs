using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SButtonSkill : MonoBehaviourCore
{
    [SerializeField] private FixedJoystick fixedJoystick;
    [SerializeField] private Vector2 joyStickDir;
    [SerializeField] private GameObject directionSprite;
    private float countValue;
    private float rotateAngle;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        joyStickDir = fixedJoystick.Direction;
        MoveToDir(joyStickDir);
    }
    private bool MoveToDir(Vector2 dir)
    {
        if (dir.sqrMagnitude < 0.1f) return false;

        rotateAngle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        if (rotateAngle < 0) rotateAngle += 360;
        directionSprite.transform.eulerAngles = Vector3.forward* -rotateAngle;
        return true;
    }
}
