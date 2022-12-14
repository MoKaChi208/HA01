using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SJoystickController : MonoBehaviourCore
{
    public SkillType skillType;
    public Image handleImage;
    public RawImage imageSkill;
    public SFirstSkillJoystick joystickSkill;
    public void Awake()
    {
        SetColorPressUp();
        joystickSkill.pressUp = SetColorPressUp;
        joystickSkill.pressDown = SetColorPressDown;
    }
    public void SetColorPressDown()
    {
        handleImage.color = new Color32(225, 225, 225, 225);
    }
    public void SetColorPressUp()
    {
        handleImage.color = new Color32(225, 225, 225, 0);
    }
}
