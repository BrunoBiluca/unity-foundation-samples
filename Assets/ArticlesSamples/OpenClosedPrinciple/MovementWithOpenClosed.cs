using UnityEngine;

namespace Assets.ArticlesSamples
{
    public class MovementWithOpenClosed : MonoBehaviour
    {
        private ITransformation[] transformations;

        public void Start()
        {
            transformations = GetComponents<ITransformation>();
        }

        public void Update()
        {
            foreach(var transformation in transformations)
                transformation.Apply(transform);
        }
    }
}