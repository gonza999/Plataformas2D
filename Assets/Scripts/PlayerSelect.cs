using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{
   public enum Player
    {
        Frog,
        VirtualGuy,
        Pinkman,
        MaskDude
    };

    public bool enableSelectPlayer;
    public Player playerSelected;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    public RuntimeAnimatorController[] playerController;
    public Sprite[] playerRenderer;

    private void Start()
    {
        if (enableSelectPlayer)
        {
            switch (playerSelected)
            {
                case Player.Frog:
                    spriteRenderer.sprite = playerRenderer[0];
                    animator.runtimeAnimatorController = playerController[0];
                    break;
                case Player.Pinkman:
                    spriteRenderer.sprite = playerRenderer[1];
                    animator.runtimeAnimatorController = playerController[1];
                    break;
                case Player.VirtualGuy:
                    spriteRenderer.sprite = playerRenderer[2];
                    animator.runtimeAnimatorController = playerController[2];
                    break;
                case Player.MaskDude:
                    spriteRenderer.sprite = playerRenderer[3];
                    animator.runtimeAnimatorController = playerController[3];
                    break;
                default:
                    break;
            }
        }
        else
        {
            ChangePlayerInMenu();
        }
      
    }

    internal void ChangePlayerInMenu()
    {
        switch (PlayerPrefs.GetString("PlayerSelected"))
        {
            case "Frog":
                spriteRenderer.sprite = playerRenderer[0];
                animator.runtimeAnimatorController = playerController[0];
                break;
            case "PinkMan":
                spriteRenderer.sprite = playerRenderer[1];
                animator.runtimeAnimatorController = playerController[1];
                break;
            case "VirtualGuy":
                spriteRenderer.sprite = playerRenderer[2];
                animator.runtimeAnimatorController = playerController[2];
                break;
            case "MaskDude":
                spriteRenderer.sprite = playerRenderer[3];
                animator.runtimeAnimatorController = playerController[3];
                break;
            default:
                break;
        }
    }
}
