﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using GMap.NET;
using GMap.NET.WindowsForms;
using MissionPlanner.Properties;

namespace MissionPlanner.Utilities
{
    public class GMapMarkerRallyPt : GMapMarker
   {
      public float? Bearing;

      static readonly System.Drawing.Size SizeSt = new System.Drawing.Size(Resources.marker_02.Width, Resources.marker_02.Height);

      //static Bitmap localcache1 = Resources.shadow50;
      static Bitmap localcache2 = Resources.marker_02;

      public GMapMarkerRallyPt(PointLatLng p)
         : base(p)
      {
         Size = SizeSt;
         Offset = new Point(-10, -40);
      }

      static readonly Point[] Arrow = new Point[] { new Point(-7, 7), new Point(0, -22), new Point(7, 7), new Point(0, 2) };

      public override void OnRender(Graphics g)
      {
#if !PocketPC
         if(!Bearing.HasValue)
         {
            // g.DrawImageUnscaled(localcache1, LocalPosition.X, LocalPosition.Y);
         }
         g.TranslateTransform(ToolTipPosition.X, ToolTipPosition.Y);

         if(Bearing.HasValue)
         {
            g.RotateTransform(Bearing.Value - Overlay.Control.Bearing);
            g.FillPolygon(Brushes.Red, Arrow);
         }

         g.ResetTransform();

         if(!Bearing.HasValue)
         {
             g.DrawImageUnscaled(localcache2, LocalPosition.X, LocalPosition.Y);
         }
#else
        //    DrawImageUnscaled(g, Resources.shadow50, LocalPosition.X, LocalPosition.Y);
            DrawImageUnscaled(g, Resources.marker, LocalPosition.X, LocalPosition.Y);
#endif
      }
   }
}
