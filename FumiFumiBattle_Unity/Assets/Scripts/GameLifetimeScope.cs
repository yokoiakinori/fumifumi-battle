using Note;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using VContainerTest;

public class GameLifetimeScope : LifetimeScope
{
    [SerializeField]
     NoteScreen noteScreen;
    
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<NotesService>(Lifetime.Singleton);
        builder.Register<NoteBase>(Lifetime.Transient);
        builder.RegisterEntryPoint<NotePresenter>();
        builder.RegisterComponent(noteScreen);
    }
}
