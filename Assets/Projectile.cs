using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    bool collided = false;
    [SerializeField]
    float timeToLive = 3f;
    private float lifeTime = 0f;
    [SerializeField]
    int damage = 4;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag != "Bullet" && collision.gameObject.tag != "Player" && !collided)
        {
            if(collision.gameObject.tag == "Enemy")
            {
                collision.gameObject.GetComponent<Health>().Damage(damage);
            }
            
            collided = true;
            Object.Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        lifeTime += Time.fixedDeltaTime;
        if (lifeTime > timeToLive)
        {
            Destroy(this.gameObject);
        }
    }

}
