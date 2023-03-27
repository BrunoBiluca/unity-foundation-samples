using UnityEngine;

namespace Assets.ArticlesSamples
{
    public class MovementWithoutOpenClosed : MonoBehaviour
    {
        float radius = 5f;
        float posX = 0f;
        float posY = 0f;

        public void Update()
        {
            posX += Time.deltaTime;
            posY += Time.deltaTime;
            transform.position = new Vector3(
                Mathf.Sin(posX) * radius,
                Mathf.Cos(posY) * radius,
                0f
            );

            transform.localScale = new Vector3(
                Mathf.Abs(Mathf.Sin(posX)),
                Mathf.Abs(Mathf.Cos(posY)),
                1f
            );
        }
    }
}