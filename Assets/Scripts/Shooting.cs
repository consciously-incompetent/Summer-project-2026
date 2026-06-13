using UnityEngine;

public class Shooting : MonoBehaviour
{

    public GameObject bullet;
    float t;
    
    public float rateOfFire;
    public float bulletSpeed;
    public float bulletDamage;
    public float BulletLifeTime;

    //heat
    float heat;
    bool isOverheating;
    public float timeToMaxHeat;
    public int SelfHeatDamage;
    public float HeatDamage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButton(0))
        {
            t += Time.deltaTime;
            heat += Time.deltaTime;
            if(t > rateOfFire)
            {
                Fire();
                t = 0;
            }
        }

        if (heat > timeToMaxHeat && !isOverheating)
        {
            overheat();
            isOverheating = true;
        }

    }

    public void Fire()
    {
        GameObject NewBullet = Instantiate(bullet);
        NewBullet.transform.position = transform.position;
        BulletMove Script = NewBullet.GetComponent<BulletMove>();
        Script.dir = transform.eulerAngles;
        Script.speed = bulletSpeed;
        Script.lifetime = BulletLifeTime;
    }

    public void overheat()
    {

    }

}
