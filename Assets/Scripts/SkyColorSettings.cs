using Dpr.Battle.Logic;
using Dpr.Battle.View.Systems;
using System;
using System.Runtime.InteropServices;
using UnityEngine;

public sealed class SkyColorSettings : MonoBehaviour
{
	public const int PERIODO_OF_TIME_NUM = 5;

    public static SkyColorSettings global { get; set; }

    private static bool _set_property_id = false;

	private static readonly int _upper_color_id = Shader.PropertyToID("_UpperColor");
	private static readonly int _lower_color_id = Shader.PropertyToID("_LayerTex");
    private static readonly int _starlight_power_id = Shader.PropertyToID("_StarlightPower");
    private static readonly int _starlight_st_id = Shader.PropertyToID("_StarlightTex_ST");
    private static readonly int _scenery_color_id = Shader.PropertyToID("_SceneryColor");
    private static readonly int _cloud_color_id = Shader.PropertyToID("_CloudColor");
    private static readonly int _shadow_color_id = Shader.PropertyToID("_ShadowColor");
    private static readonly int _near_speed_id = Shader.PropertyToID("_NearCloudSpeed");
    private static readonly int _far_speed_id = Shader.PropertyToID("_FarCloudSpeed");

    [SerializeField]
	public Renderer _renderer;
	[SerializeField]
	public Property _morning;
	[SerializeField]
	public Property _daytime;
	[SerializeField]
	public Property _evening;
	[SerializeField]
	public Property _night;
	[SerializeField]
	public Property _midnight;
	[SerializeField]
	public Property[] _none = new Property[PERIODO_OF_TIME_NUM];
	[SerializeField]
	public Property[] _shine = new Property[PERIODO_OF_TIME_NUM];
    [SerializeField]
	public Property[] _rain = new Property[PERIODO_OF_TIME_NUM];
    [SerializeField]
	public Property[] _snow = new Property[PERIODO_OF_TIME_NUM];
    [SerializeField]
	public Property[] _sand = new Property[PERIODO_OF_TIME_NUM];
    [SerializeField]
	public Property[] _cloud = new Property[PERIODO_OF_TIME_NUM];
    [SerializeField]
	private BtlvWeather _currentWeather;
	[SerializeField]
	private PeriodOfDay _periodOfDay;
	[Range(0.0f, 1.0f)]
	[SerializeField]
	private float _weight = 1.0f;
	private BtlWeather _prevWeather;

	private static MaterialPropertyBlock _propertyBlock = null;
	
	public BtlvWeather CurrentWeather { get => _currentWeather; private set => _currentWeather = value; }
	public float Weight { get => _weight; set => _weight = Mathf.Clamp01(value); }
	
	// TODO
	private void OnValidate() { }
	
	// TODO
	private Property QueryProperty() { return default; }
	
	// TODO
	private void SetParameters() { }
	
	// TODO
	private void OnEnable() { }
	
	// TODO
	private void OnDisable() { }
	
	// TODO
	private void OnUpdate(float deltaTime) { }
	
	// TODO
	public Property GetProperty(BtlvWeather weather, PeriodOfDay periodOfDay) { return default; }
	
	// TODO
	public Property[] GetProperties(BtlvWeather weather) { return default; }
	
	public BtlvWeather GetWeather() {
	    return _currentWeather;
	}
	
	// TODO
	public void SetWeather(BtlvWeather weather, PeriodOfDay periodOfDay, float weight = 1.0f) { }
	
	// TODO
	public void SetWeather(BtlWeather weather, PeriodOfDay periodOfDay, float weight = 1.0f) { }
	
	// TODO
	public void ResetSkyColor() { }
	
	// TODO
	public void ChangeWeather(BtlvWeather fromWeather, BtlvWeather toWeather, PeriodOfDay periodOfDay, float weight = 0.0f) { }

	// TODO
	public void ChangeWeather(BtlvWeather fromWeather, BtlvWeather toWeather, PeriodOfDay periodOfDay, float duration, [Optional] Action onComplete) { }
	
	// TODO
	public void ChangeWeather(BtlvWeather fromWeather, BtlvWeather toWeather, float duration, [Optional] Action onComplete) { }
	
	// TODO
	public void ChangeTemporaryPeriodOfDay(PeriodOfDay periodOfDay, [Optional] [DefaultParameterValue(0.0f)] float duration, [Optional] Action onComplete) { }

	[Serializable]
	public struct Property
	{
		[SerializeField]
		public Color upperColor;
		[SerializeField]
		public float upperIntensity;
		[SerializeField]
		public Color lowerColor;
		[SerializeField]
		public float lowerIntensity;
		[SerializeField]
		public float starlightPower;
		[SerializeField]
		public Vector4 starlightTiling;
		[SerializeField]
		public Color sceneryColor;
		[SerializeField]
		public Color cloudColor;
		[SerializeField]
		public Color shadowColor;
		[SerializeField]
		public float farCloudSpeed;
		[SerializeField]
		public float nearCloudSpeed;
	}
}