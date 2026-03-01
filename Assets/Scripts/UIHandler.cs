using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class UIHandler : MonoBehaviour
{
    private SystemManager systemManager;
    public TMP_Dropdown rulesetDropdown;
    public TMP_InputField iterationsInput;
    public TMP_InputField branchAngleInput;
    public TMP_InputField branchRadiusInput;
    public TMP_InputField symbolLengthInput;
    public Button generateStochasticButton;
    public Button generateD0LButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get the system manager
        systemManager = this.GetComponent<SystemManager>();
        // Set up button listeners
        generateD0LButton.onClick.AddListener(generateD0L);
        generateStochasticButton.onClick.AddListener(generateStochastic);
    }

    // Update is called once per frame
    void Update()
    {
        // Enter generates new stochastic tree
        if (Input.GetKeyDown(KeyCode.Return))
        {
            generateStochastic();
        }
    }

    /// <summary>
    /// Generates the LSystem, apply rules as D0L. If multiple rules are present it will ignore
    /// ones that are a larger index in the rules list and take the probability of the first
    /// occurence of a character to be 1. 
    /// </summary>
    void generateD0L()
    {
        setRuleset();
        stepD0LString(int.Parse(iterationsInput.text));
        systemManager.startTurtle(
            float.Parse(branchAngleInput.text),
            float.Parse(branchRadiusInput.text)/100,
            float.Parse(symbolLengthInput.text)/10
        );
    }

    /// <summary>
    /// Steps the LSystem string deterministically by a certain amount of iterations.
    /// </summary>
    /// <param name="iterations">How many times to apply the LSystem rules to the axiom</param>
    void stepD0LString(int iterations)
    {
        for (int i = 0; i < iterations; i++)
        {
            systemManager.stepD0LSystem();
        }
    }

    /// <summary>
    /// Generates the LSystem stochastically. It applies the rules at a probability, 
    /// if the probabilities sum to 1, one of the rules will be applied guarenteed.
    /// See LSystem.stochasticStep() for full details of the rule probabilties.
    /// </summary>
    void generateStochastic()
    {
        setRuleset();
        stepStochasticLString(int.Parse(iterationsInput.text));
        systemManager.startTurtle(
            float.Parse(branchAngleInput.text),
            float.Parse(branchRadiusInput.text)/100,
            float.Parse(symbolLengthInput.text)/10
        );
    }

    /// <summary>
    /// Steps the LSystem string stochastically by a certain amount of iterations
    /// </summary>
    /// <param name="iterations">How many times to apply the LSystem rules to the axiom</param>
    void stepStochasticLString(int iterations)
    {
        for (int i = 0; i < iterations; i++)
        {
            systemManager.stepStochasticLSystem();
        }
    }

    /// <summary>
    /// Sets the ruleset based on the dropdown.
    /// </summary>
    void setRuleset()
    {
        systemManager.resetLSystem(); // Must reset old system before switching ruleset.

        if (rulesetDropdown.options[rulesetDropdown.value].text == "Ruleset 1")
        {
            systemManager.selectedRuleset = 0;
        }
        
        if (rulesetDropdown.options[rulesetDropdown.value].text == "Ruleset 2")
        {
            systemManager.selectedRuleset = 1;
        }
        // Debug.Log(rulesetDropdown.options[rulesetDropdown.value].text );
    }
}
