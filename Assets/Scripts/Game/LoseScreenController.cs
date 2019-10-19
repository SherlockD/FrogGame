using UniRx;
using UnityEngine;

public class LoseScreenController : BaseGameScreenPanel
{
    public bool SetActive
    {
        set => gameObject.SetActive(value);
    }
}
