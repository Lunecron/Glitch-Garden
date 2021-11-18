using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float rotationSpeed = 0f;
    [SerializeField] float damage = 50f;
    [SerializeField] bool destroyable = false;
    Animator animator;
    bool hasAnimator = false;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.GetComponent<Animator>())
        {
            animator = gameObject.GetComponent<Animator>();
            hasAnimator = true;
        }
        else
        {
            hasAnimator = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        if(rotationSpeed > 0)
        {
            Rotate();
        }

        if (hasAnimator)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Destroy"))
            {
                Destroy(gameObject);
            }
        }
    }

    public void Rotate()
    {
        transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
    }

    public float GetSpeed()
    {
        return speed;
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Health>();
        var attacker = otherCollider.GetComponent<Attacker>();

        if(attacker && health)
        {
            //reduce health
            health.DealDamage(damage);

            if (!destroyable)
            {
                if (hasAnimator)
                {
                    SetSpeed(0f);
                    animator.SetBool("HitSomething", true);
                }
                else
                {
                    Destroy(gameObject);
                }
                
            }
        }
        
        
    }

}
