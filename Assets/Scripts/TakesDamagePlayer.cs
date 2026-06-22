using Unity.VisualScripting;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class TakesDamagePlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    //remeber to make all dmaaging effects have the bulletMove script at some point even if the damage acts differetnly 
    //spilt the bulletMove script into deals damage and a movement scritp 

    public int health;
    public int damageTaken;
    

    void Update()
    {
        if (damageTaken > health)
        {
            //game over
            Debug.Log("game over");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject bulllet = collision.gameObject;

        if (bulllet.CompareTag("EnemyBullet"))
        {
            DealDamage script = bulllet.GetComponent<DealDamage>();

            damageTaken += script.damage;
                Destroy(collision.gameObject); 

        }

    }

}

