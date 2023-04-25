/* a simple procedural texture */
/* the student should change this to implement a checkerboard */

/* passed interpolated variables to from the vertex */
varying vec2 v_uv;

/* colors for the checkerboard */
uniform vec3 light;
uniform vec3 dark;

/* number of checks over the UV range */
uniform float checks;

uniform float blur;

void main()
{
    float x = v_uv.x * checks;
    float y = v_uv.y * checks;

    float xc = floor(x);
    float yc = floor(y);

    float d = .5;

    float dx = abs(d-fract(x));
    float dy = abs(d-fract(y));

    vec3 fl,n_fl;
    mod(xc+yc,2.)!=1. ? fl=light, n_fl=dark : fl=dark, n_fl=light;

    float m = max(dx,dy);

    float a = fwidth(m);
    
    float dc = smoothstep(d-a, d,m)/2.;

    gl_FragColor = vec4(mix(fl, n_fl, dc), 1.);
}