using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;

namespace Screens
{
    public class ScreenManager : Singleton<ScreenManager>
    {
        public List<ScreenBase> screenBases;

        public ScreenType startScreen = ScreenType.Panel;

        private ScreenBase _screenBase;

        private void Start()
        {
            HideAll();
            ShowByType(startScreen);               
        }

        public void ShowByType(ScreenType type)
        {
            if (_screenBase != null) _screenBase.Hide();

            var nextScreen = screenBases.Find(x => x.screenType == type);

            nextScreen.Show();
            _screenBase = nextScreen;
        }

        public void HideAll()
        {
            screenBases.ForEach(x => x.Hide());
        }
    }
}
