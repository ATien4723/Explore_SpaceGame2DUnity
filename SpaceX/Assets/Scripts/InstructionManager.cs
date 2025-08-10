using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionManager : MonoBehaviour
{
    [SerializeField] GameObject instructionPanel;  // Panel chứa trang hướng dẫn

    public void CloseInstructions()
    {
        instructionPanel.SetActive (false);
    }
}
