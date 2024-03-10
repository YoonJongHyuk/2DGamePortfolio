using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingSceneController : MonoBehaviour
{
	static string nextScene;

	[SerializeField]
	Image progressBar;

	public static void LoadScene(string sceneName)
	{
		nextScene = sceneName; // 이 부분은 기존 코드와 동일하나, nextScene을 사용하는 방식으로 변경 필요
		SceneManager.LoadScene("TestLoading");
	}

	// Start is called before the first frame update
	void Start()
	{
		StartCoroutine(LoadSceneProcess());
	}

	IEnumerator LoadSceneProcess()
	{
		AsyncOperation op = SceneManager.LoadSceneAsync(SceneManagerEx.sceneToLoad.ToString());
		op.allowSceneActivation = false;


		float timer = 0.0f;
		while (!op.isDone)
		{
			yield return null;

			if (op.progress < 0.1f)
			{
				progressBar.fillAmount = op.progress;
			}
			else
			{
				timer += Time.unscaledDeltaTime;
				progressBar.fillAmount = Mathf.Lerp(0.1f, 1f, timer);
				if (progressBar.fillAmount >= 1f)
				{
					op.allowSceneActivation = true;
					yield break;
				}
			}
		}
	}
}
