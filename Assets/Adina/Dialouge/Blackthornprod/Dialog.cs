using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public GameObject continueButton;

    void Start()
    {
        StartCoroutine(Type());
    }
    
    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void Update()
    {
        if(textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
    }

    public void NextSenetence()
    {
        continueButton.SetActive(false);

        if (index < sentences.Length - 1)
        {
            index ++;
            textDisplay.text = " ";
            StartCoroutine(Type());
            //continueButton.SetActive(true);
        }
        else
        {
            textDisplay.text = " ";
            continueButton.SetActive(false);
        }
    }
}
