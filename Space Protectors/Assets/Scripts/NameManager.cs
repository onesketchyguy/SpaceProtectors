using UnityEngine;
using UnityEngine.UI;

public class NameManager : MonoBehaviour
{
    public Text inputName;

    private string nameInputed = "";

    public int maxCharacters = 3;

    void Update()
    {
        if (nameInputed.ToCharArray().Length < maxCharacters)
            nameInputed += Input.inputString;

        nameInputed = nameInputed.ToUpperInvariant();

        if (Input.GetKeyDown(KeyCode.Backspace) || Input.GetKeyUp(KeyCode.Backspace))
        {
            nameInputed = BackSpace(nameInputed);
        }

        inputName.text = $"{nameInputed} : {FindObjectOfType<ScoreKeeper>().score}";

        if (Input.GetKeyDown(KeyCode.Return))
        {
            FindObjectOfType<GameOverManager>().NameInputed(nameInputed);
        }
    }

    private string BackSpace(string input)
    {
        string toReturn = "";

        for (int i = 0; i < input.ToCharArray().Length - 1; i++)
        {
            toReturn += input.ToCharArray()[i];
        }

        return toReturn;
    }
}
