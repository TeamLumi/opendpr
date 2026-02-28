using Audio;
using DG.Tweening;
using Dpr.EvScript;
using Dpr.Field.Walking;
using Dpr.SubContents;
using Dpr.UI;
using Effect;
using Pml;
using SmartPoint.AssetAssistant;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using XLSXContent;

namespace Dpr.FureaiHiroba
{
    public sealed class FureaiManager : SingletonMonoBehaviour<FureaiManager>
    {
        public bool isUpdateStop;
        public int TalkPokeIndex;
        public int TalkItemNo = -1;
        public int TalkSealNo = -1;
        public bool isCreatingPoke;
        public bool isSyuugouPoke;
        public bool isKaisanPoke;
        public bool isEntering;
        public bool isInHiroba;
        public Action<uint> _EnterHirobaCreate;
        public Action _EnterHirobaKaisan;
        public Action _ExitHirobaSyuugou;
        private int Debug_EffectRemoveNum;
        public FureaiDataManager fureaiDataManager;
        [SerializeField]
        private PokeWalkManager pokeWalkMng;
        [SerializeField]
        private FureaiHiroba_PokeFactory pokeFactory;
        private List<FureaiPokeModel> fureaiPokeModels;
        private IEnumerator AddPokeCor;
        [SerializeField]
        private int MaxPitch = 60;
        [SerializeField]
        private int MinPitch = 20;
        [SerializeField]
        private int MaxFov = 26;
        [SerializeField]
        private int MinFov = 10;
        [SerializeField]
        private float pitch = 45.0f;
        [SerializeField]
        private float fov = 20.0f;
        [SerializeField]
        private float far = 30.0f;
        private Tweener Tw_CamPitch;
        private Tweener Tw_CamFov;
        public static List<int> MemoryDebugList  = new List<int>();
        private bool isAlreadyKutibue;
        public int AnimID = FieldPokemonEntity.Animation.Happy03;
        private static readonly Vector2Int[] EnterPosArrayLeft = new Vector2Int[5]
        {
            new Vector2Int(10, 43), new Vector2Int(13, 43), new Vector2Int(16, 45),
            new Vector2Int(12, 41), new Vector2Int(16, 42),
        };
        private static readonly Vector2Int[] EnterPosArrayRight = new Vector2Int[5]
        {
            new Vector2Int(51, 44), new Vector2Int(53, 43), new Vector2Int(51, 42),
            new Vector2Int(53, 41), new Vector2Int(49, 41),
        };
        public static readonly int[] HappyAnimID = new int[3]
        {
            FieldPokemonEntity.Animation.Happy02, FieldPokemonEntity.Animation.Happy03, FieldPokemonEntity.Animation.Happy01
        };
        private static readonly EffectFieldID[] effectFieldIDs = new EffectFieldID[6]
        {
            EffectFieldID.EF_F_TRADE_BG_01,  EffectFieldID.EF_F_TRADE_BG_02,    EffectFieldID.EF_F_TRADE_TRANSBALL_01,
            EffectFieldID.EF_F_TRADE_BALL01, EffectFieldID.EF_F_TRADE_TRAIL_01, EffectFieldID.EF_F_TRADE_SLOWTRAIL_01,
        };
        private int effIndex;
        private FureaiPokeModel firstMod;
        [Button("DebugSE", "DebugSE", new object[0] { })]
        public int Button05;
        [Button("AddPokeWalkDebug", "連れ歩きに追加（生成順）", new object[0] { })]
        public int Button03;
        [Button("Debug_EnterPokeCreate", "FureaiEnterPokeCreate", new object[0] { })]
        public int Button01;
        [Button("_DebugGetNearEmptyPosition", "_DebugGetNearEmptyPosition", new object[0] { })]
        public int Button011;
        [Button("DebugStopTime", "DebugStopTime", new object[0] { })]
        public int button00;
        [Button("DebugCreatePoke", "DebugCreatePoke", new object[0] { })]
        public int Button001;
        [Button("DelPoke", "最後に生成したポケ削除", new object[0] { })]
        public int button99;
        [Button("_DebugAddPoke", "ピッピ", new object[1] { MonsNo.PIPPI })]
        public int button01;
        [Button("_DebugAddPoke", "ピカチュウ", new object[1] { MonsNo.PIKATYUU })]
        public int button02;
        [Button("_DebugAddPoke", "アチャモ", new object[1] { MonsNo.ATYAMO })]
        public int button03;
        [Button("_DebugAddPoke", "ナエトル", new object[1] { MonsNo.NAETORU })]
        public int button04;
        [Button("_DebugAddPoke", "ヒコザル", new object[1] { MonsNo.HIKOZARU })]
        public int button05;
        [Button("_DebugAddPoke", "ポッチャマ", new object[1] { MonsNo.POTTYAMA })]
        public int button06;
        [Button("_DebugAddPoke", "プリン", new object[1] { MonsNo.PURIN })]
        public int button07;
        [Button("_DebugAddPoke", "ドダイトス", new object[1] { MonsNo.DODAITOSU })]
        public int button08;
        [Button("_DebugAddPoke", "イーブイ", new object[1] { MonsNo.IIBUI })]
        public int button09;
        [Button("_DebugAddPoke", "ハヤシガメ", new object[1] { MonsNo.HAYASIGAME })]
        public int button10;
        [Button("_DebugAddPoke", "モウカザル", new object[1] { MonsNo.MOUKAZARU })]
        public int button11;
        [Button("_DebugAddPoke", "ゴウカザル", new object[1] { MonsNo.GOUKAZARU })]
        public int button12;
        [Button("_DebugAddPoke", "ポッタイシ", new object[1] { MonsNo.POTTAISI })]
        public int button13;
        [Button("_DebugAddPoke", "エンペルト", new object[1] { MonsNo.ENPERUTO })]
        public int button14;
        [Button("_DebugAddPoke", "コダック", new object[1] { MonsNo.KODAKKU })]
        public int button15;
        [Button("_DebugAddPoke", "パチリス", new object[1] { MonsNo.PATIRISU })]
        public int button16;
        [Button("_DebugAddPoke", "ピンプク", new object[1] { MonsNo.PINPUKU })]
        public int button17;
        [Button("_DebugAddPoke", "ミミロル", new object[1] { MonsNo.MIMIRORU })]
        public int button18;
        [Button("_DebugAddPoke", "フワンテ", new object[1] { MonsNo.HUWANTE })]
        public int button19;
        [Button("_DebugAddPoke", "エネコ", new object[1] { MonsNo.ENEKO })]
        public int button20;
        [Button("_DebugAddPoke", "キノココ", new object[1] { MonsNo.KINOKOKO })]
        public int button21;
        [Button("_DebugAddPoke", "ブースター", new object[1] { MonsNo.BUUSUTAA })]
        public int button22;
        [Button("_DebugAddPoke", "サンダース", new object[1] { MonsNo.SANDAASU })]
        public int button23;
        [Button("_DebugAddPoke", "シャワーズ", new object[1] { MonsNo.SYAWAAZU })]
        public int button24;
        [Button("_DebugAddPoke", "エーフィ", new object[1] { MonsNo.EEFI })]
        public int button25;
        [Button("_DebugAddPoke", "ブラッキー", new object[1] { MonsNo.BURAKKII })]
        public int button26;
        [Button("_DebugAddPoke", "リーフィア", new object[1] { MonsNo.RIIFIA })]
        public int button27;
        [Button("_DebugAddPoke", "グレイシア", new object[1] { MonsNo.GUREISIA })]
        public int button28;

        public bool isCanCreatePoke { get => !isCreatingPoke && pokeFactory.PokeList.Count == 0; }
        public bool isCanSyuugou { get => !isCreatingPoke && pokeFactory.PokeList.Count != 0; }
        public bool isCanKaisan { get => !isKaisanPoke && isEntering; }
        private bool isOn_PulsOrMinus
        {
            get => (GameController.on & GameController.ButtonMask.Plus) != 0 ||
                   (GameController.on & GameController.ButtonMask.Minus) != 0;
        }
        private bool isRelease_PulsOrMinus
        {
            get => (GameController.release & GameController.ButtonMask.Plus) != 0 ||
                   (GameController.release & GameController.ButtonMask.Minus) != 0;
        }

        private IEnumerator Start()
        {
            pitch = 40.0f;
            fov = 18.0f;

            yield return fureaiDataManager.LoadMD();

            yield return fureaiDataManager.Init();

            yield return UIManager.Instance.OpLoadWindows(new List<UIWindowID>() { UIWindowID.FUREAI_POKESELECT });

            yield return new WaitForEndOfFrame();

            pokeFactory.Init(fureaiDataManager);
            pokeWalkMng.Init(fureaiDataManager, pokeFactory.PokeList);
            Sequencer.update += MyUpdate;
            Sequencer.lateUpdate += MyLateUpdate;

            _EnterHirobaCreate = FureaiEnterPokeCreate;
            _EnterHirobaKaisan = HirobaEnterKaisan;
            _ExitHirobaSyuugou = HirobaExitSyuugou;

            FieldManager.fwMng.isEvent = false;
            FlagWork.SetSysFlag(EvScript.EvWork.SYSFLAG_INDEX.SYS_FLAG_PAIR, false);
        }

        public void SetDataManager(FureaiDataManager dataManager)
        {
            fureaiDataManager = dataManager;
        }

        public bool IsEnterble(int monsNo)
        {
            if (monsNo != 0)
                return fureaiDataManager.EnterblePokeList.FindIndex(x => monsNo == x) != -1;
            else
                return false;
        }

        // TODO
        private void MyUpdate(float deltaTime) { }

        private bool CheckLongPush(float duration)
        {
            var ticks = DateTime.Now.Ticks;
            var times = Math.Max(GameController.times[GameController.ButtonIndex.Plus], GameController.times[GameController.ButtonIndex.Minus]);
            return duration * 1e+07f < (ticks - times);
        }

        private bool KutibueInput()
        {
            if (isOn_PulsOrMinus)
            {
                if (CheckLongPush(0.5f))
                    Kutibue_Kaisan();

                return true;
            }
            else if (isRelease_PulsOrMinus)
            {
                Kutibue_Yobiyose();
                return true;
            }
            else
            {
                isAlreadyKutibue = false;
                return false;
            }
        }

        private void Kutibue_Yobiyose()
        {
            if (!PlayerWork.isPlayerInputActive || isAlreadyKutibue)
                return;

            var pos = EntityManager.activeFieldPlayer.transform.position;
            var list = pokeFactory.PokeList.FindAll(x =>
            {
                if (!x.CheckState<SanpoState>() && !x.CheckState<SanpoPairState>())
                    return false;
                else
                    return Vector3.Distance(pos, x.entity.transform.position) < 12.0f;
            });

            PlayerWork.isPlayerInputActive = false;
            EntityManager.activeFieldPlayer.GetAnimationPlayer().Play(FieldPlayerEntity.Animation.Idle, 0.2f);

            var playerTra = EntityManager.activeFieldPlayer.transform;

            Sequencer.Start(Utils.LoadEffect(EffectContestID.EF_SU_AMITY_WHISTLE_CALL, eff =>
                EffectManager.Instance.Play(eff, playerTra.position, playerTra.rotation, null, null)));

            DOVirtual.DelayedCall(0.2f, () =>
            {
                var maxDelay = 0.0f;
                list.ForEach(x =>
                {
                    var dist = Vector3.Distance(pos, x.entity.transform.position);
                    dist /= 20.0f;

                    if (maxDelay < dist)
                        maxDelay = dist;

                    DOVirtual.DelayedCall(dist, () =>
                    {
                        x.controller.emoticon.Enter();
                        x.controller.emoticon.PlaySeAmbient(0);
                        x.sanpoModel.actionModel.corSystem.Cancel();

                        _ = x.controller != null;

                        x.controller.AI.GetNowState().Cancel();

                        AI ai = null;
                        if (x.controller != null)
                            ai = x.controller.AI;

                        ai.ChangeState(typeof(ReturnState));

                        _ = x.controller != null;

                        x.controller.AI.GetNowState().Play(new LookAtPlayer(0.8f, 0.02f), null);
                        Utils.PlayVoicePikaBui_Yobiyose(x.monsNo, x.controller.voicePlayer);
                    });
                });

                DOVirtual.DelayedCall(Mathf.Clamp(maxDelay + 0.2f, 1.0f, 3.0f), () =>
                {
                    list.ForEach(x =>
                    {
                        x.controller.OnPlayerNear += model => pokeWalkMng.AddPoke(model);
                    });

                    PlayerWork.isPlayerInputActive = true;
                });
            });
            AudioManager.Instance.PlaySe(AK.EVENTS.S_OPE001, null);
        }

        private void Kutibue_Kaisan()
        {
            if (!PlayerWork.isPlayerInputActive || isAlreadyKutibue)
                return;

            isAlreadyKutibue = true;
            var model = pokeWalkMng.GetPokeWalkers().Find(x => x.isSelectPoke);

            var all = pokeFactory.PokeList.FindAll(x => model != x && x.CheckState<PokeWalkingState>());
            pokeFactory.CreatePositionNoList(all.Count);
            var randomList = all.OrderBy(i => Guid.NewGuid()).ToList();

            pokeWalkMng.AllSubPoke(model);
            EntityManager.activeFieldPlayer.GetAnimationPlayer().Play(FieldPlayerEntity.Animation.Idle, 0.2f);

            PlayerWork.isPlayerInputActive = false;
            AudioManager.Instance.PlaySe(AK.EVENTS.S_OPE002, null);

            var playerTra = EntityManager.activeFieldPlayer.transform;
            Sequencer.Start(Utils.LoadEffect(EffectContestID.EF_SU_AMITY_WHISTLE_LEAVE, null));

            for (int i=0; i<randomList.Count; i++)
            {
                var x = randomList[i];
                DOVirtual.DelayedCall(x.controller.walkModel.order * 0.1f + 0.2f, () =>
                {
                    x.controller.emoticon.Enter(3);
                    x.controller.emoticon.PlaySeAmbient(3);
                    x.walkData.actionModel.corSystem.Cancel();
                    x.sanpoModel.actionModel.corSystem.Cancel();

                    x.sanpoModel.PairModel = null;
                    x.sanpoModel.isPairEnd = false;
                    x.controller.model.route = null;

                    pokeFactory.SetPokePosition(false, null, x, Vector2Int.zero);
                    pokeFactory.SetPairModel(x);
                    x.route = x.GetRoute(x.sanpoModel.InitPos, 60);

                    var ai = x.controller == null ? null : x.controller.AI;
                    ai.ChangeState(typeof(GotoSanpoState));

                    _ = x.controller != null;
                    x.controller.AI.GetNowState().Play(new LookAtNextRoute(5.0f, 1.0f), null);

                    Utils.PlayVoicePikaBui_Kaisan(x.monsNo, x.controller.voicePlayer);
                });
            }

            DOVirtual.DelayedCall(1.5f, () => PlayerWork.isPlayerInputActive = true);
        }

        private Tweener ToCameraDefault(float duration = 0.5f)
        {
            Tw_CamFov = DOTween.To(() => fov, x => fov = x, 20.0f, duration);
            Tw_CamPitch = DOTween.To(() => pitch, x => pitch = x, 45.0f, duration);

            return Tw_CamFov;
        }

        private void MyLateUpdate(float deltaTime)
        {
            var action = pokeFactory.PokeList.Find(x => x.walkData.actionModel.IsAction);
            var retState = pokeFactory.PokeList.Find(x => x.CheckState<ReturnState>());

            foreach (var poke in pokeFactory.PokeList)
            {
                poke.walkData.actionModel.isNoneActionMember = action == null;
                poke.walkData.actionModel.isNoneStrayMember = retState == null;
            }
        }

        public void WalkCountClear(int TemotiNo)
        {
            var model = pokeFactory.PokeList.Find(x => x.TemotiNo == TemotiNo);
            model.walkData.totalMoveDistance = 0.0f;
            model.MonohiroiItemNo = -1;
            model.MonohiroiSealNo = -1;
        }

        public FieldObjectEntity GetPokeEntityByTemotiNo(int temotiNo)
        {
            return pokeFactory.PokeList.Find(x => x.TemotiNo == temotiNo).GetEntity();
        }

        public void DelPoke(FureaiPokeModel model)
        {
            Destroy(model.entity.gameObject);
            pokeWalkMng.GetPokeWalkers().Remove(model);
            EvDataManager.Instanse.FieldObjectEntityRemove(model.GetEntity());

            model.controller.OnPlayerNear -= pokeWalkMng.AddPoke;
            pokeFactory.PokeList.Remove(model);

            EntityManager.Remove(model.entity);
            EntityManager.BuildFieldEntities();
            model.Destroy();
        }

        public void Destroy()
        {
            Destroy(fureaiDataManager.gameObject);
            Destroy(gameObject);
        }

        private void FureaiEnterPokeCreate(uint SelectTemotiNo)
        {
            isEntering = true;
            isCreatingPoke = true;

            _ = fureaiDataManager.GetMD<HirobaEnterablePoke>();

            Sequencer.Start(CreatePokeForFureaiEnter(SelectTemotiNo));
        }

        // TODO
        private IEnumerator CreatePokeForFureaiEnter(uint SelectPoke_TemotiNo)
        {
            var pokePara = PlayerWork.playerParty.GetMemberPointer(SelectPoke_TemotiNo);
            WalkingCharacterModel mod = null;

            Vector2Int[] posArray;
            Vector2Int initGrid;
            if (EntityManager.activeFieldPlayer.worldPosition.x <= -45.0f)
            {
                posArray = EnterPosArrayRight;
                initGrid = new Vector2Int(51, 47);
            }
            else
            {
                posArray = EnterPosArrayLeft;
                initGrid = new Vector2Int(12, 47);
            }
            
            AddPokeCor = pokeFactory.AddPoke(pokePara, model =>
            {
                // TODO
            }, true, initGrid);

            yield return Sequencer.Start(AddPokeCor);

            pokeFactory.PokeList.ForEach(x => x.controller.getWalkingCharacters = pokeWalkMng.GetPokeWalkers);

        }

        // TODO
        public void HirobaEnterKaisan() { }

        // TODO
        public void HirobaExitSyuugou() { }

        // TODO
        private IEnumerator DoEndofFrame(Action act) { return null; }

        // TODO
        private IEnumerator RouteCheck(List<FureaiPokeModel> list) { return null; }

        private void AddFirstPoke()
        {
            pokeWalkMng.AddPoke(firstMod);
            firstMod = null;
        }

        // TODO
        public void SetSelectWalkingPoke(uint temotiNo) { }

        // TODO
        public int GetSelectWalkingPokeTemotiNo() { return 0; }

        // TODO
        public void SelectPokeHide() { }

        // TODO
        public void SelectPokeGotoPlayerNear() { }

        // TODO
        public void TalkStart(int temoti) { }

        // TODO
        private IEnumerator WaitEventEnd(FureaiPokeModel poke) { return null; }

        // TODO
        public void PlayVoice_TemotiID(uint temoti) { }

        public List<FureaiPokeModel> GetWalkingPokes()
        {
        	return this.pokeWalkMng.PokeWalkers;
        }

        // TODO
        private void OnDestroy() { }

        // TODO
        public void DebugSE() { }

        // TODO
        public void AddPokeWalkDebug() { }

        // TODO
        public void DebugAddPoke(bool CreatePlayerPosition = false) { }

        public void DelPoke()
        {
            if (pokeWalkMng.GetPokeWalkers().Count != 0)
                DelPoke(pokeWalkMng.GetDelPoke());
        }

        // TODO
        public void SubPoke() { }

        private void Debug_EnterPokeCreate()
        {
            FureaiEnterPokeCreate(1);
        }

        // TODO
        public void _DebugGetNearEmptyPosition() { }

        // TODO
        public void DebugStopTime() { }

        // TODO
        public void DebugCreatePoke() { }
    }
}