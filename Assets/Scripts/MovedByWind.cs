using UnityEngine;

public class MovedByWind : MonoBehaviour
{
    public Vector2 pos;
    Wind WindScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        WindScript = collision.gameObject.GetComponent<Wind>();

        if (WindScript != null)
        {
            //Debug.Log(WindScript.name + " " + transform.position);
            
            pos = transform.position;

            pos += WindScript.dir * WindScript.speed * Time.deltaTime;
            

            transform.position = pos;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        WindScript = null;
    }



}
