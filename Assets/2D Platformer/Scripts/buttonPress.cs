using UnityEngine;

public class buttonPress : MonoBehaviour
{
    AudioManager audioManager;

    public void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


    public void buttonPressSound()
    {
        audioManager.PlaySFX(audioManager.buttonPress);
    }

}
