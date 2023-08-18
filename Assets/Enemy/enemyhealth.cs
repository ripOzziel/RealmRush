using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class enemyhealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    [Tooltip("Adds amount to maxHitPoints when enemy dies")]
    [SerializeField] int dificultyRamp = 0;

    int currentHitPoints = 0;

    Enemy  enemy;
    // Start is called before the first frame update
    void OnEnable()
    {
        currentHitPoints = maxHitPoints	;
    }
    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

   void OnParticleCollision(GameObject other) 
   {
        ProccesHit();

   }
   void ProccesHit()
   {
        currentHitPoints--;
        if(currentHitPoints <= 0)
        {
            gameObject.SetActive(false);
            maxHitPoints += dificultyRamp;
            enemy.RewardGold();
        }
   }
}
