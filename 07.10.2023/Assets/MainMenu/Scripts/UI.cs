using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [Header("Header")]
    [SerializeField]
    private CanvasGroup header;
    private bool fadedIn = false;

    [Header("Right Space")]
    [SerializeField]
    private TextMeshProUGUI version;

    [Header("Options Menu")]
    [SerializeField]
    public Image optionsMenu;

    // Start is called before the first frame update
    void Start()
    {
        version.text = "0.0.1";
        header.alpha = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!fadedIn)
            FadeIn();
    }

    public void FadeIn()
    {
        if (header.alpha < 1)
        {
            header.alpha += Time.deltaTime;
        }
        else
        {
            fadedIn = true;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OptionsOn()
    {
        optionsMenu.gameObject.SetActive(true);
    }

    public void OptionsOff()
    {
        optionsMenu.gameObject.SetActive(false);
    }
}
