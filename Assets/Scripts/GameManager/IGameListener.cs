namespace ShootEmUp
{
    public interface IGameListener
    {
    }

    public interface IGameFinishListener : IGameListener
    {
        void OnFinishGame();
    }

    public interface IGamePauseListener : IGameListener
    {
        void OnPauseGame();
    }

    public interface IGameResumeListener : IGameListener
    {
        void OnResumeGame();
    }

    public interface IGameStartListener : IGameListener
    {
        void OnStartGame();
    }

    public interface IGameUpdateListener : IGameListener
    {
        void OnUpdateGame(float deltaTime);
    }

    public interface IGameFixedUpdateListener : IGameListener
    {
        void OnFixedUpdateGame(float fixedDeltaTime);
    }
}