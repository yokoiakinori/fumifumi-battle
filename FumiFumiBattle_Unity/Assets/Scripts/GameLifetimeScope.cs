using GameInput;
using Judge;
using Note;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using VContainerTest;

public class GameLifetimeScope : LifetimeScope
{
    [SerializeField]
    NoteScreen noteScreen;
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
        builder.RegisterComponent(noteScreen);
        
        // GameInput
        builder.Register<GameInputs>(Lifetime.Scoped);
        
        // Judge
        builder.Register<JudgeService>(Lifetime.Singleton);
        builder.RegisterEntryPoint<JudgePresenter>();
    }
}
