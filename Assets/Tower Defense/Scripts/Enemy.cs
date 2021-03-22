using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioClip))]
[RequireComponent(typeof(AudioSource))]
public class Enemy : MonoBehaviour
{
     public Path route;
     private Waypoint[] myPathThroughLife;
     public int coinWorth;
     public int health;
     public float speed = .25f;
     public Score score;
     public AudioClip enemyHitSound;
     public AudioSource speaker;
     private int index = 0;
     private Vector3 nextWaypoint;
     private bool stop = false;

     void Awake()
     {
          myPathThroughLife = route.path;
          transform.position = myPathThroughLife[index].transform.position;
          Recalculate();
     }

     void Update()
     {
          if (health <= 0)
          {
               Death();
          }

          if (!stop)
          {
               if ((transform.position - myPathThroughLife[index + 1].transform.position).magnitude < .1f)
               {
                    index = index + 1;
                    Recalculate();
               }


               Vector3 moveThisFrame = nextWaypoint * Time.deltaTime * speed;
               transform.Translate(moveThisFrame);
          }

     }

     void Recalculate()
     {
          if (index < myPathThroughLife.Length - 1)
          {
               nextWaypoint = (myPathThroughLife[index + 1].transform.position - myPathThroughLife[index].transform.position).normalized;

          }
          else
          {
               stop = true;
          }
     }

     public void UpdateHealth()
     {
          health--;
          speaker.PlayOneShot(enemyHitSound);
     }

     void Death()
     {
          score.UpdateScore(coinWorth);
          Destroy(gameObject);
     }

     public void SetHealth(int hp)
     {
          health = hp;
     }

}
