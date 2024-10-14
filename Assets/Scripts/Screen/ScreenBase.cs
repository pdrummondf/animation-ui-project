using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

        public List<Transform> ListaObjetos;

        public bool startHidden = false;

        [Header("Animation")]
        public float animationDuration = .3f;
        public float delayEntreObjetos = .05f;

        [Button]
        protected virtual void Show()
        {
            MostrarObjetos();
            Debug.Log("Show");
        }

        [Button]
        protected virtual void Hide()
        {
            EsconderObjetos();
            Debug.Log("Hide");
        }

        private void EsconderObjetos()
        {
            ListaObjetos.ForEach(x => x.gameObject.SetActive(false));
        }

        private void MostrarObjetos()
        {
            for (int i = 0; i < ListaObjetos.Count; i++)
            {
                var item = ListaObjetos[i];
                item.gameObject.SetActive(true);
                item.DOScale(0, animationDuration).From().SetDelay(i * delayEntreObjetos);
            }
        }

        private void ForceMostrarObjetos()
        {
            ListaObjetos.ForEach(x => x.gameObject.SetActive(true));
        }

    }
}
