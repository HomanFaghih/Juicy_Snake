using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraColor : MonoBehaviour
{
    private Camera camera;
    float timer;
    float currentTime;
    [SerializeField]
    Color newColor;
    // Start is called before the first frame update
    void Awake()
    {
        camera = GetComponent<Camera>();
    }

    public void ChangeBackCamColor(float time)
    {
        //camera.backgroundColor = color;
        timer = time;
        currentTime = 0;
    }

    private void Update() {
        if(timer > 0)
        {
            currentTime += Time.deltaTime;
            float timeToComplete = currentTime / timer;

            camera.backgroundColor = Color.Lerp(newColor, Color.black, timeToComplete);
        }
    }

}
