using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Rock - Paper - Scissors : starter script
// Follow the slides and complete every TODO.
// 1 = Rock, 2 = Paper, 3 = Scissors, 4 = Unknown ("?")
public class GameController : MonoBehaviour
{
    private const int WinsToWin = 4;
    bool isMatchOver = false;

    Image imgYou;       // your selected image (rock, paper, scissor)
    Image imgCom;       // computer selected image (rock, paper, scissor)

    TMP_Text txtYou;        // the score you win
    TMP_Text txtCom;        // the score computer win
    TMP_Text txtResult;     // the result
    [SerializeField] TMP_Text txtGameOver;

    int cntYou = 0;     // number you win
    int cntCom = 0;     // number computer win



    void Start()
    {
        // init the game
        InitGame();
    }

    private void InitGame()
    {
        // TODO (slides 37-40): find the UI objects by name and get their components.
        // Example:
        // imgYou = GameObject.Find("ImgYou").GetComponent<Image>();
        // Also find: ImgCom, TxtYou, TxtCom, TxtResult_

        // TODO: set the text of txtResult to "Select the button below"

       
        imgYou = GameObject.Find("ImageYou").GetComponent<Image>();
        imgCom = GameObject.Find("ImageCom").GetComponent<Image>();

        txtYou = GameObject.Find("TxtYou").GetComponent<TMP_Text>();
        txtCom = GameObject.Find("TxtCom").GetComponent<TMP_Text>();
        txtResult = GameObject.Find("Text_Result").GetComponent<TMP_Text>();
        txtGameOver = GameObject.Find("GameOverTitle").GetComponent<TMP_Text>();

        txtResult.text = "Select the button below";
    
}

    

    // Update is called once per frame
    void Update()
    {
        // exit if press escape key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    // Slides 24-31: link this function to the On Click () event of every button.
    // Pass the button itself as the GameObject parameter.
    public void OnButtonClick(GameObject buttonObject)
    {
        Debug.Log(buttonObject.name + " clicked ");

        
        int you = int.Parse(buttonObject.name.Substring(0, 1));
        CheckResult(you);
    }

    void CheckResult(int yourResult)
    {
        if (isMatchOver) return;

        int comResult = UnityEngine.Random.Range(1, 4);
        int k = yourResult - comResult;

        if (k == 0)
        {
            txtResult.text = "Draw.";
        }
        else if (k == 1 || k == -2)
        {
            txtResult.text = "You win.";
            cntYou++;
        }
        else
        {
            txtResult.text = "Computer win.";
            cntCom++;
        }

        SetResult(yourResult, comResult);
        Debug.Log("Your result is: " + yourResult);

        if (cntYou >= WinsToWin)
        {
            isMatchOver = true;
            txtGameOver.text = $"You win the Best of 7! ({cntYou} - {cntCom})";
            FindFirstObjectByType<GameScreenController>().ShowGameOver();
        }
        else if (cntCom >= WinsToWin)
        {
            isMatchOver = true;
            txtGameOver.text = $"Computer wins the Best of 7! ({cntYou} - {cntCom})";
            FindFirstObjectByType<GameScreenController>().ShowGameOver();
        }
        

        // TODO (slide 33): game logic
        // 1. com = random number 1..3  ->  UnityEngine.Random.Range(1, 4)
        // 2. k = you - com
        // 3. k == 0              -> "Draw."
        //    k == 1 or k == -2   -> "You win."       (cntYou++)
        //    otherwise           -> "Computer win."  (cntCom++)
        // 4. call SetResult(yourResult, comResult)

    }

    void SetResult(int you, int com)
    {
        imgYou.sprite = Resources.Load("img_" + you, typeof(Sprite)) as Sprite;
        imgCom.sprite = Resources.Load("img_" + com, typeof(Sprite)) as Sprite;

        imgCom.transform.localScale = new Vector3(-1, 1, 1);

        txtYou.text = cntYou.ToString();
        txtCom.text = cntCom.ToString();

        // TODO (slide 41):
        // 1. change imgYou.sprite and imgCom.sprite
        //    Resources.Load("img_" + you, typeof(Sprite)) as Sprite
        // 2. flip the computer image on the x axis: localScale = (-1, 1, 1)
        // 3. update txtYou.text and txtCom.text with the scores


    }

    public void ResetMatch()
    {
        cntYou = 0;
        cntCom = 0;
        isMatchOver = false;

        txtYou.text = "0";
        txtCom.text = "0";
        txtResult.text = "Best of 7 (First to 4) - Select a button";

        Sprite unknownSprite = Resources.Load("img_4", typeof(Sprite)) as Sprite;
        if (unknownSprite != null)
        {
            imgYou.sprite = unknownSprite;
            imgCom.sprite = unknownSprite;
            imgCom.transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
