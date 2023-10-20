
using UnityEngine;
using UnityEngine.UI;
public class hieuungAT : MonoBehaviour
{
    [SerializeField] private Slider soundSlider;
    [SerializeField] private AudioSource player;
    [SerializeField] private AudioSource ketthuclevel;

    private void Start()
    {
        soundSlider.onValueChanged.AddListener(OnSoundSliderValueChanged);
    }

    private void OnSoundSliderValueChanged(float value)
    {
        player.volume = value;
        ketthuclevel.volume = value;
    }
}