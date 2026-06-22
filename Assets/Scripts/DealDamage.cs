using UnityEngine;

public class DealDamage : MonoBehaviour
{

    public int damage;
    public float lifetime;
    public bool strikethrough;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, lifetime);
    }


}
