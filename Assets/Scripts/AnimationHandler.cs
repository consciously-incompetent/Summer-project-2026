using UnityEditor.Animations;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{

    Animator m_Animator;
    Movement script;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
        script = gameObject.GetComponentInParent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        

       
        
        //if (t > 0.25)
        //{
        //    Target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    t = 0;
        //}
        
        RotateTowardsMouse(script.Target);
    }



    void RotateTowardsMouse(Vector3 Target)
    {
        //Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Target.z = 0;
        Vector2 direction = Target - transform.position;
        float angle = Vector2.SignedAngle(direction, transform.up);


        if (angle > 20)
        {
            m_Animator.SetBool("Left0", true);

        }
        else if (angle < -20)
        {
            m_Animator.SetBool("Right0",true);
        } else if (angle <= 20 || angle >= -20)
        {
            m_Animator.SetBool("Right0", false);
            m_Animator.SetBool("Left0", false);
        }

        
    }



    }
