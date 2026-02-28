using Pml;
using Pml.WazaData;
using Dpr.Battle.Logic;
using System;
using UnityEngine.EventSystems;

namespace Dpr.Battle.Logic.Handler
{
	public static class Tokusei
	{
        // TODO: cctor

        private const int TRUE = 1;
		private const int FALSE = 0;

		private const int WIDX0 = 0;
		private const int WIDX1 = 1;
		private const int WIDX2 = 2;
		private const int WIDX3 = 3;

		private const int WIDX_REMOVE_GUARD = 4;
		private const int NUM_WIDX = 5;

		private static readonly GET_FUNC_TABLE_ELEM[] GET_FUNC_TABLE;

		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Ikaku;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Seisinryoku;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Fukutsuno;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_AtuiSibou;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Tikaramoti;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Suisui;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Youryokuso;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Hayaasi;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Tidoriasi;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Harikiri;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Atodasi;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_SlowStart;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Fukugan;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Sunagakure;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Yukigakure;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Iromegane;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_HardRock;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Sniper;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Kasoku;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Tekiouryoku;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Mouka;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Gekiryu;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Sinryoku;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_MusinoSirase;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Konjou;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Plus;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_FlowerGift;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Tousousin;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Technician;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_TetunoKobusi;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Stemi;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_FusiginaUroko;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_SkillLink;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_KairikiBasami;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Surudoime;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_ClearBody;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Tanjun;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_LeafGuard;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Juunan;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Fumin;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_MagumaNoYoroi;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Meneki;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_MizuNoBale;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_MyPace;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Donkan;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_PastelVeil;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Amefurasi;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Hideri;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Sunaokosi;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Sunahaki;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Yukifurasi;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Hajimarinoumi;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Owarinodaiti;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_DeltaStream;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_AirLock;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_IcoBody;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_AmeukeZara;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_SunPower;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Rinpun;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_TennoMegumi;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_UruoiBody;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Dappi;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_PoisonHeal;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_KabutoArmor;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Kyouun;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_IkarinoTubo;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_DokunoToge;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Seidenki;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_HonoNoKarada;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_MeromeroBody;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Housi;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Samehada;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Yuubaku;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_HorobiNoSango;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Hensyoku;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Syncro;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Isiatama;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_NormalSkin;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Trace;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_SizenKaifuku;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_DownLoad;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Yotimu;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_KikenYoti;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Omitoosi;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Ganjou;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Tennen;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Tainetu;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Kansouhada;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_PunkRock;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Tyosui;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Tikuden;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_DenkiEngine;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Kimottama;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Bouon;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Fuyuu;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_FusiginaMamori;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Namake;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Simerike;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Moraibi;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Nightmare;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Nigeasi;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Katayaburi;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Tenkiya;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Yobimizu;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Hiraisin;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Kyuuban;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_HedoroEki;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Bukiyou;

		private static readonly ushort[] IgnoreItems_Bukiyou;

		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Nenchaku;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Pressure;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_MagicGuard;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Akusyuu;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Kagefumi;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Arijigoku;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Jiryoku;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Karuwaza;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Monohiroi;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_TamaHiroi;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_WaruiTeguse;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_NorowareBody;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_KudakeruYoroi;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Tikarazuku;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Makenki;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Katiki;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Yowaki;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_MultiScale;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_FriendGuard;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_IyasiNoKokoro;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Dokubousou;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Netubousou;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Telepassy;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Murakke;

		private const int MURAKKE_RANK_MAX = 5;
		private const int MURAKKE_PATTERN_MAX = 20;

		private static readonly WazaRankEffect[] handler_MurakkeTable;

		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Boujin;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Dokusyu;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_SaiseiRyoku;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Hatomune;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Sunakaki;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_MilacreSkin;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Analyze;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_SunanoTikara;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Surinuke;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_BarrierFree;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_JisinKajou;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_UltraForce;

		private static readonly ultraForce_GetEffectRankTypeTableElem[] RANK_VALUE_TABLE;

		private static readonly EventFactor.EventHandlerTable[] HandlerTable_SeiginoKokoro;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Bibiri;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_JyoukiKikan;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Watage;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Miira;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_SamayouTamasii;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Sousyoku;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_ItazuraGokoro;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_MagicMirror;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Syuukaku;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_HeavyMetal;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_LightMetal;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Amanojaku;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Kinchoukan;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_KagakuHenkaGas;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Jukusei;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Kawarimono;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Illusion;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_GoodLuck;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_MentalVeil;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_FlowerVeil;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_SweetVeil;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_MirrorArmor;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_HooBukuro;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_HengenZizai;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_DarkAura;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_FairyAura;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_AuraBreak;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_GanjouAgo;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Gorimuchu;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_FurCoat;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_KusaNoKegawa;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_NumeNume;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_KataiTume;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_SkySkin;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_FairySkin;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_FreezSkin;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_MegaLauncher;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_HayateNoTsubasa;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Boudan;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_OyakoAi;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Magician;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Kyousei;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Zikyuuryoku;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Mizugatame;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Suihou;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Yukikaki;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Haganetukai;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_HaganeNoSeisin;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_UruoiVoice;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_HealingShift;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_ElecSkin;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_SurfTail;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Hitodenasi;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Enkaku;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Zyoounoigen;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_MohuMohu;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_KooriNoRinpun;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Battery;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_PowerSpot;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Receiver;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_TobidasuNakami;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Gyakuzyou;

		private const int WIDX_NIGEGOSI_FULFILL_ENOUGH_HP = 0;
		private const int WIDX_NIGEGOSI_ATTACKER_DMG_STATUS = 1;

		private const int NIGEGOSI_ATTACKER_DMG_STATUS_NONE = 0;
		private const int NIGEGOSI_ATTACKER_DMG_STATUS_MYATTACK = 1;
		private const int NIGEGOSI_ATTACKER_DMG_STATUS_FULFILL_ITEM_EFFECT = 2;

		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Nigegosi;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_SoulHeart;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Odoriko;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Husyoku;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_ElecMaker;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_PhychoMaker;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_MistMaker;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_GrassMaker;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Gitai;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_Harikomi;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_ZettaiNemuri;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_BrainPrism;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_HutouNoTurugi;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_HukutuNoTate;
		private static readonly EventFactor.EventHandlerTable[] HandlerTable_ScrewObire;
		
		public static uint numHandlersWithHandlerPri(ushort pri, ushort numHandlers)
		{
			return numHandlers & 0xffff | pri << 0x10;
		}
		
		public static ushort calcTokHandlerSubPriority(BTL_POKEPARAM bpp)
		{
			bpp.GetValue_Base(0xc);
			return 0;
		}
		
		// TODO
		public static bool isOccurPer(EventFactor.EventHandlerArgs args, byte per) { return default; }
		
		// TODO
		public static HandlerGetFunc getHandlerGetFunc(TokuseiNo tokusei) { return default; }
		
		// TODO
		public static void Add(EventSystem pEventSystem, BTL_POKEPARAM bpp) { }
		
		// TODO
		public static void Remove(EventSystem pEventSystem, BTL_POKEPARAM bpp) { }
		
		// TODO
		public static void Swap(EventSystem pEventSystem, BTL_POKEPARAM pp1, BTL_POKEPARAM pp2) { }
		
		// TODO
		public static bool common_IsShineLocalWeather(in EventFactor.EventHandlerArgs args, byte pokeID) { return default; }
		
		// TODO
		public static void common_IkakuNoEffect_RankEffectLastCheck(in EventFactor.EventHandlerArgs args, byte pokeID, byte workIdx) { }
		
		// TODO
		public static void common_IkakuNoEffect_RankEffectFailed(in EventFactor.EventHandlerArgs args, byte pokeID, byte workIdx) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Ikaku(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Ikaku_MemberIn(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Seisinryoku(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Seisinryoku(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Seisinryoku_RankEffectLastCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Seisinryoku_RankEffectFailed(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Fukutsuno(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_FukutsunoKokoro(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_AtuiSibou(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_AtuiSibou(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Tikaramoti(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Tikaramoti(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Suisui(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Suisui(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Youryokuso(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Youryokuso(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Hayaasi(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Hayaasi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Tidoriasi(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Tidoriasi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Harikiri(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Harikiri_HitRatio(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Harikiri_AtkPower(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Atodasi(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Atodasi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SlowStart(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_SlowStart_Agility(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_SlowStart_AtkPower(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_SlowStart_MemberIn(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void common_SlowStart_Declare(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_SlowStart_TurnCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Fukugan(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Fukugan(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Sunagakure(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Sunagakure(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Sunagakure_Weather(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Yukigakure(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Yukigakure(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Yukigakure_Weather(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void common_weather_guard(in EventFactor.EventHandlerArgs args, byte pokeID, BtlWeather weather) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Iromegane(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Iromegane(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_HardRock(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_HardRock(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Sniper(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Sniper(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Kasoku(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Kasoku(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Tekiouryoku(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Tekiouryoku(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Mouka(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Mouka(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Gekiryu(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Gekiryu(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Sinryoku(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Sinryoku(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_MusinoSirase(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_MusinoSirase(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void common_hpborder_powerup(in EventFactor.EventHandlerArgs args, in byte pokeID, in byte wazaType) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Konjou(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Konjou(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Plus(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_PlusMinus(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static bool checkExistTokuseiFriend(in EventFactor.EventHandlerArgs args, byte pokeID, TokuseiNo tokuseiID) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_FlowerGift(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_FlowerGift_MemberInComp(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_FlowerGift_GotTok(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_FlowerGift_Weather(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_FlowerGift_TokOff(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_FlowerGift_AirLock(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_FlowerGift_TokChange(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_FlowerGift_Power(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_FlowerGift_Guard(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static bool checkFlowerGiftEnablePokemon(in EventFactor.EventHandlerArgs args, byte pokeID) { return default; }
		
		// TODO
		public static void common_FlowerGift_FormChange(in EventFactor.EventHandlerArgs args, byte pokeID, byte nextForm, byte fTokWin) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Tousousin(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Tousousin(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Technician(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Technician(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_TetunoKobusi(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_TetunoKobusi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Sutemi(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Sutemi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_FusiginaUroko(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_FusiginaUroko(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SkillLink(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_SkillLink(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_KairikiBasami(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_KairikiBasami_Check(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_KairikiBasami_Guard(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Surudoime(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Surudoime_Check(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Surudoime_Guard(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Surudoime_HitRank(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_ClearBody(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_ClearBody_Check(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_ClearBody_Guard(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void common_RankDownGuard_Check(in EventFactor.EventHandlerArgs args, in byte pokeID, in WazaRankEffect rankType) { }
		
		// TODO
		public static void common_RankDownGuard_Fixed(in EventFactor.EventHandlerArgs args, in byte pokeID, in byte tokwin_pokeID, in ushort strID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Tanjun(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Tanjun(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_LeafGuard(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_LeafGuard(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_LeafGuard_InemuriCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Juunan(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Juunan_PokeSick(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Juunan_Wake(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Juunan_ActEnd(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Fumin(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Fumin_PokeSick(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Fumin_Wake(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Fumin_ActEnd(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Fumin_InemuriCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_MagumaNoYoroi(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_MagumaNoYoroi_PokeSick(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_MagumaNoYoroi_Wake(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_MagumaNoYoroi_ActEnd(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Meneki(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Meneki_PokeSick(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Meneki_Wake(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Meneki_ActEnd(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_MizuNoBale(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_MizuNoBale_PokeSick(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_MizuNoBale_Wake(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_MizuNoBale_ActEnd(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_MyPace(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_MyPace_PokeSick(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_MyPace_AddSickFailed(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_MyPace_Wake(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_MyPace_ActEnd(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_MyPace_RankEffectLastCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_MyPace_RankEffectFailed(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Donkan(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Donkan(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Donkan_Wake(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Donkan_ActEnd(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Donkan_NoEffCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void common_AddSickFailed(in EventFactor.EventHandlerArgs args, byte pokeID, ushort strID) { }
		
		// TODO
		public static void handler_AddSickFailCommon(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void common_TokuseiWake_CureSick(in EventFactor.EventHandlerArgs args, byte pokeID, WazaSick sick) { }
		
		// TODO
		public static void common_TokuseiWake_CureSickCore(in EventFactor.EventHandlerArgs args, byte pokeID, WazaSick sick) { }
		
		// TODO
		public static void handler_Donkan_RankEffectLastCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Donkan_RankEffectFailed(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_PastelVeil(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Pastelveil_SickFail(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Pastelveil_SickFailed(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_PastelVeil_Wake(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_PastelVeil_ActEnd(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void common_FriendCureSick(in EventFactor.EventHandlerArgs args, byte pokeID, WazaSick cureSick) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Amefurasi(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Amefurasi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Hideri(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Hideri(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Sunaokosi(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Sunaokosi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Sunahaki(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Sunahaki(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Yukifurasi(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Yukifurasi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Hajimarinoumi(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Hajimarinoumi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Hajimarinoumi_stop(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Owarinodaiti(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Owarinodaichi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Owarinodaichi_stop(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_DeltaStream(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_DeltaStream(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_DeltaStream_stop(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void common_weather_change(in EventFactor.EventHandlerArgs args, byte pokeID, BtlWeather weather, ushort boostItem, bool isPermanent) { }
		
		// TODO
		public static void common_weather_stop(in EventFactor.EventHandlerArgs args, byte pokeID, BtlWeather weather) { }
		
		// TODO
		public static bool common_check_tokusei(in EventFactor.EventHandlerArgs args, byte selfPokeId, ushort tokusei) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_AirLock(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_AirLock_MemberIn(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_AirLock_ChangeWeather(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_IcoBody(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_IceBody(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_AmeukeZara(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_AmeukeZara(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void common_weather_recover(in EventFactor.EventHandlerArgs args, byte pokeID, BtlWeather weather) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SunPower(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_SunPower_Weather(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_SunPower_AtkPower(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Rinpun(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Rinpun_Sick(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Rinpun_Rank(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Rinpun_Shrink(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Rinpun_Guard(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Rinpun_GuardHitEnd(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_TennoMegumi(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_TennoMegumi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_TennoMegumi_Shrink(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_UruoiBody(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_UruoiBody(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Dappi(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Dappi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_PoisonHeal(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_PoisonHeal(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_KabutoArmor(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_KabutoArmor(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Kyouun(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Kyouun(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_IkarinoTubo(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_IkarinoTubo(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_DokunoToge(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_DokunoToge(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Seidenki(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Seidenki(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_HonoNoKarada(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_HonoNoKarada(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_MeromeroBody(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_MeromeroBody(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Housi(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Housi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void common_touchAddSick(EventFactor.EventHandlerArgs args, byte pokeID, WazaSick sick, in BTL_SICKCONT sickCont, byte per) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Samehada(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Samehada(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Yuubaku(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Yuubaku(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_HorobiNoSango(ref EventPriority prio) { return default; }
		
		// TODO
		public static bool common_Horobinouta(in EventFactor.EventHandlerArgs args, in byte pokeID, BTL_POKEPARAM target) { return default; }
		
		// TODO
		public static void handler_HorobiNoSango(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Hensyoku(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Hensyoku(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Syncro(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Syncro(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Isiatama(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Isiatama(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_NormalSkin(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_NormalSkin(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_NormalSkin_Pow(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_NormalSkin_ChangeGWaza(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Trace(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Trace(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SizenKaifuku(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_SizenKaifuku(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_DownLoad(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Download(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Yotimu(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Yotimu(in EventFactor.EventHandlerArgs args, byte pokeID) { }

		public static byte get_yotimu_wazapri(WazaNo waza)
		{
			if (WAZADATA.GetDamageType(waza) == WazaDamageType.NONE)
				return 1;

			byte power = (byte)WAZADATA.GetPower(waza);
			if (power == 1)
			{
				if (WAZADATA.GetCategory(waza) == WazaCategory.ICHIGEKI)
					return 150;

				switch (waza)
				{
					case WazaNo.KAUNTAA:
					case WazaNo.MIRAAKOOTO:
					case WazaNo.METARUBAASUTO:
						return 120;
					default:
						return 80;
				}
			}

			return power;
		}

		// TODO
		public static EventFactor.EventHandlerTable[] ADD_KikenYoti(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_KikenYoti(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static bool check_kikenyoti_enemys(in EventFactor.EventHandlerArgs args, in byte pokeID) { return default; }
		
		// TODO
		public static bool check_kikenyoti_poke(in EventFactor.EventHandlerArgs args, BTL_POKEPARAM bppUser, BTL_POKEPARAM bppEnemy) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Omitoosi(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Omitoosi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Ganjou(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Ganjou_Ichigeki(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Ganjou_KoraeCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Ganjou_KoraeExe(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Tennen(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Tennen_hitRank(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Tennen_AtkRank(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Tennen_DefRank(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Tainetu(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Tainetsu_WazaPow(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Tainetsu_SickDmg(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static bool common_TypeNoEffect(in EventFactor.EventHandlerArgs args, byte pokeID, byte wazaType) { return default; }
		
		// TODO
		public static void common_TypeRecoverHP(in EventFactor.EventHandlerArgs args, byte pokeID, byte denomHP) { }
		
		// TODO
		public static void common_TypeNoEffect_Rankup(in EventFactor.EventHandlerArgs args, byte pokeID, WazaRankEffect rankType, byte volume) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Kansouhada(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Kansouhada_Weather(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Kansouhada_WazaPow(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Kansouhada_Check(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_PunkRock(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_PunkRock_power(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_PunkRock_damage(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Tyosui(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Tyosui_Check(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Tikuden(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Tikuden_CheckEx(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_DenkiEngine(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_DenkiEngine_CheckEx(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Kimottama(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Kimottama(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Kimottama_kill(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Kimottama_check(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Kimottama_RankEffectLastCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Kimottama_RankEffectFailed(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Bouon(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Bouon(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Fuyuu(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Fuyuu(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Fuyuu_Disp(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Fuyuu_TurnCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_FusiginaMamori(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_FusiginaMamori(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Namake(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Namake(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Namake_Get(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Nameke_Failed(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Nameke_EndAct(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Nameke_Reset(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Simerike(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Simerike(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Simerike_Effective(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Simerike_StartSeq(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Simerike_EndSeq(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Simerike_Ieki(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static bool handler_Simerike_SkipCheck(in EventFactor.SkipCheckHandlerArgs args) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Moraibi(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Moraibi_CheckNoEffect(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Moraibi_AtkPower(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Moraibi_Remove(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Nightmare(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Nightmare(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Nigeasi(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Nigeasi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Nigeasi_Msg(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Katayaburi(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Katayaburi_MemberIn(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Katayaburi_Start(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Katayaburi_End(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Katayaburi_Ieki(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Tenkiya(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Tenkiya_MemberInComp(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Tenkiya_GetTok(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Tenkiya_Weather(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Tenkiya_AirLock(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Tenkiya_ChangeTok(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Tenkiya_TokOff(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void common_Tenkiya_Off(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void common_TenkiFormChange(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Yobimizu(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Yobimizu(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Yobimizu_TemptTargetEnd(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Yobimizu_CheckNoEffect(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Hiraisin(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Hiraisin(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Hiraisin_TemptTargetEnd(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Hiraisin_WazaExeStart(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Hiraisin_CheckNoEffect(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void common_WazaTargetChangeToMe(in EventFactor.EventHandlerArgs args, byte pokeID, byte wazaType, TemptTargetPriority temptPriority, TemptTargetCause temptCause) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Kyuuban(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Kyuuban(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_HedoroEki(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_HedoroEki(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_HedoroEki_Dead(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Bukiyou(ref EventPriority prio) { return default; }
		
		// TODO
		public static bool handler_Bukiyou_SkipCheck(in EventFactor.SkipCheckHandlerArgs args) { return default; }
		
		// TODO
		public static void handler_Bukiyou_MemberInPrev(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Bukiyou_PreChange(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Bukiyou_IekiFixed(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Bukiyou_ExeCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Bukiyou_ExeFail(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Nenchaku(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Nenchaku_NoEff(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Nenchaku(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Nenchaku_Reaction(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Pressure(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Pressure_MemberIN(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Pressure(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void common_MemberInTokMessage(in EventFactor.EventHandlerArgs args, byte pokeID, ushort strID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_MagicGuard(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_MagicGuard(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Akusyuu(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Akusyuu(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Kagefumi(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Kagefumi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Arijigoku(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Arijigoku(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Jiryoku(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Jiryoku(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Karuwaza(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Karuwaza_BeforeItemSet(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Karuwaza_Agility(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Monohiroi(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Monohiroi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static bool monohiroi_search(in EventFactor.EventHandlerArgs args, byte pokeID, out byte targetPokeID)
		{
			targetPokeID = default;
			return default;
		}
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_TamaHiroi(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_TamaHiroi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_WaruiTeguse(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_WaruiTeguse(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_NorowareBody(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_NorowareBody(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_KudakeruYoroi(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_KudakeruYoroi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Tikarazuku(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Tikarazuku_WazaPow(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Tikarazuku_CheckFail(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Tikarazuku_ShrinkCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Tikarazuku_HitChk(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static bool IsTikarazukuEffecive(WazaNo waza) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Makenki(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Makenki(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Katiki(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Katiki(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Yowaki(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Yowaki(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_MultiScale(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_MultiScale(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_FriendGuard(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_NakamaIsiki(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_IyasiNoKokoro(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_IyasiNoKokoro(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Dokubousou(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Dokubousou(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Netubousou(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Netubousou(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Telepassy(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_AunNoIki(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Murakke(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Murakke(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Boujin(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Boujin_CalcDamage(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Boujin_WazaNoEffect(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Dokusyu(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Dokusyu(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SaiseiRyoku(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_SaiseiRyoku(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Hatomune(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Hatomune_Check(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Hatomune_Guard(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Sunakaki(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Sunakaki(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_MilacreSkin(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_MilacreSkin(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Analyze(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Sinuti(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SunanoTikara(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_SunanoTikara(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Surinuke(ref EventPriority prio) { return default; }
		
		// TODO
		public static bool handler_Surinuke_SkipCheck(in EventFactor.SkipCheckHandlerArgs args) { return default; }
		
		// TODO
		public static void handler_Surinuke_Start(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Surinuke_End(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Surinuke_MigawariThrew(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_BarrierFree(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_BarrierFree(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_JisinKajou(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_JisinKajou(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_UltraForce(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_UltraForce(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static WazaRankEffect ultraForce_GetEffectRankType(in EventFactor.EventHandlerArgs args, byte pokeID) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SeiginoKokoro(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_SeiginoKokoro(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Bibiri(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Bibiri(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Bibiri_RankEffectLastCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Bibiri_RankEffectFixed(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_JyoukiKikan(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_JyoukiKikan(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Watage(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Watage(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Miira(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Miira(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SamayouTamasii(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_SamayouTamasii(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Sousyoku(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Sousyoku_CheckNoEffect(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_ItazuraGokoro(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_ItazuraGokoro(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_ItazuraGokoro_WazaParam(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_ItazuraGokoro_Reset(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_MagicMirror_ExeCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_MagicMirror_Wait(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_MagicMirror_Reflect(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_MagicMirror(ref EventPriority prio) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Syuukaku(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Syuukaku(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_HeavyMetal(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_HeavyMetal(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_LightMetal(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_LightMetal(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Amanojaku(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Amanojaku(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Kinchoukan(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Kinchoukan_MemberIn(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static bool handler_Kinchoukan_SkipCheck(in EventFactor.SkipCheckHandlerArgs args) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_KagakuHenkaGas(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_KagakuHenkaGas_Start(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_KagakuHenkaGas_End(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Jukusei(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Jukusei_KinomiCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Kawarimono(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Hensin(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Illusion(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Illusion_Damage(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Illusion_Ieki(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Illusion_ChangeTok(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void common_IllusionBreak(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_GoodLuck(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_GoodLuck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_MentalVeil(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_MentalVeil_Check(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_MentalVeil_Failed(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void common_FriendSickFailed(in EventFactor.EventHandlerArgs args, byte pokeID, ushort strID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_FlowerVeil(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_FlowerVeil_Check(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_FlowerVeil_Guard(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_FlowerVeil_SickCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_FlowerVeil_SickFailed(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_FlowerVeil_CheckInemuri(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static bool common_IsFlowerVeilTarget(in EventFactor.EventHandlerArgs args, byte pokeID, byte targetPokeID) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SweetVeil(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_SweetVeil_PokeSick(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_SweetVeil_PokeSickFailed(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_SweetVeil_Inemuri(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_MirrorArmor(ref EventPriority prio) { return default; }
		
		public static bool checkMirrorArmorCause(RankEffectCause cause)
		{
			if (1 < ((int)cause & 0xff) - 5) {
			  return ((int)cause & 0xff) - 8 < 3;
			}
			return true;
		}
		
		// TODO
		public static void handler_MirroArmor_Check(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_MirroArmor_Reflect(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_HooBukuro(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Hoobukuro(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_HengenZizai(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_HengenZizai(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_DarkAura(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_DarkAura_MemberIN(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_DarkAura(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_FairyAura(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_FairyAura_MemberIN(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_FairyAura(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_AuraBreak(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_AuraBreak_MemberIn(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_AuraBreak(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_GanjouAgo(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_GanjouAgo(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Gorimuchu(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Gorimuchu_Waza(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Gorimuchu_Power(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Gorimuchu_Change(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Gorimuchu_Check(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_FurCoat(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_FurCoat(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_KusaNoKegawa(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_KusaNoKegawa(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_NumeNume(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_NumeNume(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_KataiTume(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_KataiTume(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void common_Skin_ChangeType(in EventFactor.EventHandlerArgs args, byte pokeID, byte type) { }
		
		// TODO
		public static void common_Skin_WazaPow(in EventFactor.EventHandlerArgs args, byte pokeID, byte type) { }
		
		// TODO
		public static void common_Skin_ChangeGWaza(in EventFactor.EventHandlerArgs args, byte pokeID, WazaNo waza) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SkySkin(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_SkySkin(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_SkySkin_Pow(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_SkySkin_ChangeGWaza(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_FairySkin(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_FairySkin(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_FairySkin_Pow(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Fairykin_ChangeGWaza(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_FreezSkin(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_FreezSkin(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_FreezSkin_Pow(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_FreezSkin_ChangeGWaza(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_SkinEndCommon(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_MegaLauncher(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_MegaLauncher_Pow(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_MegaLauncher_Recover(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_HayateNoTsubasa(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_HayateNoTsubasa(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Boudan(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Boudan(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_OyakoAi(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_OyakoAi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Magician(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_magician_Start(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_magician(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static bool magician_swapitem(in EventFactor.EventHandlerArgs args, byte pokeID, byte targetPokeID) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Kyousei(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_kyousei_wazaSeqStart(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_kyousei_wazaSeqEnd(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_kyousei(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void kyousei_commonProc(in EventFactor.EventHandlerArgs args, byte pokeID, byte targetPokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Zikyuuryoku(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Zikyuuryoku_WazaDamageReaction(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Mizugatame(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Mizugatame_WazaDamageReaction(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Suihou(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Suihou_AttackerPower(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Yukikaki(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Yukikaki_CalcAgility(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Haganetukai(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Haganetukai_AttackerPower(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_HaganeNoSeisin(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_HaganeNoSeisin(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_UruoiVoice(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_UruoiVoice_WazaParam(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_HealingShift(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_HealingShift_GetWazaPriority(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_ElecSkin(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_ElecSkinWazaParam(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_ElecSkin_Pow(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_ElecSkin_ChangeGWaza(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SurfTail(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_SurfTail_CalcAgility(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Hitodenasi(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Hitodenasi_CriticalCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Enkaku(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Enkaku_WazaParam(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Zyoounoigen(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Zyoounoigen_WazaExeCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_MohuMohu(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_MohuMohu(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_KooriNoRinpun(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_KooriNoRinpun(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Battery(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Battery_WazaPower(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_PowerSpot(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_PowerSpot(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Receiver(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Receiver_DeadAfter(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_TobidasuNakami(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_TobidasuNakami_DamageProcStart(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_TobidasuNakami_IchigekiGuard(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void tobidasuNakami_RegisterDamage(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_TobidasuNakami_WazaDamageReaction(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Gyakuzyou(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Gyakuzyou_DamegeProcStart(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Gyakuzyou_IchigekiCheck(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static bool gyakuzyou_isEnoughHP(in EventFactor.EventHandlerArgs args, byte pokeID) { return default; }
		
		// TODO
		public static void handler_Gyakuzyou_EndHitReal(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static bool common_CheckTarget(in EventFactor.EventHandlerArgs args, byte checkPokeID) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Nigegosi(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Nigegosi_DamegeProcStart(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Nigegosi_BeforeIchigeki(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Nigegosi_DamegeProcEnd(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Nigegosi_EndHit(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Nigegosi_SimpleDamageBefore(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Nigegosi_SimpleDamageAfter(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void nigegosi_CheckBeforeDamage(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void nigegosi_AfterDamage_Full(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static bool nigegosi_AfterDamage_shouldEffect(in EventFactor.EventHandlerArgs args, byte pokeID) { return default; }
		
		// TODO
		public static void nigegosi_AfterDamage_Effect(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static bool nigegosi_isQuitBattle(in EventFactor.EventHandlerArgs args) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_SoulHeart(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_SoulHeart_DeadAfter(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Odoriko(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Odoriko_WazaSeqStart(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Odoriko_ExecuteEffective(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Odoriko_WazaSeqEnd(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static BtlPokePos odoriko_GetTargetPos(in EventFactor.EventHandlerArgs args, byte odorikoPokeID, byte attackPokeID) { return default; }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Husyoku(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Husyoku_CheckAddSickFailStdSkip(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_ElecMaker(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_ElecMaker_MemberIn(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_PhychoMaker(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_PhychoMaker_MemberIn(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_MistMaker(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_MistMaker_MemberIn(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_GrassMaker(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_GrassMaker_MemberIn(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void common_GroundMaker(in EventFactor.EventHandlerArgs args, byte pokeID, BtlGround ground) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Gitai(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Gitai_MemberIn(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_Gitai_Change(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_Harikomi(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_Harikomi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_ZettaiNemuri(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_ZettaiNemuri_MemberIn(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_ZettaiNemuri_AddSickCheckFail(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_BrainPrism(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_BrainPrism(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_HutouNoTurugi(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_HutouNoTurugi(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_HukutuNoTate(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_HukutuNoTate(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static EventFactor.EventHandlerTable[] ADD_ScrewObire(ref EventPriority prio) { return default; }
		
		// TODO
		public static void handler_ScrewObire_Tempt(in EventFactor.EventHandlerArgs args, byte pokeID) { }
		
		// TODO
		public static void handler_ScrewObire_Aim(in EventFactor.EventHandlerArgs args, byte pokeID) { }

		public delegate EventFactor.EventHandlerTable[] HandlerGetFunc(ref EventPriority prio);

		private struct GET_FUNC_TABLE_ELEM
		{
			public TokuseiNo tokusei;
			public HandlerGetFunc func;
			
			public GET_FUNC_TABLE_ELEM(TokuseiNo tokusei, HandlerGetFunc func)
			{
				this.tokusei = tokusei;
				this.func = func;
			}
		}

		private class MAX_PRIORITY_PARAM
		{
			public byte pokeID;
			public WazaNo wazaID;
		}

		private struct ultraForce_GetEffectRankTypeTableElem
		{
			public WazaRankEffect rankType;
			public BTL_POKEPARAM.ValueID pokeValueID;
			
			public ultraForce_GetEffectRankTypeTableElem(WazaRankEffect rankType, BTL_POKEPARAM.ValueID pokeValueID)
			{
				this.rankType = rankType;
				this.pokeValueID = pokeValueID;
			}
		}

	}
}