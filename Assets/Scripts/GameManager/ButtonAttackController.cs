using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAttackController : ClassInstanceCore
{
    public bool isClick;
    private float distanceMaxToMove = 40f;
    private float distanceMinToMove = 10f;
    public ButtonAttackController()
    {
        isClick = false;
    }
    public void GoToClosetTarget()
    {
        SAlien target;
        Vector3 direction;
        Vector3 targetPosition;
        target = GameInstance.player.alienSensor.closestAliens;

        if (target == null || !target.gameObject.activeInHierarchy)
        {
        }
        if (target != null && GameInstance.player.alienSensor.closestDistance <= distanceMaxToMove
                && GameInstance.player.alienSensor.closestDistance > distanceMinToMove)
        {
            targetPosition = target.transform.position;
            direction = targetPosition - GameInstance.player.transform.position;

            GameInstance.player.movementComponent.isClickGoTo = true;
            GameInstance.player.movementComponent.targetGoTo = direction;
        }
    }
    public void OnClickAttackButton()
    {
        isClick = true;
        GoToClosetTarget();
    }
    public void OnClickDialogueButton(){
        
    }
}
