using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PetAI : MonoBehaviour
{

    public Transform target;
    public float speed = 200f;
    public float nextWaypointDistance = 3f;
    public float minDistance = 100f;
    public float tetherDistance = 10f;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    public Transform graphics;
    public Transform Owner;

    public Animator animator;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int attackDamage = 40;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    public LayerMask enemyLayers;
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, 0.5f);
    }
    void UpdatePath() {
        if(Mathf.Abs(Owner.position.x - rb.position.x) > tetherDistance)
        {
            seeker.StartPath(rb.position, Owner.position, OnPathComplete);
        }
        if (seeker.IsDone() && Mathf.Abs(target.position.x - rb.position.x) < minDistance )
        {

            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
        else
        {
            seeker.StartPath(rb.position, Owner.position, OnPathComplete);
        }
    }
    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null)
        {
            return;
        }
        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
        animator.SetFloat("Speed", Mathf.Abs(force.x));

        if (force.x >= 0.01f || Mathf.Abs(Owner.position.x - rb.position.x) < 1f)
        {
            graphics.localScale = new Vector3(1f, 1f, 1f);
            
        }
        else if (force.x <= -0.01f)
        {
            graphics.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    void Update()
    {
        if (Mathf.Abs(target.position.x - rb.position.x) < 5f)
        {
            if(Time.time >= nextAttackTime)
            {

                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }
    void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies) 
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}

