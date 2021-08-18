using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
  [SerializeField] private AudioSource _audioSourse;
  private static float _musicVolome = 1f;

    public static float MusicVolome { get => _musicVolome; set => _musicVolome = value; }

    private void Start() {
      MusicVolome = PlayerPrefs.GetFloat("MusicVolume");
      Debug.Log(MusicVolome);
  }
  private void Update() {
      _audioSourse.volume = MusicVolome;
  }
  public void ChangeVolume(float currentVolume) => MusicVolome = currentVolume;

}
