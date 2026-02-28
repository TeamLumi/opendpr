using Pml.PokePara;
using Pml;
using System;
using UnityEngine;
using Dpr.UI;
using Pml.Item;

namespace Dpr.Item
{
    public class ItemInfo : ItemData
    {
        public const int ItemSaveSize = 3000;
        public const int ItemMaxCount = 999;
        public const int ItemShortcutSaveSize = 4;
        public const int ShortcutDirectionNone = -1;
        public const int ShortcutDirectionUp = 0;
        public const int ShortcutDirectionDown = 1;
        public const int ShortcutDirectionLeft = 2;
        public const int ShortcutDirectionRight = 3;

        private static readonly PrmID[] CheckAllowUsePrmIDs = new PrmID[31]
        {
            PrmID.ABILITY_GUARD, PrmID.CRITICAL_UP,    PrmID.ATTACK_UP,    PrmID.DEFENCE_UP,
            PrmID.AGILITY_UP,    PrmID.HIT_UP,         PrmID.SP_ATTACK_UP, PrmID.SP_DEFENCE_UP,
            PrmID.LV_UP,         PrmID.PP_RCV_POINT,   PrmID.PP_UP,        PrmID.EXP_LIMIT_FLAG,
            PrmID.HP_EXP,        PrmID.POWER_EXP,      PrmID.DEFENCE_EXP,  PrmID.AGILITY_EXP,
            PrmID.SP_ATTACK_EXP, PrmID.SP_DEFENCE_EXP, PrmID.FRIEND1,      PrmID.FRIEND2,
            PrmID.FRIEND3,       PrmID.SLEEP_RCV,      PrmID.POISON_RCV,   PrmID.BURN_RCV,
            PrmID.ICE_RCV,       PrmID.PARALYZE_RCV,   PrmID.PANIC_RCV,    PrmID.MEROMERO_RCV,
            PrmID.HP_RCV,        PrmID.DEATH_RCV,      PrmID.EVOLUTION,
        };
        private static readonly int[] SeikakuMintItemNos = new int[21]
        {
            (int)ItemNo.SAMISIGARIMINTO, (int)ItemNo.IZIPPARIMINTO, (int)ItemNo.YANTYAMINTO,   (int)ItemNo.YUKANMINTO,
            (int)ItemNo.ZUBUTOIMINTO,    (int)ItemNo.WANPAKUMINTO,  (int)ItemNo.NOUTENKIMINTO, (int)ItemNo.NONKIMINTO,
            (int)ItemNo.HIKAEMEMINTO,    (int)ItemNo.OTTORIMINTO,   (int)ItemNo.UKKARIMINTO,   (int)ItemNo.REISEIMINTO,
            (int)ItemNo.ODAYAKAMINTO,    (int)ItemNo.OTONASIIMINTO, (int)ItemNo.SINTYOUMINTO,  (int)ItemNo.NAMAIKIMINTO,
            (int)ItemNo.OKUBYOUMINTO,    (int)ItemNo.SEKKTIMINTO,   (int)ItemNo.YOUKIMINTO,    (int)ItemNo.MUJYAKIMINTO,
            (int)ItemNo.MAZIMEMINTO,
        };
        private static readonly Seikaku[] SeikakuMintSeikakuTypes = new Seikaku[21]
        {
            Seikaku.SAMISHIGARI, Seikaku.IJIPPARI,  Seikaku.YANTYA,   Seikaku.YUUKAN,
            Seikaku.ZUBUTOI,     Seikaku.WANPAKU,   Seikaku.NOUTENKI, Seikaku.NONKI,
            Seikaku.HIKAEME,     Seikaku.OTTORI,    Seikaku.UKKARIYA, Seikaku.REISEI,
            Seikaku.ODAYAKA,     Seikaku.OTONASHII, Seikaku.SINTYOU,  Seikaku.NAMAIKI,
            Seikaku.OKUBYOU,     Seikaku.SEKKATI,   Seikaku.YOUKI,    Seikaku.MUJYAKI,
            Seikaku.MAJIME,
        };
        private static readonly Seikaku[] DisabledMajimeMintSeikakuTypes = new Seikaku[5]
        {
            Seikaku.GANBARIYA, Seikaku.SUNAO, Seikaku.TEREYA, Seikaku.KIMAGURE,
            Seikaku.MAJIME,
        };
        private static readonly ItemNo[] KanpouyakuItemNos = new ItemNo[4]
        {
            ItemNo.MAHINAOSI, ItemNo.KAIHUKUNOKUSURI, ItemNo.MANTANNOKUSURI, ItemNo.SUGOIKIZUGUSURI,
        };

        private ushort _workNo;
        private bool _isDummy;
        private int _dummyCount;
        private bool _dummyIsVanishNew;
        private bool _dummyIsFavorite;
        private ushort _dummySaveSortNumber;
        private bool _dummyIsShowWazaName;
        private int _id = -1;
        private int _type = -1;
        private CategoryType _categoryType = CategoryType.Length;
        private int _price = -1;
        private int _groupId = -1;
        private int _sortId = -1;

        // TODO: Properties
        public int count
        {
            set
            {
                if (_isDummy)
                {
                    _dummyCount = value;
                    if (_dummySaveSortNumber != 0)
                        return;

                    _dummySaveSortNumber = (ushort)(ItemWork.GetValidSaveSortNumberCount(Category) + 1);
                    ItemWork.UpdateListSort(this);
                }
                else
                {
                    var item = PlayerWork.GetItem(_workNo);

                    // This seems ignored?
                    int count = Mathf.Clamp(value, 0, ItemMaxCount);

                    item.Count = value;
                    PlayerWork.SetItem(_workNo, item);

                    if (item.SortNumber != 0)
                        return;

                    item = PlayerWork.GetItem(_workNo);
                    item.SortNumber = (ushort)(ItemWork.GetValidSaveSortNumberCount(Category) + 1);
                    PlayerWork.SetItem(_workNo, item);
                    ItemWork.UpdateListSort(this);
                }
            }
            get => _isDummy ? _dummyCount : PlayerWork.GetItem(_workNo).Count;
        }
        public bool bIsNew
        {
            set
            {
                if (_isDummy)
                {
                    _dummyIsFavorite = value;
                }
                else
                {
                    var item = PlayerWork.GetItem(_workNo);
                    item.VanishNew = value;
                    PlayerWork.SetItem(_workNo, item);
                }
            }
            get => _isDummy ? _dummyIsVanishNew : PlayerWork.GetItem(_workNo).VanishNew;
        }
        public bool bIsFavorite
        {
            set
            {
                if (_isDummy)
                {
                    _dummyIsFavorite = value;
                }
                else
                {
                    var item = PlayerWork.GetItem(_workNo);
                    item.FavoriteFlag = value;
                    PlayerWork.SetItem(_workNo, item);
                }
            }
            get => _isDummy ? _dummyIsFavorite : PlayerWork.GetItem(_workNo).FavoriteFlag;
        }
        public ushort SaveSortNumber
        {
            set
            {
                if (_isDummy)
                {
                    _dummySaveSortNumber = (ushort)(value + 1);
                }
                else
                {
                    var item = PlayerWork.GetItem(_workNo);
                    item.SortNumber = (ushort)(value + 1);
                    PlayerWork.SetItem(_workNo, item);
                }
            }
            get => _isDummy ? (ushort)(_dummySaveSortNumber - 1) : (ushort)(PlayerWork.GetItem(_workNo).SortNumber - 1);
        }
        public bool IsShowWazaName
        {
            set
            {
                if (_isDummy)
                {
                    _dummyIsShowWazaName = value;
                }
                else
                {
                    var item = PlayerWork.GetItem(_workNo);
                    item.ShowWazaNameFlag = value;
                    PlayerWork.SetItem(_workNo, item);
                }
            }
            get => _isDummy ? _dummyIsShowWazaName : PlayerWork.GetItem(_workNo).ShowWazaNameFlag;
        }
        public int Id
        {
            get
            {
                if (_id == -1)
                    _id = GetParam(PrmID.ITEMNUMBER);

                return _id;
            }
        }
        public string Name { get; }
        public string DescriptionText { get; }
        public int Type { get; }
        public CategoryType Category
        {
            get
            {
                if (_categoryType == CategoryType.Length)
                    _categoryType = (CategoryType)GetParam(PrmID.F_POCKET);

                return _categoryType;
            }
        }
        public int Price { get; }
        public int GroupId { get; }
        public int SortId { get; }
        public bool CanSell { get; }
        public int SellPrice { get; }
        public bool IsLevelUp { get; }
        public bool IsNuts { get; }
        public bool IsImportant { get; }
        public bool IsAllowEquip { get; }
        public bool IsUseful { get; }
        public bool IsNoSpend { get; }
        public int ShortcutId { get; }
        public bool IsRegisterShorcut { get; }
        public BallId BallID { get => GetBallID(_workNo); }
        public bool IsJewel { get; }
        public bool IsBattleSelect { get; }
        public bool IsRecoveryHp { get; }
        public int RecoveryHpValue { get; }
        public bool IsRecoveryPp { get; }
        public int RecoveryPpValue { get; }
        public bool IsRecoveryPpAll { get; }
        public bool IsPpUp { get; }
        public bool IsPp3Up { get; }
        public bool IsRecoveryAllDead { get; }
        public bool IsRecoveryDead { get; }
        public bool IsRecoveryPoison { get; }
        public bool IsRecoveryBurn { get; }
        public bool IsRecoveryIce { get; }
        public bool IsRecoveryMeroMero { get; }
        public bool IsRecoveryPanic { get; }
        public bool IsRecoveryParalyze { get; }
        public bool IsRecoverySleep { get; }
        public bool IsHpExp { get; }
        public int HpExpValue { get => GetParam(PrmID.HP_EXP_POINT); }
        public bool IsAttackExp { get; }
        public int AttackExpValue { get => GetParam(PrmID.POWER_EXP_POINT); }
        public bool IsDeffenceExp { get; }
        public int DeffenceExpValue { get => GetParam(PrmID.DEFENCE_EXP_POINT); }
        public bool IsSpAttackExp { get; }
        public int SpAttackExpValue { get => GetParam(PrmID.SP_ATTACK_EXP_POINT); }
        public bool IsSpDeffenceExp { get; }
        public int SpDeffenceExpValue { get => GetParam(PrmID.SP_DEFENCE_EXP_POINT); }
        public bool IsAgilityExp { get; }
        public int AgilityExpValue { get => GetParam(PrmID.AGILITY_EXP_POINT); }
        public int NameSortOrder { get; set; }

        public ItemInfo(ushort item_no)
        {
            _workNo = item_no;
        }

        public ItemInfo(ushort item_no, bool is_dummy) : this(item_no)
        {
            _isDummy = is_dummy;
        }

        // TODO
        public int GetParam(PrmID pid) { return 0; }

        public int AddItem(int num = 1)
        {
            count = Mathf.Clamp(count + num, 0, ItemMaxCount);
            return count;
        }

        // TODO
        public int SubItem(int num = 1) { return 0; }

        // TODO
        public bool IsAddItem(int num = 1) { return false; }

        public bool IsCategory(CategoryType category)
        {
        	if ((int)this._categoryType == 9) {
        	  this._categoryType = (CategoryType)(GetParam(0xe));
        	  this._categoryType = (CategoryType)(this._categoryType);
        	}
        	return this._categoryType == category;
        }

        public bool IsWazaMachine()
        {
        	if ((int)this._categoryType == 9) {
        	  this._categoryType = (CategoryType)(GetParam(0xe));
        	  this._categoryType = (CategoryType)(this._categoryType);
        	}
        	return (int)this._categoryType == 5;
        }

        public eItemType GetItemType()
        {
        	if (this._type != -1) {
        	}
        	var uVar1 = GetParam(0x12);
        	this._type = uVar1;
        	return (eItemType)0;
        }

        // TODO
        public FieldFunctionType GetFieldFunctionType() { return FieldFunctionType.NONE; }

        public static void LoadItemIcon(int itemId, Action<Sprite> onLoadedCallback, bool isUnload = false, bool isLarge = false)
        {
            string spriteName = "item_" + GetParam((ushort)itemId, PrmID.ICONID).ToString("0000");
            if (itemId == (int)ItemNo.ZITENSYA)
                spriteName += "_" + PlayerWork.bicycleColor.ToString();

            if (isLarge)
                spriteName += "_L";

            var sprite = UIManager.Instance.GetAtlasSprite(SpriteAtlasID.TEXTUREMASS, spriteName);
            onLoadedCallback?.Invoke(sprite);
        }

        // TODO
        public bool CheckAllowUse(bool isBattle) { return false; }

        // TODO
        public bool GetSeikaku(out Seikaku seikaku)
        {
            seikaku = Seikaku.GANBARIYA;
            return false;
        }

        // TODO
        public bool IsUsableMajimeMint(Seikaku seikaku) { return false; }

        // TODO
        public bool GetFriendshipValue(uint currentValue, out int addValue, out int maxUsableCount)
        {
            addValue = 0;
            maxUsableCount = 0;
            return false;
        }

        // TODO
        public bool IsKanpouyaku() { return false; }

        public enum SortType : int
        {
            Type = 0,
            Name = 1,
            New = 2,
            Favorite = 3,
        }

        public enum CategoryType : int
        {
            Heal = 0,
            Ball = 1,
            Battle = 2,
            Nuts = 3,
            Tools = 4,
            WazaMachine = 5,
            Treasure = 6,
            Food = 7,
            Important = 8,
            Length = 9,
        }

        public enum eItemType : int
        {
            Pocket = 0,
            Kusuri = 1,
            Equip = 2,
            Normal = 3,
            Battle = 4,
            Ball = 5,
            Mail = 6,
            WazaMachine = 7,
            Kinomi = 8,
            Event = 9,
            Etc = 10,
            Dummy = 255,
        }
    }
}