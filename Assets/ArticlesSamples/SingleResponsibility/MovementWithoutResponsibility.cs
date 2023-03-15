using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.ArticlesSamples
{
    public class MovementWithoutResponsibility : MonoBehaviour
    {
        // Configura��o do movimento
        [SerializeField] Transform start;
        [SerializeField] Transform end;

        // Campos referentes a movimenta��o
        Vector3 startPosition;
        Vector3 target;
        float interpolation = 0f;
        float movementSpeed = 0.5f;

        // Campos referentes ao efeitos de Expans�o/Contra��o
        Vector3 minSize = new(0.5f, 0.5f, 0.5f);
        Vector3 maxSize = new(1.7f, 1.7f, 1.7f);
        float scaleInterpolation = 0f;
        float scaleSpeed = 1f;

        public void Start()
        {
            // Inicializa��o do objeto
            startPosition = start.position;
            target = end.position;
            transform.position = startPosition;
        }

        public void Update()
        {
            // Verica��o da entrada do jogador
            if(!Keyboard.current.spaceKey.isPressed)
                return;

            // C�lculo da posi��o
            interpolation += Time.deltaTime * movementSpeed;
            transform.position = Vector3.Lerp(startPosition, target, interpolation);

            // C�lculo da dire��o
            var direction = (target - startPosition).normalized;
            transform.right = direction;

            // Crit�rio de parada do movimento
            if(Vector3.Distance(transform.position, target) < 0.001f)
            {
                // Atualiza��o do alvo do movimento
                (target, startPosition) = (startPosition, target);
                interpolation = 0f;
            }

            // C�lculo do efeito de Expans�o/Contra��o
            scaleInterpolation += Time.deltaTime * scaleSpeed;
            transform.localScale = Vector3.Lerp(minSize, maxSize, scaleInterpolation);

            // Condi��o de parada do efeito de Expans�o/Contra��o
            if(scaleInterpolation > 1f)
            {
                // Atualiza��o do efeito de Expans�o/Contra��o
                (minSize, maxSize) = (maxSize, minSize);
                scaleInterpolation = 0f;
            }
        }
    }
}