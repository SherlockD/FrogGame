using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelButton : MonoBehaviour
{
    [SerializeField] private Text _buttonText;

    private Button _button;
    private int _index;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    public void Initialize(string buttonText, int index)
    {
        _buttonText.text = buttonText;
        _index = index;
    }

    public void OnLevelButtonClick()
    {
        GameManager.SetCurrentLevel(_index);

        MessageBroker.Default
            .Publish(new LoadSceneEvent("GameScene"));
    }
}
