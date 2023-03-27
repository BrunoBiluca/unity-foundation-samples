using UnityEngine;

namespace Assets.ArticlesSamples
{
    public class CircleMovement : MonoBehaviour, ITransformation
    {
        [SerializeField] float radius = 3f;
        float posX = 0f;
        float posY = 0f;

        public void Apply(Transform transform)
        {
            posX += Time.deltaTime;
            posY += Time.deltaTime;
            transform.position = new Vector3(
                Mathf.Sin(posX) * radius,
                Mathf.Cos(posY) * radius,
                0f
            );
        }
    }
}