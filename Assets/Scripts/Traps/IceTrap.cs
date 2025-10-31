using UnityEngine;

public class IceTrap : Trap
{
    [SerializeField] private float freezeDuration = 2f;

    protected override void Activate(Collider other)
    {
        IFreezable freezable = other.GetComponent<IFreezable>();
        if (freezable != null)
        {
            freezable.Freeze(freezeDuration);
            Debug.Log($"{other.name} fue congelado por {freezeDuration} segundos!");
        }
    }
}
