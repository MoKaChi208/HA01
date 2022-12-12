using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayState : MonoBehaviourCore
{
    private SGamePlayUI gamePlayUI;
    public TimeLineManager timeLineManager;
    public SPlayer player;
    public const string UI_PATH = "Prefabs/UI/";
    public const string TIMELINE_PATH = "Prefabs/TimeLine/";
    private GameStateData gameStateData;
    private void Awake()
    {
        gamePlayUI = Resources.Load<SGamePlayUI>(UI_PATH + "GamePlay");
    }

    void Start()
    {
        gamePlayUI = Instantiate(gamePlayUI);
        timeLineManager.gameObject.SetActive(true);
        //if (GameInstance.isTutorialEnable) gamePlayUI.DisplayTutorialText();

        player.movementComponent.CreateJoystick(gamePlayUI.joystickZone);


    }
}
