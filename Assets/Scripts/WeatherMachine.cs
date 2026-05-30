using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class WeatherMachine : MonoBehaviour
{
    public float timeBetweenSpawn;

    public GameObject Wind;
    public GameObject Bounds;
    public Camera cam;

    float minHeight;
    float maxHeight;

    float minWidth;
    float maxWidth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnObject(Wind, 5);
        Vector3 SpawnMaximum = Bounds.GetComponent<SpriteRenderer>().bounds.size;
        cam.WorldToScreenPoint(SpawnMaximum);

        minHeight = cam.scaledPixelHeight;
        maxHeight = cam.WorldToScreenPoint(SpawnMaximum).y;
        minWidth = cam.scaledPixelWidth;
        maxWidth = cam.WorldToScreenPoint(SpawnMaximum).x;
        // use this to spawn an  object within that space and turn it into a screen to world point and then reserese signs and spawn

    }

    // Update is called once per frame
    void Update()
    {
        //Camera cam = CameraBounds.GetComponent<Camera>();
        //Debug.DrawLine(transform.position, ;

    }



    void SpawnObject(GameObject creation, int amount)
    {

        for (int i = 0; i < amount; i++)
        {

            Vector2 pos = new Vector2(Random.Range(1, 5), Random.Range(1, 5));
            int VerticalRand = Random.Range(0,2)*2 -1;
            int HorizontalRand = Random.Range(0,2)*2 -1;
            pos.x *= VerticalRand; 
            pos.y *= HorizontalRand;

            Debug.Log("wind box "+ i + " created at " + pos);

           GameObject Temp = Instantiate(creation);

            Temp.transform.position = pos;

            Debug.Log(Camera.main.WorldToScreenPoint(Temp.transform.position));



        }





    }


}
