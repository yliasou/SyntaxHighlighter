using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[Serializable]
public class KeywordColorMapping
{
    public string keyword;
    public Color color;
}

/// <summary>
/// SyntaxHighlighter is a script for highlighting syntax in a TMP_InputField and displaying the highlighted result in a TMP_Text.
/// </summary>
// Code written by: TheFlow
// Date: [26 Nov 2023]
public class SyntaxHighlighter : MonoBehaviour
{
    public TMP_InputField codeInputField;
    public TMP_Text referenceText;
    public List<KeywordColorMapping> colorMappings = new List<KeywordColorMapping>()
    {
        new KeywordColorMapping { keyword = "class", color = new Color(0.305f, 0.788f, 0.690f) },     // Teal
        new KeywordColorMapping { keyword = "def", color = new Color(0.305f, 0.788f, 0.690f) },        // Teal
        new KeywordColorMapping { keyword = "if", color = new Color(0.000f, 0.478f, 0.800f) },         // Azure Blue
        new KeywordColorMapping { keyword = "else", color = new Color(0.000f, 0.478f, 0.800f) },       // Azure Blue
        new KeywordColorMapping { keyword = "for", color = new Color(0.000f, 0.478f, 0.800f) },        // Azure Blue
        // Add more mappings...
    };

    void Start()
    {
        // Create a TMP_Text component to handle enriched text
        GameObject textObject = new GameObject("CodeText");

        // Attach the function to highlight syntax when the input value changes
        codeInputField.onValueChanged.AddListener(HighlightSyntax);

        // Initialize TMP_Text with the initial text of the input field
        HighlightSyntax(codeInputField.text);
    }

    /// <summary>
    /// Highlights syntax in the input text and displays it in the reference text.
    /// </summary>
    /// <param name="input">The input text to be highlighted.</param>
    void HighlightSyntax(string input)
    {
        // Clear previous formatting
        referenceText.text = "";

        // Apply syntax highlighting
        referenceText.text = ApplySyntaxHighlighting(input);
    }

    /// <summary>
    /// Applies syntax highlighting to the input text based on predefined color mappings.
    /// </summary>
    /// <param name="input">The input text to be highlighted.</param>
    /// <returns>The formatted text with applied syntax highlighting.</returns>
    string ApplySyntaxHighlighting(string input)
    {
        // Start with ordinary text color
        string formattedText = $"<color=#{ColorUtility.ToHtmlStringRGB(Color.white)}>{input}</color>";

        // Apply color to keywords
        foreach (var mapping in colorMappings)
        {
            formattedText = formattedText.Replace(mapping.keyword, $"<color=#{ColorUtility.ToHtmlStringRGB(mapping.color)}>{mapping.keyword}</color>");
        }

        return formattedText;
    }
}
