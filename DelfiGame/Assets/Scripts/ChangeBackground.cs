using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackground : MonoBehaviour
{
    public float changeSpeed = 1f;
    public float colorIntensity = 1f;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = GetComponent<Camera>();
        // Start with a random color
        mainCamera.backgroundColor = Random.ColorHSV(0, 1, 1, 1, 1, 1, 1, 1);
    }

    void Update()
    {
        float hue = Mathf.PingPong(Time.unscaledTime * changeSpeed, 1f);
        Color newColor = Color.HSVToRGB(hue, colorIntensity, 1f);
        mainCamera.backgroundColor = newColor;
    }

}
