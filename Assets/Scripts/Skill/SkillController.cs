using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController
{
    public List<ActiveSkill> skills;

    public void Init()
    {
        skills = new List<ActiveSkill>();
        skills.Add(new SpinSkill());

        skills[0].SpawnSkillObjects();
    }
    public void UseFirstSkill(Vector3 position, Quaternion rotation)
    {
        skills[0].UseSkill(position, rotation);
    }
    public void UseSecondSkill(Vector3 position, Quaternion rotation)
    {
        skills[1].UseSkill(position, rotation);
    }
    public void UseThirdSkill(Vector3 position, Quaternion rotation)
    {
        skills[2].UseSkill(position, rotation);
    }
}
