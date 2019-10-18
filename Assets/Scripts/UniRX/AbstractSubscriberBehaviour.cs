using UnityEngine;

public abstract class AbstractSubscriberBehaviour : MonoBehaviour
{
    protected void Awake()
    {
        Subscribe();
    }

    public abstract void Subscribe();
}
