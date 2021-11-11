using UnityEngine;

namespace FightShipArena.Assets.Scripts.Managers.GameManager
{
    public class GameManager : MyMonoBehaviour
    {
        public IGameManagerCore Core { get; private set; }


        void Awake()
        {
            Core = new GameManagerCore(this);
        }
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
