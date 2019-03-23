﻿using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound {

    public string name;
    public AudioClip clip;

    [Range(0, 1)]
    public float volume;
    [Range(0, 3)]
    public float pitch;
    [Range(0, 1)]
    public float spatialBlend;
    [Range(0, 1)]
    public float reverb;
    public float maxDistance;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
