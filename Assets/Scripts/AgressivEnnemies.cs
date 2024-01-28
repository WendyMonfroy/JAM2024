using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgressivEnnemies : BasicEnnemie
{

    public float folowDist;
    public float speed;

    public float attackDist;
    public float attackRate;

    public bool isAttacking = false;

    [System.Serializable]
    public struct attack
    {
        public float damages;
        public int animationState;
    }

    [SerializeField]
    public attack[] attacks;

    float lastAttack = 0;

    // Update is called once per frame
    void Update()
    {
        isAttacking = (Vector3.Distance(player.position, transform.position) < attackDist);
        if(isAttacking)
        {
            if (Time.time - lastAttack > attackRate)
            {
                lastAttack = Time.time;
                //choose a random attack
                int attackId = Random.Range(0,attacks.Length);
                player.GetComponent<HeathManager>().TakeDamage(attacks[attackId].damages);
            }
        }

        if(Vector3.Distance(player.position, transform.position)<folowDist)
        {
            transform.LookAt(player.position);
            if (Vector3.Distance(player.position, transform.position) > attackDist / 3f)
                transform.Translate(transform.forward * speed * Time.deltaTime * -1);
        }
    }

}