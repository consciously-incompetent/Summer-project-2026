using UnityEngine;

public class Enemy1AI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject player;
    Vector2 target;

    public float startingSpeed;
    public float FinalSpeed;
    float currentSpeed;
    float t;


    public GameObject bounds;
    float BoundsX;
    float BoundsY;
    void Start()
    {
        currentSpeed = startingSpeed;
        BoundsX = bounds.transform.localScale.x / 2;
        BoundsY = bounds.transform.localScale.y / 2;
        //target = wander();
    }

    // Update is called once per frame
    void Update()
    {

        //{
        t += Time.deltaTime;

        if(t > 0.3)
        {
            int VerticalRand = Random.Range(0, 2) * 2 - 1;
            int HorizontalRand = Random.Range(0, 2) * 2 - 1;
             target = new Vector2(Random.Range(0, BoundsX * HorizontalRand), Random.Range(0, BoundsY * VerticalRand));
            t = 0;
        }
        wander(target);
        

        //}



    }


    void wander(Vector2 Temp)
    {
        forwardMovement(currentSpeed);
        RotateTowards(Temp, 120);
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
