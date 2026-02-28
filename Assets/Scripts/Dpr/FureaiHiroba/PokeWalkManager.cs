using Dpr.Field.Walking;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using XLSXContent;

namespace Dpr.FureaiHiroba
{
    public class PokeWalkManager : MonoBehaviour
    {
        [SerializeField]
        private FureaiDebugViewManager debugManager;
        private FureaiDataManager fureaiDataManager;
        private FormationData formationData;
        private List<FureaiPokeModel> pokeList;
        [SerializeField]
        private bool DrawDebugObjects;
        [SerializeField]
        private float basePokeSpeed = 1.0f;
        [SerializeField]
        private float baseOffsetScale = 1.5f;
        [SerializeField]
        internal List<FureaiPokeModel> PokeWalkers = new List<FureaiPokeModel>();
        [SerializeField]
        private bool isLineFormation;
        [SerializeField]
        private Transform Player;
        [SerializeField]
        private int kyori;
        [SerializeField]
        private List<Vector3> Offsets;

        public void Init(FureaiDataManager mng, List<FureaiPokeModel> pokeList)
        {
            fureaiDataManager = mng;
            this.pokeList = pokeList;

            var formation = fureaiDataManager.GetMD<PokeWalkingFormation>().Sheet1.ToList();
            formationData = new FormationData();

            formation.ForEach(x =>
            {
                formationData.SetFormationOffsets(x.PokeNum, new List<Vector2>()
                {
                    x.Offset1, x.Offset2, x.Offset3, x.Offset4, x.Offset5, x.Offset6
                });
            });
        }

        public void MyUpdate(float deltaTime)
        {
            for (int i=0; i<PokeWalkers.Count; i++)
            {
                PokeWalkers[i].walkData.order = i;

                if (PokeWalkers[i].walkData.priority > 6)
                    PokeWalkers[i].walkData.priority = 6 - i;

                PokeWalkers[i].walkData.yoyakuPriority = 6 - i;

                var target = i == 0 ? null : PokeWalkers[i-1];
                PokeWalkers[i].walkData.Offset = Vector3.back * 1.2f;
                PokeWalkers[i].Update(target, baseOffsetScale, basePokeSpeed);
            }
        }

        public void OnWarp(WalkingCharacterModel model)
        {
            // Empty
        }

        public void AddPoke(FureaiPokeModel model)
        {
            Player = EntityManager.activeFieldPlayer.transform;
            model.AI.ChangeState(typeof(PokeWalkingState));

            if (PokeWalkers.Contains(model))
                return;

            var pairModel = model.sanpoModel.PairModel;
            if (pairModel != null)
            {
                pairModel.pair.sanpoModel.PairModel = null;
                pairModel.pair.sanpoModel.isPairEnd = true;

                model.sanpoModel.Destroy();
                model.sanpoModel.isPairEnd = true;
            }

            model.walkData.actionModel.corSystem.Cancel();

            PokeWalkers.Add(model);
            debugManager.AddDebugView(model);
            PokeWalkers.Sort((a, b) => (int)(b.walkData.runSpeed * 100.0f) - (int)(a.walkData.runSpeed * 100.0f));
            model.controller.SetDebugDrawActive(DrawDebugObjects);

            MyUpdate(0.0f); // deltaTime is unused
            model.walkData.isNeedRun = false;
            model.walkData.Update(0.0f);
        }

        public void SubPoke(FureaiPokeModel model)
        {
            PokeWalkers.Remove(model);
            model.sanpoModel.InitPos = model.transform.position;
        }

        public List<FureaiPokeModel> AllSubPoke(FureaiPokeModel model)
        {
            var subList = new List<FureaiPokeModel>();

            PokeWalkers.ForEach(x =>
            {
                if (model != x)
                    subList.Add(x);
            });

            subList.ForEach(x => SubPoke(x));

            return subList;
        }

        public FureaiPokeModel GetDelPoke()
        {
            if (PokeWalkers.Count != 0)
                return PokeWalkers.Last();

            return null;
        }

        public List<FureaiPokeModel> GetPokeWalkers()
        {
            return PokeWalkers;
        }

        private void OnValidate()
        {
            // Empty
        }
    }
}