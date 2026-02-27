using UnityEngine;
using TMPro;
using System.Collections;

public class TypewriterEffectText : MonoBehaviour
{
    public TextMeshProUGUI uiText;

    [TextArea]
    public string fullText;

    public float typingSpeed = 0.05f;

    [Header("Choices UI")]
    public GameObject choicesPanel; // Parent object of your choice buttons

    private void OnEnable()
    {
        choicesPanel.SetActive(false); // Hide choices at start
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        uiText.text = "";

        foreach (char letter in fullText)
        {
            uiText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        // 🔥 Text finished → enable choices
        choicesPanel.SetActive(true);
    }
}
