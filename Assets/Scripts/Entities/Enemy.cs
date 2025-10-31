using UnityEngine;

public class Enemy : Entity, IFreezable
{
    [SerializeField] private Transform[] patrolPoints;
    [SerializeField] private float waitTime = 1f;
    private int currentPoint = 0;
    private bool waiting = false;
    private float freezeTimer = 0f;

    private void Update()
    {
        if (isFrozen)
        {
            freezeTimer -= Time.deltaTime;
            if (freezeTimer <= 0)
                isFrozen = false;
            return;
        }

        Patrol();
    }

    private void Patrol()
    {
        if (patrolPoints.Length == 0) return;

        Transform target = patrolPoints[currentPoint];
        Vector3 direction = (target.position - transform.position).normalized;
        Move(direction);

        if (Vector3.Distance(transform.position, target.position) < 0.2f && !waiting)
        {
            StartCoroutine(WaitBeforeNextPoint());
        }
    }

    private System.Collections.IEnumerator WaitBeforeNextPoint()
    {
        waiting = true;
        yield return new WaitForSeconds(waitTime);
        currentPoint = (currentPoint + 1) % patrolPoints.Length;
        waiting = false;
    }

    public void Freeze(float duration)
    {
        isFrozen = true;
        freezeTimer = duration;
    }
}
