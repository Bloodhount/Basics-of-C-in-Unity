using GB;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private GameObject MenuWindow;
    [SerializeField] private GameObject MenuButton;

    private PlayerMoveComtroller _playerComtroller;
    private PlayerPursuit[] _enemies;

    void Start()
    {
        //MenuScript menuScript = new MenuScript();
        //MenuWindow = GameObject.FindGameObjectWithTag("MenuWindow1");
        //MenuButton = GameObject.Find("MenuButton");
        _playerComtroller = FindObjectOfType<PlayerMoveComtroller>();
        _enemies = FindObjectsOfType<PlayerPursuit>();
    }
    public void OpenMenuWindow()
    {
        MenuWindow.SetActive(true);
        MenuButton.SetActive(false);
        _playerComtroller.enabled = false;
        Time.timeScale = 0;
        foreach (var enemy in _enemies)
        {
            enemy.enabled = false;
        }
    }
    public void CloseMenuWindow()
    {
        MenuWindow.SetActive(false);
        MenuButton.SetActive(true);
        _playerComtroller.enabled = true;
        Time.timeScale = 1;
        foreach (var enemy in _enemies)
        {
            enemy.enabled = true;
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        CloseMenuWindow();
    }
    public void SetVolume(float value)
    {
        AudioListener.volume = value;
    }
    private void OnDestroy()
    {
        _enemies = FindObjectsOfType<PlayerPursuit>();
    }
    private void DontDestroyOnLoad()
    {
        //MenuButton;
        //MenuWindow;
    }
}
