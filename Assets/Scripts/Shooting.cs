using UnityEngine;

public class Shooting : MonoBehaviour
{

    public GameObject bullet;
    float t;
    
    public float rateOfFire;
    public float bulletSpeed;
    public int bulletDamage;
    public float BulletLifeTime;

    //heat
    float heat;
    bool isOverheating;
    public float timeToMaxHeat;
    public int SelfHeatDamage;
    public int HeatDamage;

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
        NewBullet.transform.eulerAngles = transform.eulerAngles;
        BulletMove Script = NewBullet.GetComponent<BulletMove>();
        DealDamage ScriptD = NewBullet.GetComponent<DealDamage>();
        
        Script.speed = bulletSpeed;
        ScriptD.lifetime = BulletLifeTime;
        ScriptD.damage = bulletDamage;
    }

    public void overheat()
    {

    }

}
