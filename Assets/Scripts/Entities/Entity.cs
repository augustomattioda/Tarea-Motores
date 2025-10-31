using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField] protected float speed = 3f;
    protected bool isFrozen = false;

    public virtual void Move(Vector3 direction)
    {
        if (isFrozen) return;
        transform.position += direction * speed * Time.deltaTime;
    }
}
