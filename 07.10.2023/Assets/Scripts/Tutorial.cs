using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField]
    public Image mouseImage;
    public TextMeshProUGUI tutorialText;
    private PlayerController playerController;
    public bool endTutorial = false;

    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        //mouseImage.gameObject.SetActive(false);
        tutorialText.text = "Click screen to Start!";
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.isStarted && !endTutorial)
        {
            StartTutorial();
        }
        else if (endTutorial) 
        {
            mouseImage.gameObject.SetActive(false);
            tutorialText.gameObject.SetActive(false);
        }
    }

    public void StartTutorial()
    {
        mouseImage.gameObject.SetActive(true);
        tutorialText.text = "'Hold and Drag' the highlighted button for navigate!";
    }
}
