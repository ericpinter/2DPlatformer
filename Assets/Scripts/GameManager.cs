using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    public GameObject dialogBox;
    public GameObject dialogText;
    public GameObject scoreBox;
    public GameObject scoreText;
    public GameObject startButton;
    public GameObject creditsButton;
    public GameObject backgroundImage;
    public GameObject titleText;

    public String[] levels;
    private int currentLevel = 0;

    public GameObject menuText;
    public GameObject backButton;

    public GameObject controlsButton;


    public GameObject canvas;
    public GameObject events;


    private Coroutine dialogCo;

    private int flagsCollected;
    public int flagsTotal;

    private bool gamePaused;


    // Start is called before the first frame update
    void Start()
    {
        gamePaused = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Awake()
	{
        if(Instance == null)
		{
            Instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(canvas);
            DontDestroyOnLoad(events);
             
		}
		else
		{
            Destroy(gameObject);
		}
	}

    public void StartDialog(string text)
	{
        dialogBox.SetActive(true);
        dialogCo = StartCoroutine(TypeText(text));
	}

    public void HideDialog()
	{
        dialogBox.SetActive(false);
        if (dialogCo != null)
        {
            StopCoroutine(dialogCo);
        }
	}

    IEnumerator TypeText(string text)
	{
        dialogText.GetComponent<TextMeshProUGUI>().text = "";
        foreach(char c in text.ToCharArray())
		{
            dialogText.GetComponent<TextMeshProUGUI>().text += c;
            yield return new WaitForSeconds(0.01f);
		}
	}

    public void StartButton()
	{
        scoreText.GetComponent<TextMeshProUGUI>().text = flagsCollected + "/" + flagsTotal;
        startButton.SetActive(false);
        scoreText.SetActive(true);
        titleText.SetActive(false);
        creditsButton.SetActive(false);
        controlsButton.SetActive(false);
        //scoreBox.SetActive(true);
        NextLevel();
    }

    public void CreditsButton()
    {
        startButton.SetActive(false);
        creditsButton.SetActive(false);
        controlsButton.SetActive(false);

        //scoreBox.SetActive(true);
        StartCoroutine(LoadYourAsyncScene(false, "Credits"));
    }

    public void ControlsButton()
    {
        StartCoroutine(LoadYourAsyncScene(false, "Controls"));

        startButton.SetActive(false);
        creditsButton.SetActive(false);
        controlsButton.SetActive(false);

        //scoreBox.SetActive(true);
    }

    public void ShowMenuText(String credits)
    {
        menuText.GetComponent<TextMeshProUGUI>().text = credits;
        menuText.SetActive(true);
        titleText.SetActive(false);
        backButton.SetActive(true);
    }

    public void NextLevel()
    {
        flagsCollected = 0;
        currentLevel++;
        if (currentLevel >= levels.Length)
        {
            currentLevel = 0;
            GameOver();
            print("restarting");
        }
        else
        {
            StartCoroutine(LoadYourAsyncScene(true, levels[currentLevel]));
            print("loading "+levels[currentLevel]);
        }

    }


    public void GameOver()
	{
        startButton.SetActive(true);
        scoreText.SetActive(false);
        menuText.SetActive(false);
        titleText.SetActive(true);
        creditsButton.SetActive(true);
        controlsButton.SetActive(true);
        backButton.SetActive(false);
        //scoreBox.SetActive(false);
        StopAllCoroutines();
        HideDialog();
        StartCoroutine(ColorLerp(new Color(1, 1, 1, 1), 2));
    }

    IEnumerator ColorLerp(Color endValue, float duration)
	{
        float time = 0;
        Image sprite = backgroundImage.GetComponent<Image>();
        Color startValue = sprite.color;

        while(time < duration)
		{
            sprite.color = Color.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            yield return null;
		}
        sprite.color = endValue;
	}
    IEnumerator LoadYourAsyncScene(bool lerp, string scene)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        if (lerp) {StartCoroutine(ColorLerp(new Color(1, 1, 1, 0), 2));}

    }
    public bool IsGameStarted()
    {
        if (gamePaused)
        {
            return false;
        }
        else
        {
            return !startButton.activeSelf;
        }
    }
    public void UpdateScore()
    {
        flagsCollected++;
        Debug.Log("Plus one flag!");
        scoreText.GetComponent<TextMeshProUGUI>().text = flagsCollected + "/" + flagsTotal;
        if (flagsCollected == flagsTotal)
        {
            NextLevel();
        }

    }
    public void PauseGame()
    {
        gamePaused = !gamePaused;
    }
}
