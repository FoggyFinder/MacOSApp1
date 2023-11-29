using ObjCRuntime;
using SkiaSharp.Views.Mac;
using SkiaSharp;

namespace macOSApp1;

public partial class ViewController : NSViewController {
	protected ViewController (NativeHandle handle) : base (handle)
	{
		// This constructor is required if the view controller is loaded from a xib or a storyboard.
		// Do not put any initialization here, use ViewDidLoad instead.
	}

    private SkiaSharp.Views.Mac.SKCanvasView skiaView;
    public override void ViewDidLoad()
    {
        base.ViewDidLoad();
        if (skiaView is null)
        {
            skiaView = new SKCanvasView
            {
                Frame = new CGRect(0, 0, 600, 400)
            };
            this.View = skiaView;
        }
        skiaView.IgnorePixelScaling = true;
        skiaView.PaintSurface += OnPaintSurface;
    }

    private void OnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
    {
        // the the canvas and properties
        var canvas = e.Surface.Canvas;

        // make sure the canvas is blank
        canvas.Clear(SKColors.White);

        // draw some text
        var paint = new SKPaint
        {
            Color = SKColors.Black,
            IsAntialias = true,
            Style = SKPaintStyle.Fill,
            TextAlign = SKTextAlign.Center,
            TextSize = 24
        };
        var coord = new SKPoint(e.Info.Width / 2, (e.Info.Height + paint.TextSize) / 2);
        canvas.DrawText("SkiaSharp", coord, paint);
    }

    public override NSObject RepresentedObject {
		get => base.RepresentedObject;
		set {
			base.RepresentedObject = value;

			// Update the view, if already loaded.
		}
	}
}

