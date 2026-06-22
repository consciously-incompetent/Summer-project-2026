using UnityEngine;

public class BulletMove : MonoBehaviour
{

    public Vector3 dir;
    public float speed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dir.x = 0;
        dir.y = 0;
        transform.eulerAngles = dir;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }
}
