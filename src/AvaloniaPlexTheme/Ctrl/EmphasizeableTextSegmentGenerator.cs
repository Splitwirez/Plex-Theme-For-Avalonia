using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Utils;
using Avalonia.Layout;
using Avalonia.Media;
using Avalonia.Visuals;
using Avalonia.VisualTree;
using Avalonia.Reactive;
using System;
using System.Runtime.InteropServices;
using System.Reactive.Linq;
using System.Collections.Generic;
using Avalonia.Metadata;
using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using Avalonia.Controls.Generators;
using Avalonia.Data;

namespace AvaloniaPlexTheme
{
    /*public class EmphasizeableTextSegmentGenerator : ItemContainerGenerator<EmphasizeableTextSegment>
    {
        public EmphasizeableTextSegmentGenerator(IControl owner, AvaloniaProperty contentProperty, AvaloniaProperty contentTemplateProperty) : base(owner, contentProperty, contentTemplateProperty)
        {

        }


        protected override IControl CreateContainer(object item)
        {
            var container = item as EmphasizeableTextSegment;

            if (container != null)
            {
                return container;
            }

            else
            {
                var result = new EmphasizeableTextSegment();

                if (ContentTemplateProperty != null)
                {
                    result.SetValue(ContentTemplateProperty, ItemTemplate, BindingPriority.Style);
                }

                result.SetValue(ContentProperty, item, BindingPriority.Style);

                if (!(item is IControl))
                {
                    result.DataContext = item;

                    if ((item != null) && (item is IEmphasizeableTextSegment))
                    {
                        result.SetValue(EmphasizeableTextSegment.TextProperty, new Binding("Text"));
                        result.SetValue(EmphasizeableTextSegment.IsEmphasizedProperty, new Binding("IsEmphasized"));
                    }
                }

                return result;
            }
        }
    }*/
}