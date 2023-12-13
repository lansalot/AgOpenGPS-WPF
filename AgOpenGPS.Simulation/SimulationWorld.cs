using OpenTK.Graphics.OpenGL;
using System;
using System.Drawing;

namespace AgOpenGPS.Simulation
{
    public class SimulationWorld
    {
            //Y
            public double northingMax;
            public double northingMin;

            //X
            public double eastingMax;
            public double eastingMin;

            //Y
            public double northingMaxGeo;
            public double northingMinGeo;
            //X
            public double eastingMaxGeo;
            public double eastingMinGeo;

            public double GridSize = 4000;
            public double Count = 30;
            public bool isGeoMap = false;

        public IConfiguration Configuration { get; }
        public SimulationCamera SimulationCamera { get; }

        public SimulationWorld(IConfiguration configuration,SimulationCamera simulationCamera)
            {
                northingMaxGeo = 300;
                northingMinGeo = -300;
                eastingMaxGeo = 300;
                eastingMinGeo = -300;
            Configuration = configuration;
            SimulationCamera = simulationCamera;
        }

            public void DrawFieldSurface()
            {
                Color field = Configuration.Get<Color>("fieldColorDay");
            var isDay = Configuration.Get<bool>("isDay");
            var zoomValue = SimulationCamera.zoomValue;
            var textures = Configuration.Get<int[]>("texture");
            if (!isDay) field = Configuration.Get<Color>("fieldColorNight");

                if (Configuration.Get<bool>("isTextureOn"))
                {
                //adjust bitmap zoom based on cam zoom
                    if (zoomValue > 100) Count = 4;
                    else if (zoomValue > 80) Count = 8;
                    else if (zoomValue > 50) Count = 16;
                    else if (zoomValue > 20) Count = 32;
                    else if (zoomValue > 10) Count = 64;
                    else Count = 80;

                    GL.Enable(EnableCap.Texture2D);
                    GL.Color3(field.R, field.G, field.B);
                    GL.BindTexture(TextureTarget.Texture2D, textures[1]);
                    GL.Begin(PrimitiveType.TriangleStrip);

                    GL.TexCoord2(0, 0);
                    GL.Vertex3(eastingMin, northingMax, 0.10);
                    GL.TexCoord2(Count, 0.0);
                    GL.Vertex3(eastingMax, northingMax, 0.10);
                    GL.TexCoord2(0.0, Count);
                    GL.Vertex3(eastingMin, northingMin, 0.10);
                    GL.TexCoord2(Count, Count);
                    GL.Vertex3(eastingMax, northingMin, 0.10);

                    GL.End();

                    if (isGeoMap && zoomValue > 10)
                    {
                        GL.BindTexture(TextureTarget.Texture2D, textures[20]);
                        GL.Begin(PrimitiveType.TriangleStrip);
                        GL.Color3(0.6f, 0.6f, 0.6f);
                        GL.TexCoord2(0, 0);
                        GL.Vertex3(eastingMinGeo, northingMaxGeo, 0.0);
                        GL.TexCoord2(1, 0.0);
                        GL.Vertex3(eastingMaxGeo, northingMaxGeo, 0.0);
                        GL.TexCoord2(0.0, 1);
                        GL.Vertex3(eastingMinGeo, northingMinGeo, 0.0);
                        GL.TexCoord2(1, 1);
                        GL.Vertex3(eastingMaxGeo, northingMinGeo, 0.0);

                        GL.End();
                    }
                    GL.Disable(EnableCap.Texture2D);
                }
                else
                {
                    GL.Color3(field.R, field.G, field.B);
                    GL.Begin(PrimitiveType.TriangleStrip);
                    GL.Vertex3(eastingMin, northingMax, 0.0);
                    GL.Vertex3(eastingMax, northingMax, 0.0);
                    GL.Vertex3(eastingMin, northingMin, 0.0);
                    GL.Vertex3(eastingMax, northingMin, 0.0);
                    GL.End();

                    if (isGeoMap && zoomValue > 10)
                    {
                        GL.Enable(EnableCap.Texture2D);
                        GL.Color3(0.6f, 0.6f, 0.6f);
                        GL.BindTexture(TextureTarget.Texture2D, textures[20]);
                        GL.Begin(PrimitiveType.TriangleStrip);

                        GL.TexCoord2(0, 0);
                        GL.Vertex3(eastingMinGeo, northingMaxGeo, 0.0);
                        GL.TexCoord2(1, 0.0);
                        GL.Vertex3(eastingMaxGeo, northingMaxGeo, 0.0);
                        GL.TexCoord2(0.0, 1);
                        GL.Vertex3(eastingMinGeo, northingMinGeo, 0.0);
                        GL.TexCoord2(1, 1);
                        GL.Vertex3(eastingMaxGeo, northingMinGeo, 0.0);

                        GL.End();
                        GL.Disable(EnableCap.Texture2D);
                    }
                }
            }

            public void DrawWorldGrid(double _gridZoom)
            {
                _gridZoom *= 0.5;
            var isDay = Configuration.Get<bool>("isDay");

            if (isDay)
                {
                    GL.Color3(0.5, 0.5, 0.5);
                }
                else
                {
                    GL.Color3(0.17, 0.17, 0.17);
                }
                GL.LineWidth(1);
                GL.Begin(PrimitiveType.Lines);
                for (double num = Math.Round(eastingMin / _gridZoom, MidpointRounding.AwayFromZero) * _gridZoom; num < eastingMax; num += _gridZoom)
                {
                    if (num < eastingMin) continue;

                    GL.Vertex3(num, northingMax, 0.1);
                    GL.Vertex3(num, northingMin, 0.1);
                }
                for (double num2 = Math.Round(northingMin / _gridZoom, MidpointRounding.AwayFromZero) * _gridZoom; num2 < northingMax; num2 += _gridZoom)
                {
                    if (num2 < northingMin) continue;

                    GL.Vertex3(eastingMax, num2, 0.1);
                    GL.Vertex3(eastingMin, num2, 0.1);
                }
                GL.End();
            }

            public void checkZoomWorldGrid(double northing, double easting)
            {
                double n = Math.Round(northing / (GridSize / Count * 2), MidpointRounding.AwayFromZero) * (GridSize / Count * 2);
                double e = Math.Round(easting / (GridSize / Count * 2), MidpointRounding.AwayFromZero) * (GridSize / Count * 2);

                northingMax = n + GridSize;
                northingMin = n - GridSize;
                eastingMax = e + GridSize;
                eastingMin = e - GridSize;
            }
    }

}
