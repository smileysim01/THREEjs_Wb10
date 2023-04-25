/* Procedural shading example */
/* the student should make this more interesting */

/* pass interpolated variables to from the vertex */
varying vec2 v_uv;

/* color for the bricks */
uniform vec3 dark;
uniform vec3 light;

/* number of checks over the UV range */
uniform float bricks;

float lightIntensity;

void main()
{
    float x = v_uv.x * bricks;
    float y = v_uv.y * bricks * 2.0;

    float xc = floor(x);
    float yc = floor(y);

    float d = .5;

    float dx = x-xc-d;
    float dy = y-yc-d;

    float dc = step(mod(xc + yc, 3.0), 0.0);

    gl_FragColor = vec4(mix(light,dark,dc), 1.);
}

