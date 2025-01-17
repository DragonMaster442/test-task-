using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private string _url = "https://avatars.mds.yandex.net/get-mpic/4736439/img_id9066538669564050139.jpeg/orig";
    [SerializeField] private string _pathToImageInFolder = "Sprites/SecondImage";
    [SerializeField] private byte _nextSceneNumber = 1;
    [SerializeField] private Image _urlImage; 
    [SerializeField] private Image _folderImage;
    [SerializeField] private Button _nextSceneButton;
    [SerializeField] private ProgressBar _image1ProcessBar;
    [SerializeField] private ProgressBar _image2ProcessBar;
    [SerializeField] private ProgressBar _SceneLoadingProcessBar;

    private AsyncOperation SceneLoading;

    void Start()
    {
        LoadImageByURL().Forget();
        LoadImageFromDirectory().Forget();
        AsyncLoadScene().Forget();
    }

    private async UniTask LoadImageByURL()
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(_url);
        request.SendWebRequest();
        while(!request.isDone)
        {
            _image1ProcessBar.SetProgress(request.downloadProgress);
            await UniTask.Yield();
        }
        _image1ProcessBar.SetProgress(request.downloadProgress);
        if(request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(request.error);
        }
        else
        {
            var Texture = DownloadHandlerTexture.GetContent(request);
            _urlImage.sprite = Sprite.Create(Texture, new Rect(0, 0, Texture.width, Texture.height), new Vector2(0.5f, 0.5f));
        }
    }

    private async UniTask LoadImageFromDirectory()
    {
        ResourceRequest request = Resources.LoadAsync<Sprite>(_pathToImageInFolder);
        while(!request.isDone)
        {
            _image2ProcessBar.SetProgress(request.progress);
            await UniTask.Yield();
        }

        if(request.asset is Sprite sprite)
        {
            _folderImage.sprite = sprite;
        }
        else
        {
            Debug.LogError("Не удалось загрузить файл и папки");
        }
    }

    private async UniTask AsyncLoadScene()
    {
        SceneLoading = SceneManager.LoadSceneAsync(_nextSceneNumber);
        SceneLoading.allowSceneActivation = false;
        while(!SceneLoading.isDone)
        {
            _SceneLoadingProcessBar.SetProgress(SceneLoading.progress/90);
            if (SceneLoading.progress >= 0.9f)
            {
                _SceneLoadingProcessBar.SetProgress(1);
                _nextSceneButton.interactable = true;
            }
            await UniTask.Yield();
        }
    }

    public void LoadScene()
    {
        if(SceneLoading.progress >= 0.9f)
        {
            SceneLoading.allowSceneActivation = true;
        }
    }
}
