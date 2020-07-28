Shader "Custom/Invisible"
{
   Subshader
   {
        Tags {"Queue" = "Transparent+1"}
        Pass {Blend Zero One}
   }
}
