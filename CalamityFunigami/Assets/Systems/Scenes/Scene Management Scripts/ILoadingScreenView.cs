namespace Calamity.SceneManagement
{
    public interface ILoadingScreenView
    {
        void DisplayLoadingScreen(bool visible);
        void OnProgressUpdate(float progress);
    }
}