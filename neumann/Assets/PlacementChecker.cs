using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlacementChecker : MonoBehaviour
{
    public GameObject[] components; 
    public Transform[] correctPositions; 
    public Text successText; 

    private bool[] correctPlacement;

    void Start()
    {
        correctPlacement = new bool[components.Length];
        successText.gameObject.SetActive(false); 
    }

    void Update()
    {
        CheckPlacement();
        if (AllComponentsPlacedCorrectly())
        {
            successText.gameObject.SetActive(true);
        }
    }

    void CheckPlacement()
    {
        for (int i = 0; i < components.Length; i++)
        {
            if (Vector3.Distance(components[i].transform.position, correctPositions[i].position) < 0.5f)
            {
                correctPlacement[i] = true;
            }
            else
            {
                correctPlacement[i] = false;
            }
        }
    }

    bool AllComponentsPlacedCorrectly()
    {
        foreach (bool placedCorrectly in correctPlacement)
        {
            if (!placedCorrectly)
            {
                return false;
            }
        }
        return true;
    }
}
