using UnityEditor.Rendering;
using UnityEngine;

public class Enemy2AI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject bounds;
    public GameObject player;
    float BoundsX;
    float BoundsY;

    public GameObject GasBomb;
    Vector2 target;
    public float speed;
    public float RotSpeed;
    public float FireRate;
    float t;

    float cooldown;
    public float abilityCooldown;
    bool OnCooldown;
    public float abilityDistance;


    void Start()
    {
        BoundsX = bounds.GetComponent<SpriteRenderer>().bounds.size.x/2;
        BoundsY = bounds.GetComponent<SpriteRenderer>().bounds.size.y / 2;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        patrol();

        t += Time.deltaTime;
        if (t > FireRate)
        {
            Deploy(0,0);
            t = 0;
        }

        if(Vector2.Distance(player.transform.position, transform.position) < abilityDistance && !OnCooldown)
        {
            OnCooldown = true;
            Deploy(1,0);
            Deploy(0, 1);
            Deploy(-1, 0);
            Deploy(0, -1);
        }
        else
        {
            cooldown += Time.deltaTime;
            if(cooldown > abilityCooldown)
            {
                OnCooldown = false;
                cooldown = 0;
            }
        }

    }

    void Deploy(float X, float y)
    {
        GameObject NewBomb = Instantiate(GasBomb);
        Vector2 spawnPos = transform.position;
        spawnPos.x += X;
        spawnPos.y += y;
        NewBomb.transform.position = spawnPos;


    }




    Vector2 RandTarget()
    {
        int VerticalRand = Random.Range(0, 2) * 2 - 1;
        int HorizontalRand = Random.Range(0, 2) * 2 - 1;
        return new Vector2(Random.Range(0, BoundsX * HorizontalRand), Random.Range(0, BoundsY * VerticalRand));


    }

   void patrol()
    {
        if (Vector2.Distance(transform.position,target) < 0.5f)
        {
            target = RandTarget();
        }
        else
        {
            forwardMovement(speed, target);

        }
    }


    void forwardMovement(float speed, Vector3 temp)
    {
        Vector3 Dir = temp - transform.position;
        Dir.z = 0;
        
        transform.position += Dir.normalized * speed * Time.deltaTime;
    }

}
