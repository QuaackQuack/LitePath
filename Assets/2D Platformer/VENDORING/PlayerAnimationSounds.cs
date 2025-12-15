using UnityEngine;

public class PlayerAnimationSounds : MonoBehaviour
{
 
    AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlayerFootstepSound() 
    {
        audioSource.Play();
    }


}
