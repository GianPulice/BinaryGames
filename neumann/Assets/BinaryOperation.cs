using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BinaryOperation : MonoBehaviour
{
    public Text operationText;
    public Text scoreText;
    public Text livesText;
    public InputField resultInputField;
    public Button submitButton;
    private int binaryNum1;
    private int binaryNum2;
    private string correctResult;
    private string operation; // "suma" o "resta"
    private int score = 0;
    private int lives = 3;
    private int errorCount = 0;

    void Start()
    {
        UpdateUI();
        GenerateBinaryOperation();
        submitButton.onClick.AddListener(CheckAnswer);
    }

    void GenerateBinaryOperation()
    {
        binaryNum1 = Random.Range(0, 16); 
        binaryNum2 = Random.Range(0, 16); 

        // Convierte los números a binario
        string binaryStr1 = ConvertTo4BitBinary(binaryNum1);
        string binaryStr2 = ConvertTo4BitBinary(binaryNum2);

        operation = Random.Range(0, 2) == 0 ? "suma" : "resta";

        if (operation == "suma")
        {
            operationText.text = binaryStr1 + " + " + binaryStr2;
            correctResult = ConvertTo4BitBinary(binaryNum1 + binaryNum2);
        }
        else
        {
            operationText.text = binaryStr1 + " - " + binaryStr2;
            correctResult = ConvertTo4BitBinary(binaryNum1 - binaryNum2);
        }
    }

    string ConvertTo4BitBinary(int number)
    {
        int clampedNumber = Mathf.Clamp(number, 0, 15); 
        return System.Convert.ToString(clampedNumber, 2).PadLeft(4, '0');
    }

    void CheckAnswer()
    {
        string playerInput = resultInputField.text;

        if (playerInput == correctResult)
        {
            score++;
            errorCount = 0; 
            Debug.Log("Correct " + score);
        }
        else
        {
            errorCount++;
            Debug.Log("Incorrecto" + errorCount);

            if (errorCount >= 1)
            {
                lives--;
                errorCount = 0;
                Debug.Log("Vida " + lives);
            }
        }

        resultInputField.text = "";

        UpdateUI();

        if (lives > 0)
        {
            GenerateBinaryOperation();
        }
        else
        {
            Debug.Log(" Terminado" + score);
        }
    }

    void UpdateUI()
    {
        scoreText.text = "Puntos: " + score.ToString();
        livesText.text = "Vidas restantes: " + ConvertTo4BitBinary(lives); 
    }
}
