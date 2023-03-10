void GetLightingInformation_float(float3 WorldPos, out float3 Direction, out float3 Color, out float Attenuation)
{
    #ifdef SHADERGRAPH_PREVIEW
        Direction = float3(-0.5,0.5,-0.5);
        Color = float3(1,1,1);
        Attenuation = 1;
    #else
        float4 sCoord = TransformWorldToShadowCoord(WorldPos);
        Light light = GetMainLight(sCoord);
        Direction = light.direction;
        Attenuation = light.shadowAttenuation;
        Color = light.color;
    #endif
}