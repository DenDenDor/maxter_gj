using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private bool _isOnGame;
    [SerializeField] private GameObject _settings;
    private bool _isGameRun = true;
    [SerializeField] private MusicPlayer _musicPlayer;

    private void Start() {
        _slider.value = MusicPlayer.MusicVolome;
        if(_isOnGame)
        {
            ChangeActive();
         _musicPlayer. enabled = true;
        }
    
 }
 private void ChangeActive() 
 {
    
     _isGameRun =! _isGameRun;
     int _active = 0;
     _active = _isGameRun ? 0 : 1;
       Time.timeScale = _active;
 }
  private void Update() 
  {
     if (_isOnGame && Input.GetKeyDown(KeyCode.Escape))
     {
         
         
         ChangeActive();
         _settings.SetActive(_isGameRun);
         _musicPlayer.enabled = _isGameRun;
     }
  }
  public  void SaveInformation(float _musicVolome)
  {
      PlayerPrefs.SetFloat("MusicVolume", _musicVolome);
  }
  public void Exit()
  {
    SceneManager.LoadScene(1);
  }
}
