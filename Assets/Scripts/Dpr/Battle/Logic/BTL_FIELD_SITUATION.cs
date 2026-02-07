namespace Dpr.Battle.Logic
{
    public class BTL_FIELD_SITUATION
    {
        public BgComponentData bgComponent;
        public byte weather;
        public byte fieldWeather;
        public BtlGround ground;

        public void CopyFrom(BTL_FIELD_SITUATION src)
        {
            bgComponent = src.bgComponent;
            weather = src.weather;
            fieldWeather = src.fieldWeather;
            ground = src.ground;
        }

        public BTL_FIELD_SITUATION()
        {
            bgComponent = null;
            weather = 0;
            fieldWeather = 0;
            ground = BtlGround.BTL_GROUND_NONE;
        }
    }
}