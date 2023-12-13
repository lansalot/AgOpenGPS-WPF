﻿using OpenTK.Graphics.OpenGL;
using System;

namespace AgOpenGPS.Simulation
{
    public class SimulationCamera
    {
        private double camPosX;
        private double camPosY;
        private readonly double camPosZ;

        //private double fixHeading;
        private double camYaw;

        public double camPitch;
        public double offset;
        public double camSetDistance = -75;

        public double gridZoom;

        public double zoomValue = 15;
        public double previousZoom = 25;

        public bool camFollowing;
        public int camMode = 0;
        public double camSmoothFactor;

        public IConfiguration Configuration { get; }

        //private double camDelta = 0;

        public SimulationCamera(IConfiguration configuration)
        {
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            camPitch = Configuration.Get<double>("setDisplay_camPitch");
            zoomValue = Configuration.Get<double>("setDisplay_camZoom");
            camPosZ = 0.0;
            camFollowing = true;
            camSmoothFactor = Configuration.Get<double>("setDisplay_camSmooth");
        }

        public void SetWorldCam(double _fixPosX, double _fixPosY, double _fixHeading)
        {
            camPosX = _fixPosX;
            camPosY = _fixPosY;
            camYaw = _fixHeading;

            //back the camera up
            GL.Translate(0.0, 0.0, camSetDistance * 0.5);
            //rotate the camera down to look at fix
            GL.Rotate(camPitch, 1.0, 0.0, 0.0);

            ////draw the guide
            //GL.Begin(PrimitiveType.Triangles);
            //GL.Color3(0.98f, 0.0f, 0.0f);
            //GL.Vertex3(0.0f, -2.0f, 0.0f);
            //GL.Color3(0.0f, 0.98f, 0.0f);
            //GL.Vertex3(-2.0f, -3.0f, 0.0f);
            //GL.Color3(0.98f, 0.98f, 0.0f);
            //GL.Vertex3(2.0f, -3.0f, 0.0f);
            //GL.End();						// Done Drawing Reticle

            //following game style or N fixed cam
            if (camFollowing)
            {
                GL.Rotate(camYaw, 0.0, 0.0, 1.0);
                GL.Translate(-camPosX, -camPosY, -camPosZ);
            }
            else
            {
                GL.Translate(-camPosX, -camPosY, -camPosZ);
            }
        }
    }

}
