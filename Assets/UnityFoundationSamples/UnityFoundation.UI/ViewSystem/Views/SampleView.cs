using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UnityFoundation.UI.ViewSystem.Samples
{
    public class SampleView : ComponentizedView
    {
        private int counter;
        private string counterText = "Componente da Tela Asmodeus\n\nContagem de aberturas: <count>";

        protected override IEnumerable<ViewComponent> RegisterComponents()
        {
            yield return new("count", UpdateCounter);
            yield return new("setup text", SetupText);
        }

        public void UpdateCounter(GameObject go)
        {
            var text = counterText.Replace("<count>", (counter++).ToString());
            go.GetComponent<TextMeshProUGUI>().text = text;
        }

        private string setupTextTemplate = "Componente da Tela Asmodeus\n\nTexto passado no setup: <text>";
        private string setupText;

        public void Setup(string setupText)
        {
            this.setupText = setupText;
        }

        public void SetupText(GameObject go)
        {
            if(go == null) return;
            if(string.IsNullOrEmpty(setupText))
                throw new ArgumentNullException("setupText is null");
            go.GetComponent<TextMeshProUGUI>().text = setupTextTemplate.Replace("<text>", setupText);
        }
    }
}