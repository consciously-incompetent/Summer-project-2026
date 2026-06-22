using Unity.VisualScripting;
using UnityEngine;

public class TakesDamageEnemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int health;
    public int damageTaken;


    void Update()
    {
        if (damageTaken > health)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject bulllet = collision.gameObject;
        
        

        if (bulllet.CompareTag("Bullet"))
        {
            DealDamage script = bulllet.GetComponent<DealDamage>();

            damageTaken += script.damage;

            if (script.strikethrough == false)
            {
                Destroy(collision.gameObject);
            }

        }

    }

}

