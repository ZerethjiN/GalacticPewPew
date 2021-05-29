#version 120
#define MAX_LIGHTS 64

uniform sampler2D texture;
uniform vec3 ambient;

uniform int nbLight;
uniform float lightRadius[MAX_LIGHTS];
uniform vec3 lightColor[MAX_LIGHTS];
uniform vec3 lightPos[MAX_LIGHTS];

uniform sampler2D normalTexture;

varying vec2 worldPos;

vec4 NormalApplication(int i) {
    vec4 normalTex = texture2D(normalTexture, gl_TexCoord[0].xy);
    vec3 N = normalize(normalTex.rgb * vec3(2, 2, 2) - vec3(1, 1, 1));
    vec3 lightDir = vec3((lightPos[i].xy - worldPos), 255);
    vec3 L = normalize(lightDir);

    return vec4(max(dot(N, L), 0.0));
}

vec4 DiffuseApplication() {
    vec4 diffusetotal;

    for (int i = 0; i < nbLight; i++) {
        float dist = distance(worldPos.xy, lightPos[i].xy);
        float attenuation = clamp(1.0 - dist/lightRadius[i], 0.0, 1.0);
        diffusetotal += vec4(lightColor[i], 1) * attenuation * NormalApplication(i);
    }

    return vec4(ambient, 1) + diffusetotal;
}

void main() {
    vec4 pixel = texture2D(texture, gl_TexCoord[0].xy);

    pixel *= DiffuseApplication();
    
    gl_FragColor = pixel;
}