using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Platformer
{
    public class GameManager : MonoBehaviour
    {
        public int coinsCounter = 0;

        public GameObject playerGameObject;
        private PlayerController player;
        public GameObject deathPlayerPrefab;
        public Text coinText;
        public GameObject gameOverUI;
        public GameObject PauseUI;
        

        AudioManager audioManager;

        private void Awake()
        {
            audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        }

        void Start()
        {
            player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        void Update()
        {
            coinText.text = coinsCounter.ToString();
            if (player.deathState == true)
            {
                playerGameObject.SetActive(false);
                GameObject deathPlayer = (GameObject)Instantiate(deathPlayerPrefab, playerGameObject.transform.position, playerGameObject.transform.rotation);
                deathPlayer.transform.localScale = new Vector3(playerGameObject.transform.localScale.x, playerGameObject.transform.localScale.y, playerGameObject.transform.localScale.z);
                player.deathState = false;
                Invoke("ReloadLevel", 3);
            }

            if (PauseUI.activeInHierarchy || gameOverUI.activeInHierarchy)
            { 
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else 
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }

        }

        private void ReloadLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        // https://www.youtube.com/watch?v=pKFtyaAPzYo

        public void gameOver()
        {
            gameOverUI.SetActive(true);
        }

        public void restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("Restart");
        }

        public void mainMenu() 
        {
            SceneManager.LoadScene("mainMenu");
            Debug.Log("Main Menu");
        }

        public void quit() 
        {
            Application.Quit();
            Debug.Log("Quit");
        }

        public void play() 
        {
            SceneManager.LoadScene("LoadingScreen");
            Debug.Log("Play");
        }
    
        public void buttonPressSound() 
        {
            audioManager.PlaySFX(audioManager.buttonPress);
        }

    }
}
