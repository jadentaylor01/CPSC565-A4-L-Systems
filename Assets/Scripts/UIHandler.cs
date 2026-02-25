using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIHandler : MonoBehaviour
{
    private SystemManager systemManager;
    public Button stepButton;
    public TMP_Text currentStringText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        systemManager = this.GetComponent<SystemManager>();
        stepButton.onClick.AddListener(stepString);
    }

    // Update is called once per frame
    void Update()
    {
        currentStringText.text = systemManager.getCurrentString();
    }

    void stepString()
    {
        systemManager.stepLSystem();
    }
}
