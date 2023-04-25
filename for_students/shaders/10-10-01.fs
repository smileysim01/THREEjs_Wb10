/*
 * Placeholder shader
 * The student should replace this with their own shader file.
 */

precision highp float;
uniform vec2 resolution;
uniform float time;

void main() {
    vec2  p = 7. * (2.*gl_FragCoord.xy-resolution.xy) / resolution.y;
    float m1 = sin(length(p)*0.3 - time*0.3);
    float m2 = sin(0.3*(length(p)*0.3 - time*0.3));
    float c1 = 0.012 / abs(length(mod(p,2.0*m1)-m1) - 0.3);
    float c2 = 0.012 / abs(length(mod(p,2.0*m2)-m2) - 0.3);

    gl_FragColor = vec4(vec3(1.,2.,8.)*c1 + vec3(8.,2.,1.)*c2, 1.0);
}

