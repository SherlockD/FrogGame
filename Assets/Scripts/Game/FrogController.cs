using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class FrogController : MonoBehaviour
{
    [SerializeField] private Sprite _male_frog_sprite;
    [SerializeField] private Sprite _female_frog_sprite;

    public int FrogType { get; private set; }
    public RectTransform RectTransform { get; private set;}

    private Image _frogImage;

    private void Awake()
    {
        _frogImage = GetComponent<Image>();

        RectTransform = GetComponent<RectTransform>();
    }

    public void Initialize(int frogType)
    {
        FrogType = frogType;

        _frogImage.sprite = (frogType == 1) ? _male_frog_sprite : _female_frog_sprite;
    }
}
