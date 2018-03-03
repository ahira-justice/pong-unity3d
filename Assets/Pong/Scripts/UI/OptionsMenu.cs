using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {
    private Image top;
    private Image bottom;
    private Image easy;
    private Image medium;
    private Image hard;
    private GameObject optionsMenu;

    private Color setColor = new Color(0.3085f, 0.6367f, 1f, 1f);
    private Color defaultColor = new Color(1f, 1f, 1f, 1f);

    private void Awake(){
        optionsMenu = GameObject.FindWithTag("OptionsMenu");
        top = optionsMenu.transform.Find("Panel").transform.Find("Top").GetComponent<Image>();
        bottom = optionsMenu.transform.Find("Panel").transform.Find("Bottom").GetComponent<Image>();
        easy = optionsMenu.transform.Find("Panel").transform.Find("Easy").GetComponent<Image>();
        medium = optionsMenu.transform.Find("Panel").transform.Find("Medium").GetComponent<Image>();
        hard = optionsMenu.transform.Find("Panel").transform.Find("Hard").GetComponent<Image>();
    }

    public void SetPaddle(int value){
        if (value == 1)
            GameControl.playerID = 1;
        else if (value == 2)
            GameControl.playerID = 2;
    }

    public void SetDifficulty(int value){
        if (value == 1)
            GameControl.difficulty = Difficulty.EASY;
        else if (value == 2)
            GameControl.difficulty = Difficulty.MEDIUM;
        else if (value == 3)
            GameControl.difficulty = Difficulty.HARD;
    }

    public void Back(){
        optionsMenu.transform.Find("Panel").gameObject.SetActive(false);
    }

    public void SetOptionsColor(){
        if (GameControl.playerID == 1){
            top.color = setColor;
            bottom.color = defaultColor;
        }
        else if (GameControl.playerID == 2){
            top.color = defaultColor;
            bottom.color = setColor;
        }

        if (GameControl.difficulty == Difficulty.EASY){
            easy.color = setColor;
            medium.color = defaultColor;
            hard.color = defaultColor;
        }
        else if (GameControl.difficulty == Difficulty.MEDIUM){
            easy.color = defaultColor;
            medium.color = setColor;
            hard.color = defaultColor;
        }
        else if (GameControl.difficulty == Difficulty.HARD){
            easy.color = defaultColor;
            medium.color = defaultColor;
            hard.color = setColor;
        }
    }
}
