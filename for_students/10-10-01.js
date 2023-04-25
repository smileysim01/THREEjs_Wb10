/*jshint esversion: 6 */
// @ts-check

import * as T from "../libs/CS559-Three/build/three.module.js";
import { GrWorld } from "../libs/CS559-Framework/GrWorld.js";
import { GrObject } from "../libs/CS559-Framework/GrObject.js";
import * as InputHelpers from "../libs/CS559/inputHelpers.js";
import * as SimpleObjects from "../libs/CS559-Framework/SimpleObjects.js";
import { shaderMaterial } from "../libs/CS559-Framework/shaderHelper.js";

{
  let mydiv = document.getElementById("div1");

  let world = new GrWorld({ width: mydiv ? 600 : 800, where: mydiv });
  
  // Replace these files with your own shaders!
  let res= new T.Vector2(800,800);
  let shaderMat = shaderMaterial("./shaders/10-10-01.vs", "./shaders/10-10-01.fs", {
    side: T.DoubleSide,
    uniforms: {
      time: {value:0.0},
      resolution:{value: res}
    },
  });

  let sphere = new SimpleObjects.GrSphere({ x: -2, y: 1, material: shaderMat })
  let wall = new SimpleObjects.GrSquareSign({ x: 2, y: 1, size: 1, material: shaderMat });

  let aniTime = 0;
  wall.stepWorld = function (delta, timeofday) {
    aniTime += delta;
    let newR = Math.sin(aniTime / 200) / 2 + 0.5; // get a number between 0-1
    shaderMat.uniforms.resolution.value.x = newR;
    shaderMat.uniforms.time.value = aniTime * 0.001; // pass in the time in seconds
  };
  aniTime = 0;
  sphere.stepWorld = function (delta, timeofday) {
    aniTime += delta;
    let newR = Math.sin(aniTime / 200) / 2 + 0.5; // get a number between 0-1
    shaderMat.uniforms.resolution.value.x = newR;
    shaderMat.uniforms.time.value = aniTime * 0.001; // pass in the time in seconds
  };

  world.add(sphere);
  world.add(wall);

  world.go();
}
