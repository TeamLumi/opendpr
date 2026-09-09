using Audio;
using Dpr.Demo;
using Dpr.Message;
using Dpr.MsgWindow;
using Effect;
using Pml.PokePara;
using Pml;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using XLSXContent;
using System.Collections.Generic;
using SmartPoint.AssetAssistant;
using Dpr.UI;
using Dpr.EvScript;
using Dpr.Field.Walking;
using System.Runtime.InteropServices;

namespace Dpr.SubContents
{
    public static class Utils
    {
        public const int GAME_FPS = 30;
        public const float GURUGURU_HEIGHT_UNION = 10.0f;
        public const float GURUGURU_HEIGHT_OTHER = 20.0f;

        private static readonly int[] RandMotions = new int[4] { 46, 47, 48, 49 };
        private static readonly int[] pikaRandomVoices = new int[4] { 19, 20, 22, 22 };
        private static readonly int[] evRandomVoices = new int[4] { 22, 22, 23, 23 };
        private static readonly int[] pikaRankVoices = new int[4] { 24, 23, 18, 17 };
        private static readonly int[] evRankVoices = new int[4] { 25, 24, 20, 19 };
        private static readonly int[] pikaNoticeVoice = new int[3] { 29, 27, 26 };
        private static readonly int[] evNoticeVoice = new int[3] { 32, 30, 28 };
        private static readonly int[] FT_motionIndex = new int[6] { 44, 41, 6, 7, 36, 9 };
        private static readonly int[] Pffin_motionIndex = new int[4] { 54, 44, 41, 32 };
        private static readonly int[] pikaPoffinVoice = new int[4] { 13, 14, 15, 16 };
        private static readonly int[] evPoffinVoice = new int[4] { 15, 16, 17, 18 };
        private static readonly int[] pikaDrowseVoice = new int[3] { 9, 10, 11 };
        private static readonly int[] evDrowseVoice = new int[3] { 9, 10, 11 };

        public static readonly Vector2Int[] directList = new Vector2Int[4]
        {
            Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right,
        };
        private static readonly DIR[] dirs = new DIR[4]
        {
            DIR.DIR_DOWN, DIR.DIR_UP, DIR.DIR_RIGHT, DIR.DIR_LEFT,
        };
        private const int GROUP_NAME_LNGTH = 5;
        private const int POKE_RARITY_VERY_RARE = 3;
        private const int POKE_RARITY_LEGEND_RARE = 2;
        private const int POKE_RARITY_SUB_LEGEND_RARE = 1;
        public static readonly MonsNo[] very_rare_monsno = new MonsNo[9]
        {
            MonsNo.MYUU,    MonsNo.SEREBHI, MonsNo.ZIRAATI,  MonsNo.DEOKISISU,
            MonsNo.FIONE,   MonsNo.MANAFI,  MonsNo.DAAKURAI, MonsNo.SHEIMI,
            MonsNo.ARUSEUSU,
        };
        public static readonly MonsNo[] legend_rare_monsno = new MonsNo[9]
        {
            MonsNo.MYUUTUU,  MonsNo.RUGIA,    MonsNo.HOUOU,    MonsNo.KAIOOGA,
            MonsNo.GURAADON, MonsNo.REKKUUZA, MonsNo.DHIARUGA, MonsNo.PARUKIA,
            MonsNo.GIRATHINA,
        };
        public static readonly MonsNo[] sub_legend_rare_monsno = new MonsNo[17]
        {
            MonsNo.HURIIZAA,   MonsNo.SANDAA,   MonsNo.FAIYAA,    MonsNo.RAIKOU,
            MonsNo.ENTEI,      MonsNo.SUIKUN,   MonsNo.REZIROKKU, MonsNo.REZIAISU,
            MonsNo.REZISUTIRU, MonsNo.RATHIASU, MonsNo.RATHIOSU,  MonsNo.YUKUSII,
            MonsNo.EMURITTO,   MonsNo.AGUNOMU,  MonsNo.HIIDORAN,  MonsNo.REZIGIGASU,
            MonsNo.KURESERIA,
        };

        public static bool PushA { get => (GameController.ButtonMask.A & GameController.push) != 0 || PushZL || PushZR; }
        public static bool PushB { get => (GameController.ButtonMask.B & GameController.push) != 0; }
        public static bool PushX { get => (GameController.ButtonMask.X & GameController.push) != 0; }
        public static bool PushY { get => (GameController.ButtonMask.Y & GameController.push) != 0; }
        public static bool PushR { get => (GameController.ButtonMask.R & GameController.push) != 0; }
        public static bool PushL { get => (GameController.ButtonMask.L & GameController.push) != 0; }
        public static bool PushZL { get => (GameController.ButtonMask.ZL & GameController.push) != 0; }
        public static bool PushZR { get => (GameController.ButtonMask.ZR & GameController.push) != 0; }
        public static bool PushPulsMinus { get => (GameController.ButtonMask.Plus & GameController.push) != 0 || (GameController.ButtonMask.Minus & GameController.push) != 0; }
        public static bool PushRStick { get => (GameController.ButtonMask.StickR & GameController.push) != 0; }
        public static bool PushAorB { get => PushA || PushB; }
        public static bool PressA { get => (GameController.ButtonMask.A & GameController.on) != 0 || PressZL || PressZR; }
        public static bool PressB { get => (GameController.ButtonMask.B & GameController.on) != 0; }
        public static bool PressX { get => (GameController.ButtonMask.X & GameController.on) != 0; }
        public static bool PressY { get => (GameController.ButtonMask.Y & GameController.on) != 0; }
        public static bool PressR { get => (GameController.ButtonMask.R & GameController.on) != 0; }
        public static bool PressL { get => (GameController.ButtonMask.L & GameController.on) != 0; }
        public static bool PressZR { get => (GameController.ButtonMask.ZL & GameController.on) != 0; }
        public static bool PressZL { get => (GameController.ButtonMask.ZR & GameController.on) != 0; }
        public static bool KeyLeft { get => (UIManager.StickLLeft & GameController.push) != 0; }
        public static bool KeyRight { get => (UIManager.StickLRight & GameController.push) != 0; }
        public static bool KeyDown { get => (UIManager.StickLDown & GameController.push) != 0; }
        public static bool KeyUp { get => (UIManager.StickLUp & GameController.push) != 0; }

        // TODO
        public static IEnumerator LoadEffect(EffectFieldID id, UnityAction<EffectData> OnLoad) { return null; }

        // TODO
        public static IEnumerator LoadEffect(EffectBattleID id, UnityAction<EffectData> OnLoad) { return null; }

        // TODO
        public static IEnumerator LoadEffect(EffectContestID id, UnityAction<EffectData> OnLoad) { return null; }

        public static IEnumerator LoadAsset(string path, Action<UnityEngine.Object> OnLoad, bool isVariant = false, bool useAssetUnloader = true, int id = AssetUnloader.ID_DEMO)
        {
            string[] variants = null;
            if (isVariant)
                variants = MessageHelper.GetLocalizeVariants();

            AssetManager.AppendAssetBundleRequest(path, true, null, variants);
            FieldManager.abUnloader.AddPath(path, id, useAssetUnloader);

            yield return AssetManager.DispatchRequests((eventType, name, asset) =>
            {
                if (eventType != RequestEventType.Activated)
                    return;

                OnLoad.Invoke(asset);
            });
        }

        public static string GetPokemonAssetbundleName(string AssetBundleName)
        {
            return "pokemons/field/" + AssetBundleName;
        }

        public static string GetBattlePokemonAssetbundleName(string AssetBundleName)
        {
            return "pokemons/battle/" + AssetBundleName;
        }

        // TODO
        public static string GetAssetNamebyPath(string AssetBundlePath) { return ""; }

        // TODO
        public static PokemonInfo.SheetCatalog GetPokemonCatalog(PokemonParam p) { return null; }

        // TODO
        public static string GetBallModelPath(BallId ballId) { return ""; }

        // TODO
        public static void DrawMessage(MsgWindowParam param, ref MsgWindow.MsgWindow window) { }

        public static MsgWindowParam CreateMsgWindowParam(string msgFileName, string labelName, bool inputClose = false, bool inputEnable = false)
        {
            var param = new MsgWindowParam
            {
                useMsgFile = MessageManager.Instance.GetMsgFile(msgFileName),
                labelName = labelName,
                inputEnabled = inputEnable,
                inputCloseEnabled = inputClose,
            };

            return param;
        }

        // TODO
        public static int GetUISortingOrderMax() { return 0; }

        public static int KinomiID_to_ItemID(int kinomiID)
        {
            // BUG: Not sure what 1307 is refering to here...
            // This method is supposed to convert from Berry ID to Item ID
            if (kinomiID == (int)ItemNo.ROZERUNOMI)
                return 1307;
            else
                return 148 + kinomiID;
        }

        // TODO
        public static IEnumerator ZukanTouroku(PokemonParam p, DemoSceneManager manager) { return null; }

        // TODO
        public static IEnumerator ZukanTouroku(PokemonParam p, DemoSceneManager manager, bool isGetMons) { return null; }

        // TODO
        public static AudioInstance PlayVoice(MonsNo monsNo, int formNo, int voiceNo, [Optional] UnityAction<AudioInstance> onFinished) { return null; }

        // TODO
        public static AudioInstance PlayVoiceEV(MonsNo monsNo, int formNo, int voiceNo, [Optional] UnityAction<AudioInstance> onFinished, [Optional] Transform t) { return null; }

        // TODO
        public static AudioInstance PlayVoice(MonsNo monsNo, int formNo, int voiceNo, VoicePlayerAmbient voicePlayer) { return null; }

        // TODO
        public static void StopVoice() { }

        // TODO
        public static string GetVoiceID_EV(MonsNo monsNo, int formNo, int voiceNo) { return ""; }

        // TODO
        public static string GetVoiceID(MonsNo monsNo, int formNo, int voiceNo) { return ""; }

        // TODO
        public static bool IsPikaV(MonsNo monsNo) { return false; }

        // TODO
        public static void PlayVoicePikaBui_NakayoshiRank(MonsNo monsNo, int FriendRank, VoicePlayerAmbient voicePlayer) { }

        // TODO
        public static int GetVoicePikaBui_NakayoshiRank(MonsNo monsNo, int FriendRank) { return 0; }

        // TODO
        public static int GetNakayoshiRankMotion(int FriendRank) { return 0; }

        // TODO
        public static void PlayVoicePikaBui_Notice(MonsNo monsNo, int FriendRank, VoicePlayerAmbient voicePlayer) { }

        // TODO
        public static void PlayVoicePikaBui_Poffin(MonsNo monsNo, int motionID) { }

        // TODO
        public static void PlayVoicePikaBui_Yobiyose(MonsNo monsNo, VoicePlayerAmbient voicePlayer) { }

        // TODO
        public static void PlayVoicePikaBui_Kaisan(MonsNo monsNo, VoicePlayerAmbient voicePlayer) { }

        // TODO
        public static void PlayVoicePikaBui_Roar(MonsNo monsNo, VoicePlayerAmbient voicePlayer) { }

        // TODO
        public static void PlayVoicePikaBui_Drowse(MonsNo monsNo, int sequence, VoicePlayerAmbient voicePlayer) { }

        // TODO
        public static void PlayVoicePikaBui_Touch(MonsNo monsNo, VoicePlayerAmbient voicePlayer) { }

        // TODO
        private static bool IsExistAnim(int index, AnimationPlayer animPlayer) { return false; }

        // TODO
        public static int GetExistAnim(FieldObjectEntity entity, int[] AnimationIdList) { return 0; }

        // TODO
        public static int GetExistAnim(AnimationPlayer animPlayer, int[] AnimationIdList) { return 0; }

        // TODO
        public static void WaitFrame(int frame, Action act) { }

        // TODO
        private static IEnumerator WaitFrameCoroutine(int frame, Action act) { return null; }

        // TODO
        public static int GetNakayoshiRank(uint friendship) { return 0; }

        public static void ArrayDestroy(object[] objects)
        {
            if (objects == null)
                return;

            for (int i=0; i<objects.Length; i++)
                objects[i] = null;
        }

        // TODO
        public static float Vector2ToAngle(Vector2 input, float offset) { return 0.0f; }

        // TODO
        public static bool IsInDistance(Vector3 pos1, Vector3 pos2, float targetDistance) { return false; }

        // TODO
        public static void GetAttribute(Vector3 pos, out int code, out int stop)
        {
            code = 0;
            stop = 0;
        }

        // TODO
        public static bool CheckAttributeEnterable(Vector2Int pos) { return false; }

        // TODO
        public static bool CheckAttributeEnterable(Vector3 pos) { return false; }

        // TODO
        public static DIR GetWallDir(Vector2Int pos) { return DIR.DIR_NOT; }

        // TODO
        public static bool IsAdjacent(Vector2Int pos, Vector2Int targetPos) { return false; }

        // TODO
        public static MoveTypeResult isEnterbleAttribute(Vector3 pos, MoveType moveType, bool isFureai = false) { return MoveTypeResult.OK; }

        // TODO
        public static MoveTypeResult isEnterbleAttribute(int code, int stop, MoveType moveType) { return MoveTypeResult.OK; }

        // TODO
        public static bool isNotExistsCollision(Vector3 pos) { return false; }

        // TODO
        public static void GuruguruRisingStart() { }

        // TODO
        public static void GuruguruFallStart() { }

        // TODO
        public static IEnumerator PlayerGuruguruStop(float angle, float height, bool isRising, Action OnComplete)
        {
            // TODO
            bool CheckHeight() { return default; }

            return default;
        }

        // TODO
        public static IEnumerator PlayerFallStop(float height, bool isRising, Action OnComplete)
        {
            // TODO
            bool CheckHeight() { return default; }

            return default;
        }

        public static IEnumerator OtherPlayerRising(float height, FieldObjectEntity entity, Action OnComplete)
        {
            bool CheckHeight()
            {
                return height <= entity.worldPosition.y;
            }

            entity.isLanding = false;
            var speed = 10.0f;

            while (!CheckHeight())
            {
                speed += 0.5f;

                float deltaTime = Sequencer.elapsedTime;

                entity.worldPosition = new Vector3(entity.worldPosition.x, entity.worldPosition.y + speed * deltaTime, entity.worldPosition.z);
                entity.yawAngle += deltaTime * 1050.0f;

                yield return null;
            }

            OnComplete?.Invoke();
        }

        public static void PlayerGuruguru(float deltaTime)
        {
            EntityManager.activeFieldPlayer.yawAngle += deltaTime * 1050.0f;
            EntityManager.activeFieldPlayer.GetAnimationPlayer().Play(FieldCharacterEntity.Animation.Idle);
            PlayerWork.isPlayerInputActive = false;
        }

        public static void PlayerRising(float deltaTime)
        {
            GameManager.fieldCamera.Target = EvDataManager.Instanse._dummyPlayer.transform;
            EntityManager.activeFieldPlayer.isLanding = false;
            EntityManager.activeFieldPlayer.worldPosition = new Vector3(EntityManager.activeFieldPlayer.worldPosition.x,
                                                                        EntityManager.activeFieldPlayer.worldPosition.y + deltaTime * 8.0f,
                                                                        EntityManager.activeFieldPlayer.worldPosition.z);
            PlayerWork.isPlayerInputActive = false;
        }

        public static void PlayerFall(float deltaTime)
        {
            GameManager.fieldCamera.Target = EvDataManager.Instanse._dummyPlayer.transform;
            EntityManager.activeFieldPlayer.worldPosition = new Vector3(EntityManager.activeFieldPlayer.worldPosition.x,
                                                                        EntityManager.activeFieldPlayer.worldPosition.y - deltaTime * 8.0f,
                                                                        EntityManager.activeFieldPlayer.worldPosition.z);
            PlayerWork.isPlayerInputActive = false;
        }

        public static float GetGuruGuruHeight(ZoneID zoneID)
        {
            return zoneID == ZoneID.UNION01 ? GURUGURU_HEIGHT_UNION : GURUGURU_HEIGHT_OTHER;
        }

        public static void PlayGuruguruSE(bool isRising)
        {
            if (ZoneWork.IsUnionRoom(PlayerWork.zoneID))
            {
                if (isRising)
                    AudioManager.Instance.PlaySe(AK.EVENTS.S_FI103, null);
                else
                    AudioManager.Instance.PlaySe(AK.EVENTS.S_FI104, null);
            }
        }

        // TODO
        public static IEnumerator CreateNPC(Vector2Int grid, string assetPath, Action<FieldObjectEntity> OnLoad, int id = 0) { return null; }

        // TODO
        public static void BGM_FadeOut(float duration, [Optional] Action OnComplete) { }

        // TODO
        public static void PlayCurrentFieldBGM(bool isIgnoreEvent = false) { }

        // TODO
        public static string CheckNGTrainerName(string baseTrainerName, MessageEnumData.MsgLangId langId) { return ""; }

        // TODO
        public static string CheckNGTrainerName(ref string trainerName, MessageEnumData.MsgLangId langId) { return ""; }

        // TODO
        public static string CheckNGTrainerName(ref string trainerName, MessageEnumData.MsgLangId langId, int cassetVersion) { return ""; }

        private static int GetPersonNameLength() {
            return 6;
        }

        // TODO
        public static string CheckNGPokeName(ref string nickname, MonsNo monsNo, MessageEnumData.MsgLangId langId) { return ""; }

        // TODO
        public static string CheckNGPokeName(PokemonParam param) { return ""; }

        private static int GetMonsNameLength() {
            return 6;
        }

        // TODO
        public static string CheckNGGroupName(ref string groupName, MessageEnumData.MsgLangId langId, int cassetVersion) { return ""; }

        // TODO
        private static string GetReplacedNGName(int cassetVersion) { return ""; }

        // TODO
        public static void OpenPasswordSoftwareKeyboard(Action<bool, string> result) { }

        // TODO
        public static int GetPokeRarityNum(MonsNo monsNo) { return 0; }

        // TODO
        public static bool CheckInvalidTradePoke(MonsNo monsNo) { return false; }

        // TODO
        public static string GetPlayerIdText(uint id) { return ""; }

        // TODO
        public static uint GetPlayerPartyCount() { return 0; }

        // TODO
        public static PokemonParam UpdateTranerMemo(PokemonParam updateParam) { return null; }

        public class AssetUnloader
        {
            public const int ID_FUREAI = 1;
            public const int ID_FIELD_TUREARUKI = 2;
            public const int ID_DEMO = 0;
            public const int ID_UG_COMMON = 4;
            private List<(string, int, bool)> paths;

            public AssetUnloader()
            {
                paths = new List<(string, int, bool)>();
            }

            public void AddPath(string path, int id = ID_DEMO, bool useAssetUnloader = true)
            {
                if (!string.IsNullOrEmpty(path))
                    paths.Add((path, id, useAssetUnloader));
            }

            public void Unload(int id = ID_DEMO)
            {
                paths.ForEach(x =>
                {
                    if (id == x.Item2)
                    {
                        if (x.Item3)
                        {
                            var unloader = new AssetBundleUnloader();
                            unloader.assetBundleName = x.Item1;
                            unloader.isUnloadAllLoadedObjects = true;
                            unloader.Release();
                            return;
                        }

                        AssetManager.UnloadAssetBundle(x.Item1);
                    }
                });

                paths.RemoveAll(x => id == x.Item2);
            }
        }

        public enum MoveTypeResult : int
        {
            OK = 0,
            CantMoveType = 1,
            CantEnter = 2,
        }
    }
}
