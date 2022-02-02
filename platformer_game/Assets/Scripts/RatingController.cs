using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RatingController : MonoBehaviour
{

    public RectTransform prefab;

    public RectTransform content;

    public class PlayerModel
    {
        public string name;
        public int keyScore;
        public int coinScore;

        public PlayerModel()
        {

        }

    }

    private void Start()
    {
        var data = GameController.instanse.LoadGame();
        if (data != null)
        {
            PlayerModel[] models = new PlayerModel[data.Length];
            for (int i = 0; i < models.Length; i++)
            {
                models[i] = new PlayerModel();
                models[i].name = data[i].playerName;
                models[i].coinScore = data[i].playerCoinsScore;
                models[i].keyScore = data[i].playerKeyScore;

            }

            var orderByCoins = models.OrderBy(x => x.coinScore);
            var newlist = orderByCoins.Reverse().ToList();
            OnRecieveModel(newlist.ToArray());
        }

    }


    void OnRecieveModel(PlayerModel[] items)
    {
        foreach (Transform child in content)
        {
            if (child != null)
                Destroy(child.gameObject);
        }

        foreach (var model in items)
        {

            var instance = GameObject.Instantiate(prefab.gameObject) as GameObject;
            instance.transform.SetParent(content, false);
            InitializeItemView(instance, model);

        }
    }

    private void InitializeItemView(GameObject instance, PlayerModel model)
    {
        PlayerView view = new PlayerView(instance.transform);
        view.name.text = model.name;
        view.keyScore.text = model.keyScore.ToString();
        view.coinScore.text = model.coinScore.ToString();

    }



    public class PlayerView
    {
        public Text name;
        public Text keyScore;
        public Text coinScore;


        public PlayerView(Transform transform)
        {
            keyScore = transform.Find("keyScore").GetComponent<Text>();
            name = transform.Find("name").GetComponent<Text>();
            coinScore = transform.Find("coinScore").GetComponent<Text>();

        }

    }
}
