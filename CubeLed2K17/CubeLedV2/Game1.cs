﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
//using CFPT.Manager;

namespace CubeLed
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
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
        Cube myCube;

        //BasicEffect for rendering
        BasicEffect basicEffect;

        //Orbit
        bool orbit = false;

        public Game1(IntPtr drawSurface)
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

            //Setup Camera
            camTarget = new Vector3(100f, 100f, 0f);
            camPosition = new Vector3(10f, 100f, -400f);
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
            myCube = new Cube(GraphicsDevice, 10, new Vector3(10, 10, 10));
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

            /*if (Keyboard.GetState().IsKeyDown(Keys.NumPad8))
            {
                if (mySphere.Brightness < 100)
                {
                    mySphere.Brightness++;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.NumPad2))
            {
                if (mySphere.Brightness > 0)
                {
                    mySphere.Brightness--;
                }
            }*/

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                camPosition.X -= 1f;
                camTarget.X -= 1f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                camPosition.X += 1f;
                camTarget.X += 1f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                camPosition.Y -= 1f;
                camTarget.Y -= 1f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                camPosition.Y += 1f;
                camTarget.Y += 1f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.PageUp) && camPosition.Z < -150f)
            {
                camPosition.Z += 1f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.PageDown))
            {
                camPosition.Z -= 1f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                orbit = !orbit;
            }

            if (orbit)
            {
                Matrix rotationMatrix = Matrix.CreateRotationY(
                                        MathHelper.ToRadians(1f));
                camPosition = Vector3.Transform(camPosition,
                              rotationMatrix);
            }
            viewMatrix = Matrix.CreateLookAt(camPosition, camTarget,
                         Vector3.Up);

            //mySphere.Update(gameTime);
            //myFace.Update(gameTime);
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

            //mySphere.Draw(viewMatrix, projectionMatrix);
            //myFace.Draw(viewMatrix, projectionMatrix);
            myCube.Draw(viewMatrix, projectionMatrix);
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
    }
}