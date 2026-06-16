using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
using UnityEngine.VFX;

public class WeatherMachine : MonoBehaviour
{
    public float timeBetweenSpawn;
    float t;

    public int spawnAmount;

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
        
        Vector3 SpawnMaximum = Bounds.GetComponent<SpriteRenderer>().bounds.size;
        cam.WorldToScreenPoint(SpawnMaximum);

        minHeight = cam.scaledPixelHeight;
        maxHeight = cam.WorldToScreenPoint(SpawnMaximum).y/2;
        minWidth = cam.scaledPixelWidth;
        maxWidth = cam.WorldToScreenPoint(SpawnMaximum).x/2;
        Debug.Log("minimum height is " + minHeight + " maximum heaight is " + maxHeight + " minimum width is " + minWidth + " maximum width is " + maxWidth);
        // use this to spawn an  object within that space and turn it into a screen to world point and then reserese signs and spawn
        SpawnObject(Wind, 5);
    }

    // Update is called once per frame
    void Update()
    {
        //Camera cam = CameraBounds.GetComponent<Camera>();
        //Debug.DrawLine(transform.position, ;
         t += Time.deltaTime;

        if (t > timeBetweenSpawn)
        {
            SpawnObject(Wind, spawnAmount);
            t = 0;
        }



    }



    void SpawnObject(GameObject creation, int amount)
    {

        for (int i = 0; i < amount; i++)
        {

            Vector2 pos = new Vector2(Random.Range(minWidth, maxWidth), Random.Range(minHeight, maxHeight));
            int VerticalRand = Random.Range(0,2)*2 -1;
            int HorizontalRand = Random.Range(0,2)*2 -1;
            pos = cam.ScreenToWorldPoint(pos);
            //Debug.Log(pos);
            pos.x *= VerticalRand; 
            pos.y *= HorizontalRand;

            Debug.Log("wind box "+ i + " created at " + pos);

           GameObject Temp = Instantiate(creation);

            Temp.transform.position = pos;

            //Debug.Log(Camera.main.WorldToScreenPoint(Temp.transform.position));



        }





    }


}
