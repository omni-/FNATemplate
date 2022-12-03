using System;
using Microsoft.Xna.Framework;
using FNATemplate.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using FNATemplate.Objects;

class FNAGame : Game
{
    [STAThread]
    static void Main(string[] args)
    {
        using (FNAGame g = new FNAGame())
        {
            g.Run();
        }
    }
    private InputManager _inputManager { get; init; }

    private SpriteBatch batch;
    private Player p;
    private SoundEffect sound;

    private FNAGame()
    {
        GraphicsDeviceManager gdm = new GraphicsDeviceManager(this);

        // Typically you would load a config here...
        gdm.PreferredBackBufferWidth = 680;
        gdm.PreferredBackBufferHeight = 470;
        gdm.IsFullScreen = false;
        gdm.SynchronizeWithVerticalRetrace = true;
        _inputManager = new();
        Content.RootDirectory = "resources";
    }


    protected override void Initialize()
    {
        /* This is a nice place to start up the engine, after
		 * loading configuration stuff in the constructor
		 */
        p = new Player();
        base.Initialize();
    }

    protected override void LoadContent()
    {
        // Create the batch...
        batch = new SpriteBatch(GraphicsDevice);

        p.Sprite = Content.Load<Texture2D>("sprites/sample1.png");
        sound = Content.Load<SoundEffect>("sounds/hp.wav");
    }

    protected override void UnloadContent()
    {
        // Clean up after yourself!
        base.UnloadContent();
    }

    protected override void Update(GameTime gameTime)
    {
        if (_inputManager.IsNewKeypress(Keys.Space))
        {
            Console.WriteLine("spacebar pressed");
            sound.Play();
        }

        p.Update(gameTime, _inputManager);

        // Run game logic in here. Do NOT render anything here!
        _inputManager.Update();
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        // Render stuff in here. Do NOT run game logic in here!
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // Draw the texture to the corner of the screen
        batch.Begin();
        batch.Draw(p.Sprite, p.Position, Color.White);
        batch.End();

        base.Draw(gameTime);
    }
}