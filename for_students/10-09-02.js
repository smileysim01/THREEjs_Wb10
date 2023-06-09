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

  let earth_texture = new T.TextureLoader().load("textures/earth.jpg");
  let space_texture = new T.TextureLoader().load("textures/space.jpg");

  /**
   *
   * @param {GrObject} obj
   * @param {number} [speed=0.5] - rotations per second
   */
 function spinY(obj, speed = 0.5) {
   obj.stepWorld = function (delta, timeOfDay) {
     obj.objects.forEach((obj) =>
       obj.rotateY(((speed * delta) / 1000) * Math.PI)
     );
   };
   return obj;
 }
  
  let shaderMat = shaderMaterial("./shaders/10-09-02.vs", "./shaders/10-09-02.fs", {
    side: T.DoubleSide,
    uniforms: {
      earth_tex: {value: earth_texture},
      space_map: {value: space_texture}
    },
  });

  world.add(
    spinY(
      new SimpleObjects.GrSphere({
        x: -2,
        y: 1,
        widthSegments: 100,
        heightSegments: 100,
        material: shaderMat,
      })
    )
  );

  world.add(new SimpleObjects.GrSphere({ x: -2, y: 1, material: shaderMat }));
  world.add(
    new SimpleObjects.GrSquareSign({ x: 2, y: 1, size: 1, material: shaderMat })
  );

  world.go();
}
