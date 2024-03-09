using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;
using UnityEditor;
public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance {get; private set;}
    private CinemachineVirtualCamera cinemachineCamera;
    private CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin;

    [SerializeField]
    private AnimationCurve shakeSpeedCurve;
    float timer;
    float startingIntensity;
    float currentTime;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        cinemachineCamera = GetComponent<CinemachineVirtualCamera>();
        cinemachineBasicMultiChannelPerlin = cinemachineCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();   
    }

    public void ShakeCamera(float intensity, float time)
    {
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
        startingIntensity = intensity;
        currentTime = 0;
        timer = time;
    }


    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
        {
            currentTime += Time.deltaTime;
            float percentageComplete = currentTime / timer;
            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = Mathf.Lerp(startingIntensity, 0f, shakeSpeedCurve.Evaluate(percentageComplete));
        }
    }
}
