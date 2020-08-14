using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SM4Camera : MonoBehaviour
{
    public Canvas canvas;
    public Camera camera;

    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>();
        camera = FindObjectOfType<Camera>();
        MatchCameraToCanvas();
    }

    public void MatchCameraToCanvas()
    {
        camera.orthographicSize = canvas.GetComponent<RectTransform>().sizeDelta.y / 2;
    }
}
