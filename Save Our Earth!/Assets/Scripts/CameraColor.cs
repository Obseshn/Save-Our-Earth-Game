using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraColor : MonoBehaviour
{
    private Camera camera;
    private void Start()
    {
        
    }

    private void OnEnable()
    {
        camera = GetComponent<Camera>();
        ChangeBGColor();
    }

    private void ChangeBGColor()
    {
        Color newColor = ColorPickerTriangle.TheColor;
        camera.backgroundColor = newColor;
    }
}
