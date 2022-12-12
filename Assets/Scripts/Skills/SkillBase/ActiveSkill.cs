using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ActiveSkill : Skill
{
    public ObjectInstantiation objectInstantiation;
    protected Transform objectContainer;
    public Coroutine skillCoroutine;
    protected NeighbourPositions neighbourPositions;
    public int number;
    public int baseNumber;
    public float baseCooldown;
    public bool skillCoroutineTriggered;
    protected object coolDownDelay;
    private object startgateCooldownDelay;
    protected virtual object CoolDownDelay
    {
        get
        {
            return coolDownDelay;
        }
    }
    protected object shootingDelay = new WaitForSeconds(0.2f);
    protected virtual object ShootingDelay => shootingDelay;
    protected Vector3 projectileOffset = new Vector3(0, 0.5f, 0);
    public ActiveSkill()
    {
        this.neighbourPositions = GameInstance.neighbourPositions;
    }
    public ActiveSkill(Transform objectContainer)
    {
        this.objectContainer = objectContainer;
    }

    protected override void OnLevelUpFinish()
    {
        if (level > maxSkillLevel)
        {
            evolution = true;
            if (level == maxSkillLevel + 1) OnEvolutionTriggered();
        }
        UpdateNumber();
        UpdateCoolDown();
    }

    public override void UpdateSkillData(int level)
    {
        base.UpdateSkillData(level);
        // baseNumber = DataFactory.GetSkillNumber(skillType, level);
        //    baseCooldown = DataFactory.GetCoolDownTime(skillType, level);
    }

    public virtual void UpdateNumber()
    {
        number = baseNumber;
    }

    public virtual void UpdateCoolDown()
    {
        // float talentCooldownEffect = Player.playerProperties.cooldownDecreasement;
        // float skillCooldownEffect = Player.playerProperties.coolDownPercentage;
        //  float marsBeltEffect = Player.playerProperties.marsBeltCooldownPercentage;
        //  float totalDecreasement = talentCooldownEffect + skillCooldownEffect + marsBeltEffect;
        //    baseCooldown -= baseCooldown * totalDecreasement * 0.01f;
        //  coolDownDelay = new WaitForSeconds(baseCooldown);
        // startgateCooldownDelay = new WaitForSeconds(baseCooldown * (1 - Player.playerProperties.stargateCooldownDamageMultiply));
    }

    public override void UpdatePower()
    {
        power = Player.playerProperties.Damage * basePowerPercentage * 0.01f;
    }

    public virtual void SpawnSkillObjects()
    {

    }

    protected virtual void OnEvolutionTriggered()
    {
        // GameInstance.gameEvent.OnSkillEvolutionTriggered?.Invoke(skillType);
    }

    public virtual void DestroySkillObject()
    {

    }

    public virtual void HideSkillObjects()
    {

    }

    public override void TriggerHidden()
    {
        base.TriggerHidden();
        HideSkillObjects();
        StopCoroutineSkill();
    }

    public virtual void StopCoroutineSkill()
    {
        if (skillCoroutine != null) StopCoroutine(skillCoroutine);
    }

    public virtual void StartSkillCoroutine()
    {
        skillCoroutineTriggered = true;
        skillCoroutine = StartCoroutine(SkillCoroutine());
    }

    protected virtual IEnumerator SkillCoroutine()
    {
        yield return null;
    }
}
