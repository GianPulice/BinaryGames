using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BinaryConversionInput : MonoBehaviour
{
    public Text decimalText;
    public Text scoreText;
    public Text livesText;
    public InputField binaryInputField;
    public Button submitButton;
    private int decimalNumber;
    private string correctBinary;
    private int score = 0;
    private int lives = 3;
    private int errorCount = 0;

    void Start()
    {
        UpdateUI();
        GenerateDecimalNumber();
        submitButton.onClick.AddListener(CheckAnswer);
    }

    void GenerateDecimalNumber()
    {
        decimalNumber = Random.Range(0, 16); 
        decimalText.text = decimalNumber.ToString();
        correctBinary = ConvertTo4BitBinary(decimalNumber); 
    }

    string ConvertTo4BitBinary(int number)
    {
        return System.Convert.ToString(number, 2).PadLeft(4, '0');
    }

    void CheckAnswer()
    {
        string playerInput = binaryInputField.text;

        if (playerInput == correctBinary)
        {
            score++;
            errorCount = 0; 
            Debug.Log("Correcto! Puntos: " + score);
        }
        else
        {
            errorCount++;
            Debug.Log("Incorrecto! Errores: " + errorCount);

            if (errorCount >= 1)
            {
                lives--;
                errorCount = 0;
                Debug.Log("Vida perdida! Vidas restantes: " + lives);
            }
        }

        binaryInputField.text = "";

        UpdateUI();

        if (lives > 0)
        {
            GenerateDecimalNumber();
        }
        else
        {
            Debug.Log("Juego Terminado. Puntos finales: " + score);
        }
    }

    void UpdateUI()
    {
        scoreText.text = "Puntos: " + score.ToString();
        livesText.text = "Vidas restantes: " + ConvertTo4BitBinary(lives); 
    }
}