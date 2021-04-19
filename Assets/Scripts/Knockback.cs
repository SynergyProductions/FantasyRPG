using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float thrust;
    public float knockTime;
    public float damage;
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("breakable") && this.gameObject.CompareTag("Player"))
        {
            collider.GetComponent<Pot>().Smash();
        }
        if(collider.gameObject.CompareTag("enemy") || collider.gameObject.CompareTag("Player"))
        {
            Rigidbody2D hit = collider.GetComponent<Rigidbody2D>();
            if(hit != null)
            {
                Vector2 difference =hit.transform.position - transform.position;
                difference = difference.normalized * thrust;
                hit.AddForce(difference, ForceMode2D.Impulse);
                if(collider.gameObject.CompareTag("enemy") && collider.isTrigger)
                {
                    hit.GetComponent<EnemyAI>().currentState = EnemyState.stagger;
                    collider.GetComponent<EnemyAI>().Knock(hit, knockTime, damage);
                
                }
                if(collider.gameObject.CompareTag("Player"))
                {
                    if(collider.GetComponent<PlayerController>().currentState != PlayerState.stagger)
                    {
                        hit.GetComponent<PlayerController>().currentState = PlayerState.stagger;
                        collider.GetComponent<PlayerController>().Knock(knockTime, damage);
                    }
                }

            }
        }
    }

}
