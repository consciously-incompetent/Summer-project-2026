using Unity.VisualScripting;
using UnityEngine;

public class Wind : MonoBehaviour
{

    public float speed;
    public Vector2 dir = Vector2.right;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("test");
    }

}
