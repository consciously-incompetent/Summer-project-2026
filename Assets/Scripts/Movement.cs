using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Movement : MonoBehaviour
{
    Vector3 Target;
    public GameObject MovBounds;
    public float movBoundsX;
    public float movBoundsY;

    //float t;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(MovBounds.transform.localScale.x);
        movBoundsX = MovBounds.transform.localScale.x / 2;
        movBoundsY = MovBounds.transform.localScale.y / 2;




    }

    // Update is called once per frame
    void Update()
    {

        //t += Time.deltaTime;
        //if(t> 1)
        //{
        //    mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    t = 0;
        //}

        if(transform.position.x >=  movBoundsX || transform.position.x <= -movBoundsX)
        {
            Target = MovBounds.transform.position;
        } else if (transform.position.y >= movBoundsY || transform.position.y <= -movBoundsY)
        {
            Target = MovBounds.transform.position;
        }
        else
        {
            Target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }


        forwardMovement(4);
        RotateTowardsMouse(Target,120f);
    }

    void forwardMovement(float speed)
    {
        transform.position += transform.up * speed * Time.deltaTime;   
    }


    void RotateTowardsMouse(Vector3 Target, float RotSpeed)
    {
        //Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Target.z = 0;
        Vector2 direction = Target - transform.position;
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
        //Debug.Log(Vector2.SignedAngle(direction, transform.up));
        Debug.DrawLine(transform.position, Target);
        Debug.DrawLine(transform.up + Vector3.up*10,transform.position);



    }
 
    }



