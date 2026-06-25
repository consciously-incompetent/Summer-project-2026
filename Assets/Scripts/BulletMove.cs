using UnityEngine;

public class BulletMove : MonoBehaviour
{


    public float speed;

    public float speedUpRate;
    public float MaxSpeed;
    public bool SpeedUp = false;    

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (SpeedUp && speed < MaxSpeed)      
        {
            speed += Time.deltaTime * speedUpRate;
        }
        transform.position += transform.up * speed * Time.deltaTime;
    }
}
