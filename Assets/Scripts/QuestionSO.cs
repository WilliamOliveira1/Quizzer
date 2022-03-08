using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    
    [TextArea(2,6)] // Set the area to put text in the inspector
    // Make the private variable appear in inspector
    [SerializeField] private string question = "Enter new question here";
    [SerializeField] private string[] answers = new string[4];
    [SerializeField] private int correctAnswerIndex;

    /// <summary>
    /// Get question from a list
    /// </summary>
    /// <returns>single question</returns>
    public string GetQuestion()
    {
        return question;
    }

    /// <summary>
    /// Get answer
    /// </summary>
    /// <param name="index">which answer is correct</param>
    /// <returns>String of answer</returns>
    public string GetAnswer(int index)
    {
        return answers[index];
    }

    /// <summary>
    /// Get position of answer in array
    /// </summary>
    /// <returns>int of position</returns>
    public int getCorrectAnswerIndex()
    {
        return correctAnswerIndex;
    }
}