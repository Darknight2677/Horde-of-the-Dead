using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCController : MonoBehaviour
{
    [SerializeField] Dialogue dialogue;
    public void Interact()
    {
        DialogManager.Instance.ShowDialog(dialogue);
    }
}
