using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Linq;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private QuestionSO question;
    [SerializeField] private GameObject[] answerButtons;
    private System.Random rnd = new System.Random();
    private int correctAnswerIndex;
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;
    private int test; 

    // Start is called before the first frame update
    void Start()
    {
        DisplayQuestion();
    }

    public void OnAnserSelected(int index)
    {
        Image buttonImage;

        if (index == test)
        {
            questionText.text = "Correct!";
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        else
        {
            correctAnswerIndex = question.getCorrectAnswerIndex();
            string correctAnswer = question.GetAnswer(correctAnswerIndex);
            questionText.text = $"Desculpe a resposta correta é:\n {correctAnswer}";
            buttonImage = answerButtons[test].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
    }

    private void DisplayQuestion()
    {
        questionText.text = question.GetQuestion();

        //Set randon position for our questions
        IEnumerable<int> randomRange = Enumerable.Range(0, 4)
                                     .Select(i => new Tuple<int, int>(rnd.Next(4), i))
                                     .OrderBy(i => i.Item1)
                                     .Select(i => i.Item2);
        var items = randomRange.ToList();
        // Get the new position of the correct answer
        var result = from s in items
                     where s == question.getCorrectAnswerIndex()
                     select s;
        int corretAnswerIndex = items.FindIndex(a => a == result.First());
        test = corretAnswerIndex;

        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            foreach (var item in items)
            {
                buttonText.text = question.GetAnswer(item);
                // Once the position is set we remove from list
                items.Remove(item);
                break;
            }
        }
    }
}
