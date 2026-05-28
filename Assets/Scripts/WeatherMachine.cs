using UnityEngine;
using UnityEngine.Rendering.Universal;

public class WeatherMachine : MonoBehaviour
{
    public float timeBetweenSpawn;

    public GameObject Wind;
    public GameObject MaxBounds;
    public GameObject CameraBounds;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnObject(Wind, 5);
        Camera cam = CameraBounds.GetComponent<Camera>();
        //cam.ScreenToWorldPoint
        
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



        }





    }


}
