using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Pixelplacement;

public class SGameInstance : Singleton<SGameInstance>
{
    public SPlayer player;
    private Dictionary<int, SMonster> monsterDictionary;
    public NeighbourPositions neighbourPositions;
    public GameEvent gameEvent;
    public Camera mainCam;
    public bool isSavingAvailable = true;

    private void Awake()
    {
        MonoUtility.SetTimeScale(1, this);
        monsterDictionary = new Dictionary<int, SMonster>();
        gameEvent = new GameEvent();
        neighbourPositions = new NeighbourPositions(Camera.main);
    }

    public void AddMonster(SMonster monster)
    {
        if (!monsterDictionary.ContainsKey(monster.transform.GetInstanceID()))
            monsterDictionary.Add(monster.transform.GetInstanceID(), monster);
    }

    public SMonster GetMonsterReference(int transformInstanceID)
    {
        if (monsterDictionary.ContainsKey(transformInstanceID))
            return monsterDictionary[transformInstanceID];

        return null;
    }

}



