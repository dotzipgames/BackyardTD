using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePositionManager : MonoBehaviour
{
    private Camera cam;
    public Vector2 mousePos = new Vector2();
    public Vector3 newPos;


    private void Start()
    {
        cam = Camera.main;
    }
    private void Update()
    {
        mousePos = Input.mousePosition;
        newPos = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));
    }
}