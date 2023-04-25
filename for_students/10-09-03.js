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

  let texture = new T.TextureLoader().load("textures/rope.jpg");

  let shaderMat = shaderMaterial("./shaders/10-09-03.vs", "./shaders/10-09-03.fs", {
    side: T.DoubleSide,
    uniforms: {
      tex: {value: texture}
    },
  });

  let s_seg = new InputHelpers.LabelSlider("segs", {
    width: 400,
    min: 4,
    max: 32,
    step: 1,
    initial: 8,
    where: mydiv,
  });

  let sphere = new SimpleObjects.GrSphere({ x: -2, y: 1, material: shaderMat });

  world.add(sphere);
  world.add(
    new SimpleObjects.GrSquareSign({ x: 2, y: 1, size: 1, material: shaderMat })
  );

  world.go();

  function onchangecomplexity() {
    let m = s_seg.value();
    sphere.setSegmentation(m,m-2);
  }
  s_seg.oninput = onchangecomplexity;
  onchangecomplexity();
}
