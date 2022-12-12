using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SPlayer : MonoBehaviourCore
{
    public PlayerProperties playerProperties;
    public SPlayerMovementController movementComponent;
    public Rigidbody playerRigid;
    public SFollower follower;
    public SAlienSensor alienSensor;
    public SDialogueSensor dialogueSensor;

    private void Reset()
    {
        movementComponent = GetComponent<SPlayerMovementController>();
        // follower = Resources.Load<SFollower>("Follower");
        alienSensor = GetComponentInChildren<SAlienSensor>();
        playerRigid = GetComponent<Rigidbody>();
        dialogueSensor = GetComponentInChildren<SDialogueSensor>();
    }

    private void Awake()
    {
        movementComponent.playerProperties = playerProperties;
    }

    private void Start()
    {
        playerProperties.CalculateProperties();
    }
    private void Update()
    {
        if (alienSensor.closestDistance <= 2 || alienSensor.closestAliens == null || alienSensor.closestDistance >= 40f)
        {
            movementComponent.isClickGoTo = false;
            movementComponent.targetGoTo = Vector3.zero;
        }
    }
}
