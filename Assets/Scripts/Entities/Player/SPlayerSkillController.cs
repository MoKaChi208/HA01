using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
using UnityEngine.UI;

public class SPlayerSkillController : MonoBehaviour
{
    public SSkillJoytickPanel skillPanel;
    private Vector3 joyStickDir;
    private float rotateAngle;
    public bool isRotate;
    public GameObject spin;
    public SDirectionLine line;
    public SkillController skillController;
    public const string SKILL_JOYSTICK_PATH = "Prefabs/Skill/";

    private void Start()
    {
        skillPanel = Resources.Load<SSkillJoytickPanel>(SKILL_JOYSTICK_PATH + "SkillPanel");
        skillController = new SkillController();
        skillController.Init();
    }

    public void CreatePanel(RectTransform createZone)
    {
        skillPanel = Instantiate(skillPanel, createZone);
        LoadFirstSkill();
    }

    void Update()
    {
        joyStickDir = skillPanel.joystickControllers[0].joystickSkill.Direction;
        isRotate = RotateDir(joyStickDir);
        if (joyStickDir != Vector3.zero)
        {
            line.spriteLine[0].SetActive(true);
        }
        else
        {
            line.spriteLine[0].SetActive(false);
        }
    }

    private bool RotateDir(Vector2 dir)
    {
        if (dir.sqrMagnitude < 0.1f) return false;

        rotateAngle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        if (rotateAngle < 0) rotateAngle += 360;
        line.transform.eulerAngles = Vector3.forward * -rotateAngle;
        return true;
    }
    public void SpawnBullet()
    {
        // GameObject bullet = Instantiate(spin, transform.position, Quaternion.identity);
        Instantiate(spin, line.gameObject.transform.position, line.gameObject.transform.rotation);
    }
    public void UseFirstSkill()
    {
        SGameInstance.Instance.gameEvent.OnPlayerUseSkill?.Invoke();
        skillController.UseFirstSkill(line.gameObject.transform.position, line.gameObject.transform.rotation);
    }
    public void UseSecondSkill()
    {
        SGameInstance.Instance.gameEvent.OnPlayerUseSkill?.Invoke();
        //skillController.UseFirstSkill(line.gameObject.transform.position, line.gameObject.transform.rotation);
    }
    public void UseThirdSkill()
    {
        SGameInstance.Instance.gameEvent.OnPlayerUseSkill?.Invoke();
        //skillController.UseFirstSkill(line.gameObject.transform.position, line.gameObject.transform.rotation);
    }
    public void LoadFirstSkill()
    {
        skillPanel.joystickControllers[0].imageSkill.texture = skillController.skills[0].iconSkill;
    }

}
