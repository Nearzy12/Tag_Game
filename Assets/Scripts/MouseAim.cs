using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAim : MonoBehaviour
{
    float rotationValueX;
    float rotationValueY;
    public float mouseSens = 100;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;
        rotationValueX -= mouseY;
        rotationValueX = Mathf.Clamp(rotationValueX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotationValueX, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);
    }
}
