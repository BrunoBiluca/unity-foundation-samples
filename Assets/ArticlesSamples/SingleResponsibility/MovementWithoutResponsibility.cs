using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.ArticlesSamples
{
    public class MovementWithoutResponsibility : MonoBehaviour
    {
        // Configuração do movimento
        [SerializeField] Transform start;
        [SerializeField] Transform end;

        // Campos referentes a movimentação
        Vector3 startPosition;
        Vector3 target;
        float interpolation = 0f;
        float movementSpeed = 0.5f;

        // Campos referentes ao efeitos de Expansão/Contração
        Vector3 minSize = new(0.5f, 0.5f, 0.5f);
        Vector3 maxSize = new(1.7f, 1.7f, 1.7f);
        float scaleInterpolation = 0f;
        float scaleSpeed = 1f;

        public void Start()
        {
            // Inicialização do objeto
            startPosition = start.position;
            target = end.position;
            transform.position = startPosition;
        }

        public void Update()
        {
            // Vericação da entrada do jogador
            if(!Keyboard.current.spaceKey.isPressed)
                return;

            // Cálculo da posição
            interpolation += Time.deltaTime * movementSpeed;
            transform.position = Vector3.Lerp(startPosition, target, interpolation);

            // Cálculo da direção
            var direction = (target - startPosition).normalized;
            transform.right = direction;

            // Critério de parada do movimento
            if(Vector3.Distance(transform.position, target) < 0.001f)
            {
                // Atualização do alvo do movimento
                (target, startPosition) = (startPosition, target);
                interpolation = 0f;
            }

            // Cálculo do efeito de Expansão/Contração
            scaleInterpolation += Time.deltaTime * scaleSpeed;
            transform.localScale = Vector3.Lerp(minSize, maxSize, scaleInterpolation);

            // Condição de parada do efeito de Expansão/Contração
            if(scaleInterpolation > 1f)
            {
                // Atualização do efeito de Expansão/Contração
                (minSize, maxSize) = (maxSize, minSize);
                scaleInterpolation = 0f;
            }
        }
    }
}