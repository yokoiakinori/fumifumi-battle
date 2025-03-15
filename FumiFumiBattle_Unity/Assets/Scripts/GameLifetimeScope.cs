using GameInput;
using Judge;
using Note;
using Score;
using UnityEngine;
using UnityEngine.Serialization;
using VContainer;
using VContainer.Unity;
using VContainerTest;

public class GameLifetimeScope : LifetimeScope
{
    [SerializeField]
    NoteView noteView;
    [SerializeField]
    JudgeView judgeView;
    [SerializeField]
    NoteBase noteBase;
    [SerializeField]
    Transform canvasTransform;
    
    protected override void Configure(IContainerBuilder builder)
    {
        // Note
        builder.Register<NotesService>(Lifetime.Singleton)
            .WithParameter(noteBase)
            .WithParameter(canvasTransform);
        builder.RegisterEntryPoint<NotePresenter>();
        builder.RegisterComponent(noteView);
        
        // GameInput
        builder.Register<GameInputs>(Lifetime.Scoped);
        
        // Judge
        builder.Register<JudgeService>(Lifetime.Singleton);
        builder.RegisterEntryPoint<JudgePresenter>();
        builder.RegisterComponent(judgeView);
        
        // Score
        builder.Register<ScoreService>(Lifetime.Singleton);
    }
}
