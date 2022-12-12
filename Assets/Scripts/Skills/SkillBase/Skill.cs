using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum ObjectInstantiation
{
    ChildObject, Individual, None
}

[System.Serializable]
public class Skill : ClassInstanceCore
{
    public SkillType skillType;
    private SPlayer player;
    protected SPlayer Player
    {
        get
        {
            if (player == null) player = GameInstance.player;
            return player;
        }
    }
    public int level;
    public int maxSkillLevel;
    public float power;
    public bool evolution;
    public float basePowerPercentage;
    public bool powerUpAndGiftAffected;
    public bool ReachMaxLevel
    {
        get { return level >= maxSkillLevel; }
    }
    public bool isHidden;

    public virtual void LevelUp()
    {
        if (level < 0) level = 0;
        level++;

        UpdateSkillData(level);
        UpdatePower();
        OnLevelUpFinish();
    }

    public virtual void LevelUp(int upToLevel)
    {
        level = Mathf.Clamp(upToLevel, 1, maxSkillLevel + 1);

        UpdateSkillData(level);
        UpdatePower();
        OnLevelUpFinish();
    }

    public virtual void UpdateSkillData(int level)
    {
        basePowerPercentage =0;
        // DataFactory.GetSkillPower(skillType, level);
    }

    public virtual void UpdatePower()
    {
        power = basePowerPercentage;
    }

    public float CalculatePowerAfterBuff(int level)
    {
        float basePower = 0;
        //DataFactory.GetSkillPower(skillType, level);
        return basePower;
    }

    protected virtual void OnLevelUpFinish()
    {

    }

    public virtual void TriggerHidden()
    {
        isHidden = true;
    }

    public static Skill InstantiateNewSkill(SkillType skillType, Transform playerFollower)
    {
        Skill skill = null;
        return skill;
    }
}

