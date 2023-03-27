using UnityEngine;

namespace Assets.ArticlesSamples
{
    public class ScaledEffect : MonoBehaviour, ITransformation
    {
        float posX = 0f;
        float posY = 0f;

        public void Apply(Transform transform)
        {
            posX += Time.deltaTime;
            posY += Time.deltaTime;
            transform.localScale = new Vector3(
                Mathf.Abs(Mathf.Sin(posX)),
                Mathf.Abs(Mathf.Cos(posY)),
                1f
            );
        }
    }
}