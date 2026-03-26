using UnityEngine;

public class PlaySoundOnMouseClick : MonoBehaviour
{
    public AudioClip clickSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse click
        {
            audioSource.PlayOneShot(clickSound);
        }
    }
}