using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;
    [SerializeField] GameObject applePrefab;
    [SerializeField] GameObject eatParticle;
    [SerializeField] int xMax;
    [SerializeField] int yMax;
    private CameraColor cameraColor;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        cameraColor = Camera.main.GetComponent<CameraColor>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnApple()
    {
        GameManager.Instance.ResetUIScore();
        int xRange = UnityEngine.Random.Range(-xMax, xMax + 1);
        int yRange = UnityEngine.Random.Range(-yMax, yMax + 1);
        applePrefab.SetActive(true);
        applePrefab.transform.position = new Vector2(xRange, yRange);
    }

    public void SpawnParticle(Vector2 spawnPosition)
    {
        eatParticle.SetActive(false);
        eatParticle.SetActive(true);
        eatParticle.transform.position = spawnPosition;
        CameraShake.Instance.ShakeCamera(6, 0.5f);
        cameraColor.ChangeBackCamColor(1);
    }
}
