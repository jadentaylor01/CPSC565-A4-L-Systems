using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Security.Cryptography;

public class UIHandler : MonoBehaviour
{
    private SystemManager systemManager;
    public Button generateButton;
    public Button nextButton;
    public TMP_Text currentStringText;
    public TMP_InputField iterationsInput;
    public TMP_InputField branchAngleInput;
    public TMP_InputField branchRadiusInput;
    public TMP_InputField symbolLengthInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        systemManager = this.GetComponent<SystemManager>();
        generateButton.onClick.AddListener(generate);
        nextButton.onClick.AddListener(stepTurtle);
    }

    // Update is called once per frame
    void Update()
    {
        // currentStringText.text = systemManager.getCurrentString();

        // Enter generates new tree
        if (Input.GetKeyDown(KeyCode.Return))
        {
            generate();
        }
    }

    void generate()
    {
        systemManager.resetLSystem();
        stepString(int.Parse(iterationsInput.text));
        systemManager.startTurtle(
            float.Parse(branchAngleInput.text),
            float.Parse(branchRadiusInput.text)/100,
            float.Parse(symbolLengthInput.text)/10
        );
    }

    void stepString(int iterations)
    {
        for (int i = 0; i < iterations; i++)
        {
            systemManager.stepLSystem();
        }
    }


    void stepTurtle()
    {
        systemManager.stepTurtle();
    }
}
