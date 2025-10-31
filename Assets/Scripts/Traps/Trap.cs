using UnityEngine;

public abstract class Trap : MonoBehaviour
{
    [SerializeField] protected float triggerRadius = 1.5f;

    protected virtual void OnTriggerEnter(Collider other)
    {
        Activate(other);
    }

    protected abstract void Activate(Collider other);
}
