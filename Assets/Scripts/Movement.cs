using Unity.Mathematics;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       




    }

    // Update is called once per frame
    void Update()
    {
        forwardMovement(1);
        //RotateTowardsMouse();
    }

    void forwardMovement(float speed)
    {
        Vector3 pos =  transform.localPosition;
        pos += Vector3.up * speed * Time.deltaTime;

        transform.position = pos;


    }


    void RotateTowardsMouse()
    {
        Quaternion rot = transform.rotation;
        rot.z += 15 *  Time.deltaTime;
        transform.rotation = rot;

    }



}
