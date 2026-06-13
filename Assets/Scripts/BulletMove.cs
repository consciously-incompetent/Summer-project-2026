using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public Vector3 dir;
    public float speed;
    public float lifetime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dir.x = 0;
        dir.y = 0;
        transform.eulerAngles = dir;
        Destroy(gameObject,lifetime);
    }

    // Update is called once per frame
    void Update()
    {

        transform.position += transform.up * speed * Time.deltaTime;


    }
}
