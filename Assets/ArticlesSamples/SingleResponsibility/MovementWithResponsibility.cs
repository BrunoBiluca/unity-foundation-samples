using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.ArticlesSamples
{
    public class PositionHandler
    {
        private readonly Transform transform;
        private readonly float speed;

        private Vector3 startPosition;
        private Vector3 target;
        private float interpolation = 0f;

        public PositionHandler(
            Transform transform,
            Vector3 startPosition,
            Vector3 target,
            float speed
        )
        {
            this.transform = transform;
            this.startPosition = startPosition;
            this.target = target;
            this.speed = speed;
        }

        public void Update(float amount)
        {
            interpolation += amount * speed;
            transform.position = Vector3.Lerp(startPosition, target, interpolation);
        }

        public bool WasTargetReached()
        {
            return Vector3.Distance(transform.position, target) < 0.001f;
        }

        public void ChangeDirection()
        {
            (target, startPosition) = (startPosition, target);
            interpolation = 0f;

            var direction = (target - startPosition).normalized;
            transform.right = direction;
        }
    }

    public class PlayerInputs
    {
        public bool IsMovementPressed()
        {
            return Keyboard.current.spaceKey.isPressed;
        }
    }

    public class ExpansionContractionEffect
    {
        private readonly Transform transform;
        private readonly float speed;

        private Vector3 minSize;
        private Vector3 maxSize;
        private float scaleInterpolation;

        public ExpansionContractionEffect(
            Transform transform, Vector3 minSize, Vector3 maxSize, float speed
        )
        {
            this.transform = transform;
            this.minSize = minSize;
            this.maxSize = maxSize;
            this.speed = speed;
        }

        public void Update(float amount)
        {
            scaleInterpolation += amount * speed;
            transform.localScale = Vector3.Lerp(minSize, maxSize, scaleInterpolation);
        }

        public bool IsOnLimit()
        {
            return scaleInterpolation >= 1f;
        }

        public void ChangeScaleDirection()
        {
            (minSize, maxSize) = (maxSize, minSize);
            scaleInterpolation = 0f;
        }
    }

    public class MovementWithResponsibility : MonoBehaviour
    {
        // Configuração do movimento
        [SerializeField] Transform start;
        [SerializeField] Transform end;

        private PositionHandler positionHandler;
        private PlayerInputs playerInputs;
        private ExpansionContractionEffect expansionContractionEffect;

        public void Start()
        {
            // Inicialização do objeto
            positionHandler = new(transform, start.position, end.position, 0.5f);
            expansionContractionEffect = new(
                transform, new(0.5f, 0.5f, 0.5f), new(1.7f, 1.7f, 1.7f), 1f
            );
            playerInputs = new PlayerInputs();
        }

        public void Update()
        {
            // Verificação da entrada do jogador
            if(!playerInputs.IsMovementPressed())
                return;

            // Cálculo da posição
            positionHandler.Update(Time.deltaTime);

            if(positionHandler.WasTargetReached())
                positionHandler.ChangeDirection();

            // Cálculo do efeito de Expansão/Contração
            expansionContractionEffect.Update(Time.deltaTime);

            if(expansionContractionEffect.IsOnLimit())
                expansionContractionEffect.ChangeScaleDirection();
        }
    }
}