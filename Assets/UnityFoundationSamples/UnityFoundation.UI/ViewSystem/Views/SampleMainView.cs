using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityFoundation.Code;

namespace UnityFoundation.UI.ViewSystem.Samples
{
    public class SampleMainView : BaseView
    {
        [SerializeField] private GameObject componentPrefab;

        private int componentsNumber;
        public void Setup(int componentsNumber)
        {
            this.componentsNumber = componentsNumber;
        }

        protected override void OnShow()
        {
            var viewsHolder = transform.Find("views");

            TransformUtils.RemoveChildObjects(viewsHolder);

            for(int i = 0; i < componentsNumber; i++)
            {
                Instantiate(componentPrefab, viewsHolder)
                    .GetComponent<SampleComponent>()
                    .Setup(i.ToString());
            }
        }
    }
}