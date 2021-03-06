﻿/* *
 * Projet : CubeLed2K17
 * Description : GUI for user interaction with the 3D Cube led.
 * Authors     : Devaud Alan, Amado Kevin & Mendez Gregory
 * Date        :
 * Version 1.0
 */
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace CubeLed2K17
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class CL2K17Viewer3D : Game
    {
        //public CubeLedManager CubeLedManager { get; set; }

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private IntPtr drawSurface;

        //Camera
        Vector3 camTarget;
        Vector3 camPosition;
        Matrix projectionMatrix;
        Matrix viewMatrix;
        Matrix worldMatrix;
        //Sphere mySphere;
        //Face myFace;
        CL2K17Cube myCube;

        //BasicEffect for rendering
        BasicEffect basicEffect;

        public int faceShowed;

        public CL2K17Viewer3D(IntPtr drawSurface)
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
            this.drawSurface = drawSurface;
            graphics.PreparingDeviceSettings +=
            new EventHandler<PreparingDeviceSettingsEventArgs>(graphics_PreparingDeviceSettings);
            System.Windows.Forms.Control.FromHandle((this.Window.Handle)).VisibleChanged +=
            new EventHandler(Game1_VisibleChanged); 
            //this.CubeLedManager = new CubeLedManager();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
            faceShowed = 0;
            //Setup Camera
            camTarget = new Vector3(100f, 110f, 0f);
            camPosition = new Vector3(90f, 100f, -300f);
            projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45f), GraphicsDevice.DisplayMode.AspectRatio, 1f, 1000f);
            viewMatrix = Matrix.CreateLookAt(camPosition, camTarget, new Vector3(0f, 1f, 0f));// Y up
            worldMatrix = Matrix.CreateWorld(camTarget, Vector3.Forward, Vector3.Up);

            //BasicEffect
            basicEffect = new BasicEffect(GraphicsDevice);
            basicEffect.Alpha = 1f;

            // Want to see the colors of the vertices, this needs to be on
            basicEffect.VertexColorEnabled = true;

            //Lighting requires normal information which VertexPositionColor does not have
            //If you want to use lighting and VPC you need to create a custom def
            basicEffect.LightingEnabled = false;

            //mySphere = new Sphere(GraphicsDevice, 10, new Vector3(10,10,10));
            //myFace = new Face(GraphicsDevice, 10, new Vector3(10, 10, 10),1);
            myCube = new CL2K17Cube(GraphicsDevice, 10, new Vector3(10, 10, 10));
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back ==
                            ButtonState.Pressed || Keyboard.GetState().IsKeyDown(
                            Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                //camPosition.X -= 1f;
                camTarget.X -= 1f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
              //  camPosition.X += 1f;
                camTarget.X += 1f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                //camPosition.Y -= 1f;
                camTarget.Y -= 1f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
              //  camPosition.Y += 1f;
                camTarget.Y += 1f;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.NumPad0))
            {
                faceShowed = 0;    
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.NumPad1))
            {
                faceShowed = 1;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.NumPad2))
            {
                faceShowed = 2;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.NumPad3))
            {
                faceShowed = 3;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.NumPad4))
            {
                faceShowed = 4;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.NumPad5))
            {
                faceShowed = 5;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.NumPad6))
            {
                faceShowed = 6;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.NumPad7))
            {
                faceShowed = 7;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.NumPad8))
            {
                faceShowed = 8;
            }

            viewMatrix = Matrix.CreateLookAt(camPosition, camTarget,
                         Vector3.Up);

            myCube.Update(gameTime);
            base.Update(gameTime);
            
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            basicEffect.Projection = projectionMatrix;
            basicEffect.View = viewMatrix;
            basicEffect.World = worldMatrix;

            GraphicsDevice.Clear(Color.CornflowerBlue);

            //Turn off culling so we see both sides of our rendered triangle
            RasterizerState rasterizerState = new RasterizerState();
            rasterizerState.CullMode = CullMode.None;
            GraphicsDevice.RasterizerState = rasterizerState;

            switch (faceShowed)
            {
                case 1:
                    myCube.showFace(0, viewMatrix, projectionMatrix);
                    break;
                case 2:
                    myCube.showFace(1, viewMatrix, projectionMatrix);
                    break;
                case 3:
                    myCube.showFace(2, viewMatrix, projectionMatrix);
                    break;
                case 4:
                    myCube.showFace(3, viewMatrix, projectionMatrix);
                    break;
                case 5:
                    myCube.showFace(4, viewMatrix, projectionMatrix);
                    break;
                case 6:
                    myCube.showFace(5, viewMatrix, projectionMatrix);
                    break;
                case 7:
                    myCube.showFace(6, viewMatrix, projectionMatrix);
                    break;
                case 8:
                    myCube.showFace(7, viewMatrix, projectionMatrix);
                    break;
                case 0:
                    myCube.Draw(viewMatrix, projectionMatrix);
                    break;
            }

            base.Draw(gameTime);
        }

        void graphics_PreparingDeviceSettings(object sender, PreparingDeviceSettingsEventArgs e)
        {
            e.GraphicsDeviceInformation.PresentationParameters.DeviceWindowHandle =
            drawSurface;
        }

        private void Game1_VisibleChanged(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Control.FromHandle((this.Window.Handle)).Visible == true)
                System.Windows.Forms.Control.FromHandle((this.Window.Handle)).Visible = false;
        }

        /// <summary>
        /// Change on/off the led
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public void ChangeLed(int x, int y, int z)
        {
            // % 8 is for protect the function
            myCube.ChangeLed(Math.Abs(x - 7) % 8, y % 8, Math.Abs(z - 7) % 8);
        }

        //
        public void SelectLed(int x, int y, int z)
        {
            // % 8 is for protect the function
            myCube.SelectLed(Math.Abs(x - 7) % 8, y % 8, Math.Abs(z - 7) % 8);
        }

        public string[, ,] GetCubeState()
        {
            return this.myCube.GetCubeState();
        }
    }
}
