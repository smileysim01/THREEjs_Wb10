/* Procedural shading example */
/* the student should make this more interesting */

/* pass interpolated variables to from the vertex */
varying vec2 v_uv;

/* colors for the dots */
uniform vec3 light;
uniform vec3 dark;

/* number of dots over the UV range */
uniform float dots;

/* how big are the circles */
uniform float radius;

varying vec3 l_normal;

// note that this is in WORLD COORDINATES
const vec3 lightDirWorld = vec3(0,0,1);

void main()
{
    float x = v_uv.x * dots;
    float y = v_uv.y * dots;

    float xc = floor(x);
    float yc = floor(y);

    float dx = x-xc-.5;
    float dy = y-yc-.5;

    float d = sqrt(dx*dx + dy*dy);
    float dc = step(d,radius);

    vec3 color;
    
    if(mod(xc+yc,2.0)==0.0)  color = dark;
    else    color = vec3(0,1,0);

        vec3 nhat = normalize(l_normal);

    // get the lighting vector in the view coordinates
    vec3 lightDir = normalize(vec4(lightDirWorld, 0)).xyz;

    // deal with two sided lighting
    float dlight = dot(nhat, lightDir);

    gl_FragColor = vec4(dlight * mix(light,color,dc), 1.);
}

