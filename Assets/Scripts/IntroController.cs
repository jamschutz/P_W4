using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class IntroController : MonoBehaviour
{
    public TMP_Text text;

    int line;
    string[] instructions = new string[] {
        "In 3947, the world began to die.",
        "Petunia and Bartleby are in search of a way out.",
        "One of you will be Petunia. You will navigate, but you are too scared to watch.\n\nPress WASD to move, and IJKL to control the camera.\n\nWhile the game runs, you must close your eyes.",
        "The other of you will be Bartleby.\n\nYou will be on the lookout, and direct Petunia where to go.\n\nYou are not allowed to talk.",
        "If either of you become too anxious, Petunia will hold the spacebar to tell a story.\n\nBoth of you may open your eyes while spacebar is held down, but Petunia must close her eyes again before letting go.",
        "If Petunia ever sees anything besides the story, <b>you both lose, permanently, and can never replay this game.</b>",
        "When you are ready to begin, close your eyes Petunia, and press spacebar.",
    };


    void Start()
    {
        line = 0;
        text.text = instructions[line++];
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            if(line < instructions.Length)
                text.text = instructions[line++];
            else
                SceneManager.LoadScene(1);
        }
    }
}
