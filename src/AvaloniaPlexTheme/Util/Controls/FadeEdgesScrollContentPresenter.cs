using Avalonia;
using Avalonia.Animation.Easings;
using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Threading;
using Avalonia.VisualTree;
using System;
using Avalonia.LogicalTree;
using System.IO;

namespace AvaloniaPlexTheme
{
    public enum StartCorner
    {
        TopLeft,
        TopRight,
        BottomRight,
        BottomLeft
    }


    public class FadeEdgesScrollContentPresenter : ScrollContentPresenter
    {
        static readonly Vector PX_DPI = new Vector(1, 1);
        static readonly Color FILL_COLOR = Color.FromArgb(0xFF, 0x7F, 0x7F, 0x7F);
        static readonly Thickness EDGE_FADE_THICKNESS = new Thickness(48);
        static readonly IEasing EDGE_FADE_EASE = new LinearEasing();
        static readonly string DEBUG_SAVE_PATH = Path.Combine(Environment.CurrentDirectory, "FadeEdgesDebug");
        //static bool DEBUG_PRINT_ALPHA_CALC = true;
        const bool DEBUG_SAVE_MASK = false;
        const bool DEBUG_DRAW_SAMPLE_PATTERN = false;
        const bool DEBUG_FORCE_DRAW_EDGES = true;
        


        static FadeEdgesScrollContentPresenter()
        {
            if (DEBUG_SAVE_MASK)
            {
                if (!Directory.Exists(DEBUG_SAVE_PATH))
                    Directory.CreateDirectory(DEBUG_SAVE_PATH);
            }
            
            PaddingProperty.Changed.AddClassHandler<FadeEdgesScrollContentPresenter>((x, e) => x.RefreshPadding());
            //ChildProperty.Changed.AddClassHandler<FadeEdgesScrollContentPresenter>((x, e) => x.RefreshMask());
            
            AvaloniaProperty[] contentPositioningProps =
            {
                ContentProperty,
                ContentTemplateProperty,
                PaddingProperty,
                BoundsProperty,
                //ExtentProperty,
                OffsetProperty,
            };

            foreach (AvaloniaProperty prop in contentPositioningProps)
            {
                prop.Changed.AddClassHandler<FadeEdgesScrollContentPresenter>(OnContentPositioningPropertiesChanged);
                AffectsRender<FadeEdgesScrollContentPresenter>(prop);
                //AffectsArrange<FadeEdgesScrollContentPresenter>(prop);
                //AffectsMeasure<FadeEdgesScrollContentPresenter>(prop);
            }


            ExtentProperty.Changed.AddClassHandler<FadeEdgesScrollContentPresenter>(OnContentPositioningPropertiesChanged);
        }

        static void OnContentPositioningPropertiesChanged(object sender, AvaloniaPropertyChangedEventArgs e)
        {
            if (sender is FadeEdgesScrollContentPresenter sned)
                sned.RefreshMask();
        }

        static void OnPaddingPropertyChanged(object sender, AvaloniaPropertyChangedEventArgs e)
        {
            if (sender is FadeEdgesScrollContentPresenter sned)
                sned.RefreshPadding();
        }



        static byte CalcAlpha(double start, double end, double pos)
        {
            //double extreme1 = Math.Abs(firstExtreme);
            //double extreme2 = Math.Abs(secondExtreme);

            //double start = Math.Min(extreme1, extreme2);
            //double end = Math.Max(extreme1, extreme2);
            if (start >= end)
                throw new Exception($"'{nameof(start)}' must be less than '{nameof(end)}'!");
            
            double progress = Math.Abs(pos);


            /*bool isAtEnds = 
                    (progress <= (start + 1)) ||
                    (progress >= (end - 1));*/
            /*if (DEBUG_PRINT_ALPHA_CALC)
                Console.WriteLine($"{nameof(CalcAlpha)}: {start}, {end}, {progress}...");*/

            double diff = end - start;
            /*if (DEBUG_PRINT_ALPHA_CALC)
                Console.WriteLine($"\t...{nameof(diff)}: {diff}...");*/

            double intoEase = (progress - start) / diff;
            /*if (DEBUG_PRINT_ALPHA_CALC)
                Console.WriteLine($"\t...{nameof(intoEase)}: {intoEase}...");*/
            
            double eased = EDGE_FADE_EASE.Ease(intoEase);
            /*if (DEBUG_PRINT_ALPHA_CALC)
                Console.WriteLine($"\t...{nameof(eased)}: {eased}...");*/



            byte retVal = (byte)((double)eased * (double)byte.MaxValue); //((eased / 100) * (double)byte.MaxValue);
            /*if (DEBUG_PRINT_ALPHA_CALC)
                Console.WriteLine($"...returning {nameof(retVal)}: {retVal}");*/
            
            return retVal;
        }

        
        
        
        
        /*GradientStops _hStops = new GradientStops()
        {
            new GradientStop(Colors.Transparent, 0),
            new GradientStop(Colors.Black, 0),
            new GradientStop(Colors.Black, 1),
            new GradientStop(Colors.Transparent, 1)
        };
        GradientStops _vStops = new GradientStops()
        {
            new GradientStop(Colors.Transparent, 0),
            new GradientStop(Colors.Black, 0),
            new GradientStop(Colors.Black, 1),
            new GradientStop(Colors.Transparent, 1)
        };

        LinearGradientBrush _hBrush;
        LinearGradientBrush _vBrush;*/
        ImageBrush _brush = new ImageBrush()
        {
            //Stretch = Stretch.Fill
        };
        Thickness _restrictedPadding = new Thickness(0);

        public FadeEdgesScrollContentPresenter() : base()
        {
            RefreshPadding();
            this[!BackgroundProperty] = this[!OpacityMaskProperty];
        }


        protected override void OnAttachedToLogicalTree(LogicalTreeAttachmentEventArgs e)
        {
            base.OnAttachedToLogicalTree(e);
            RefreshMask();
            InvalidateMeasure();
            InvalidateArrange();
        }


        protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
        {
            base.OnAttachedToVisualTree(e);
            RefreshMask();
            InvalidateMeasure();
            InvalidateArrange();
        }
        
        /*protected override Size MeasureOverride(Size availableSize)
        {
            var retSize = base.MeasureOverride(availableSize);
            RefreshMask();
            return retSize;
        }*/

        protected override void OnMeasureInvalidated()
        {
            base.OnMeasureInvalidated();
            RefreshMask();
        }

        
        protected override Size ArrangeOverride(Size finalSize)
        {
            var retSize = base.ArrangeOverride(finalSize);
            Dispatcher.UIThread.Post(() => RefreshMask());
            return retSize;
        }

        /*protected override void OnArrangeInvalidated()
        {
            base.OnArrangeInvalidated();
            RefreshMask();
        }*/


        void RefreshPadding()
        {
            var padd = Padding;
            if (padd != null)
                _restrictedPadding = new Thickness(Math.Max(padd.Left, 0), Math.Max(padd.Top, 0), Math.Max(padd.Right, 0), Math.Max(padd.Bottom, 0));
            else
                _restrictedPadding = new Thickness(0);
        }
        
        void RefreshMask()
        {
            var content = Content;
            if ((content == null) ||  (!(content is IVisual vis)))
                return;
            

            var visBound = vis.Bounds;
            var thisBound = Bounds;

            UpdateStops(thisBound.Left - visBound.Left, thisBound.Top - visBound.Top, visBound.Right - thisBound.Right, visBound.Bottom - thisBound.Bottom);
            //InvalidateMeasure();
            //InvalidateArrange();
            InvalidateVisual();
        }


        /*double _prevL = -20;
        double _prevT = -20;
        double _prevR = -20;
        double _prevB = -20;*/
        bool _prevL = false;
        bool _prevT = false;
        bool _prevR = false;
        bool _prevB = false;

        void UpdateStops(double left, double top, double right, double bottom)
        {
            Console.WriteLine($"{nameof(UpdateStops)}({left}, {top}, {right}, {bottom});");

            bool canScrollH = CanHorizontallyScroll;
            bool canScrollV = CanVerticallyScroll;
            
            double pLeft = (left + _restrictedPadding.Left);
            double pTop = (top + _restrictedPadding.Top);
            double pRight = (right + _restrictedPadding.Right);
            double pBottom = (bottom + _restrictedPadding.Bottom);
            Console.WriteLine($"\tPadded: {pLeft}, {pTop}, {pRight}, {pBottom}");


            bool l = canScrollH && (pLeft > 0);
            bool t = canScrollV && (pTop > 0);
            bool r = canScrollH && (pRight > 0);
            bool b = canScrollV && (pBottom > 0);
            Console.WriteLine($"\tResults: {l}, {t}, {r}, {b}");

            bool anyDifferent =
                (l != _prevL) ||
                (t != _prevT) ||
                (r != _prevR) ||
                (b != _prevB);


            if (anyDifferent)
            {
                UpdateOpacityMask(l, t, r, b);

                _prevL = l;
                _prevT = t;
                _prevR = r;
                _prevB = b;
            }
        }


        void UpdateOpacityMask(bool left, bool top, bool right, bool bottom)
        {
            Bitmap bmp = null;
            
            if (left || top || right || bottom)
                GetOpacityMaskBitmap(left, top, right, bottom);
            
            
            bool newBmp = bmp != null;
            bool hasOpacityMask = OpacityMask == _brush;

            
            if (newBmp)
            {
                _brush.Source = bmp;

                if (!hasOpacityMask)
                    OpacityMask = _brush;
            }
            else
            {
                OpacityMask = null;
            }
            
            /*if (OpacityMask is ImageBrush imgBrush)
                imgBrush.Source = bmp;
            else
                OpacityMask = new ImageBrush(bmp);*/
        }
        

        Bitmap GetOpacityMaskBitmap(bool fadeFromLeft, bool fadeFromTop, bool fadeFromRight, bool fadeFromBottom) //double left, double top, double right, double bottom)
        {
            Size size = Bounds.Size;
            bool noSize = (size.Width <= 0) || (size.Height <= 0);
            
            if (noSize)
                return null;
            
            
            
            WriteableBitmap bmp = new WriteableBitmap(PixelSize.FromSize(size, PX_DPI.X), PX_DPI, PixelFormat.Rgba8888, AlphaFormat.Unpremul);
            using (var fb = bmp.Lock())
            {

                unsafe
                {
                    int pxWidth = fb.Size.Width;
                    int pxHeight = fb.Size.Height;
                    int rowBytes = fb.RowBytes;
                    
                    int byteCount = (pxWidth * pxHeight) * 4;
                    
                    
                    Color[,] pixels = new Color[pxWidth, pxHeight];

                    int pixelsTotalLength = pixels.GetLength(0) * pixels.GetLength(1);



                    if (DEBUG_DRAW_SAMPLE_PATTERN)
                    {
                        byte red = 0xFF;
                        byte alpha = 0xFF;

                        for (int y = 0; y < pxHeight; y++)
                        {
                            for (int x = 0; x < pxWidth; x++)
                            {
                                int pixelIndex = (x * y);
                                byte green = (byte)(((double)x / (double)pxWidth) * (double)byte.MaxValue);
                                byte blue = (byte)(((double)y / (double)pxHeight) * (double)byte.MaxValue);
                                
                                pixels[x, y] = Color.FromArgb(alpha, red, green, blue);
                            }
                        }
                    }
                    
                    
                    if ((!DEBUG_DRAW_SAMPLE_PATTERN) || DEBUG_FORCE_DRAW_EDGES)
                    {
                        int exteriorL = fadeFromLeft ? (int)_restrictedPadding.Left : 0;
                        int exteriorT = fadeFromTop ? (int)_restrictedPadding.Top : 0;
                        int exR = fadeFromRight ? (int)_restrictedPadding.Right : 0;
                        int exB = fadeFromBottom ? (int)_restrictedPadding.Bottom : 0;
                        
                        int interiorL = fadeFromLeft ? exteriorL + (int)EDGE_FADE_THICKNESS.Left : 0;
                        int interiorT = fadeFromTop ? exteriorT + (int)EDGE_FADE_THICKNESS.Top : 0;
                        int inR = fadeFromRight ? exR + (int)EDGE_FADE_THICKNESS.Right : 0;
                        int inB = fadeFromBottom ? exB + (int)EDGE_FADE_THICKNESS.Bottom : 0;

                        /*int interiorInFromRight = pxWidth - exteriorR;
                        int exteriorInFromRight = pxWidth - interiorR;
                        int interiorInFromBottom = pxHeight - exteriorB;
                        int exteriorInFromBottom = pxHeight - interiorB;*/

                        int interiorR = pxWidth - inR;
                        int exteriorR = pxWidth - exR;

                        int interiorB = pxHeight - inB;
                        int exteriorB = pxHeight - exB;

                        bool noSpace = (exteriorL >= interiorL) || (interiorL >= interiorR) || (interiorR >= exteriorR)
                                     || (exteriorT >= interiorT) || (interiorT >= interiorB) || (interiorB >= exteriorB);


                        if (noSpace)
                        {
                            interiorL = 0;
                            interiorT = 0;
                            interiorR = pxWidth;
                            interiorB = pxHeight;
                        }


                        for (int y = interiorT; y < interiorB; y++)
                        {
                            for (int x = interiorL; x < interiorR; x++)
                            {
                                pixels[x, y] = FILL_COLOR;
                            }
                        }


                        if (!noSpace)
                        {
                            if (fadeFromLeft)
                                FadeEdge(exteriorL, interiorT, interiorL, interiorB, Dock.Left, ref pixels);


                            if (fadeFromTop)
                            {
                                FadeEdge(interiorL, exteriorT, interiorR, interiorT, Dock.Top, ref pixels);

                                if (fadeFromLeft)
                                    FadeCorner(exteriorL, exteriorT, interiorL, interiorT, StartCorner.TopLeft, ref pixels);
                            
                                if (fadeFromRight)
                                    FadeCorner(interiorR, exteriorT, exteriorR, interiorT, StartCorner.TopRight, ref pixels);
                            }


                            if (fadeFromRight)
                                FadeEdge(interiorR, interiorT, exteriorR, interiorB, Dock.Right, ref pixels);


                            if (fadeFromBottom)
                            {
                                FadeEdge(interiorL, interiorB, interiorR, exteriorB, Dock.Bottom, ref pixels);

                                if (fadeFromRight)
                                    FadeCorner(interiorR, interiorB, exteriorR, exteriorB, StartCorner.BottomRight, ref pixels);
                            
                                if (fadeFromLeft)
                                    FadeCorner(exteriorL, interiorB, interiorL, exteriorB, StartCorner.BottomLeft, ref pixels);
                            }
                        }
                    }


                    using (var stream = new UnmanagedMemoryStream((byte*)fb.Address, byteCount, byteCount, FileAccess.ReadWrite))
                    {
                        stream.Seek(0, SeekOrigin.Begin);
                        for (int y = 0; y < pxHeight; y++)
                        {
                            for (int x = 0; x < pxWidth; x++)
                            {
                                Color currentColor = pixels[x, y];
                                
                                stream.WriteByte(currentColor.B);
                                stream.WriteByte(currentColor.G);
                                stream.WriteByte(currentColor.R);
                                stream.WriteByte(currentColor.A);
                            }
                        }
                    }
                }
            }

            if (DEBUG_SAVE_MASK)
            {
                string now = DateTime.Now.ToString();
                foreach (char c in Path.GetInvalidPathChars())
                {
                    now = now.Replace(c.ToString(), string.Empty);
                }
                now = now.Replace("\\", "/");
                now = now.Replace("/", "-");
                now = now.Replace(":", "-");
                now = now.Replace(".", "-");

                string savePath = Path.Combine(DEBUG_SAVE_PATH, now + ".png");
                //Console.WriteLine($"savePath: {savePath}");
                
                bmp.Save(savePath);
            }
            
            return bmp;
        }
        

        const byte FADED_PIXEL_RED = 0xFF;
        const byte FADED_PIXEL_GREEN = 0x00;
        const byte FADED_PIXEL_BLUE = 0xFF;
        void FadePixels(int xStart, int yStart, int xEnd, int yEnd, Func<int, int, byte> getAlpha, ref Color[,] pixels) //int xFirst, int xLast, int yFirst, int yLast, Func<int, int, byte> getAlpha, ref Color[,] pixels, bool xStepToPositive = true, bool yStepToPositive = true) //int xStep = 1, int yStep = 1
        {
            /*if (DEBUG_PRINT_ALPHA_CALC)
                Console.WriteLine($"{nameof(FadePixels)} called");*/
            
            if (xStart >= xEnd)
                throw new Exception($"'{nameof(xStart)}' must be less than '{nameof(xEnd)}'!");
            
            if (yStart >= yEnd)
                throw new Exception($"'{nameof(yStart)}' must be less than '{nameof(yEnd)}'!");
            
            /*int xStep = xStepToPositive ? 1 : -1;
            int yStep = yStepToPositive ? 1 : -1;

            int xStart = xStepToPositive ? xFirst : xLast;
            int xEnd = xStepToPositive ? xLast : xFirst;
            int yStart = yStepToPositive ? yFirst : yLast;
            int yEnd = yStepToPositive ? yLast : yFirst;*/
            
            
            /*int alphaStart = xStart * yStart;
            int alphaEnd = xEnd * yEnd;*/

            for (int y = yStart; y < yEnd; y++)
            {
                /*if (DEBUG_PRINT_ALPHA_CALC)
                    Console.WriteLine($"{nameof(FadePixels)} called");*/
                for (int x = xStart; x < xEnd; x++)
                {
                    pixels[x,y] = Color.FromArgb(getAlpha(x, y), FADED_PIXEL_RED, FADED_PIXEL_GREEN, FADED_PIXEL_BLUE);
                }
            }
        }


        void FadeEdge(int edgeLeft, int edgeTop, int edgeRight, int edgeBottom, Dock edge, ref Color[,] pixels)
        {
            int startDistance;
            int endDistance;
            int nearInset;
            int farInset;
            int width = pixels.GetLength(0);
            int height = pixels.GetLength(1);

            //int startFar = -1;
            //int endFar = -1;

            Func<int, int, byte> calcAlpha;

            switch (edge)
            {
                case (Dock.Top):
                    calcAlpha = (x, y) => CalcAlpha(edgeTop, edgeBottom, y);
                    break;
                case (Dock.Right):
                    calcAlpha = (x, y) => (byte)(byte.MaxValue - CalcAlpha(edgeLeft, edgeRight, x));
                    break;
                case (Dock.Bottom):
                    //DEBUG_PRINT_ALPHA_CALC = true;
                    /*calcAlpha = (x, y) => 
                    {
                        if (edge == Dock.Bottom)
                            DEBUG_PRINT_ALPHA_CALC = true;
                        
                        var ret = CalcAlpha(edgeTop, edgeBottom, y);
                        DEBUG_PRINT_ALPHA_CALC = false;
                        return ret;
                    };*/
                    //DEBUG_PRINT_ALPHA_CALC = false;
                    calcAlpha = (x, y) => (byte)(byte.MaxValue - CalcAlpha(edgeTop, edgeBottom, y));
                    break;
                /*case (Dock.Right):
                    //startFar = width - startDistance;
                    //endFar = width - endDistance;
                    FadePixels(startDistance, endDistance, nearInset, farInset, (x, y) => CalcAlpha(startDistance, endDistance, x), ref pixels);
                    break;*/
                /*case (Dock.Bottom):
                    //startFar = height - startDistance;
                    //endFar = height - endDistance;
                    FadePixels(nearInset, farInset, startDistance, endDistance, (x, y) => CalcAlpha(startDistance, endDistance, y), ref pixels);
                    break;*/
                default: //from left
                    //FadePixels(startDistance, endDistance, nearInset, farInset, (x, y) => CalcAlpha(startDistance, endDistance, x), ref pixels);
                    calcAlpha = (x, y) => CalcAlpha(edgeLeft, edgeRight, x);
                    break;    
            }

            FadePixels(edgeLeft, edgeTop, edgeRight, edgeBottom, calcAlpha, ref pixels);
        }

        void FadeCorner(int cornerLeft, int cornerTop, int cornerRight, int cornerBottom, StartCorner corner, ref Color[,] pixels)
        {
            /*int width = pixels.GetLength(0);
            int height = pixels.GetLength(1);*/
            /*int cornerBottom = cornerLeft + cornerWidth;
            int cornerRight = cornerTop + cornerHeight;*/
            double cornerWidth = cornerRight - cornerLeft;
            double cornerHeight = cornerTop - cornerBottom;

            Func<int, int, byte> positiveCalcAlpha = 
                (x, y) => CalcAlpha(cornerLeft * cornerTop, cornerRight * cornerBottom, x * y);
            

            Func<int, byte> calcXAlpha = 
                (val) => CalcAlpha(cornerLeft, cornerRight, val);
            
            Func<int, byte> calcYAlpha = 
                (val) => CalcAlpha(cornerTop, cornerRight, val);

            Func<int, byte> calcReversedXAlpha = 
                (val) => 
                {
                    double result = -calcXAlpha(val);

                    result /= (double)byte.MaxValue;

                    result *= cornerWidth;
                    return (byte)((cornerLeft + result) * byte.MaxValue);
                };
            
            Func<int, byte> calcReversedYAlpha = 
                (val) => 
                {
                    double result = -calcYAlpha(val);

                    result /= (double)byte.MaxValue;

                    result *= cornerHeight;
                    return (byte)((cornerTop + result) * byte.MaxValue);
                };
            
            Func<double, double, byte> averageCalculatedAlphas =
                (first, second) => (byte)((first + second) / 2.0);

            bool xToPositive = true;
            bool yToPositive = true;

            Func<int, int, byte> calcAlpha;
            switch (corner)
            {
                case (StartCorner.TopRight):
                    xToPositive = false;
                    calcAlpha = (x, y) => averageCalculatedAlphas(calcReversedXAlpha(x), calcYAlpha(y));
                    break;
                case (StartCorner.BottomRight):
                    xToPositive = false;
                    yToPositive = false;
                    //calcAlpha = (x, y) => CalcAlpha(inFromRight * inFromBottom, width * height, x * y);

                    

                    double brCalcAlpha_first = cornerLeft * cornerTop;
                    double brCalcAlpha_second = cornerRight * cornerBottom;
                    
                    double brCalcAlpha_max = Math.Max(brCalcAlpha_first, brCalcAlpha_second);
                    /*calcAlpha = (x, y) =>
                    {
                        return CalcAlpha(brCalcAlpha_first, brCalcAlpha_second, ((x * y) - brCalcAlpha_max) * -1);
                    };

                    calcAlpha = (x, y) => 
                    {
                        CalcAlpha((cornerLeft * -cornerTop), (-cornerRight * -cornerBottom)
                    }*/
                    calcAlpha = (x, y) => averageCalculatedAlphas(calcReversedXAlpha(x), calcReversedYAlpha(y));
                    break;
                case (StartCorner.BottomLeft):
                    yToPositive = false;
                    //calcAlpha = (x, y) => CalcAlpha(width, inFromBottom, x * y);
                    calcAlpha = (x, y) => averageCalculatedAlphas(calcXAlpha(x), calcReversedYAlpha(y));
                    break;
                default: //top-left
                    //calcAlpha = (x, y) => CalcAlpha(0, cornerWidth * cornerHeight, x * y);
                    //calcAlpha = positiveCalcAlpha;
                    calcAlpha = (x, y) => averageCalculatedAlphas(calcXAlpha(x), calcYAlpha(y));
                    break;
            }

            FadePixels(cornerLeft, cornerTop, cornerRight, cornerBottom, calcAlpha, ref pixels/*, xToPositive, yToPositive*/);
        }
    }
}