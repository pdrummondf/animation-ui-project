using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStartGame : MonoBehaviour
{
    public ParticleSystem particle;

    public void OnClick()
    {
        particle.Play();
    }
}
