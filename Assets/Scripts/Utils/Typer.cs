using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using NaughtyAttributes;

public class Typer : MonoBehaviour
{
    [Header("Animation")]
    public TextMeshProUGUI textMesh;
    public float timeBetweenLetters = .1f;

    [Header("Texto")]
    public string frase;

    [Button]
    public void StartType()
    {
        StartCoroutine(Type(frase));
    }

    IEnumerator Type(string s)
    {
        textMesh.text = "";
        foreach (char item in s.ToCharArray())
        {
            textMesh.text += item;
            yield return new WaitForSeconds(timeBetweenLetters);
        }
    }

    private void Awake()
    {
        textMesh.text = "";
    }
}
