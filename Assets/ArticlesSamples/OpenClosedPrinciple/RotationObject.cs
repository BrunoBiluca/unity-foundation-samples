using UnityEngine;

namespace Assets.ArticlesSamples
{
    public class RotationObject : MonoBehaviour, ITransformation
    {
        public void Apply(Transform transform)
        {
            transform.Rotate(0, 0, 1f);
        }
    }
}