using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public AudioClip typingSoundClip; // Typing sound effect clip
    private AudioSource audioSource; // Audio source component for playing sound

    private int index;
    private bool isTyping;
    private bool allowSkip = true; // Allows skipping of typing animation

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>(); // Ensure there's an AudioSource component to play sounds
        textComponent.text = string.Empty;
        StartDialogue();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && allowSkip)
        {
            if (isTyping)
            {
                CompleteLine();
            }
            else
            {
                NextLine();
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        textComponent.text = "";
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            PlayTypingSound(); // Play sound effect
            yield return new WaitForSeconds(textSpeed);
        }
        isTyping = false;
        // Here, add UI feedback to show it's time to proceed.
    }

    void CompleteLine()
    {
        StopAllCoroutines();
        textComponent.text = lines[index]; // Show complete text immediately
        isTyping = false;
        // Here, update UI to indicate text can be skipped or proceeded.
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            StartCoroutine(TypeLine());
        }
        else
        {
            // Optionally, trigger a callback here to notify other systems that dialogue has ended.
            gameObject.SetActive(false);
        }
    }

    public void NextButton()
    {
        if (isTyping)
        {
            CompleteLine();
        }
        else
        {
            NextLine();
        }
    }

    public void AgainLine()
    {
        gameObject.SetActive(true);
        StartDialogue();
    }

    public void AdjustTextSpeed(float newSpeed)
    {
        textSpeed = newSpeed;
    }

    private void PlayTypingSound()
    {
        if (typingSoundClip != null && audioSource != null)
        {
            audioSource.PlayOneShot(typingSoundClip); // Play the typing sound clip once
        }
    }
}
