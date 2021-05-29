#version 120
uniform sampler2D texture;

varying vec2 worldPos;

void main() {
    vec4 pixel = texture2D(texture, gl_TexCoord[0].xy);
    
    gl_FragColor = pixel;
}