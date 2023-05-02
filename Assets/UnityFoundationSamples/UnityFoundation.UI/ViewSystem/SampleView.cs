using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UnityFoundation.UI.ViewSystem
{
    public class SampleView : ComponentizedView
    {
        private int counter;
        private string counterText= "Componente da Tela Asmodeus\n\nContagem de aberturas: <count>";

        protected override IEnumerable<ViewComponent> RegisterComponents()
        {
            yield return new("count", UpdateCounter);
        }

        public void UpdateCounter(GameObject go)
        {
            var text = counterText.Replace("<count>", (counter++).ToString());
            go.GetComponent<TextMeshProUGUI>().text = text;
        }
    }
}