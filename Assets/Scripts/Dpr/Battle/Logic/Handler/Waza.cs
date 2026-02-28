using Pml;
using Pml.WazaData;
using Dpr.Battle.Logic;
using System;
using UnityEngine.EventSystems;

namespace Dpr.Battle.Logic.Handler
{
	public static class Waza
	{
        // TODO: cctor

        private const int FALSE = 0;
		private const int TRUE = 1;

		public const byte EVENT_WAZA_STICK_MAX = 8;
		private const int WORKIDX_STICK = 6;

		private static readonly GET_FUNC_TABLE_ELEM[] GET_FUNC_TABLE;

		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Texture;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_TrickRoom;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Juryoku;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Kiribarai;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Kawarawari;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Tobigeri;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Monomane;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Sketch;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_KonoyubiTomare;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Ikarinokona;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_KumoNoSu;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_KuroiKiri;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Haneru;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Oiwai;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_TeWoTunagu;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Noroi;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Denjiha;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_NayamiNoTane;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Yumekui;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_TriAttack;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Nettou;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_UtakatanoAria;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Osyaberi;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Makituku;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Uzusio;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_IkariNoMaeba;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Gamusyara;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_TikyuuNage;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Takuwaeru;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Hakidasu;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Nomikomu;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Counter;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_MilerCoat;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_MetalBurst;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Totteoki;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Ibiki;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Fuiuti;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Daibakuhatsu;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Kiaidame;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Juden;

		private const int JUDEN_STAT_NONE = 0;
		private const int JUDEN_STAT_START = 1;
		private const int JUDEN_STAT_WAZA = 2;

		private static readonly EventFactor.EventHandlerTable[] HandlerTable_HorobiNoUta;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_YadorigiNoTane;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_NekoNiKoban;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_AquaRing;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Abareru;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Sawagu;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Korogaru;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_TripleKick;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_GyroBall;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Revenge;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Jitabata;

		private static readonly handler_JitabataTableElem[] handler_JitabataTable;

		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Karagenki;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Sippegaesi;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Funka;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Siboritoru;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Siomizu;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_RenzokuGiri;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Dameosi;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Ketaguri;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_WeatherBall;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Tatumaki;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Kaminari;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Fubuki;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_ZettaiReido;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Jisin;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_SabakiNoTubute;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_MultiAttack;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_TechnoBaster;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_MezameruPower;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Hatakiotosu;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_MagicCoat;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Dorobou;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Trick;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Naminori;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Fumituke;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_DaiMaxHou;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Mineuti;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Koraeru;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Mamoru;

		private static readonly ushort[] WazaTable_Mamoru;

		private static readonly ushort[] RandRangeTable_Mamoru;

		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Recycle;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_PsycoShift;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Itamiwake;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Haradaiko;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Feint;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_IjigenHall;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_TuboWoTuku;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Nemuru;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Meromero;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Texture2;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Encore;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Chouhatu;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Kanasibari;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Present;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Fuuin;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Alomatherapy;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_IyasiNoSuzu;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Okimiyage;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Urami;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_JikoAnji;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_HeartSwap;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_PowerSwap;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_GuardSwap;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_PowerTrick;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_PowerShare;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_GuardShare;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_LockON;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Dokudoku;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Reflector;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_HikariNoKabe;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_SinpiNoMamori;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_SiroiKiri;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Oikaze;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Makibisi;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Dokubisi;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_StealthRock;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_NebaNebaNet;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_WideGuard;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_TatamiGaeshi;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Hensin;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_MikadukiNoMai;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_IyasiNoNegai;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Negaigoto;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Miraiyoti;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_HametuNoNegai;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Ieki;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Narikiri;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_TonboGaeri;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_KousokuSpin;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_BatonTouch;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Teleport;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Nagetukeru;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_DenjiFuyuu;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Tedasuke;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_FukuroDataki;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Nekodamasi;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Deaigasira;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_AsaNoHizasi;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Sunaatume;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_FlowerHeal;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_SoraWoTobu;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_ShadowDive;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Tobihaneru;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Diving;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_AnaWoHoru;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_SolarBeam;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_GodBird;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_RocketZutuki;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Tuibamu;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Hoobaru;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Waruagaki;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Michidure;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Onnen;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Tiisakunaru;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Marukunaru;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Haneyasume;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_KiaiPunch;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_YubiWoFuru;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_SizenNoTikara;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Negoto;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Manekko;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_GensiNoTikara;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_BenomShock;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Tatarime;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Acrobat;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_AsistPower;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_HeavyBomber;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_HeatStamp;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_ElectBall;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_EchoVoice;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Katakiuti;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Ikasama;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_BodyPress;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Mizubitasi;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_MahouNoKona;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_SimpleBeem;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_NakamaDukuri;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_ClearSmog;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Yakitukusu;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_TomoeNage;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Hoeru;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Utiotosu;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_KarawoYaburu;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_MirrorType;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_BodyPurge;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_PsycoShock;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_NasiKuzusi;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_WonderRoom;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_MagicRoom;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Inotigake;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_OsakiniDouzo;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Sakiokuri;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Rinsyou;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_FastGuard;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_SideChange;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_CourtChange;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_InisieNoUta;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Seityou;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_FreezeBolt;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_FlameSoul;

		private static readonly GetCombiWazaTypeTableElem[] CombiTbl;

		private static readonly EventFactor.EventHandlerTable[] HandlerTable_CombiWazaCommon;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Halloween;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Morinonoroi;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_FlowerGuard;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_TodomeBari;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_KogoeruHadou;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Hikkurikaesu;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_NeraiPunch;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_SuteZerifu;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_FlyingPress;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_FreezDry;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Souden;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_GrassField;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_MistField;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_ElecField;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_PhychoField;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_KingShield;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Blocking;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_ThousanArrow;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_HappyTime;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_ZibaSousa;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_BenomTrap;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_PlasmaFist;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_FairyLock;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Funjin;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_GeoControl;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_TrickGuard;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_NeedleGuard;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_SouthernWave;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_IjigenRush;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_AuraGuruma;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_DarkHole;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Tootika;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_MezameruDance;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Kahundango;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_CorePunisher;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Kagenui;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Kuraituku;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_TakoGatame;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Zyouka;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Tikarawosuitoru;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Togisumasu;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_SpeedSwap;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Moetukiru;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_KutibasiCanon;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_TrapShell;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Zidanda;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_AuroraVeil;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Saihai;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_MeteorDrive;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_ShadowSteal;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_PhotonGeyser;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Hanabisenyou;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_DaiWall;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_NeraiUti;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_HaisuiNoJin;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_SoulBeat;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Ochakai;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_DengekiKutibasi;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_TarShot;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_DragonArrow;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_InotiNoSizuku;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Newton;
		
		// TODO
		public static HandlerGetFunc getHandlerGetFunc(WazaNo waza) { return default; }
		
		// TODO
		public static bool Add(EventSystem pEventSystem, BTL_POKEPARAM poke, WazaNo waza, uint subPri) { return default; }
		
		public static bool canRegister(EventSystem pEventSystem, byte pokeID, WazaNo waza)
		{
			var uVar2 = pEventSystem.GetFactorContainer();
			var lVar3 = uVar2.SeekFactor(0,pokeID);
			if (lVar3 != null) {
			  var iVar4 = 8;
			  do {
			    var sVar1 = lVar3.GetSubID();
			    if (sVar1 == waza) {
			      return false;
			    }
			    if (iVar4 == 0) {
			      return false;
			    }
			    lVar3 = uVar2.GetNextFactor(lVar3,0);
			    iVar4 = iVar4 + -1;
			  } while (lVar3 != null);
			}
			return true;
		}
		
		// TODO
		public static void Remove(EventSystem pEventSystem, BTL_POKEPARAM poke, WazaNo waza) { }
		
		// TODO
		public static void RemoveForce(EventSystem pEventSystem, BTL_POKEPARAM poke, WazaNo waza) { }
		
		// TODO
		public static void removeHandlerForce(EventSystem pEventSystem, byte pokeID, WazaNo waza) { }
		
		public static void RemoveForceAll(EventSystem eventSystem, BTL_POKEPARAM poke)
		{
			var uVar1 = poke.GetID();
			var uVar2 = eventSystem.GetFactorContainer();
			var lVar3 = uVar2.SeekFactor(0,uVar1);
			while (lVar3 != 0) {
			  eventSystem.RemoveFactor(lVar3);
			  lVar3 = uVar2.SeekFactor(0,uVar1);
			}
		}
		
		// TODO
		public static bool common_checkActStart_isMyWaza(in EventFactor.EventHandlerArgs args, in byte pokeID) { return default; }
		
		// TODO
		public static bool common_IsMyEvent(in EventFactor.EventHandlerArgs args, EventVar.Label pokeIDLabel, byte pokeID) { return default; }
		
		// TODO
		public static void handler_common_ExeCheck2nd_FailOnRaid(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_common_ExeCheck2nd_FailOnRaidPlayerSide(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_common_ExeCheck2nd_FailOnRaidBoss(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_common_ExeCheck3rd_FailToG(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_common_ExeCheck3rd_FailToGWall(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static byte getEventVarTarget(in EventFactor.EventHandlerArgs args, int n) { return default; }
		
		// TODO
		public static void common_SetWazaEffectIndex(in EventFactor.EventHandlerArgs args, byte effectIndex) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Texture() { return default; }
		
		// TODO
		public static void handler_Texture(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_TrickRoom() { return default; }
		
		// TODO
		public static void handler_TrickRoom(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Juryoku() { return default; }
		
		// TODO
		public static void handler_Juryoku(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Kiribarai() { return default; }
		
		// TODO
		public static void handler_Kiribarai(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Kawarawari() { return default; }
		
		// TODO
		public static void handler_Kawarawari_DmgProc1(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Kawarawari_DmgProcEnd(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Kawarawari_DmgDetermine(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static bool handler_Kawarawari_SkipCheck(in EventFactor.SkipCheckHandlerArgs args) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Tobigeri() { return default; }
		
		// TODO
		public static void handler_Tobigeri_NoEffect(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Monomane() { return default; }
		
		// TODO
		public static void handler_Monomane(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Sketch() { return default; }
		
		// TODO
		public static void handler_Sketch(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static WazaNo sketch_GetTargetWaza(BTL_POKEPARAM target) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_KonoyubiTomare() { return default; }
		
		// TODO
		public static void handler_KonoyubiTomare_ExeCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_KonoyubiTomare_Exe(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_KonoyubiTomare_TemptTarget(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_KonoyubiTomare_TurnCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Ikarinokona() { return default; }
		
		// TODO
		public static void handler_Ikarinokona_TemptTarget(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_KumoNoSu() { return default; }
		
		// TODO
		public static void handler_KumoNoSu_NoEffCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_KumoNoSu(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_KuroiKiri() { return default; }
		
		// TODO
		public static void handler_KuroiKiri(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Haneru() { return default; }
		
		// TODO
		public static void handler_Haneru_CheckFail(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Haneru(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Oiwai() { return default; }
		
		// TODO
		public static void handler_Oiwai(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_TeWoTunagu() { return default; }
		
		// TODO
		public static void handler_TeWoTunagu(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Noroi() { return default; }
		
		// TODO
		public static void handler_Noroi_WazaParam(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Noroi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Noroi_ExeCheck3rd_FailToGWall(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Denjiha() { return default; }
		
		// TODO
		public static void handler_Denjiha(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_NayamiNoTane() { return default; }
		
		// TODO
		public static void handler_NayamiNoTane_NoEff(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_NayamiNoTane(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Yumekui() { return default; }
		
		// TODO
		public static void handler_Yumekui(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_TriAttack() { return default; }
		
		// TODO
		public static void handler_TriAttack(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Nettou() { return default; }
		
		// TODO
		public static void handler_Nettou(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_UtakatanoAria() { return default; }
		
		// TODO
		public static void handler_UtakatanoAria(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Osyaberi() { return default; }
		
		// TODO
		public static void handler_Osyaberi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Makituku() { return default; }
		
		// TODO
		public static void handler_Makituku(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Makituku_Str(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		public static bool makituku_GetStr(out ushort pStrID, WazaNo wazano)
		{
			if ((int)wazano < 0x81) {
			  if ((int)wazano < 0x24) {
			    if ((int)wazano == 0x14) {
			      pStrID = (ushort)0x43e;
			      return true;
			    }
			    if ((int)wazano == 0x23) {
			      pStrID = (ushort)0x448;
			      return true;
			    }
			  }
			  else {
			    if ((int)wazano == 0x53) {
			      pStrID = (ushort)0x460;
			      return true;
			    }
			    if ((int)wazano == 0x80) {
			      pStrID = (ushort)0x452;
			      return true;
			    }
			  }
			}
			else if ((int)wazano < 0x149) {
			  if ((int)wazano == 0xfa) {
			    pStrID = (ushort)0x45c;
			    return true;
			  }
			  if ((int)wazano == 0x148) {
			    pStrID = (ushort)0x468;
			    return true;
			  }
			}
			else {
			  if ((int)wazano == 0x1cf) {
			    pStrID = (ushort)0x464;
			    return true;
			  }
			  if ((int)wazano == 0x263) {
			    pStrID = (ushort)0x680;
			    return true;
			  }
			  if ((int)wazano == 0x30b) {
			    pStrID = (ushort)0x7b6;
			    return true;
			  }
			}
			pStrID = (ushort)0x7de;
			return false;
		}
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Uzusio() { return default; }
		
		// TODO
		public static void handler_Uzusio_CheckHide(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Uzusio_Dmg(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_IkariNoMaeba() { return default; }
		
		// TODO
		public static void handler_IkariNoMaeba(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		public static ushort common_CalcFixDamageByDefenderHp(BTL_POKEPARAM target, byte numerator, byte denominator)
		{
			var uVar2 = target.GetValue(0xe);
			var uVar1 = 0;
			if ((denominator & 0xff) != 0) {
			  uVar1 = ((uVar2 & 0xffff) * (numerator & 0xff)) / (denominator & 0xff);
			}
			if ((uVar1 & 0xffff) == 0) {
			  uVar1 = 1;
			}
			return (ushort)(uVar1);
		}
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Gamusyara() { return default; }
		
		// TODO
		public static void handler_Gamusyara_CheckNoEffect(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Gamusyara(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_TikyuuNage() { return default; }
		
		// TODO
		public static void handler_TikyuuNage(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Takuwaeru() { return default; }
		
		// TODO
		public static void handler_Takuwaeru_CheckExe(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Takuwaeru(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Hakidasu() { return default; }
		
		// TODO
		public static void handler_Hakidasu_CheckExe(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Hakidasu_Pow(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Hakidasu_Done(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Nomikomu() { return default; }
		
		// TODO
		public static void handler_Nomikomu_Ratio(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Counter() { return default; }
		
		// TODO
		public static void handler_Counter_CheckExe(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Counter_Target(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Counter_CalcDamage(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_MilerCoat() { return default; }
		
		// TODO
		public static void handler_MilerCoat_CheckExe(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_MilerCoat_Target(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_MilerCoat_CalcDamage(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_MetalBurst() { return default; }
		
		// TODO
		public static void handler_MetalBurst_CheckExe(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_MetalBurst_Target(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_MetalBurst_CalcDamage(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void common_Counter_ExeCheck(in EventFactor.EventHandlerArgs args, in WazaDamageType dmgType, in byte pokeID) { }
		
		// TODO
		public static void common_Counter_SetTarget(in EventFactor.EventHandlerArgs args, in WazaDamageType dmgType, in byte pokeID) { }
		
		// TODO
		public static void common_Counter_CalcDamage(in EventFactor.EventHandlerArgs args, in WazaDamageType dmgType, in int ratio, in byte pokeID) { }
		
		// TODO
		public static bool common_Counter_GetRec(in EventFactor.EventHandlerArgs args, in WazaDamageType dmgType, BTL_POKEPARAM.WAZADMG_REC rec, in byte pokeID) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Totteoki() { return default; }
		
		// TODO
		public static void handler_Totteoki(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Ibiki() { return default; }
		
		// TODO
		public static void handler_Ibiki_CheckFail_1(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Ibiki_CheckFail_2(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Fuiuti() { return default; }
		
		// TODO
		public static void handler_Fuiuti_NoEff(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static bool handler_Fuiuti_CheckSuccess(in EventFactor.EventHandlerArgs args, byte targetPokeID) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Daibakuhatsu() { return default; }
		
		// TODO
		public static void handler_Daibakuhatsu_ExeStart(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Daibakuhatsu_DmgDetermine(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Daibakuhatsu_ExeFix(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Kiaidame() { return default; }
		
		// TODO
		public static void handler_Kiaidame(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Juden() { return default; }
		
		// TODO
		public static void handler_Juden_Exe(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Juden_RemoveAllTarget(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Juden_Pow(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Juden_WazaStart(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Juden_WazaEnd(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_HorobiNoUta() { return default; }
		
		// TODO
		public static void handler_HorobiNoUta_Exe(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_YadorigiNoTane() { return default; }
		
		// TODO
		public static void handler_YadorigiNoTane_Param(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_NekoNiKoban() { return default; }
		
		// TODO
		public static void handler_NekoNiKoban(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_AquaRing() { return default; }
		
		// TODO
		public static void handler_AquaRing(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Abareru() { return default; }
		
		// TODO
		public static void handler_Abareru(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void abareru_Unlock(in EventFactor.EventHandlerArgs args, in byte pokeID) { }
		
		// TODO
		public static void handler_Abareru_SeqEnd(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Abareru_turnCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Sawagu() { return default; }
		
		// TODO
		public static void handler_Sawagu(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void Sawagu_CureLock(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Sawagu_SeqEnd(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Sawagu_turnCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Sawagu_CheckSickFail(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Sawagu_CheckInemuri(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Korogaru() { return default; }
		
		// TODO
		public static void handler_Korogaru_ExeFix(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Korugaru_Avoid(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Korogaru_NoEffect(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Korogaru_SeqEnd(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void common_Korogaru_Unlock(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Korogaru_Pow(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_TripleKick() { return default; }
		
		// TODO
		public static void handler_TripleKick(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_TripleKick_HitCount(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_GyroBall() { return default; }
		
		// TODO
		public static void handler_GyroBall(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static ushort common_CalcAgility(in EventFactor.EventHandlerArgs args, byte pokeID) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Revenge() { return default; }
		
		// TODO
		public static void handler_Revenge(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Jitabata() { return default; }
		
		// TODO
		public static void handler_Jitabata(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Karagenki() { return default; }
		
		// TODO
		public static void handler_Karagenki_AtkPow(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Karagenki_WazaPow(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Sippegaesi() { return default; }
		
		// TODO
		public static void handler_Sippegaesi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Funka() { return default; }
		
		// TODO
		public static void handler_Funka(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Siboritoru() { return default; }
		
		// TODO
		public static void handler_Siboritoru(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Siomizu() { return default; }
		
		// TODO
		public static void handler_Siomizu(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_RenzokuGiri() { return default; }
		
		// TODO
		public static void handler_RenzokuGiri(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Dameosi() { return default; }
		
		// TODO
		public static void handler_Dameosi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Ketaguri() { return default; }
		
		// TODO
		public static void handler_Ketaguri(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_WeatherBall() { return default; }

		private static bool get_WeatherBallParam(ref Waza.WeatherBallParam param, BtlWeather weather)
		{
			switch (weather)
			{
				case BtlWeather.BTL_WEATHER_SHINE:
					param.type = PokeType.HONOO;
					param.effIndex = (byte)BtlvWazaEffect_TurnType.BTLV_WAZAEFF_WEATHERBALL_SHINE;
					return true;
				case BtlWeather.BTL_WEATHER_RAIN:
					param.type = PokeType.MIZU;
					param.effIndex = (byte)BtlvWazaEffect_TurnType.BTLV_WAZAEFF_WEATHERBALL_RAIN;
					return true;
				case BtlWeather.BTL_WEATHER_SNOW:
					param.type = PokeType.KOORI;
					param.effIndex = (byte)BtlvWazaEffect_TurnType.BTLV_WAZAEFF_WEATHERBALL_SNOW;
					return true;
				case BtlWeather.BTL_WEATHER_SAND:
					param.type = PokeType.IWA;
					param.effIndex = (byte)BtlvWazaEffect_TurnType.BTLV_WAZAEFF_WEATHERBALL_SAND;
					return true;
				case BtlWeather.BTL_WEATHER_STORM:
					param.type = PokeType.MIZU;
					param.effIndex = (byte)BtlvWazaEffect_TurnType.BTLV_WAZAEFF_WEATHERBALL_RAIN;
					return true;
				case BtlWeather.BTL_WEATHER_DAY:
					param.type = PokeType.HONOO;
					param.effIndex = (byte)BtlvWazaEffect_TurnType.BTLV_WAZAEFF_WEATHERBALL_SHINE;
					return true;
				default:
					param.type = PokeType.NORMAL;
					param.effIndex = (byte)BtlvWazaEffect_TurnType.BTLV_WAZAEFF_WEATHERBALL_NORMAL;
					return false;
			}
		}

		// TODO
		public static void handler_WeatherBall_Type(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_WeatherBall_Pow(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_WeatherBall_ChangeGWaza(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Tatumaki() { return default; }
		
		// TODO
		public static void handler_Tatumaki_checkHide(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Tatumaki(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Kaminari() { return default; }
		
		// TODO
		public static void handler_Kaminari_checkHide(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Kaminari_excuseHitCalc(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Kaminari_hitRatio(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Fubuki() { return default; }
		
		// TODO
		public static void handler_Fubuki(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_ZettaiReido() { return default; }
		
		// TODO
		public static void handler_ZettaiReido_hitRatio(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Jisin() { return default; }
		
		// TODO
		public static void handler_Jisin_checkHide(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Jisin_damage(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SabakiNoTubute() { return default; }
		
		// TODO
		public static void handler_SabakiNoTubute(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_MultiAttack() { return default; }
		
		public static PokeType multiAttack_GetType(ItemNo item)
		{
			var uVar1 = 10;
			switch(item) {
			case 0x388:
			  return (PokeType)1;
			case 0x389:
			  return (PokeType)2;
			case 0x38a:
			  return (PokeType)3;
			case 0x38b:
			  return (PokeType)4;
			case 0x38c:
			  return (PokeType)5;
			case 0x38d:
			  return (PokeType)6;
			case 0x38e:
			  return (PokeType)7;
			case 0x38f:
			  return (PokeType)8;
			case 0x390:
			  return (PokeType)9;
			case 0x391:
			  break;
			case 0x392:
			  return (PokeType)0xb;
			case 0x393:
			  return (PokeType)0xc;
			case 0x394:
			  return (PokeType)0xd;
			case 0x395:
			  return (PokeType)0xe;
			case 0x396:
			  return (PokeType)0xf;
			case 0x397:
			  return (PokeType)0x10;
			case 0x398:
			  return (PokeType)0x11;
			default:
			  uVar1 = 0;
			}
			return uVar1;
		}
		
		// TODO
		public static void handler_MultiAttack(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_MultiAttack_ChangeGWaza(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_TechnoBaster() { return default; }
		
		public static void technoBaster_GetParam(ref PokeType pType, ref byte pEffectIdx, ItemNo item)
		{
			if ((item - 0x74U & 0xffff) < 4) {
			  pType = (PokeType)((char)(0xe090c0a >> (int)((item - 0x74U & 3) << 3)));
			  pEffectIdx = (byte)((char)item + -0x73);
			}
		}
		
		// TODO
		public static void handler_TechnoBaster(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_TechnoBaster_ChangeGWaza(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_MezameruPower() { return default; }
		
		// TODO
		public static void handler_MezameruPower_Type(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Hatakiotosu() { return default; }
		
		// TODO
		public static void handler_Hatakiotosu_WazaPow(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Hatakiotosu_EndHit(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_MagicCoat() { return default; }
		
		// TODO
		public static void handler_MagicCoat_ExeCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_MagicCoat(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_MagicCoat_Wait(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_MagicCoat_Reflect(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_MagicCoat_TurnCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Dorobou() { return default; }
		
		// TODO
		public static void handler_Dorobou_Start(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Dorobou(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Trick() { return default; }
		
		// TODO
		public static void handler_Trick(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Naminori() { return default; }
		
		// TODO
		public static void handler_Naminori_checkHide(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Naminori(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Fumituke() { return default; }
		
		// TODO
		public static void handler_Fumituke_DamegeProc(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Fumituke_HitCheckSkip(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_DaiMaxHou() { return default; }
		
		// TODO
		public static void handler_DaiMaxHou_DamegeProc(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Mineuti() { return default; }
		
		// TODO
		public static void handler_Mineuti(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Koraeru() { return default; }
		
		// TODO
		public static void handler_Koraeru(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Koraeru_Check(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Koraeru_TurnCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Mamoru() { return default; }
		
		// TODO
		public static void handler_Mamoru_StartSeq(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Mamoru_ExeCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Mamoru_ExeFail(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static bool handler_Mamoru_Core(in EventFactor.EventHandlerArgs args, in byte pokeID) { return default; }
		
		// TODO
		public static void IncrementMamoruCounter(in EventFactor.EventHandlerArgs args, in byte pokeID) { }
		
		// TODO
		public static void handler_Mamoru(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static bool mamoru_MsgAfterCritical(in EventFactor.EventHandlerArgs args, in byte pokeID) { return default; }
		
		// TODO
		public static void handler_Mamoru_Dmg(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Mamoru_MsgAfterCritical(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Mamoru_Off(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Recycle() { return default; }
		
		// TODO
		public static void handler_Recycle(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_PsycoShift() { return default; }
		
		// TODO
		public static void handler_PsycoShift(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Itamiwake() { return default; }
		
		// TODO
		public static void handler_Itamiwake(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		public static void itamiwake_CalcShiftHP(out int pAttackerHP, out int pDefenderHP, BTL_POKEPARAM pAttacker, BTL_POKEPARAM pDefender)
		{
			var iVar2 = pAttacker.GetValue(0xe);
			var iVar3 = pDefender.GetValue(0xe);
			var uVar1 = (uint)(iVar3 + iVar2) >> 1;
			pAttackerHP = uVar1 - iVar2;
			pDefenderHP = uVar1 - iVar3;
		}
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Haradaiko() { return default; }
		
		// TODO
		public static void handler_Haradaiko(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Feint() { return default; }
		
		// TODO
		public static void handler_Feint_MamoruBreak(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Feint_NoEffCheckBegin(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Feint_NoEffCheckEnd(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void SleepGuardSideEffects(in EventFactor.EventHandlerArgs args, byte pokeID, bool wakeFlag) { }
		
		// TODO
		public static void SleepGuardSideEffect(in EventFactor.EventHandlerArgs args, byte attackPokeId, byte targetPokeId, bool wakeFlag) { }
		
		// TODO
		public static void handler_Feint_AfterDamage(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void common_feint_proc(in EventFactor.EventHandlerArgs args, byte pokeID, ushort strID) { }
		
		// TODO
		public static void common_mamoruBreakAfter(in EventFactor.EventHandlerArgs args, byte attackPokeID, BTL_POKEPARAM target, ushort strID) { }
		
		// TODO
		public static void common_mamoruBreak_RemoveSideEff(in EventFactor.EventHandlerArgs args, byte pokeID, BTL_POKEPARAM target) { }
		
		// TODO
		public static bool common_IsExistGuardTypeSideEffect(in EventFactor.EventHandlerArgs args, byte targetPokeID, bool bIncludeNotCountupType) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_IjigenHall() { return default; }
		
		// TODO
		public static void handler_IjigenHall_AfterDamage(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_TuboWoTuku() { return default; }
		
		// TODO
		public static void handler_TuboWoTuku(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Nemuru() { return default; }
		
		// TODO
		public static void handler_Nemuru_exeCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Nemuru(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Meromero() { return default; }
		
		// TODO
		public static void handler_Meromero_CheckNoEffect(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Texture2() { return default; }
		
		// TODO
		public static void handler_Texture2(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Encore() { return default; }
		
		// TODO
		public static void handler_Encore(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Chouhatu() { return default; }
		
		// TODO
		public static void handler_Chouhatu(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Kanasibari() { return default; }
		
		// TODO
		public static void handler_Kanasibari(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static WazaNo kanashibari_GetTargetWaza(BTL_POKEPARAM target) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Present() { return default; }
		
		// TODO
		public static void handler_Present_Check(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Present_Fix(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Present_Pow(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Fuuin() { return default; }
		
		// TODO
		public static void handler_Fuuin(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Alomatherapy() { return default; }
		
		// TODO
		public static void handler_Alomatherapy_Exe(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Alomatherapy(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_IyasiNoSuzu() { return default; }
		
		// TODO
		public static void handler_IyasiNoSuzu_Exe(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_IyasiNoSuzu_RemoveAllTarget(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_IyasiNoSuzu(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static bool common_CureFriendPokeSick(in EventFactor.EventHandlerArgs args, byte attackerID, bool excludeOutOfWazaTarget, bool canWriteGenFlag) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Okimiyage() { return default; }
		
		// TODO
		public static void handler_Okimiyage(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Urami() { return default; }
		
		// TODO
		public static void handler_Urami(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_JikoAnji() { return default; }
		
		// TODO
		public static void handler_JikoAnji(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_HeartSwap() { return default; }
		
		// TODO
		public static void handler_HeartSwap(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_PowerSwap() { return default; }
		
		// TODO
		public static void handler_PowerSwap(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_GuardSwap() { return default; }
		
		// TODO
		public static void handler_GuardSwap(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_PowerTrick() { return default; }
		
		// TODO
		public static void handler_PowerTrick(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_PowerShare() { return default; }
		
		// TODO
		public static void handler_PowerShare(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_GuardShare() { return default; }
		
		// TODO
		public static void handler_GuardShare(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_LockON() { return default; }
		
		// TODO
		public static void handler_LockON(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Dokudoku() { return default; }
		
		// TODO
		public static void handler_Dokudoku(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Dokudoku_Done(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Reflector() { return default; }
		
		// TODO
		public static void handler_Reflector(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_HikariNoKabe() { return default; }
		
		// TODO
		public static void handler_HikariNoKabe(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SinpiNoMamori() { return default; }
		
		// TODO
		public static void handler_SinpiNoMamori(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SiroiKiri() { return default; }
		
		// TODO
		public static void handler_SiroiKiri(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Oikaze() { return default; }
		
		// TODO
		public static void handler_Oikaze(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Makibisi() { return default; }
		
		// TODO
		public static void handler_Makibisi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Dokubisi() { return default; }
		
		// TODO
		public static void handler_Dokubisi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_StealthRock() { return default; }
		
		// TODO
		public static void handler_StealthRock(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_NebaNebaNet() { return default; }
		
		// TODO
		public static void handler_NebaNebaNet(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_WideGuard() { return default; }
		
		// TODO
		public static void handler_WideGuard_ExeCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_WideGuard(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_TatamiGaeshi() { return default; }
		
		// TODO
		public static void handler_TatamiGaeshi_ExeCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_TatamiGaeshi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static bool common_SideEffectStdMsg(in EventFactor.EventHandlerArgs args, in byte pokeID, BtlSide side, BtlSideEffect effect, in BTL_SICKCONT cont, ushort strID) { return default; }
		
		// TODO
		public static bool common_SideEffectCore(in EventFactor.EventHandlerArgs args, byte pokeID, BtlSide side, BtlSideEffect effect, in BTL_SICKCONT cont, BtlStrType strType, uint strID, int strArg, bool replaceStrArg0ByExpandSide) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Hensin() { return default; }
		
		// TODO
		public static void handler_Hensin(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_MikadukiNoMai() { return default; }
		
		// TODO
		public static void handler_MikadukiNoMai(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_IyasiNoNegai() { return default; }
		
		// TODO
		public static void handler_IyasiNoNegai(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Negaigoto() { return default; }
		
		// TODO
		public static void handler_Negaigoto(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Miraiyoti() { return default; }
		
		// TODO
		public static void handler_Miraiyoti(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Miraiyoti_Decide(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void common_delayAttack(in EventFactor.EventHandlerArgs args, byte pokeID, BtlPokePos targetPos) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_HametuNoNegai() { return default; }
		
		// TODO
		public static void handler_HametuNoNegai(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_HametuNoNegai_Decide(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Ieki() { return default; }
		
		// TODO
		public static void handler_Ieki(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Narikiri() { return default; }
		
		// TODO
		public static void handler_Narikiri(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_TonboGaeri() { return default; }
		
		// TODO
		public static void handler_TonboGaeri(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_KousokuSpin() { return default; }
		
		// TODO
		public static void handler_KousokuSpin(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_BatonTouch() { return default; }
		
		// TODO
		public static void handler_BatonTouch(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Teleport() { return default; }
		
		// TODO
		public static bool teleport_isQuitBattle(in EventFactor.EventHandlerArgs args, in byte pokeID) { return default; }
		
		// TODO
		public static bool teleport_canQuitBattle(in EventFactor.EventHandlerArgs args, ref WazaFailCause pFailCause, in byte pokeID) { return default; }
		
		// TODO
		public static void handler_Teleport_ExeCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Teleport_ExeCheck_QuitBattle(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Teleport_ExeCheck_ChangePokemon(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Teleport(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Teleport_QuitBattle(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Teleport_ChangePokemon(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Teleport_ExMsg(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Nagetukeru() { return default; }
		
		// TODO
		public static void handler_Nagetukeru_ExeCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Nagetukeru_WazaPower(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Nagetukeru_DmgProcStart(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Nagetukeru_DmgAfter(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Nagetukeru_Done(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_DenjiFuyuu() { return default; }
		
		// TODO
		public static void handler_DenjiFuyuu_CheckFail(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_DenjiFuyuu(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Tedasuke() { return default; }
		
		// TODO
		public static void handler_Tedasuke_SkipAvoid(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Tedasuke_CheckHide(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Tedasuke_Ready(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static bool tedasuke_IsSuccess(in EventFactor.EventHandlerArgs args, byte pokeID) { return default; }
		
		// TODO
		public static void handler_Tedasuke_WazaPow(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Tedasuke_TurnCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_FukuroDataki() { return default; }
		
		// TODO
		public static void handler_FukuroDataki(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_FukuroDataki_Pow(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static BTL_POKEPARAM common_FukuroDataki_GetParam(in EventFactor.EventHandlerArgs args, byte myPokeID, byte idx) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Nekodamasi() { return default; }
		
		// TODO
		public static void handler_Nekodamasi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Deaigasira() { return default; }
		
		// TODO
		public static void handler_Deaigasira(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_AsaNoHizasi() { return default; }
		
		// TODO
		public static void handler_AsaNoHizasi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Sunaatume() { return default; }
		
		// TODO
		public static void handler_Sunaatume(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_FlowerHeal() { return default; }
		
		// TODO
		public static void handler_FlowerHeal(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SoraWoTobu() { return default; }
		
		// TODO
		public static void handler_SoraWoTobu_TameStart(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_ShadowDive() { return default; }
		
		// TODO
		public static void handler_ShadowDive_TameStart(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_ShadowDive_AfterDamage(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Tobihaneru() { return default; }
		
		// TODO
		public static void handler_Tobihaneru_TameStart(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Diving() { return default; }
		
		// TODO
		public static void handler_Diving_TameStart(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_AnaWoHoru() { return default; }
		
		// TODO
		public static void handler_AnaWoHoru_TameStart(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SolarBeam() { return default; }
		
		// TODO
		public static void handler_SolarBeam_TameSkip(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_SolarBeam_TameStart(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_SolarBeam_Power(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_GodBird() { return default; }
		
		// TODO
		public static void handler_GodBird_TameStart(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_RocketZutuki() { return default; }
		
		// TODO
		public static void handler_RocketZutuki_TameStart(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Tuibamu() { return default; }
		
		// TODO
		public static void handler_Tuibamu(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Hoobaru() { return default; }
		
		// TODO
		public static void handler_Hoobaru(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Hoobaru_Decide(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Waruagaki() { return default; }
		
		// TODO
		public static void handler_Waruagaki_KickBack(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Waruagaki_SeqStart(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Waruagaki_WazaParam(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Michidure() { return default; }
		
		// TODO
		public static void handler_Michidure_CheckFail(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void stickMitidureFactor(in EventFactor.EventHandlerArgs args, in byte pokeID) { }
		
		// TODO
		public static void handler_Michidure_Ready(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void removeMitidureFactor(in EventFactor.EventHandlerArgs args, in byte pokeID) { }
		
		// TODO
		public static void handler_Michidure_ActStart(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Michidure_WazaDamage(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Onnen() { return default; }
		
		// TODO
		public static void stickOnnenFactor(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void removeOnnenFactor(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Onnen_Ready(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Onnen_WazaDamage(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Onnen_ActStart(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Tiisakunaru() { return default; }
		
		// TODO
		public static void handler_Tiisakunaru(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Marukunaru() { return default; }
		
		// TODO
		public static void handler_Marukunaru(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Haneyasume() { return default; }
		
		// TODO
		public static void handler_Haneyasume(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_KiaiPunch() { return default; }
		
		// TODO
		public static void handler_KiaiPunch(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_YubiWoFuru() { return default; }
		
		// TODO
		public static void handler_YubiWoFuru(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_YubiWoFuru_Msg(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SizenNoTikara() { return default; }
		
		// TODO
		public static void handler_SizenNoTikara(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_SizenNoTikara_Msg(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Negoto() { return default; }
		
		// TODO
		public static void handler_Negoto(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Manekko() { return default; }
		
		// TODO
		public static void handler_Manekko_CheckParam(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static WazaNo manekko_GetTargetWaza(BattleEnv pBattleEnv) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_GensiNoTikara() { return default; }
		
		// TODO
		public static void handler_GensiNoTikara(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_BenomShock() { return default; }
		
		// TODO
		public static void handler_BenomShock(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Tatarime() { return default; }
		
		// TODO
		public static void handler_Tatarime(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Acrobat() { return default; }
		
		// TODO
		public static void handler_Acrobat(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_AsistPower() { return default; }
		
		// TODO
		public static void handler_AsistPower(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_HeavyBomber() { return default; }
		
		// TODO
		public static void handler_HeavyBomber(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_HeatStamp() { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_ElectBall() { return default; }
		
		// TODO
		public static void handler_ElectBall(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_EchoVoice() { return default; }
		
		// TODO
		public static void handler_EchoVoice(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Katakiuti() { return default; }
		
		// TODO
		public static void handler_Katakiuti(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Ikasama() { return default; }
		
		// TODO
		public static void handler_Ikasama(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_BodyPress() { return default; }
		
		// TODO
		public static void handler_BodyPress(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Mizubitasi() { return default; }
		
		// TODO
		public static void handler_Mizubitasi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_MahouNoKona() { return default; }
		
		// TODO
		public static void handler_MahouNoKona(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SimpleBeem() { return default; }
		
		// TODO
		public static void handler_SimpleBeem(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_NakamaDukuri() { return default; }
		
		// TODO
		public static void handler_NakamaDukuri(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_ClearSmog() { return default; }
		
		// TODO
		public static void handler_ClearSmog(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Yakitukusu() { return default; }
		
		// TODO
		public static void handler_Yakitukusu(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_TomoeNage() { return default; }
		
		// TODO
		public static void handler_TomoeNage(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Hoeru() { return default; }
		
		// TODO
		public static void handler_Hoeru(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Utiotosu() { return default; }
		
		// TODO
		public static void handler_Utiotosu(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static bool common_UtiotosuEffect(in EventFactor.EventHandlerArgs args, byte atkPokeID, byte targetPokeID) { return default; }
		
		// TODO
		public static bool common_UtiotosuEffect_falldown(in EventFactor.EventHandlerArgs args, byte atkPokeID, byte targetPokeID, BTL_POKEPARAM bppTarget) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_KarawoYaburu() { return default; }
		
		// TODO
		public static void handler_KarawoYaburu(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_MirrorType() { return default; }
		
		// TODO
		public static void handler_MirrorType(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_BodyPurge() { return default; }
		
		// TODO
		public static void handler_BodyPurge(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_PsycoShock() { return default; }
		
		// TODO
		public static void handler_PsycoShock(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_NasiKuzusi() { return default; }
		
		// TODO
		public static void handler_NasiKuzusi_CalcDmg(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_NasiKuzusi_HitCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_WonderRoom() { return default; }
		
		// TODO
		public static void handler_WonderRoom(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_MagicRoom() { return default; }
		
		// TODO
		public static void handler_MagicRoom(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Inotigake() { return default; }
		
		// TODO
		public static void handler_Inotigake_CalcDamage(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Inotigake_CheckDead(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_OsakiniDouzo() { return default; }
		
		// TODO
		public static void handler_OsakiniDouzo(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Sakiokuri() { return default; }
		
		// TODO
		public static void handler_Sakiokuri(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Rinsyou() { return default; }
		
		// TODO
		public static void handler_Rinsyou(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Rinsyou_Pow(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_FastGuard() { return default; }
		
		// TODO
		public static void handler_FastGuard(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SideChange() { return default; }
		
		// TODO
		public static void handler_SideChange(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_CourtChange() { return default; }
		
		// TODO
		public static void handler_CourtChange(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_InisieNoUta() { return default; }
		
		// TODO
		public static void handler_InisieNoUta(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Seityou() { return default; }
		
		// TODO
		public static void handler_Seityou(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_FreezeBolt() { return default; }
		
		// TODO
		public static void handler_FreezeBolt_TameStart(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_FlameSoul() { return default; }
		
		// TODO
		public static void handler_FlameSoul_Pow(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static Waza.CombiEffectType GetCombiWazaType(WazaNo waza1, WazaNo waza2) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_CombiWazaCommon() { return default; }
		
		// TODO
		public static void handler_CombiWaza_CheckExe(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_CombiWaza_Decide(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_CombiWaza_TypeMatch(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_CombiWaza_Pow(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_CombiWaza_ChangeEff(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_CombiWaza_AfterDmg(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Halloween() { return default; }
		
		// TODO
		public static void handler_Halloween(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Morinonoroi() { return default; }
		
		// TODO
		public static void handler_Morinonoroi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_FlowerGuard() { return default; }
		
		// TODO
		public static void handler_Tagayasu_CheckHide(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_FlowerGuard(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static bool common_GuardUpByPokeType(in EventFactor.EventHandlerArgs args, byte pokeID, byte pokeType) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_TodomeBari() { return default; }
		
		// TODO
		public static void handler_TodomeBari(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_KogoeruHadou() { return default; }
		
		// TODO
		public static void handler_KogoeruHadou(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Hikkurikaesu() { return default; }
		
		// TODO
		public static void handler_Hikkurikaesu(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_NeraiPunch() { return default; }
		
		// TODO
		public static void handler_NeraiPunch(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SuteZerifu() { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_FlyingPress() { return default; }
		
		// TODO
		public static void handler_FlyingPress(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_FreezDry() { return default; }
		
		// TODO
		public static void handler_FreezDry(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Souden() { return default; }
		
		// TODO
		public static void handler_Souden(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_GrassField() { return default; }
		
		// TODO
		public static void handler_GrassField(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_MistField() { return default; }
		
		// TODO
		public static void handler_MistField(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_ElecField() { return default; }
		
		// TODO
		public static void handler_ElecField(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_PhychoField() { return default; }
		
		// TODO
		public static void handler_PhychoField(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_common_GroundSet(in EventFactor.EventHandlerArgs args, byte pokeID, BtlGround ground) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_KingShield() { return default; }
		
		// TODO
		public static void handler_KingShield(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void kingShield_Success(in EventFactor.EventHandlerArgs args, in byte pokeID) { }
		
		// TODO
		public static void handler_KingShield_Success(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_KingShield_MsgAfterCritical(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_KingShield_DmgReaction(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Blocking() { return default; }
		
		// TODO
		public static void Blocking_Success(in EventFactor.EventHandlerArgs args, in byte pokeID) { }
		
		// TODO
		public static void handler_Blocking_Success(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Blocking_DmgReaction(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_ThousanArrow() { return default; }
		
		// TODO
		public static void handler_ThousanArrow_CancelFloat(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_ThousanArrow_AffEnable(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_ThousanArrow_CheckAffine(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_ThousanArrow(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_HappyTime() { return default; }
		
		// TODO
		public static void handler_HappyTime(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_ZibaSousa() { return default; }
		
		// TODO
		public static void handler_ZibaSousa(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_BenomTrap() { return default; }
		
		// TODO
		public static void handler_BenomTrap(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_PlasmaFist() { return default; }
		
		// TODO
		public static void handler_PlasmaFist(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_FairyLock() { return default; }
		
		// TODO
		public static void handler_FairyLock(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Funjin() { return default; }
		
		// TODO
		public static void handler_Funjin(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_GeoControl() { return default; }
		
		// TODO
		public static void handler_GeoControl_TameStart(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_TrickGuard() { return default; }
		
		// TODO
		public static void handler_TrickGuard(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_NeedleGuard() { return default; }
		
		// TODO
		public static void needleGuard_Success(in EventFactor.EventHandlerArgs args, in byte pokeID) { }
		
		// TODO
		public static void handler_NeedleGuard_Success(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_NeedleGuard_DmgReaction(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SouthernWave() { return default; }
		
		// TODO
		public static void handler_southernWave(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_IjigenRush() { return default; }
		
		// TODO
		public static void handler_IjigenRush(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_IjigenRush_AfterDamage(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_AuraGuruma() { return default; }
		
		// TODO
		public static void handler_AuraGuruma(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_AuraGuruma_Waza(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_AuraGuruma_ChangeGWaza(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_DarkHole() { return default; }
		
		// TODO
		public static void handler_DarkHole(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Tootika() { return default; }
		
		// TODO
		public static void tootika_Success(in EventFactor.EventHandlerArgs args, in byte pokeID) { }
		
		// TODO
		public static void handler_Tootika_Success(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Tootika_DmgReaction(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_MezameruDance() { return default; }
		
		// TODO
		public static void handler_MezameruDance_WazaParam(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Kahundango() { return default; }
		
		// TODO
		public static void handler_Kahundango_ExecuteCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Kahundango_RecoverCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Kahundango_RecoverFix(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Kahundango_Check_Affinity(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_CorePunisher() { return default; }
		
		// TODO
		public static void handler_CorePunisher_HitReal(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Kagenui() { return default; }
		
		// TODO
		public static void handler_Kagenui_HitReal(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Kuraituku() { return default; }
		
		// TODO
		public static bool kuraitukuCheck(in EventFactor.EventHandlerArgs args, BTL_POKEPARAM attack, BTL_POKEPARAM target) { return default; }
		
		// TODO
		public static void kuraitukuSet(in EventFactor.EventHandlerArgs args, byte attackPokeID, byte targetPokeID) { }
		
		// TODO
		public static void handler_Kuraituku(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_TakoGatame() { return default; }
		
		// TODO
		public static void handler_TakoGatame_NoEffCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_takoGatame(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Zyouka() { return default; }
		
		// TODO
		public static void handler_Zyouka(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Tikarawosuitoru() { return default; }
		
		// TODO
		public static void handler_Tikarawosuitoru(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Togisumasu() { return default; }
		
		// TODO
		public static void handler_Togisumasu(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SpeedSwap() { return default; }
		
		// TODO
		public static void handler_SpeedSwap(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Moetukiru() { return default; }
		
		// TODO
		public static void handler_Moetukiru_WazaMeltCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Moetukiru_ExeCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Moetukiru_DamageProcEnd(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_KutibasiCanon() { return default; }
		
		// TODO
		public static void handler_KutibasiCanon_BeforeFight(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_KutibasiCanon_DamageReaction(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_KutibasiCanon_WazaSeqEnd(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_KutibasiCanon_ReplaceWaza(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_KutibasiCanon_Canceled(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_KutibasiCanon_ExeCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_TrapShell() { return default; }
		
		// TODO
		public static void handler_TrapShell_BeforeFight(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_TrapShell_DamageProcEnd(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_TrapShell_ExeCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_TrapShell_WazaEnd(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Zidanda() { return default; }
		
		// TODO
		public static void handler_Zidanda_Dmg(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_AuroraVeil() { return default; }
		
		// TODO
		public static void handler_AuroraVeil_CheckExe(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_AuroraVeil(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Saihai() { return default; }
		
		// TODO
		public static void handler_Saihai(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_MeteorDrive() { return default; }
		
		// TODO
		public static void handler_MeteorDrive_WazaSeqStart(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_MeteorDrive_WazaSeqEnd(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_ShadowSteal() { return default; }
		
		// TODO
		public static void handler_ShadowSteal_DamageProcStart(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_PhotonGeyser() { return default; }
		
		// TODO
		public static void handler_PhotonGeyser_WazaParam(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Hanabisenyou() { return default; }
		
		// TODO
		public static void handler_Hanabisenyou_dmg_determine(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Hanabisenyou_no_effect(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void common_HanabisenyouReaction(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_DaiWall() { return default; }
		
		// TODO
		public static void handler_DaiWall(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_DaiWall_NoEffectCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_NeraiUti() { return default; }
		
		// TODO
		public static void handler_NeraiUti_Tempt(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_NeraiUti_Aim(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_HaisuiNoJin() { return default; }
		
		// TODO
		public static void handler_HaisuiNoJin_ExeCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_HaisuiNoJin(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SoulBeat() { return default; }
		
		// TODO
		public static void handler_SoulBeat_CheckExe(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_SoulBeat_Damage(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Ochakai() { return default; }
		
		// TODO
		public static bool ochakai_EatNuts(in EventFactor.EventHandlerArgs args, byte pokeID) { return default; }
		
		// TODO
		public static void handler_Ochakai(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_DengekiKutibasi() { return default; }
		
		// TODO
		public static void handler_DengekiKutibasi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_TarShot() { return default; }
		
		// TODO
		public static void handler_TarShot_Str(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_DragonArrow() { return default; }
		
		// TODO
		public static void handler_DragonArrow_Param(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_DragonArrow_Inc(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_DragonArrow_Msg(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_InotiNoSizuku() { return default; }
		
		// TODO
		public static void handler_InotiNoSizuku_Msg(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Newton() { return default; }
		
		// TODO
		public static void handler_Newton(in EventFactor.EventHandlerArgs args, byte pokeID) { }

		public enum CombiEffectType : int
		{
			COMBI_EFFECT_NULL = 0,
			COMBI_EFFECT_RAINBOW = 1,
			COMBI_EFFECT_BURNING = 2,
			COMBI_EFFECT_MOOR = 3,
		}

		public delegate EventFactor.EventHandlerTable[] HandlerGetFunc();

		private struct GET_FUNC_TABLE_ELEM
		{
			public WazaNo waza;
			public HandlerGetFunc func;
			
			public GET_FUNC_TABLE_ELEM(WazaNo waza, HandlerGetFunc func)
			{
				this.waza = waza;
				this.func = func;
			}
		}

		private struct handler_JitabataTableElem
		{
			public ushort dot_ratio;
			public ushort pow;
			
			public handler_JitabataTableElem(ushort dot_ratio, ushort pow)
			{
				this.dot_ratio = dot_ratio;
				this.pow = pow;
			}
		}

		private struct WeatherBallParam
		{
			public PokeType type;
			public byte effIndex;
		}

		private struct GetCombiWazaTypeTableElem
		{
			public WazaNo waza1;
			public WazaNo waza2;
			public CombiEffectType effect;
			
			public GetCombiWazaTypeTableElem(WazaNo waza1, WazaNo waza2, CombiEffectType effect)
			{
				this.waza1 = waza1;
				this.waza2 = waza2;
				this.effect = effect;
			}
		}

	}
}