using Pml.PokePara;
using Pml;
using System;
using UnityEngine;
using XLSXContent;

namespace Dpr.SubContents
{
    [Serializable]
    public class BindModel
    {
        public bool StartActive;
        public Transform parent;
        public string assetBundlePath;
        public MonsNo monsNo;
        public bool isEgg;
        public bool isBattleScale;
        [NonSerialized]
        public UnityEngine.Object LoadedAsset;
        [NonSerialized]
        public string Rename = "";
        [NonSerialized]
        public PokemonInfo.SheetCatalog catalog;
        [NonSerialized]
        public bool isVariants;
        [NonSerialized]
        public float scale = -1.0f;
        [NonSerialized]
        public PokemonParam pokeParam;

        // TODO
        public string GetAssetName() { return null; }

        public void Destroy()
        {
        	this.LoadedAsset = null;
        	this.catalog = null;
        	this.parent = null;
        	this.pokeParam = null;
        }
    }
}