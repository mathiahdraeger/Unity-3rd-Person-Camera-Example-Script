using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public float rotationSpeed = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public GameObject followTransform;
    // Update is called once per frame
    void Update()
    {

        #region Follow Transform Rotation

        followTransform.transform.rotation *= Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed, Vector3.up);

        #endregion

        #region Vertical rotation

        followTransform.transform.rotation *= Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * rotationSpeed, Vector3.right);


        var angles = followTransform.transform.localEulerAngles;
        angles.z = 0;
        var angle = followTransform.transform.localEulerAngles.x;

        if (angle > 180 && angle < 340)
            angles.x = 340;
        else if (angle < 180 && angle > 40)
            angles.x = 40;

        followTransform.transform.localEulerAngles = angles;

        #endregion

        transform.rotation = Quaternion.Euler(0, followTransform.transform.rotation.eulerAngles.y, 0);

        followTransform.transform.localEulerAngles = new Vector3(angles.x, Input.GetAxis("Mouse Y"), 0);
 


    }
}
