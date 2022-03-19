using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    Text _livesText, _coinsText;

    Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        if (_anim == null)
        { Debug.LogError("Animator script is NULL in UIManager"); }

        _livesText.text = "Lives: 5";
        _coinsText.text = "Coins: 0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ManageLives(int lives)
    {
        _livesText.text = "Lives: " + lives.ToString();
    }

    public void ManageCoins(int coins)
    {
        _coinsText.text = "Coins: " + coins.ToString();
    }

    public void GameOver()
    {
        _anim.SetBool("IsGameOver", true);
    }
}
