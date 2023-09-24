using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioSource musicaFundo;

    public void VolumeMusical(float value)
    {
        musicaFundo.volume = value;
    }
}
