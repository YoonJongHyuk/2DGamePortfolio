using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI speakerText; // 발화자 이름을 표시할 UI 컴포넌트
    public TextMeshProUGUI dialogueText; // 대사 내용을 표시할 UI 컴포넌트
    public string resourcePath; // 인스펙터에서 설정할 JSON 파일의 리소스 경로

    private DialogueData dialogueData;
    private int currentLineIndex = 0;

    private void Start()
    {
        // 대사창을 시작 시 비활성화
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
        currentLineIndex = 0; // 데이터를 로드할 때 인덱스를 초기화
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
            DeactivateDialogue(); // 대화 종료 시 대사창을 끔
        }
    }

    public void OnUserInput()
    {
        DisplayNextLine();
    }


    // 예제: LoadDialogue 메서드 구현
    public void LoadDialogue(string path)
    {
        // 예를 들어, Resources.Load를 사용하여 대화 JSON 파일 로드
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
