using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;
using DG.Tweening;

namespace Screens
{
    public enum ScreenType
    {
        Panel,
        Info_Panel,
        Shop
    }
    public class ScreenBase : MonoBehaviour
    {
        public ScreenType screenType;

        public Image uiBackground;

        public List<Transform> ListaObjetos;
        public List<Typer> ListaFrases;

        public bool startHidden = false;

        [Header("Animation")]
        public float animationDuration = .3f;
        public float delayEntreObjetos = .05f;

        [Button]
        public virtual void Show()
        {
            MostrarObjetos();
            Debug.Log("Show");
        }

        [Button]
        public virtual void Hide()
        {
            EsconderObjetos();
            Debug.Log("Hide");
        }

        private void EsconderObjetos()
        {
            ListaObjetos.ForEach(x => x.gameObject.SetActive(false));
            uiBackground.enabled = false;
        }

        private void MostrarObjetos()
        {
            ResetUiElements();
            for (int i = 0; i < ListaObjetos.Count; i++)
            {
                var item = ListaObjetos[i];
                item.gameObject.SetActive(true);
                item.DOScale(0, animationDuration).From().SetDelay(i * delayEntreObjetos);
            }

            Invoke(nameof(StartType), delayEntreObjetos * ListaObjetos.Count);
            uiBackground.enabled = true;
        }

        private void StartType()
        {
            for (int i = 0; i < ListaFrases.Count; i++)
            {
                ListaFrases[i].StartType();
            }
        }

        private void ForceMostrarObjetos()
        {
            ListaObjetos.ForEach(x => x.gameObject.SetActive(true));
            uiBackground.enabled = true;
        }

        public void ResetUiElements()
        {
            ListaObjetos.ForEach(x => x.localScale = Vector3.one);
        }

        private void Start()
        {
            if (startHidden)
            {
                Hide();
            }
        }

    }
}
