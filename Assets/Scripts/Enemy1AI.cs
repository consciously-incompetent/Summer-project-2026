using UnityEngine;

public class Enemy1AI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject player;
    public GameObject Bullet;
    Vector2 target;

    public float startingSpeed;
    public float FinalSpeed;
    public float Sight;
    public float fireRate;
    float currentSpeed;
    float t;
    float shootTime;


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
    void FixedUpdate()
    {
        if(Vector2.Distance(player.transform.position, transform.position) < Sight)
        {
            Chase();
        }
        else
        {
            t += Time.deltaTime;
            currentSpeed = startingSpeed;
            if (t > 1)
            {
                int VerticalRand = Random.Range(0, 2) * 2 - 1;
                int HorizontalRand = Random.Range(0, 2) * 2 - 1;
                target = new Vector2(Random.Range(0, BoundsX * HorizontalRand), Random.Range(0, BoundsY * VerticalRand));
                t = 0;
            }
            wander(target);
        }

    }

    void Chase()
    {
        shootTime += Time.deltaTime;
        if (currentSpeed < FinalSpeed)
        {
            currentSpeed += Time.deltaTime;
        }
        forwardMovement(currentSpeed);
        RotateTowards(player.transform.position, 180);
        if(shootTime > fireRate)
        {
            Fire();
            shootTime = 0;

        }


    }

    void wander(Vector2 Temp)
    {
        forwardMovement(currentSpeed);
        RotateTowards(Temp, 90);
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




    void Fire()
    {
        GameObject NewBullet = Instantiate(Bullet);
        NewBullet.transform.position = transform.position;
        BulletMove Script = NewBullet.GetComponent<BulletMove>();
        Script.dir = transform.eulerAngles;
    }


    }
