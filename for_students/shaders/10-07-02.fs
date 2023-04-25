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

    float dx = x-xc-d;
    float dy = y-yc-d;

    float m = max(dx,dy);

    float a = fwidth(d);
    
    float dc = 1.0 - (smoothstep(d-a, d+a, d));

    gl_FragColor = vec4(mod(xc+yc,2.0)!=1.0 ? mix(light,dark,dc):mix(dark,light,dc), 1.);
}


