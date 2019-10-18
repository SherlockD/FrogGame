using System;
using UnityEngine;

public class LoseScreenController : MonoBehaviour
{
    public event Action OnMainMenuClickCallback;
    public event Action OnRestartGameClickCallback;

    public void OnMainMenuButtonClick()
    {
        OnMainMenuClickCallback?.Invoke();
    }

    public void OnRestartButtonClick()
    {
        OnRestartGameClickCallback?.Invoke();
    }
}
