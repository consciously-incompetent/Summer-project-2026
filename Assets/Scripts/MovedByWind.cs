using UnityEngine;

public class MovedByWind : MonoBehaviour
{
    public Vector2 pos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("fuck you");
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Wind WindScript = collision.gameObject.GetComponent<Wind>();
        Debug.Log("test");
        if (WindScript != null)
        {
            Debug.Log(WindScript.name);
            pos = transform.position;

            pos += WindScript.dir * WindScript.speed;

            transform.position = pos;
        }
    }

}
