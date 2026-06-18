using Unity.VisualScripting;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class TakesDamagePlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
            BulletMove script = bulllet.GetComponent<BulletMove>();

            damageTaken += script.damage;

            if (script.strikethrough == false)
            {
                Destroy(collision.gameObject);
            }

        }

    }

}

