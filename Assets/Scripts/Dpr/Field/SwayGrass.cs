using AK;
using AttributeData;
using Audio;
using Dpr.Battle.Logic;
using Pml;
using UnityEngine;

namespace Dpr.Field
{
    public static class SwayGrass
    {
        public const uint MAX_RENSA_COUNT = 99999999;
        private const int SWAY_GRASS_MAX = 4;
        private const int SWAY_GRASS_SEARCH_SIZE = 9;
        private static bool is_swaygrass_flag = false;
        private static ZoneID swayZone;
        private static GrassData[] grass_data = new GrassData[SWAY_GRASS_MAX];
        private static AudioInstance[] _grassAudio = new AudioInstance[SWAY_GRASS_MAX];
        public static GrassData work_data = new GrassData();
        public static uint rensa_count = 0;
        public static MonsNo rensa_mons;
        public static uint rensa_lv;
        public static bool BattleEndRensaStart = false;
        public static GameObject RootGrass = null;
        public const int POKETORE_CHARGE_MAX = 50;
        public static bool _callSwayBGM = false;
        public static bool _callStopSwayBGM = false;
        public const int LOT_NO_GRASS = 0;
        public const int LOT_FAIL = 1;
        public const int LOT_OK = 2;

        public static void SwayGrass_InitSwayGrass() 
        {
            // Global Sway reset
            is_swaygrass_flag = false;
            swayZone = ZoneID.UNKNOWN;
            rensa_count = 0;
            rensa_mons = 0;
            rensa_lv = 0;
            work_data = null;

            if (RootGrass == null)
            {
                RootGrass = new GameObject();
                RootGrass.name = "SwayGrass Root";
            }

            for (int i = 0; i < grass_data.Length; i++)
            {
                if (grass_data[i] == null)
                {
                    grass_data[i] = new GrassData();
                    grass_data[i].transObject = new GameObject();
                    grass_data[i].transObject.transform.SetParent(RootGrass.transform);
                    grass_data[i].transObject.name = string.Format("grass {0}", i);
                }

                else
                {
                    grass_data[i].enable = false;
                    grass_data[i].effectTime = 0f;
                    grass_data[i].rensaMons = false;
                    grass_data[i].rank = 0;
                    grass_data[i].random_iro = 0;
                    grass_data[i].random_kakure = 0;
                    grass_data[i].attricode = -1;
                }
            }

            StopSE();
            TairyouHasseiPokeManager.ForceStop = false;
            PlayerWork.PoketchData.ResetTempPoketore();
        }

        public static void StopSE()
        {
            for (int i = 0; i < _grassAudio.Length; i++)
            {
                if (_grassAudio[i] != null)
                {
                    _grassAudio[i].Stop();
                }
                _grassAudio[i] = null;
            }
        }

        public static bool SwayGrass_CheckSpEncount(ref FieldEncount.SWAY_ENC_INFO info, ref Vector3 pos, float size) 
        {
            int swayGrassIndex = CheckSwayGrass(ref pos, size);
            if (swayGrassIndex == -1)
                return false;

            work_data = grass_data[swayGrassIndex];
            if (rensa_count == 0)
            {
                info.Decide = false;
                info.Table = (RandomGroupWork.RandomValue(100) < 20) ? 0 : 1; // 20% chance for Table = 0, otherwise Table = 1
                return true;
            }

            else
            {
                info.Decide = true;
                info.Table = 0;
                return true;
            }
        }

        public static bool SwayGrass_CheckValid()
        {
            return is_swaygrass_flag;
        }

        public static int CheckSwayGrass(ref Vector3 pos, float size) 
        {
            if (!is_swaygrass_flag)
                return -1;

            for (int i = 0; i < grass_data.Length; i++)
            {
                GrassData tile = grass_data[i];
                if (!tile.enable)
                    continue;

                float dy = System.Math.Abs(tile.position.y - pos.y);
                if (dy > 1.0f)
                    continue;

                float dx = System.Math.Abs(tile.position.x - pos.x);
                float dz = System.Math.Abs(tile.position.z - pos.z);
                if (dx <= size && dz <= size)
                    return i;
            }

            return -1;
        }
        private static bool GetChainFlg(int inRound, BtlResult inBattleResult)
        {
            int rng = RandomGroupWork.RandomValue(100);
            int continueChain;

            if (inBattleResult == BtlResult.BTL_RESULT_WIN)
            {
                switch (inRound)
                {
                    case 1:
                        continueChain = 53;
                        break;
                    case 2:
                        continueChain = 63;
                        break;
                    case 3:
                        continueChain = 73;
                        break;
                    case 4:
                        continueChain = 83;
                        break;
                    default:
                        continueChain = 0;
                        break;
                }
            }
            else if (inBattleResult == BtlResult.BTL_RESULT_CAPTURE)
            {
                switch (inRound)
                {
                    case 1:
                        continueChain = 63;
                        break;
                    case 2:
                        continueChain = 73;
                        break;
                    case 3:
                        continueChain = 83;
                        break;
                    case 4:
                        continueChain = 93;
                        break;
                    default:
                        continueChain = 0;
                        break;
                }
            }
            else
            {
                continueChain = 0;
            }

            return rng < continueChain;
        }

        public static void SwayGrass_ChargePokeSearcher(byte diff) 
        {
            var itemInfo = ItemWork.GetItemInfo((int)ItemNo.POKETORE);
            if (itemInfo == null || itemInfo.count <= 0)
                return;

            var encData = PlayerWork.Enc_SV_Data;

            byte newCharge = (byte)(encData.PokeToreCharge + diff);

            encData.PokeToreCharge = (byte)((newCharge > POKETORE_CHARGE_MAX) ? POKETORE_CHARGE_MAX : newCharge);

            PlayerWork.Enc_SV_Data = encData;
        }

        public static int LotSwayGrass(ref Vector2Int grid, float height) 
        {
            // Reset all slots 
            for (int i = 0; i < grass_data.Length; i++)
            {
                if (grass_data[i] == null)
                    grass_data[i] = new GrassData();

                grass_data[i].enable = false;
            }

            // 9x9 grid around center tile
            const int AREA = SWAY_GRASS_SEARCH_SIZE * SWAY_GRASS_SEARCH_SIZE;
            int[] ranks = new int[AREA];
            int[] attrCodes = new int[AREA];

            int maxRankFound = 0;
            int grassCount = 0;

            for (int ry = 0; ry < SWAY_GRASS_SEARCH_SIZE; ry++)
            {
                for (int rx = 0; rx < SWAY_GRASS_SEARCH_SIZE; rx++)
                {
                    int index = ry * SWAY_GRASS_SEARCH_SIZE + rx;
                    
                    int dx = rx - 4;
                    int dy = ry - 4;


                    var cell = new Vector2Int(grid.x + dx, grid.y + dy);
                    GameManager.GetAttribute(cell, out int attrId, out _);
                    int code = GameManager.GetAttributeTable(attrId).Code;
                    attrCodes[index] = code;

                    if (!AttributeID.MATR_IsGrass(code))
                    {
                        ranks[index] = 0;
                        continue;
                    }

                    // Ring is mapped by Chebyshev distance from the center (4,4)
                    // This is explicitely written out, as there are no calls to math libraries here
                    if (dx == -4 || dx == 4 || dy == -4 || dy == 4)
                        ranks[index] = 4;
                    else if (dx == -3 || dx == 3 || dy == -3 || dy == 3)
                        ranks[index] = 3;
                    else if (dx == -2 || dx == 2 || dy == -2 || dy == 2)
                        ranks[index] = 2;
                    else if (dx == -1 || dx == 1 || dy == -1 || dy == 1)
                        ranks[index] = 1;

                    if (ranks[index] > maxRankFound)
                        maxRankFound = ranks[index];

                    grassCount++;
                }
            }

            if (grassCount == 0)
                return LOT_NO_GRASS;

            bool allDisabled = false;

            int iroRange = RensaNum(rensa_count, false);
            int swayPatchNo = grassCount >= SWAY_GRASS_MAX ? SWAY_GRASS_MAX : grassCount;
            if (swayPatchNo < 1)
                allDisabled = true;

            int threshold = maxRankFound;

            for (int i = 0; i < swayPatchNo; i++)
            {
                int tileIndex;
                do
                {
                    tileIndex = RandomGroupWork.RandomValue(AREA);
                }
                while (ranks[tileIndex] < threshold);

                // 9x9 index back to grid
                int rx = tileIndex % SWAY_GRASS_SEARCH_SIZE;
                int ry = (tileIndex / SWAY_GRASS_SEARCH_SIZE) % AREA;
                int dx = rx - 4;
                int dy = ry - 4;
                var cell = new Vector2Int(grid.x + dx, grid.y + dy);

                // Position from grid - Initial Y = height + 2, then raycast down to ground.
                Vector2 pos2 = FieldObjectEntity.GridToPosition(cell);
                grass_data[i].position = new Vector3(pos2.x, height + 2.0f, pos2.y);

                bool raycastHit = Physics.Raycast(grass_data[i].position, new Vector3(0.0f, -1.0f, 0.0f), out var hitInfo, 3.0f, Layer.Ground);
                if (raycastHit)
                    grass_data[i].position.y = hitInfo.point.y;
                grass_data[i].enable = raycastHit;

                grass_data[i].effectTime = 0.0f;
                grass_data[i].random_iro = RandomGroupWork.RandomValue(iroRange);
                grass_data[i].random_kakure = RandomGroupWork.RandomValue(128);
                grass_data[i].rank = ranks[tileIndex];
                grass_data[i].attricode = attrCodes[tileIndex];

                ranks[tileIndex] = -1;
                threshold -= 2;
                if (threshold < 2)
                    threshold = 1;
            }

            for (int i = 0; i < grass_data.Length; i++)
                allDisabled &= !grass_data[i].enable;

            if (allDisabled)
                return LOT_FAIL;

            swayZone = PlayerWork.zoneID;
            is_swaygrass_flag = true;
            TairyouHasseiPokeManager.ForceStop = true;

            // Stop existing audio and spawn patches + audio per enabled patch
            for (int i = 0; i < grass_data.Length; i++)
            {
                _grassAudio[i]?.Stop();

                if (!grass_data[i].enable)
                    continue;

                if (grass_data[i].transObject == null)
                {
                    grass_data[i].transObject = new GameObject();
                    grass_data[i].transObject.transform.SetParent(RootGrass.transform);
                    grass_data[i].transObject.name = string.Format("grass {0}", i);
                }
                grass_data[i].transObject.transform.position = grass_data[i].position;

                _grassAudio[i] = AudioManager.Instance.CreateSe(EVENTS.S_ENV001, EVENTS.STOP_S_ENV001, Vector3.zero, Quaternion.identity, grass_data[i].transObject.transform);
                _grassAudio[i].Play(OnAudioInstanceFinished);
            }

            _callSwayBGM = true;
            return LOT_OK;
        }

        private static void OnAudioInstanceFinished(AudioInstance instance) 
        {
            for (int i = 0; i < grass_data.Length; i++)
            {
                if (_grassAudio[i] != null && _grassAudio[i] == instance)
                {
                    _grassAudio[i] = null;
                    return;
                }
            }
        }

        public static bool SwayZone() 
        {
            return PlayerWork.zoneID == swayZone;
        }

        public static void Update(float deltatime) 
        {
            if (!is_swaygrass_flag)
                return;
            
            if (!SwayZone())
                {
                    SwayGrass_InitSwayGrass();
                    return;
                }

            for (int i = 0; i < grass_data.Length; i++)
            {
                if (grass_data[i].enable)
                {
                    PlayEffect(deltatime, i);
                }
            }
        }

        private static void PlayEffect(float deltatime, int i) 
        {
            ref var grassData = ref grass_data[i];

            if (grassData.effectTime > 0f)
            {
                grassData.effectTime -= deltatime;
                return;
            }

            EffectFieldID effectIndex;
            switch ((MapAttribute)grassData.attricode)
            {
                case MapAttribute.MATTR_E_SNOWGRASS_01:
                    effectIndex = EffectFieldID.EF_F_GRASS_03_SHAKE_01;
                    break;
                case MapAttribute.MATTR_E_KUSA_4:
                    effectIndex = EffectFieldID.EF_F_GRASS_02_SHAKE_01;
                    break;
                default:
                    effectIndex = EffectFieldID.EF_F_GRASS_04_SHAKE_01;
                    break;
            }

            if (grassData.random_kakure == 0)
                effectIndex = (EffectFieldID)((int)effectIndex + 1);

            FieldManager.Instance.CallEffect(effectIndex, grassData.position, null, null);

            if (grassData.random_iro == 0)
                FieldManager.Instance.CallEffect(EffectFieldID.EF_F_GRASS_SPARKLE, grassData.position, null, null);

            grassData.effectTime = (RandomGroupWork.Value() * 15f + 1f) / 30f;
        }

        public static int RensaNum(uint rensa, bool omamori = false) 
        {
            int[] shinyOdds = new int[41]             
            {
                4096, 3855, 3640, 3449, 3277, 3121, 2979, 2849, 2731, 2621,
                2521, 2427, 2341, 2259, 2185, 2114, 2048, 1986, 1927, 1872,
                1820, 1771, 1724, 1680, 1638, 1598, 1560, 1524, 1489, 1456,
                1310, 1285, 1260, 1236, 1213, 1192, 993, 799, 400, 200, 99,
            };

            int[] shinyCharmOdds = new int[41]         
            {
                3640, 3449, 3277, 3121, 2979, 2849, 2731, 2621, 2521, 2427,
                2341, 2259, 2185, 2114, 2048, 1986, 1927, 1872, 1820, 1771,
                1724, 1680, 1638, 1598, 1560, 1524, 1489, 1456, 1424, 1394,
                1260, 1236, 1213, 1192, 1170, 1149, 963, 780, 390, 195, 97
            };


            int[] oddsTable = omamori ? shinyCharmOdds : shinyOdds;

            if (rensa < oddsTable.Length)
                return oddsTable[rensa];
            else
                return oddsTable[oddsTable.Length - 1];
        }

        public static void BtlResultRensa(BtlResult result) 
        {
            if (!is_swaygrass_flag)
                return;

            if (work_data == null)
            {
                SwayGrass_InitSwayGrass();
                return;
            }

            rensa_count += 1;

            if (rensa_count >= MAX_RENSA_COUNT)
                rensa_count = MAX_RENSA_COUNT;

            PlayerWork.PoketchData.PoketoreSetCount((ushort)rensa_mons, (int)rensa_count);

            if (GetChainFlg(work_data.rank, result))
            {
                work_data = null;
            }
            else
            {
                SwayGrass_InitSwayGrass();
                _callStopSwayBGM = true;
            }

            if (is_swaygrass_flag)
            {
                _callSwayBGM = true;
                BattleEndRensaStart = true;
            }
        }

        public static byte RensaTalent() 
        {
            if (!is_swaygrass_flag)
                return 0;

            var rensa = rensa_count + 1;
            if (rensa >= MAX_RENSA_COUNT)
                rensa = MAX_RENSA_COUNT;

            switch (rensa)
            {
                case 0:
                    return 0;
                case 20:
                    return 1;
                case 30:
                    return 2;
                case 40:
                    return 3;
                case 100:
                    return 5;
                default:
                    if (rensa % 100 == 0)
                        return 5;
                    else
                        return 0;
            }
        }

        public class GrassData
        {
            public bool enable;
            public float effectTime;
            public bool rensaMons;
            public int rank;
            public int random_iro;
            public int random_kakure;
            public Vector3 position;
            public int attricode = -1;
            public GameObject transObject;
        }
    }
}