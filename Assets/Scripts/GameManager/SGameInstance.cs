using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Pixelplacement;

public class SGameInstance : Singleton<SGameInstance>
{
    public SPlayer player;
    private Dictionary<int, SAlien> alienDictionary;
    public NeighbourPositions neighbourPositions;
    public GameEvent gameEvent;
    public Camera mainCam;
    public bool isSavingAvailable = true;

    private void Awake()
    {
        MonoUtility.SetTimeScale(1, this);
        gameEvent = new GameEvent();
        neighbourPositions = new NeighbourPositions(Camera.main);
    }

    public void AddMonster(SAlien monster)
    {
        if (!alienDictionary.ContainsKey(monster.transform.GetInstanceID()))
            alienDictionary.Add(monster.transform.GetInstanceID(), monster);
    }

    public SAlien GetMonsterReference(int transformInstanceID)
    {
        if (alienDictionary.ContainsKey(transformInstanceID))
            return alienDictionary[transformInstanceID];

        return null;
    }

}
[System.Serializable]
public class Cheat
{
    public bool enableSkillCheat;
    public bool dailyRewardCheat;
    public int loginDays;
}



