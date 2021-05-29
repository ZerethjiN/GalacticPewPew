#version 120
varying vec2 worldPos;

void main() {
    gl_Position = gl_ModelViewProjectionMatrix * gl_Vertex;

    worldPos = gl_Vertex.xy;

    gl_TexCoord[0] = gl_TextureMatrix[0] * gl_MultiTexCoord0;

    gl_FrontColor = gl_Color;
}