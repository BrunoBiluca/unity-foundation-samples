using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UnityFoundation.UI.ViewSystem.Samples
{
    public class SampleComponent : ComponentizedView
    {
        private string number;

        public void Setup(string number)
        {
            this.number = number;
        }

        protected override IEnumerable<ViewComponent> RegisterComponents()
        {
            yield return new("text", SetNumber);
        }

        public void SetNumber(GameObject gameObject)
        {
            Debug.Log("setNumber");
            if(string.IsNullOrEmpty(number))
                throw new ArgumentNullException(nameof(number));
            gameObject.GetComponent<TextMeshProUGUI>().text = number;
        }
    }
}