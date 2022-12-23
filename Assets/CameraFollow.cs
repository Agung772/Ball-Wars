using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerPos;
    public Vector3 offset;
    public Vector3 vector3SaatIni;
    public float cameraSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, playerPos.localPosition + offset, cameraSpeed * Time.deltaTime);

        vector3SaatIni = transform.localPosition;
    }
}
