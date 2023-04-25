/* Procedural shading example */
/* the student should make this more interesting */

/* pass interpolated variables to from the vertex */
varying vec2 v_uv;

uniform sampler2D earth_tex;
uniform sampler2D space_map;

// @@Snippet:simple_lighting
varying vec3 v_normal;

// note that this is in VIEW COORDINATES
const vec3 lightDir = vec3(0,0,1);

void main()
{

    vec4 etex = texture(earth_tex, v_uv);
    vec4 stex = texture(space_map, v_uv);

    // we need to renormalize the normal since it was interpolated
    vec3 nhat = normalize(v_normal);

    // deal with two sided lighting
    // light comes from above and below (use clamp rather than abs to get one sided)
    float light = abs(dot(nhat, lightDir));

    vec4 color = mix(etex,stex,v_uv.x);

    // brighten the base color
    gl_FragColor = vec4(light * color);
}

