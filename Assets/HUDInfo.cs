using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDInfo : MonoBehaviour {

    public static int _Hunger;

    void Start()
    {
        SetHungerText();
    }

    // Use this for initialization    
    void Update()
    {
        SetHungerText();
    }

    private void SetHungerText()
    {
        GameObject hungerScoreObject = this.gameObject;
        Text textComponent = hungerScoreObject.GetComponent<Text>();
        textComponent.text = string.Format("Hunger: {0}", _Hunger);

        if (_Hunger <= 0)
        {
            textComponent.text = "Game Over! Press space to restart.";
            Player.gameOver = true;
        }
    }
}
