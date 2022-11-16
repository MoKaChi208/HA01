using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MonsterProperties : CharacterProperties
{
    public float exp;
    public int addtionalPower;
    public static int addtionalPowerByMinutes;

    public void LoadPropertiesOfType(int type)
    {
        addtionalPower = 1;
        speed = DataFactory.GetAlienSpeed(type);
        damage = DataFactory.GetDamageToPlayer(type);
        health = DataFactory.GetAlienHealth(type);

        health = health * addtionalPower * addtionalPowerByMinutes;
        speed += 2;
        damage += 2;
        health += 2;
    }
}
public class SMonster : MonoBehaviourCore
{
    public float speed;
    public float health;
    public float damageToPlayer;
    // Start is called before the first frame update
    void Start()
    {
        speed = DataFactory.GetAlienSpeed(1);
        health = DataFactory.GetAlienHealth(1);
        damageToPlayer = DataFactory.GetDamageToPlayer(1);
    }

    // Update is called once per frame
}
