﻿using Xamarin.Forms;

namespace XFlayout
{
    class XFPage3 : ContentPage
    {
        public XFPage3()
        {
            var layout = new RelativeLayout();

            var label1 = new Label()
            {
                Text = "This is a line of text"
            };

            layout.Children.Add(label1,
                Constraint.Constant(0),
                Constraint.RelativeToParent(parent =>
                {
                    return parent.Height / 2;
                }));

            var label2 = new Label()
            {
                Text = "More Text over here"
            };

            layout.Children.Add(label2,
                Constraint.RelativeToView(label1, (parent, otherView) =>
                {
                    return otherView.X + otherView.Width;
                }),
                Constraint.RelativeToView(label1, (parent, otherView) =>
                {
                    return otherView.Y - otherView.Height;
                }));

            var label3 = new Label()
            {
                Text = "Last text added"
            };

            layout.Children.Add(label3,
                Constraint.RelativeToView(label2, (parent, otherView) => {
                    return (otherView.X + otherView.Width) - label3.Width;
                }),
                Constraint.RelativeToView(label1, (parent, otherView) => {
                    return otherView.Y;
                }));
            label3.SizeChanged += (o, e) => { layout.ForceLayout(); };
            Content = layout;
        }
    }
}
