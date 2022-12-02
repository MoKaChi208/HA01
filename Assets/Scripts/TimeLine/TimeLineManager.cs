using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Cinemachine;
public class TimeLineManager : MonoBehaviourCore
{
    private bool fix = false;
    public Animator busAnimator;
    public RuntimeAnimatorController busAnim;
    public PlayableDirector director;
    public GameObject player;
    public GameObject startPointCamera;
    public CinemachineVirtualCamera cinemachineVirtual;


    void OnEnable()
    {
        busAnim = busAnimator.runtimeAnimatorController;
        busAnimator.runtimeAnimatorController = null;
        cinemachineVirtual.m_LookAt = startPointCamera.transform;
        cinemachineVirtual.Follow = startPointCamera.transform;

    }
    // Update is called once per frame
    void Update()
    {
        if (director.state != PlayState.Playing && !fix)
        {
            fix = true;
            busAnimator.runtimeAnimatorController = busAnim;
        }
        if (player.transform.position.x <= startPointCamera.transform.position.x)
        {
            cinemachineVirtual.m_LookAt = player.transform;
            cinemachineVirtual.Follow = player.transform;
        }
    }
}
