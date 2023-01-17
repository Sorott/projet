using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioScript : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private AudioMixer audioMixer;
    //[Range (-80f, 20f)]

    private void OnEnable()
    {
        slider.onValueChanged.AddListener(SliderOnValueChanged);        
    }

    private void OnDisable()
    {
        slider.onValueChanged.RemoveListener(SliderOnValueChanged);
    }
    // Update is called once per frame
    private void SliderOnValueChanged(float volume)
    {
        audioMixer.SetFloat("MasterVolume", volume);
    }
}
