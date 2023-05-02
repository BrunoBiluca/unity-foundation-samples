using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityFoundation.UI.ViewSystem.Samples
{
    public class SimpleViewSystemSample : MonoBehaviour
    {
        [SerializeField] private SampleMainView mainView;
        [SerializeField] private SampleView view1;
        [SerializeField] private SampleView view2;

        private ViewsGroup allViewsGroup;
        private ExclusiveViewGroup mainViewGroup;

        private void Awake()
        {
            allViewsGroup = new ViewsGroup();
            mainViewGroup = new ExclusiveViewGroup();

            mainView.Setup(3);
            mainViewGroup.RegisterMain(mainView);

            view1.Setup("Esse texto veio do game_manager");
            allViewsGroup.Register(view1);
            mainViewGroup.Register(view1);

            allViewsGroup.Register(view2);
            mainViewGroup.Register(view2);
        }

        public void HideAllViews()
        {
            allViewsGroup.Hide();
        }
    }
}