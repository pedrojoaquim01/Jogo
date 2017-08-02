using C3.XNA;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGame
{
    public class Paddle : GameObject
    {
        public bool atira = false;
        public Ball ball;

        public override void Load(ContentManager content)
        {
            animation.textures = new Texture2D[1];
            animation.textures[0] = content.Load<Texture2D>("alien-vermelho");
            position = new Vector2( 250.0f, 400.0f );
            collider.size = new Vector2(55.0f, 37.0f);
        }
      
        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                position.X += 4.0f;
                
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                position.X -= 4.0f;
                
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                atira = true;
            }
           
        }
       
        public override void Draw(SpriteBatch spriteBatch)
        {
            Texture2D texture = animation.GetCurrentFrame();
            spriteBatch.Draw(texture, position, null, color,
                0.0f, Vector2.Zero, scale * 3.5f, SpriteEffects.None, 0.0f);

            collider.Draw(spriteBatch, position);
        }
    }
}
