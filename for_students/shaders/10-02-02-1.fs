/* simplest possible fragment shader - just a constant color */
/* but a wrinkle: we pass the color from the javascript program in a uniform */
uniform vec3 color;

// We also passed in the time as a uniform (for bonus exercise)
uniform float time;

void main()
{
    float m = abs(sin(time* 5.0)/2.0 + 0.5);
    gl_FragColor = vec4(m, 0.8,0.8,1);
}

