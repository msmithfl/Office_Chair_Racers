using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera m_OverviewCamera;
    [SerializeField] private CinemachineVirtualCamera m_FollowCamera;

    private bool m_OverviewCamActive = true;

    private float m_CamDistanceAtStart;

    private CinemachineFramingTransposer m_FollowCameraValues;

    private CameraFocusPoint m_CameraFocusScript;

    [SerializeField] private float m_ZoomSpeed = 0.01f;

    private void Start()
    {
        m_CameraFocusScript = FindObjectOfType<CameraFocusPoint>();

        m_FollowCameraValues = m_FollowCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
        m_CamDistanceAtStart = m_FollowCameraValues.m_CameraDistance;
    }

    private void Update()
    {
        FollowCameraDistance();
    }

    private void FollowCameraDistance()
    {
        m_FollowCameraValues.m_CameraDistance = m_CamDistanceAtStart + (m_CameraFocusScript.distanceBetweenPlayers * m_ZoomSpeed);
    }

    public void SwitchCameraPriority()
    {
        if (m_OverviewCamActive)
        {
            m_OverviewCamera.Priority = 0;
            m_FollowCamera.Priority = 1;
        }
        else
        {
            m_OverviewCamera.Priority = 1;
            m_FollowCamera.Priority = 0;
        }

        m_OverviewCamActive = !m_OverviewCamActive;
    }
}
