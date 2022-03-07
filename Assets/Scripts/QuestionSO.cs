using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    
    [TextArea(2,6)] // Set the area to put text in the inspector
    // Make the private variable appear in inspector
    [SerializeField] private string question = "Enter new question here";

    /// <summary>
    /// Get question from a list
    /// </summary>
    /// <returns>single question</returns>
    public string GetQuestion()
    {
        return question;
    }
}