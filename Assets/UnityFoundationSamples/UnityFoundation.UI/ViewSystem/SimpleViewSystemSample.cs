using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityFoundation.UI.ViewSystem
{
    public class SimpleViewSystemSample : MonoBehaviour
    {
        [SerializeField] private BaseView[] allViews;

        [SerializeField] private BaseView mainView;

        private ViewsGroup allViewsGroup;
        private ExclusiveViewGroup mainViewGroup;

        private void Awake()
        {
            allViewsGroup = new ViewsGroup();

            mainViewGroup = new ExclusiveViewGroup();
            mainViewGroup.RegisterMain(mainView);

            foreach(var view in allViews)
            {
                allViewsGroup.Register(view);
                mainViewGroup.Register(view);
            }
        }

        public void HideAllViews()
        {
            allViewsGroup.Hide();
        }
    }
}