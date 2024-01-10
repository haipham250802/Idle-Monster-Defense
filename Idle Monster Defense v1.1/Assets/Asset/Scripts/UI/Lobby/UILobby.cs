using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UILobby : MonoBehaviour
{
    [SerializeField] Button fightButton;
    [SerializeField] Transform content;
    private void Start()
    {
        initButton();
    }
    private void initButton()
    { 
        fightButton.onClick.AddListener(onClickFightButton);
    }
    private void onClickFightButton()
    {
        SceneManager.LoadScene(1);
    }
    public void transitionFight()
    {

    }
    public void transitionUpgrade()
    {

    }
    public void transitionShop()
    {

    }
}
