using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider ChosenSlider;

    void Update()
    {
        SoundManager.Instance.ChangeMasterVolume(ChosenSlider.value);
        ChosenSlider.onValueChanged.AddListener(val => SoundManager.Instance.ChangeMasterVolume(val));
    }
}
