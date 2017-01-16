﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CFPT.Manager;
using System;

namespace CubeLed2K17
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        public CubeLedManager CubeLedManager { get; set; }

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Camera
        Vector3 camTarget;
        Vector3 camPosition;
        Matrix projectionMatrix;
        Matrix viewMatrix;
        Matrix worldMatrix;

        int PreviousMouseState;
        MouseState CurrentMouseState;
        Cube myCube;
        private Texture2D cursorTexture;
        private Vector2 cursorPos;

        //BasicEffect for rendering
        BasicEffect basicEffect;

        //Orbit
        bool orbit = false;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
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

            myCube = new Cube(GraphicsDevice, 10, new Vector3(10, 10, 10));
            this.CubeLedManager = new CubeLedManager();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            cursorTexture = Content.Load<Texture2D>("Graphics\\HandGrab.png");
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
            this.cursorPos = new Vector2(CurrentMouseState.X - this.cursorTexture.Width / 2, CurrentMouseState.Y - cursorTexture.Height / 2);

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back ==
                            ButtonState.Pressed || Keyboard.GetState().IsKeyDown(
                            Keys.Escape))
                Exit();

            this.UsbUpdater(gameTime);

            // ------------ Important --------------- change the brightness of the led
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
            // ---------------------------------------

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

            CurrentMouseState = Mouse.GetState();
            camPosition.Z += (CurrentMouseState.ScrollWheelValue - PreviousMouseState < 0) ? 8 : 0;
            camPosition.Z -= (CurrentMouseState.ScrollWheelValue - PreviousMouseState > 0) ? 8 : 0;
            PreviousMouseState = CurrentMouseState.ScrollWheelValue;

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

            myCube.Update(gameTime);
            base.Update(gameTime);
            
        }

        private void UsbUpdater(GameTime gameTime)
        {
            if (this.CubeLedManager.IsConnected)
            {
                Console.WriteLine("Cube is connected");
            }

            if (this.CubeLedManager.CanCommunicate)
            {
                Console.WriteLine("Cube can communicate");
            }
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
            
            myCube.Draw(viewMatrix, projectionMatrix);
            spriteBatch.Begin();
            //spriteBatch.Draw(cursorTexture, new Rectangle((int)cursorPos.X, (int)cursorPos.Y, cursorTexture.Width, cursorTexture.Height), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        /*public Ray CalculateRay(Vector2 mouseLocation, Matrix view, Matrix projection, Viewport viewport)
        {
            Vector3 nearPoint = viewport.Unproject(new Vector3(mouseLocation.X,
                    mouseLocation.Y, 0.0f),
                    projection,
                    view,
                    Matrix.Identity);

            Vector3 farPoint = viewport.Unproject(new Vector3(mouseLocation.X,
                    mouseLocation.Y, 1.0f),
                    projection,
                    view,
                    Matrix.Identity);

            Vector3 direction = farPoint - nearPoint;
            direction.Normalize();

            return new Ray(nearPoint, direction);
        }

        public float? IntersectDistance(BoundingSphere sphere, Vector2 mouseLocation,
            Matrix view, Matrix projection, Viewport viewport)
        {
            Ray mouseRay = CalculateRay(mouseLocation, view, projection, viewport);
            return mouseRay.Intersects(sphere);
        }*/
    }
}
