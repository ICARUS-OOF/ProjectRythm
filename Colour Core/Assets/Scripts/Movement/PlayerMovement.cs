using ColourCore.Data;
using ColourCore.Handlers;
using UnityEngine;
using UnityEngine.U2D;

namespace ColourCore
{
    namespace Movement
    {
        public class PlayerMovement : MonoBehaviour
        {
            public bool isOnMenu = false;

            public float speed = 5f;
            public float squeezeVal = 0.075f;
            public float shrinkSpeed = 2f;

            private Rigidbody2D rb;
            public Transform trailTransform;

            Vector2 movement;

            private void Awake()
            {
                rb = GetComponent<Rigidbody2D>();    
            }

            void Update()
            {
                trailTransform.position = transform.position;
                if (!isOnMenu)
                {
                    GetComponent<SpriteShapeRenderer>().color = GameHandler.GetCorrespondingColour(GameHandler.singleton.playerCorruptColour);
                }

                movement.x = Input.GetAxisRaw("Horizontal");
                movement.y = Input.GetAxisRaw("Vertical");

                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
                {
                    transform.localScale = Vector2.Lerp(transform.localScale, new Vector2(squeezeVal, transform.localScale.y), shrinkSpeed * Time.deltaTime);
                }
                else
                {
                    transform.localScale = Vector2.Lerp(transform.localScale, new Vector2(0.1f, transform.localScale.y), shrinkSpeed * Time.deltaTime);
                }
                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
                {
                    transform.localScale = Vector2.Lerp(transform.localScale, new Vector2(transform.localScale.x, squeezeVal), shrinkSpeed * Time.deltaTime);
                }
                else
                {
                    transform.localScale = Vector2.Lerp(transform.localScale, new Vector2(transform.localScale.x, 0.1f), shrinkSpeed * Time.deltaTime);
                }
                if (!isOnMenu)
                {
                    if (Input.GetButtonDown("Fire1"))
                    {
                        GameHandler.singleton.ChangeCorruptColour();
                    }
                }
            }

            private void FixedUpdate()
            {
                rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
            }
        }
    }
}