using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class QT_Events : MonoBehaviour
{

    public Text letter;

    public GameObject UIImage;
    public Image ShrinkingImage;

    private int RandomXPosition;
    private int RandomYPosition;

    public float SetTimer;
    private int LetterChoice;
    public float Timer;
    public float buttonTimer;
    private int RandomLetter;
    private int Check = 0;
    private bool bCanPress = true;
    private bool bUpdate = true;

    public AudioClip RightButtonAudio;
    public AudioClip WrongButtonAudio;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (bUpdate)
        {
            Timer -= Time.deltaTime;
            if (Check == 0)
            {
                LetterChoice = ChosenLetter();
                Timer = SetTimer;
                Check = 1;
            }

            if (bCanPress)
            {
                if (Timer <= SetTimer)
                {
                    ShrinkingImage.GetComponent<Image>().transform.localScale = new Vector3(1 + Timer, 1 + Timer, 0);

                    if (LetterChoice == 1)
                    {
                        if (Input.GetKey("a"))
                        {
                            StartCoroutine(holdButton());

                           
                        }

                        /*lse
                        {
                            WrongA();
                        }*/
                    }

                    if (LetterChoice == 2)
                    {
                        if (Input.anyKeyDown)
                        {
                            if (Input.GetButtonDown("DKey"))
                            {
                                ShowLetter();
                            }

                            else
                            {
                                WrongA();
                            }
                        }
                    }

                    if (LetterChoice == 3)
                    {
                        if (Input.anyKeyDown)
                        {
                            if (Input.GetButtonDown("SKey"))
                            {
                                ShowLetter();
                            }
                            else
                            {
                                WrongA();
                            }
                        }
                    }
                }
                if (Timer <= 0)
                {
                    Timer = SetTimer;
                    WrongA();
                }
            }
        }
    }

    public int ChosenLetter()
    {
        RandomLetter = Random.Range(1, 4);
        RandomYPosition = Random.Range(50, 930);
        RandomXPosition = Random.Range(50, 1770);

        UIImage.GetComponent<Image>().transform.position = new Vector3(RandomXPosition, RandomYPosition, 0);


        if (RandomLetter == 1)
        {
            letter.text = "A";
            return 1;
        }

        if (RandomLetter == 2)
        {
            letter.text = "D";
            return 2;
        }

        if (RandomLetter == 3)
        {
            letter.text = "S";
            return 3;
        }

        return 4;
    }

    public void ShowLetter()
    {
        bCanPress = false;

        AudioSource.PlayClipAtPoint(RightButtonAudio, Camera.main.transform.position);
        StartCoroutine(TimeOut(0));
    }

    public void WrongA()
    {
        bCanPress = false;

        AudioSource.PlayClipAtPoint(WrongButtonAudio, Camera.main.transform.position);
        StartCoroutine(TimeOut(1));
    }

    IEnumerator TimeOut(float animation)
    {
        if (animation == 0)
        {
            UIImage.GetComponent<Animator>().Play("correctAnswer");
        }

        if (animation == 1)
        {
            UIImage.GetComponent<Animator>().Play("wrongAnswer");
        }

        yield return new WaitForSeconds(3);

        UIImage.GetComponent<Animator>().Play("Default");
        ShrinkingImage.GetComponent<Image>().transform.localScale = new Vector3(3, 3, 0);
        Check = 0;
        bCanPress = true;
        Timer = SetTimer;
    }

    IEnumerator holdButton()
    {
        yield return new WaitForSeconds(buttonTimer);
        Debug.Log("Its holding");
    }
}
