using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraColor : MonoBehaviour
{
    private Camera cameraMain;
    float timer; 
    float currentTime;
    [SerializeField]
    Color newColor;

    // Start is called before the first frame update
    void Awake()
    {
        cameraMain = GetComponent<Camera>();
    }

    public void ChangeBackCamColor(float time, Color32 color)
    {
        cameraMain.backgroundColor = color;
        newColor = color;
        timer = time;
        currentTime = 0;
    }

    private void Update() 
    {
        if(timer > 0)
        {
            currentTime += Time.deltaTime;
            float timeToComplete = currentTime / timer; 

            cameraMain.backgroundColor = Color.Lerp(newColor, Color.black, timeToComplete);
        }
    }

}
