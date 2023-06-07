using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerController playerController;
    private Animator playerAnim;

    [Header("Variables")]
    private bool hasAnim;

    private void Awake()
    {
        hasAnim = gameObject.TryGetComponent<Animator>(out playerAnim);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayWalkAnim();
    }

    private void PlayWalkAnim()
    {
        if (hasAnim)
        {
            playerAnim.SetBool(AnimTags.IS_WALKING, playerController.IsWalking());
        }
    }
}
