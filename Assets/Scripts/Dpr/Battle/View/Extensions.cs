using DG.Tweening;
using Dpr.Battle.Logic;
using Dpr.Battle.View.Systems;
using Dpr.SequenceEditor;
using Dpr.Trainer;
using Pml;
using Pml.PokePara;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using XLSXContent;

namespace Dpr.Battle.View
{
    public static class Extensions
    {
        private static ComparerMotionReplaceData _comparerCatalog = new ComparerMotionReplaceData();

        // TODO
        public static void SetRotation(this Transform self, Axis axis, float value) { }

        // TODO
        public static void SetOrigin(this Transform self, [Optional] Transform parent) { }

        // TODO
        public static void SetTwist(this Transform self, float twist, bool isLocal = false) { }

        // TODO
        public static void InverseScale(this Transform self, bool isYInverse = false) { }

        // TODO
        public static Tweener DOVector(this Vector3 self, Vector3 endValue, float duration) { return null; }

        // TODO
        public static BattleDefaultPlacementData.SheetDefaultCharaPlacementData GetTrainerPlacementData(this BattleDefaultPlacementData self, BtlRule rule, BtlvPos vPos, Size pokeSize, SEQ_DEF_DEFAULT_PLACEMENT placement, out Vector3 pos, out int rotY)
        {
            pos = Vector3.zero;
            rotY = 0;
            return null;
        }

        // TODO
        public static BattleDefaultPlacementData.SheetDefaultCharaPlacementData GetPokemonPlacement(this BattleDefaultPlacementData self, BtlRule rule, BtlvPos vPos, Size size, SEQ_DEF_DEFAULT_PLACEMENT placement, out Vector3 pos, out int rotY)
        {
            pos = Vector3.zero;
            rotY = 0;
            return null;
        }

        // TODO
        public static BattleDefaultPlacementData.SheetDefaultCameraPlacementData GetDefaultCameraPlacementData(this BattleDefaultPlacementData self, BtlRule rule, Size pokePlayer, Size pokeEnemy) { return null; }

        // TODO
        public static BattleWaitCameraData.SheetWaitCameraData GetWaitCameraData(this BattleWaitCameraData self, int index) { return null; }

        // TODO
        public static BattleWaitCameraData.SheetWaitCameraData[] GetWaitCameraDatas(this BattleWaitCameraData self, MainModule.BtlDetailRule rule) { return default; }

        // TODO
        public static BattleWaitCameraData.SheetWaitCameraData[] GetTutorialWaitCameraDatas(this BattleWaitCameraData self) { return null; }

        // TODO
        public static BattleWaitCameraData.SheetWaitCameraData[] GetDemoCaptureWaitCameraDatas(this BattleWaitCameraData self) { return null; }

        public static MaskPattern GetMaskPattern(this BattleWaitCameraData.SheetWaitCameraData self)
        {
        	return (MaskPattern)0;
        }

        // TODO
        public static BattleDataTable.SheetSetupIntroPlaySequenceData GetSetupIntroPlaySequenceData(this BattleDataTable self, BattleSetupIntroID id) { return null; }

        // TODO
        public static BattleDataTable.SheetBattleWazaMsgFrameData FindMsgFrameData(this BattleDataTable self, string hashKey) { return null; }

        // TODO
        public static BattleDataTable.SheetBattleMiscEffectData FindMiscEffectData(this BattleDataTable self, BtlEff eff) { return null; }

        // TODO
        public static BattleDataTable.SheetBattleConstant GetBattleConstant(this BattleDataTable self, BattleConstantKey key) { return null; }

        // TODO
        public static int GetBattleConstantInt(this BattleDataTable self, BattleConstantKey key) { return 0; }

        // TODO
        public static float GetBattleConstantFloat(this BattleDataTable self, BattleConstantKey key) { return 0.0f; }

        // TODO
        public static string GetBattleConstantString(this BattleDataTable self, BattleConstantKey key) { return null; }

        // TODO
        public static BattleDataTable.SheetMotionTimingData GetMotionTimingData(this BattleDataTable self, MonsNo monsNo, int formNo, Sex sex) { return null; }

        // TODO
        public static BattleDataTable.SheetMotionReplaceData GetMotionReplaceData(this BattleDataTable self, int uniqueId) { return null; }

        // TODO
        public static BattleDataTable.SheetPokemonEntryMotionData GetPokemonEntryMotionData(this BattleDataTable self, int index) { return null; }

        public static BattleDataTable.SheetAgeEyeBlink GetAgeEyeBlinkData(this BattleDataTable self, TrainerAge age)
        {
            for (int i=0; i<self.AgeEyeBlink.Length; i++)
            {
                if (self.AgeEyeBlink[i].age == age)
                    return self.AgeEyeBlink[i];
            }

            return null;
        }

        // TODO
        public static BattleDataTable.SheetDisableBlinkPokemon GetDisableBlinkPokemon(this BattleDataTable self, MonsNo no) { return null; }

        // TODO
        public static BattleDataTable.SheetPokemonMotionBlendTime GetPokemonMotionBlendTime(this BattleDataTable self, MonsNo no) { return null; }

        // TODO
        public static BattleDataTable.SheetInterpolationSequence GetInterpolationSequence(this BattleDataTable self, string seqName) { return null; }

        // TODO
        public static BattleViewSystem.BattleViewSide GetBattleSide(this BtlvPos pos) { return default; }

        // TODO
        public static Ease GetEase(this EaseFunc self) { return default; }

        // TODO
        public static BtlEff GetWheatherEffect(this BtlWeather self) { return BtlEff.BTLEFF_ETC_MEGA_EVOLUTION; }

        // TODO
        public static BtlEff GetGroundEffect(this BtlGround self) { return BtlEff.BTLEFF_ETC_MEGA_EVOLUTION; }

        // TODO
        public static BtlvPos GetBtlvPos(this WaitCameraTarget self) { return BtlvPos.BTL_VPOS_NEAR_1; }

        // TODO
        public static JointName GetJointName(this WaitCameraNode self) { return JointName.Origin; }

        // TODO
        public static BattlePokemonEntity.AnimationState GetAnimationState(this SEQ_DEF_ATK_MOT self) { return default; }

        // TODO
        public static BattleCharacterEntity.AnimationState ToTrainerAnimationState(this SEQ_DEF_TRAINER_MOTION self) { return default; }

        // TODO
        public static SEQ_DEF_TRAINER_MOTION ToDefTrainerMotion(this BattleCharacterEntity.AnimationState self) { return default; }

        // TODO
        public static void Reserve<T>(this List<T> self, int capacity) { }

        // TODO
        public static T At<T>(this IList<T> self, int index) { return default(T); }

        // TODO
        public static void PushBack<T>(this IList<T> self, T item) { }

        // TODO
        public static void EmplaceBack<T>(this IList<T> self, T item) { }

        // TODO
        public static T Front<T>(this IList<T> self) { return default(T); }

        // TODO
        public static T Back<T>(this IList<T> self) { return default(T); }
    }
}