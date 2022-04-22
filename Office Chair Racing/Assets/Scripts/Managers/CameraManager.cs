using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera overviewCamera;
    [SerializeField] private CinemachineVirtualCamera followCamera;

    private bool overviewCamActive = true;

    [SerializeField] private bool distanceTest = false;
    private float camDistanceAtStart;

    private CinemachineFramingTransposer cinemachineValues;

    private CameraFocusPoint cameraFocusScript;

    [SerializeField] private float zoomSpeed = 0.01f;

    private void Start()
    {
        cameraFocusScript = FindObjectOfType<CameraFocusPoint>();

        cinemachineValues = followCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
        camDistanceAtStart = cinemachineValues.m_CameraDistance;
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

    private void Update()
    {
        print(cameraFocusScript.distanceBetweenPlayers * zoomSpeed);
        cinemachineValues.m_CameraDistance = camDistanceAtStart + (cameraFocusScript.distanceBetweenPlayers * zoomSpeed);
        //cinemachineValues.m_CameraDistance = cameraFocusScript.distanceBetweenPlayers * zoomSpeed;

        //if (distanceTest)
        //{
        //    cinemachineValues.m_CameraDistance = 20;
        //}
        //else
        //{
        //    cinemachineValues.m_CameraDistance = camDistanceAtStart;
        //}
    }
}
