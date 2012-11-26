﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Californium;
using SFML.Graphics;
using SFML.Window;

namespace Example.Entities
{
    class Panel : Entity
    {
        private bool dragging;
        private Vector2f dragOffset;

        public Panel()
        {
            Size = new Vector2f(100, 100);
            Position = new Vector2f(10, 10);
            
            Input.MouseButton[Mouse.Button.Left] = args =>
            {
                var pos = args.Position;
                if (!BoundingBox.Contains(pos.X, pos.Y))
                    return false;

                if (args.Pressed && !dragging)
                {
                    dragging = true;
                    dragOffset = new Vector2f(Position.X - pos.X, Position.Y - pos.Y);
                }
                else if (!args.Pressed && dragging)
                {
                    dragging = false;
                }

                return true;
            };

            Input.MouseMove = args =>
            {
                var pos = args.Position;

                if (!dragging)
                    return false;

                Position = new Vector2f(pos.X, pos.Y) + dragOffset;
                return true;
            };
        }

        public override void Update(float dt)
        {
            var bounds = Parent.Camera.Bounds;

            if (Position.X < bounds.Left) Position.X = bounds.Left;
            if (Position.Y < bounds.Top) Position.Y = bounds.Top;
            if (Position.X > bounds.Left + bounds.Width - 100) Position.X = bounds.Left + bounds.Width - 100;
            if (Position.Y > bounds.Top + bounds.Height - 100) Position.Y = bounds.Top + bounds.Height - 100;
        }

        public override void Draw(RenderTarget rt)
        {
            var shape = new RectangleShape(Size);
            shape.FillColor = new Color(255, 255, 255, 128);
            shape.Position = Position;

            rt.Draw(shape);
        }
    }
}