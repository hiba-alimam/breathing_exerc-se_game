using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private bool bProgressBar, bHoldBar;
    public Image selectedImage;

    public float time;

    public int levelDuration;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bProgressBar)
        {
            time += Time.deltaTime/levelDuration;
            selectedImage.GetComponent<Image>().fillAmount = time;
 
        }
    }
}
