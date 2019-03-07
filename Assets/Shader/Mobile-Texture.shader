// Unity built-in shader source. Copyright (c) 2016 Unity Technologies. MIT license (see license.txt)

// Simplified Diffuse shader. Differences from regular Diffuse one:
// - no Main Color
// - fully supports only 1 directional light. Other lights can affect it, but it will be per-vertex/SH.

Shader "Mobile/TextureCustom" {
Properties {
    _MainTex ("Base (RGB)", 2D) = "white" {}
	_Color("Color", COLOR) = (1,1,1,1)
	_Speed("Speed", Float) = 1
}
SubShader {
    Tags { "RenderType"="Opaque" }
    LOD 150

CGPROGRAM
#pragma surface surf Lambert noforwardadd

sampler2D _MainTex;
uniform float4 _Color;
uniform float _Speed;

struct Input {
    float2 uv_MainTex;
};

void surf (Input IN, inout SurfaceOutput o) {
	const float2 uv_MT = float2(IN.uv_MainTex.x, IN.uv_MainTex.y-abs(_Time.y * _Speed));
    fixed4 c = tex2D(_MainTex, uv_MT);
    o.Albedo = c.rgb*_Color.xyz;
    o.Alpha = c.a;
}
ENDCG
}

Fallback "Mobile/VertexLit"
}
