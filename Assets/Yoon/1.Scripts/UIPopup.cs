using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPopup : MonoBehaviour
{
    [SerializeField] private GameObject[] popupCanvas; // �˾� â�� ĵ����

    // �˾��� ���� �� ȣ��˴ϴ�.
    public void Open_Close()
    {
        bool currentActiveState = popupCanvas[0].activeSelf; // ù ��° �θ� ĵ������ Ȱ�� ���¸� Ȯ���մϴ�.

        // ��� �θ� ĵ������ �ڽ� ĵ���� ������Ʈ���� Ȱ��ȭ �Ǵ� ��Ȱ��ȭ�մϴ�.
        ToggleCanvasAndChildren(!currentActiveState);
    }

    public void Open()
    {
        if (popupCanvas != null)
        {
            // �˾� ĵ������ Ȱ��ȭ�մϴ�.
            ToggleCanvasAndChildren(true);
        }
    }

    public void Close()
    {
        if (popupCanvas != null)
        {
            ToggleCanvasAndChildren(false);
        }
    }

    private void ToggleCanvasAndChildren(bool active)
    {
        foreach (GameObject canvas in popupCanvas)
        {
            canvas.SetActive(active);
        }
    }

    // ���� ���� ��ư Ŭ�� �� ȣ��� �Լ�
    public void QuitGame()
    {
        Debug.Log("���� ���� ��ư�� Ŭ���Ǿ����ϴ�."); // �� ���� �ʿ����� ������ ����뿡 ������ �˴ϴ�.
        Application.Quit(); // ���� ����
    }



    // �˾� ������ � ������ ������ �� ȣ��� �޼������ �߰��� �� �ֽ��ϴ�.
    public void OnButtonClicked()
    {
        // �˾� �� ��ư�� Ŭ���Ǿ��� �� ������ ������ ���⿡ �ۼ��մϴ�.
        Debug.Log("Click");
    }

    private void Update()
    {
        // ESC Ű �Է��� �����մϴ�.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            bool currentActiveState = popupCanvas[0].activeSelf; // ù ��° �θ� ĵ������ Ȱ�� ���¸� Ȯ���մϴ�.

            // ��� �θ� ĵ������ �ڽ� ĵ���� ������Ʈ���� Ȱ��ȭ �Ǵ� ��Ȱ��ȭ�մϴ�.
            ToggleCanvasAndChildren(!currentActiveState);
            popupCanvas[1].SetActive(false);
        }
    }


    

}
