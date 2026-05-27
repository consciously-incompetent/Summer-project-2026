
using UnityEngine;


public class Wind : MonoBehaviour
{

    public float speed;
    public float LifeTime;
    public float decayRate;
    public Vector2 dir;

    float t;

    public float maxSpeed;
    public float minspeed;

    public float maxDecayRate;
    public float minDecayRate;

    public int maxTimeLength;
    public int minTimeLength;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dir = transform.right;
        speed = Random.Range(minspeed, maxSpeed);
        decayRate = Random.Range(minDecayRate, maxDecayRate);
        LifeTime = Random.Range(minTimeLength, maxTimeLength);
    }

    private void Update()
    {
        t += Time.deltaTime;

        if (t > LifeTime)
        {
            
            Decay();
        }

        
     


    }


    void Decay()
    {
        speed -= decayRate * Time.deltaTime;
      
        if (speed < 0)
        {
            
            Destroy(gameObject);
        }
        
            
        


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("test");
    }

}
