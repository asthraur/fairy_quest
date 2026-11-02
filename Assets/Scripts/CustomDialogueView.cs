using UnityEngine;
using Yarn.Unity;
using System;
using System.Collections;

public class CustomDialogueView : DialogueViewBase
{
    public TMPro.TextMeshProUGUI text;
    public RectTransform container;

    private float appearanceTime = 0.5f;
    private float disappearanceTime = 0.5f;
    private bool waitForInput;

    public Coroutine currentAnimation;

    public Action advanceHandler = null;

   private float Scale
    {
        set => container.localScale = new Vector3(value, value, value);
    }

    public void Start()
    {
        Scale = 0;
    }

    public override void RunLine(LocalizedLine dialogueLine, Action onDialogueLineFinished)
    {
        if (gameObject.activeInHierarchy == false)
        {
            onDialogueLineFinished();
            return;
        }

        Scale = 0;
        text.text = dialogueLine.Text.Text;

        advanceHandler = requestInterrupt;

        currentAnimation = this.Tween(
            0f, 1f,
            appearanceTime,
            (from, to, t) => Scale = Mathf.Lerp(from, to, t),
            () =>
            {
                currentAnimation = null;

                if (waitForInput)
                {
                    advanceHandler = requestInterrupt;
                }
                else{
                    advanceHandler = null;
                    onDialogueLineFinished();
                }
            });
    }

    public override void InterruptLine(LocalizedLine dialogueLine, Action onDialogueLineFinished)
    {
        base.InterruptLine(dialogueLine, onDialogueLineFinished);

        if(gameObject.activeInHierarchy == false)
        {
            onDialogueLineFinished();
            return;
        }

        advanceHandler = null;

        if(currentAnimation != null)
        {
            StopCoroutine(currentAnimation);
            currentAnimation = null;
        }

        Scale = 1;

        onDialogueLineFinished();
    }

    public override void DismissLine(Action onDismissalComplete)
    {
        if(gameObject.activeInHierarchy == false)
        {
            onDismissalComplete();
            return;
        }

        if(currentAnimation != null)
        {
            StopCoroutine(currentAnimation);
            currentAnimation = null;
        }

        advanceHandler = () =>
        {
            if (currentAnimation != null)
            {
                StopCoroutine(currentAnimation);
                currentAnimation = null;
            }
            advanceHandler = null;
            onDismissalComplete();
            Scale = 0;
        };

        currentAnimation = this.Tween(
            1f, 0f,
            disappearanceTime,
            (from, to, t) => Scale = Mathf.Lerp(from, to, t),
            () =>
            {
                advanceHandler = null;
                currentAnimation = null;
                onDismissalComplete();
            });
    }

    public override void RunOptions(DialogueOption[] dialogueOptions, Action<int> onOptionSelected)
    {
        base.RunOptions(dialogueOptions, onOptionSelected);
    }

    public override void UserRequestedViewAdvancement()
    {
        advanceHandler?.Invoke();
    }

    
}

public static class TweenExtensions
{
    public delegate void TweenFunction<T>(T from, T to, float factor);

    public static Coroutine Tween<T>(this MonoBehaviour behaviour, T from, T to, float time, TweenFunction<T> handler, System.Action onComplete = null)
    {
        return behaviour.StartCoroutine(HandleTween(from, to, time, handler, onComplete));
    }

    private static IEnumerator HandleTween<T>(T from, T to, float time, TweenFunction<T> handler, System.Action onComplete)
    {
        var timeElapsed = 0f;

        while(timeElapsed < time)
        {
            float factor = Mathf.Clamp01(timeElapsed / time);
            handler(from, to, factor);
            timeElapsed += Time.deltaTime;

            yield return null;

            handler(from, to, 1f);

            onComplete?.Invoke();
        }
    }
}
