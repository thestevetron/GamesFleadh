using UnityEngine;
using System.Collections;

public class AnimateMenu : MonoBehaviour 
{
    //public Animation anim;
    //public Animator animator;
    //public Sprite _hamster;

    public Sprite[] sprites;
    public float fps;
    private SpriteRenderer spriteRenderer;
    
	void Start () 
    {
        spriteRenderer = renderer as SpriteRenderer;
        //anim.Play();
        //animator.Play(0, 1, 1);
	}
	
	void Update () 
    {
        int index = (int)((Time.timeSinceLevelLoad+1) * fps);
        index = index % sprites.Length;
        spriteRenderer.sprite = sprites[index];
	}
}
