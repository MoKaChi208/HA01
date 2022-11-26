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

    private void Reset()
    {
        movementComponent = GetComponent<SPlayerMovementController>();
        follower = Resources.Load<SFollower>("Follower");
        alienSensor = GetComponentInChildren<SAlienSensor>();
        playerRigid = GetComponent<Rigidbody>();
    }

    private void Awake()
    {
       // movementComponent.playerProperties = playerProperties;
    }

    private void Start()
    {
        follower = Instantiate(follower, transform.position, Quaternion.identity);
        follower.target = transform;
        playerProperties.CalculateProperties();
    }

    // private void EnableBehaviours(bool isEnable)
    // {
    //     movementComponent.floatingJoystick.gameObject.SetActive(isEnable);
    //     movementComponent.enabled = isEnable;
    // }
}
