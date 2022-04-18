using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSound : MonoBehaviour
{
    [SerializeField] private bool ToggleMusic, ToggleEffect;
    // Start is called before the first frame update
    public void Toggle()
    {
        if (ToggleEffect)
        {
            SoundManager.Instance.ToggleEffects();
        }

        if(ToggleMusic)
        {
            SoundManager.Instance.ToggleMusic();
        }    
    }
}
