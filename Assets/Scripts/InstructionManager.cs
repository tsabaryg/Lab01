using UnityEngine;
using TMPro;
using UnityEngine.Video;
using UnityEngine.UI;

[System.Serializable]
public struct Instruction
{
    public string text;
    public Sprite image;
    public VideoClip video;
    public AudioClip audio;
}

public class InstructionManager : MonoBehaviour
{
    public Instruction[] instructions;
    public TextMeshProUGUI textUI; // גרור TextualInstruction
    public RawImage imageUI; // גרור VisualInstruction
    public VideoPlayer videoPlayer; // גרור VideoInstruction
    public AudioSource audioSource; // גרור VocalInstruction
    public Button nextButton;
    public Button prevButton;

    private int currentIndex = 0;

    void Start()
    {
        UpdateInstruction();
        UpdateButtons();
    }

    public void Next()
    {
        if (currentIndex < instructions.Length - 1)
        {
            currentIndex++;
            UpdateInstruction();
            UpdateButtons();
        }
    }

    public void Previous()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            UpdateInstruction();
            UpdateButtons();
        }
    }

    void UpdateInstruction()
    {
        Instruction instr = instructions[currentIndex];
        textUI.text = instr.text;
        imageUI.gameObject.SetActive(instr.image != null);
        imageUI.texture = instr.image ? instr.image.texture : null;
        videoPlayer.clip = instr.video;
        videoPlayer.gameObject.SetActive(instr.video != null);
        if (instr.video) videoPlayer.Play();
        audioSource.clip = instr.audio;
        audioSource.gameObject.SetActive(instr.audio != null);
        if (instr.audio) audioSource.Play();
    }

    void UpdateButtons()
    {
        prevButton.interactable = currentIndex > 0;
        nextButton.interactable = currentIndex < instructions.Length - 1;
    }
}