Shader "Custom/BeltScroll"
 {
    Properties {
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _ScrollXSpeed ("X Scroll Speed", Range(-5, 5)) = 0
        _ScrollYSpeed ("Y Scroll Speed", Range(-5, 5)) = 0
    }
    SubShader {
        Tags { "RenderType"="Opaque" }
       
        CGPROGRAM
        #pragma surface surf Lambert alpha
 
        sampler2D _MainTex;
        fixed _ScrollXSpeed;
        fixed _ScrollYSpeed;
 
        struct Input {
            float2 uv_MainTex;
        };
 
        void surf (Input IN, inout SurfaceOutput o) {
            fixed varX = _ScrollXSpeed * _Time;
            fixed varY = _ScrollYSpeed * _Time;
            fixed2 uv_Tex = IN.uv_MainTex + fixed2(varX, varY);
            half4 c = tex2D(_MainTex, uv_Tex);
            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
