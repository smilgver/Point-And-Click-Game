using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScreenShift : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField] bool cameraTransitioned = true;
    public Vector3 cameraPos1 = new Vector3(-24, 40, -25);
    public Vector3 cameraPos2 = new Vector3(-24, 40, -71);
    
    void Start()
    {
        camera = Camera.main;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(cameraTransitioned)
            {
                cameraTransitioned = false;
                camera.transform.DOMove(cameraPos2, 1);
            }
            else if(!cameraTransitioned)
            {
                cameraTransitioned = true;
                camera.transform.DOMove(cameraPos1, 1);
            }
        }
    }
}
