using UnityEngine;
using UnityEngine.UI;

public class NameManager : MonoBehaviour
{
    public Text inputName;

    private string nameInputed = "";

    public int maxCharacters = 3;

    public int minCharacters = 3;

    void Update()
    {
        if (nameInputed.ToCharArray().Length < maxCharacters)
            nameInputed += Input.inputString;

        nameInputed = nameInputed.ToUpperInvariant();

        if (Input.GetKeyDown(KeyCode.Backspace) || Input.GetKeyUp(KeyCode.Backspace))
        {
            nameInputed = BackSpace(nameInputed);
        }

        string finalString = "";

        for (int i = 0; i < maxCharacters; i++)
        {
            if (nameInputed.ToCharArray().Length - 1 >= i)
            {
                finalString += nameInputed.ToCharArray()[i];
            }
            else
            {
                finalString += "-";
            }
        }

        inputName.text = $"{finalString} : {FindObjectOfType<ScoreKeeper>().score}";

        if (Input.GetKeyDown(KeyCode.Return) && nameInputed.ToCharArray().Length >= minCharacters)
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
