/* Procedural shading example */
/* the student should make this more interesting */

/* pass interpolated variables to from the vertex */
varying vec2 v_uv;

uniform sampler2D tex;

void main()
{

    vec4 rope = texture(tex, v_uv);

    gl_FragColor = vec4(rope);
}

