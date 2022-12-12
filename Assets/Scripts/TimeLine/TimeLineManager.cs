using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Cinemachine;
using UnityEngine.Events;
using System;
public class TimeLineManager : MonoBehaviourCore
{
    private bool fix = false;
    public Animator busAnimator;
    public RuntimeAnimatorController busAnim;
    public PlayableDirector director;
    public GameObject player;
    public GameObject startPointCamera;
    public CinemachineVirtualCamera cinemachineVirtual;
    //public GameObject joystick;



    void OnEnable()
    {
        busAnim = busAnimator.runtimeAnimatorController;
        busAnimator.runtimeAnimatorController = null;
        cinemachineVirtual.m_LookAt = startPointCamera.transform;
        cinemachineVirtual.Follow = startPointCamera.transform;
        StartCoroutine(PlayTimelineRoutine());
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

    private IEnumerator PlayTimelineRoutine()
    {
        yield return new WaitForSeconds((float)director.duration);
      //  joystick.SetActive(true);
    }
}
