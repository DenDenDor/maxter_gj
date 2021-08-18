using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
public class LoadingScene : MonoBehaviour
{
[SerializeField] private int _waitTime;
[SerializeField] private int _number_current_scene;
[SerializeField] private bool _isIntermediateScene;
    private int _sceneNumber;
	[SerializeField] private Slider slider;
	[SerializeField] private GameObject _panel;

	public void Initialize(int number) => _sceneNumber = number;
	
    public void LoadScene() => StartCoroutine(Load());
    
	public void Exit() => Application.Quit();


 private void Start() 
 {
     _panel?.SetActive(false);
 }
 private IEnumerator Load()
 {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_sceneNumber);

		_panel?.SetActive(true);


		while (!asyncLoad.isDone) 
		{
			slider.value = Mathf.Lerp(slider.value,(asyncLoad.progress / .9f), 0.1f);
			yield return null;
		}
	
 }
 

}
