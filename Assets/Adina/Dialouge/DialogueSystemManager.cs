using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialougeSysytemMananger : MonoBehaviour
{
    public Text nameText;
    public Text dialougeText;

    //public Animator animator;

    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }
    public void StartDialouge(Dialouge dialouge)
    {
        //anaimator.SetBool("IsOpen", true);
        nameText.text = dialouge.name;
        sentences.Clear();

        foreach (string snetence in dialouge.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentencs();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialouge();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    IEnumerator TypeSentence(string sentence)
    {
        dialougeText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialougeText.text += letter;
            yield return null;
        }
    }

    voidEndDialouge()
    {
        //anaimator.SetBool("IsOpen", false);
    }

}
