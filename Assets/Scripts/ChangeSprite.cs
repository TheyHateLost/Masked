using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    public class ChangeSpriteExample : MonoBehaviour
    {
        public SpriteRenderer spriteRenderer;
        public Sprite newSprite;
        void Start()
        {
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        }
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                ChangeSprite();
            }
        }
        void ChangeSprite()
        {
            spriteRenderer.sprite = newSprite;
        }
    }
}
