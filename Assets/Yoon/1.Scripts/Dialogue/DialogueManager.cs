using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI speakerText; // ��ȭ�� �̸��� ǥ���� UI ������Ʈ
    public TextMeshProUGUI dialogueText; // ��� ������ ǥ���� UI ������Ʈ
    public string resourcePath; // �ν����Ϳ��� ������ JSON ������ ���ҽ� ���

    private DialogueData dialogueData;
    private int currentLineIndex = 0;

    private void Start()
    {
        // ���â�� ���� �� ��Ȱ��ȭ
        gameObject.SetActive(false);
    }

    public void ActivateDialogue()
    {
        LoadDialogueDataFromResources(resourcePath);
        gameObject.SetActive(true);
        DisplayNextLine();
    }

    public void DeactivateDialogue()
    {
        gameObject.SetActive(false);
    }

    public void LoadDialogueDataFromResources(string resourcePath)
    {
        TextAsset dialogueTextAsset = Resources.Load<TextAsset>(resourcePath);
        if (dialogueTextAsset == null)
        {
            Debug.LogError("Dialogue file not found in Resources");
            return;
        }

        string dataAsJson = dialogueTextAsset.text;
        dialogueData = JsonUtility.FromJson<DialogueData>(dataAsJson);
        currentLineIndex = 0; // �����͸� �ε��� �� �ε����� �ʱ�ȭ
    }

    public void DisplayNextLine()
    {
        if (currentLineIndex < dialogueData.dialogues.Length)
        {
            speakerText.text = dialogueData.dialogues[currentLineIndex].speaker;
            dialogueText.text = dialogueData.dialogues[currentLineIndex].text;
            currentLineIndex++;
        }
        else
        {
            DeactivateDialogue(); // ��ȭ ���� �� ���â�� ��
        }
    }

    public void OnUserInput()
    {
        DisplayNextLine();
    }


    // ����: LoadDialogue �޼��� ����
    public void LoadDialogue(string path)
    {
        // ���� ���, Resources.Load�� ����Ͽ� ��ȭ JSON ���� �ε�
        TextAsset dialogueTextAsset = Resources.Load<TextAsset>(path);
        if (dialogueTextAsset != null)
        {
            string dataAsJson = dialogueTextAsset.text;
            dialogueData = JsonUtility.FromJson<DialogueData>(dataAsJson);
            currentLineIndex = 0;
            DisplayNextLine();
        }
        else
        {
            Debug.LogError("Cannot find dialogue file: " + path);
        }
    }
}
