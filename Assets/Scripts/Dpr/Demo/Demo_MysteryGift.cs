using Dpr.SubContents;
using GameData;
using Pml.PokePara;
using System.Collections;
using UnityEngine;
using XLSXContent;

namespace Dpr.Demo
{
	public class Demo_MysteryGift : DemoBase
	{
		private TimeLineBinder timeLine;
		public PokemonParam gift_Pokemon;
		public bool isGetMons;
		
		public Demo_MysteryGift()
		{
			UseCamera = true;
			FadeColor = Color.black;
			DisableEnvironmentController = false;
			isDisablePostProcess = true;
			isDisableMainCamera = true;
		}
		
		public override void Destroy()
		{
			base.Destroy();
			timeLine = null;
		}
		
		public override IEnumerator Enter()
		{
			yield return Utils.LoadAsset("demo/timeline/mysterygift", asset =>
			{
				if (asset.name == "MysteryGiftTimeLine")
					timeLine = (Object.Instantiate(asset, parent) as GameObject).GetComponent<TimeLineBinder>();
			});

			PokemonInfo.SheetCatalog catalog = null;
			var param = gift_Pokemon;
			var scale = -1.0f;

			if (gift_Pokemon != null)
			{
                if (gift_Pokemon.IsEgg(EggCheckType.BOTH_EGG))
                {
                    catalog = DataManager.GetPokemonCatalog(param.GetMonsNo(), param.GetFormNo(), param.GetSex(), param.IsRare(), true);

                    yield return Utils.LoadAsset("objects/" + catalog.AssetBundleName, asset =>
                    {
                        if (asset.name == catalog.AssetBundleName)
                            PokeAssets.Add(catalog.UniqueID, asset);
                    });

                    scale = param.GetMonsNo() == Pml.MonsNo.MANAFI ? 3.0f : 2.0f;
                }
                else
                {
                    catalog = Utils.GetPokemonCatalog(gift_Pokemon);

                    yield return LoadPokeAsset(param, false, true, true);
                }

                timeLine.ExternalAssets.Add("_Poke01", new TimeLineBinder.PokemonData(PokeAssets[catalog.UniqueID], catalog, param) { scale = scale });
            }

			yield return timeLine.Setup();

			if (gift_Pokemon == null)
			{
				timeLine.UnMuteTrack("presentbox Item");
				timeLine.UnMuteTrack("LightLoop Item");
				timeLine.MuteTrack("Poke1");
				timeLine.MuteTrack("LightLoop Poke");
                timeLine.MuteTrack("nakigoe");
            }
			else
			{
                timeLine.MuteTrack("presentbox Item");
                timeLine.MuteTrack("LightLoop Item");
                timeLine.UnMuteTrack("Poke1");
                timeLine.UnMuteTrack("LightLoop Poke");

                if (gift_Pokemon.IsEgg(EggCheckType.BOTH_EGG))
                {
                    timeLine.MuteTrack("nakigoe");
                    timeLine.MuteTrack("LightLoop Poke");
                }
                else
                {
                    timeLine.UnMuteTrack("nakigoe");
                    timeLine.UnMuteTrack("LightLoop Poke");
                }
            }

			var cam = timeLine.GetCamera();
            cam.targetTexture = cameraController.cam.targetTexture;
			cam.enabled = true;

			cameraController.cam.targetTexture = null;
            cameraController.cam.enabled = false;
            cameraController.cam.SetActive(false);

			manager.UICanvas.sortingOrder = Utils.GetUISortingOrderMax() + 1;

			var canvasTf = timeLine.transform.Find("Canvas");
			if (canvasTf != null)
			{
				var canvas = canvasTf.GetComponent<Canvas>();
				if (canvas != null)
					canvas.sortingOrder = manager.UICanvas.sortingOrder + 1;
			}

			timeLine.Play();
        }
		
		// TODO
		public override IEnumerator Main() { return default; }
		
		// TODO
		public override IEnumerator Exit() { return default; }
	}
}