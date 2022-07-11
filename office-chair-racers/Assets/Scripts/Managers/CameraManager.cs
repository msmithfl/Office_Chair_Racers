using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera overviewCamera;
    [SerializeField] private CinemachineVirtualCamera followCamera;

    private bool overviewCamActive = true;

    private float camDistanceAtStart;

    private CinemachineFramingTransposer followCameraValues;

    private CameraFocusPoint cameraFocusScript;

    [SerializeField] private float zoomSpeed = 0.01f;

    private void Start()
    {
        cameraFocusScript = FindObjectOfType<CameraFocusPoint>();

        followCameraValues = followCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
        camDistanceAtStart = followCameraValues.m_CameraDistance;
    }

    private void Update()
    {
        FollowCameraDistance();
    }

    private void FollowCameraDistance()
    {
        followCameraValues.m_CameraDistance = camDistanceAtStart + (cameraFocusScript.distanceBetweenPlayers * zoomSpeed);
    }

    public void SwitchCameraPriority()
    {
        if (overviewCamActive)
        {
            overviewCamera.Priority = 0;
            followCamera.Priority = 1;
        }
        else
        {
            overviewCamera.Priority = 1;
            followCamera.Priority = 0;
        }

        overviewCamActive = !overviewCamActive;
    }
}
