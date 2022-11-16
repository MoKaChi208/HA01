using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPlayer : MonoBehaviourCore
{
    public PlayerProperties playerProperties;
    public Rigidbody playerRigid;
    private void Start()
    {
        playerProperties.CalculateProperties();
    }
}
