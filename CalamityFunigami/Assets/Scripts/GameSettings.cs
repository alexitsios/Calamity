using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public delegate void OnSettingsChangedCallback();
    public OnSettingsChangedCallback onSettingsChanged;

    [SerializeField] private Difficulty m_gameDifficulty = Difficulty.Medium;
    [SerializeField] private float m_masterVolume = 1;
    [SerializeField] private float m_musicVolume = 1;
    [SerializeField] private float m_fXVolume = 1;

    public Difficulty GameDifficulty => m_gameDifficulty;
    public float MasterVolume => m_masterVolume;
    public float MusicVolume => m_musicVolume;
    public float FXVolume => m_fXVolume;

    public void SetDifficulty(Difficulty difficulty)
    {
        m_gameDifficulty = difficulty;
        onSettingsChanged?.Invoke();
    }

    public void SetMasterVolume(float volume)
    {
        volume = Mathf.Clamp(volume, 0, 1);
        m_masterVolume = volume;
        onSettingsChanged?.Invoke();
    }

    public void SetMusicVolume(float volume)
    {
        volume = Mathf.Clamp(volume, 0, 1);
        m_musicVolume = volume;
        onSettingsChanged?.Invoke();
    }

    public void SetFXVolume(float volume)
    {
        volume = Mathf.Clamp(volume, 0, 1);
        m_fXVolume = volume;
        onSettingsChanged?.Invoke();
    }
}

public enum Difficulty { Easy, Medium, Hard }