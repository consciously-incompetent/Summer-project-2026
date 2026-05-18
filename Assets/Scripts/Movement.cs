using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Movement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       




    }

    // Update is called once per frame
    void Update()
    {
        forwardMovement(4);
        RotateTowardsMouse(120f);
    }

    void forwardMovement(float speed)
    {
        transform.position += transform.up * speed * Time.deltaTime;
        


    }


    void RotateTowardsMouse(float RotSpeed)
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        Vector3 direction = mousePos - transform.position;
        Vector3 Rot = transform.eulerAngles;
        
     
        if(Vector2.SignedAngle(direction, transform.up) >= 5)
        {
            Rot.z += -RotSpeed * Time.deltaTime;

        } else if(Vector2.SignedAngle(direction, transform.up) <= -5)
        {
            Rot.z += RotSpeed * Time.deltaTime;
        }
            transform.eulerAngles = Rot;



        //Debug.Log(direction);
        //Debug.Log(transform.up);
        Debug.Log(Vector2.SignedAngle(direction, transform.up));
        Debug.DrawLine(transform.position, mousePos);
        Debug.DrawLine(transform.up + Vector3.up*10,transform.position);



    }



}
