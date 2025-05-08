// LAB_02
// Naresh P. Koirala
// Submission Code : 1241_2300_L02
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Drawing;
using GDIDrawer;

namespace nkoirala1_Lab02 
{
    internal class Ball : IComparable<Ball>
    {
        public static float Friction = 0.991f;
        static Random _rnd = new Random();
        Vector2 _center;
        Vector2 _velocity;
        public Vector2 Center { get { return _center; } }
        public Vector2 Velocity { get { return _velocity; } }
        public int Radius { get; private set; }
        public int Hits { get; private set; }
        public int TotalHits { get; private set; }
        public Color BallColor { get; private set; }


        public Ball(CDrawer _drawer, Color _clr)
        { 
            BallColor = _clr;
            Radius = _rnd.Next(20, 51);
            _center = new Vector2(_rnd.Next(Radius, (_drawer.m_ciWidth - Radius)), _rnd.Next(Radius, _drawer.m_ciHeight - Radius));
        }

        public Ball(CDrawer _drawer)
        {
            Radius = 30;
            BallColor = Color.White;
            _center = new Vector2(_rnd.Next(Radius, _drawer.m_ciWidth - Radius ), _rnd.Next(Radius, _drawer.m_ciHeight - Radius));
        }

        public void ResetHits()
        {
            Hits = 0;
        }

        public void SetVelocity(Vector2 velo)
        {
            _velocity = velo;
        }

        public override bool Equals(object obj)
        {
            if (obj is Ball otherBall)
            {
                float distance = Vector2.Distance(this.Center, otherBall.Center);

                return distance < (this.Radius + otherBall.Radius);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return 1;
        }

        public override string ToString()
        {
            return Radius + " : " + Hits;
        }

        public void Show(CDrawer _drawer)
        {
            if (BallColor == Color.White)
            {
                _drawer.AddCenteredEllipse((int)_center.X, (int)_center.Y, Radius * 2 , Radius * 2 , BallColor, 2, Color.Yellow);
            }
            else
            {
                _drawer.AddCenteredEllipse((int)_center.X, (int)_center.Y, Radius * 2, Radius * 2, BallColor);
            }

            _drawer.AddText(this.ToString(), Radius / 4, (int)_center.X - Radius, (int)_center.Y - Radius, Radius * 2, Radius * 2,Color.Black);
        }

        public void Move(CDrawer _drawer, List<Ball> balls)
        {
            this._velocity *= Friction;

            if (Velocity.LengthSquared() < 0.1f)
            {
                _velocity = Vector2.Zero;
                return;
            }

            if (_center.X - Radius <= 0 || _center.X + Radius >= _drawer.m_ciWidth)
                _velocity.X = -_velocity.X;
            if (_center.Y - Radius <= 0 || _center.Y + Radius >= _drawer.m_ciHeight)
                _velocity.Y = -_velocity.Y;


            _center += _velocity;

            foreach (Ball target in balls)
            {
                if (target != this && this.Equals(target))
                {
                    ProcessCollision(target);
                    Hits++;
                    TotalHits++;
                }
            }
        }

        /// <summary>
        /// Processes the collision between this ball and a target ball.
        /// Updates the velocities to reflect the collision and ensures that balls do not overlap post-collision.
        /// </summary>
        /// <param name="tar">The target ball involved in the collision.</param>
        private void ProcessCollision(Ball tar)
        {
            Vector2 dist = tar._center - _center; // Get Collision Vector
            Vector2 myNorm = Vector2.Normalize(tar._center - _center); // Normalize for invoking ball
            Vector2 targetNorm = Vector2.Normalize(_center - tar._center); // Normalize for target ball

            // Calculate Radius weighted velocity vector
            //Vector2 CMVelocity = Vector2.Add(Vector2.Multiply((float)_iRadius / (_iRadius + tar._iRadius), _v), Vector2.Multiply((float)tar._iRadius / (_iRadius + tar._iRadius), tar._v));
            Vector2 CMVelocity = (_velocity * ((float)Radius / (Radius + tar.Radius)) + (tar._velocity * ((float)tar.Radius / (Radius + tar.Radius))));

            // Process invoking ball
            _velocity -= CMVelocity;// Vector2.Subtract(_v, CMVelocity);
            _velocity = Vector2.Reflect(_velocity, myNorm); // perform "bounce"
            _velocity += CMVelocity;// Vector2.Add(_v, CMVelocity);
            Hits++;
            TotalHits++;

            // Process target ball
            tar._velocity -= CMVelocity;
            tar._velocity = Vector2.Reflect(tar._velocity, targetNorm); // perform bounce
            tar._velocity += CMVelocity;// Vector2.Add(tar._v, CMVelocity);
            tar.Hits++;
            tar.TotalHits++;

            // "Fix" collision if balls overlapped - could apply weighted adjustment shift between both balls
            //       but here we just move the target ball over on collision vector so it doesn't overlap
            //tar._center = Vector2.Add(tar._center, Vector2.Multiply((float)((_iRadius + tar._iRadius - dist.Length()) / (_iRadius + tar._iRadius)), dist));
            tar._center += dist * (float)((Radius + tar.Radius - dist.Length()) / (Radius + tar.Radius));
        }

        public int CompareTo(Ball other)
        {
            return other.Radius.CompareTo(this.Radius);
        }

        public static int CompareByHit(Ball a, Ball b) => b.Hits.CompareTo(a.Hits);


        public static int CompareByTotalHits(Ball a, Ball b) => b.TotalHits.CompareTo(a.TotalHits);

    }
}
