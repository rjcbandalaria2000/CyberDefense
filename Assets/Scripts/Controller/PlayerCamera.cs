using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [Header("Mouse")]
    public float mouseSensitivity = 100.0f;
    public float xRotation = 0f;
    public Transform player;

    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        #region mouseControls
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -45f, 45f);

        this.gameObject.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);
        #endregion

        #region raycasting
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(this.transform.position, forward, Color.red);

        if (Physics.Raycast(this.transform.position, forward, out hit, 10))
        {
            Debug.DrawRay(this.transform.position, forward, Color.green);
           // Debug.Log(hit.collider.gameObject.name);

            if (hit.collider.gameObject.GetComponent<Interactable>() != null)
            {
                hit.collider.gameObject.GetComponent<Interactable>().InvokeInteract();
            }
            
            
        }
        #endregion
    }
}
