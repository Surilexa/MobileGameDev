using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance {  get; private set; }
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    private float shakeTimer;

    private void Awake()
    {
        Instance = this;
    }

    public void shake(float intensity, float duration)
    {
        CinemachineBasicMultiChannelPerlin perl = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        perl.m_AmplitudeGain = intensity;
  
        Debug.Log(perl.m_AmplitudeGain);
        shakeTimer = duration;
    }
    private void Update()
    {
       
        if (shakeTimer > 0f)
        {
            shakeTimer -= Time.deltaTime;
            if (shakeTimer <= 0f)
            {
                CinemachineBasicMultiChannelPerlin perl = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                perl.m_AmplitudeGain = 0f;
            }
        }

    }

}
