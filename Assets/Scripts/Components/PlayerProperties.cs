using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerProperties : CharacterProperties
{
    public float maxHealth;
    public float Damage
    {
        get { return damage; }
    }
    public float baseDamage;

    private void ResetEquipmentEffectAttributes()
    {
    }

    public void CalculateProperties()
    {
        health += DataController.gameData.playerData.health;
        damage += damage;
        baseDamage = damage;
        armor += 1;
        maxHealth = DataController.gameData.playerData.health;
        speed = DataController.gameData.playerData.speed;
    }

    public void UpdateAndCalculateTalentData()
    {
        CalculateProperties();
    }
}
