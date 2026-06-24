using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class Enemy3AI : MonoBehaviour
{
    public GameObject player;
    public GameObject missile;

    Vector2 target;


    public float FearDistance;
    public float ChaseDistance;
    public int speed;
    public float rateOfFire;
    public float rotSpeed;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        target = player.transform.position;


        target = player.transform.position;
        if (Vector2.Distance(transform.position, player.transform.position) > ChaseDistance)
        {

            MoveTowards(target);

        }
        else if (Vector2.Distance(transform.position, player.transform.position) < FearDistance)
        {

            moveBackwards(target);
            Debug.Log(target);


        }
        else
        {
            Hunt(target);
        }



        Debug.DrawLine(transform.position, target);
            //MoveTowards(target);




    }


void Fire()
{



}


    void Hunt(Vector3 tempTarget)
    {
        Vector3 dir = tempTarget - transform.position;
        dir.z = 0;
        forwardMovement(speed);
        

    }



  void MoveTowards(Vector2 TempTarget)
    {
        forwardMovement(speed);
        RotateTowards(TempTarget, rotSpeed);
    }

    void moveBackwards(Vector2 TempTarget)
    {
        forwardMovement(-speed);
        RotateTowards(TempTarget, rotSpeed);
    }



    void forwardMovement(float speed)
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }


    void RotateTowards(Vector3 Target, float RotSpeed)
    {
        //Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Target.z = 0;
        Vector2 direction = Target - transform.position;
        Vector3 Rot = transform.eulerAngles;


        if (Vector2.SignedAngle(direction, transform.up) >= 5)
        {
            Rot.z += -RotSpeed * Time.deltaTime;

        }
        else if (Vector2.SignedAngle(direction, transform.up) <= -5)
        {
            Rot.z += RotSpeed * Time.deltaTime;
        }
        transform.eulerAngles = Rot;
    }
}
