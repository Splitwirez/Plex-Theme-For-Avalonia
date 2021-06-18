using System.Runtime.InteropServices;
using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Notifications;
using Avalonia.Controls.Templates;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.Templates;
using Avalonia.Metadata;
using Avalonia.Styling;
using ControlCatalog.ViewModels;
using System;
using System.ComponentModel;
using System.Linq;

namespace ControlCatalog
{
    public class ComparisonControl : ContentControl
    {

    }

    /*public class ComparisonControl : ItemsControl
    {
        public static readonly StyledProperty<object> CompareTemplateProperty =
            AvaloniaProperty.Register<ComparisonControl, object>(nameof(CompareTemplate));
        
        public object CompareTemplate
        {
            get => GetValue(CompareTemplateProperty);
            set => SetValue(CompareTemplateProperty, value);
        }


        public static readonly StyledProperty<IControlTemplate> OutCompareTemplateProperty =
            AvaloniaProperty.Register<ComparisonControl, IControlTemplate>(nameof(OutCompareTemplate));
        
        public IControlTemplate OutCompareTemplate
        {
            get => GetValue(OutCompareTemplateProperty);
            protected set => SetValue(OutCompareTemplateProperty, value);
        }

        static ComparisonControl()
        {
            CompareTemplateProperty.Changed.AddClassHandler<ComparisonControl>((sender, e) =>
            {
                if (sender is ComparisonControl sned)
                {
                    sned.RefreshOutCompareTemplate(e.NewValue);
                }
            });
        }

        protected void RefreshOutCompareTemplate(object value)
        {
            bool isNl = value == null;
            
            bool isTmpl = false;
            IControlTemplate template = null;
            if (value is IControlTemplate tmpl)
            {
                template = tmpl;
                isTmpl = true;
            }

            
            bool isTyp = false;
            Type typ = null;
            if (value is Type tpe)
            {
                tpe = typ;
                isTyp = true;
            }

            bool isICtrlTyp = isTyp && ImplementsIControl(typ);
            

            if (!isTmpl)
            {
                OutCompareTemplate = null;
                return;
            }
            if (isNl)
            {
                OutCompareTemplate = null;
            }
            else
            {
                OutCompareTemplate = (isTyp && ImplementsIControl(typ)) ? 
                new FuncControlTemplate((type, nameScope) => (IControl)Activator.CreateInstance(typ)) :
                null;
            }
        }
    
        static readonly Type Ctr = typeof(IControl);
        static bool ImplementsIControl(Type typ)
        {
            bool[] results =
            {
                typ.IsAssignableFrom(Ctr),
                typ.GetInterfaces().Contains(Ctr),
                typ.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == Ctr),
                typ.GetInterface(nameof(Ctr)) != null
            };

            Console.WriteLine($"{nameof(ImplementsIControl)}({typ.FullName}):");
            //foreach (string res in results)
            for (int i = 0; i < results.Length; i++)
            {
                Console.Write($"{i}: ");
            }
            
            bool retVal = results.All(x => x);
            Console.WriteLine($"Returning {retVal}...");
            return retVal;
        }
    }

    public class CompareTemplate : IControlTemplate
    {
        [Content]
        [TemplateContent]
        public object Content { get; set; }

        public Type TargetType { get; set; }

        public ControlTemplateResult Build(ITemplatedControl control)
        {
            var ctnt = Content;
            Console.WriteLine($"Content: {ctnt}");

            if ((ctnt != null) && (ctnt is Type typ))
            {
                Console.WriteLine($"Content IS TYPE: {typ.FullName}");

                if (ImplementsIControl(typ))
                {
                    return TemplateContent.Load(Activator.CreateInstance(typ));
                }
            }
            
            return TemplateContent.Load(Content);
        }
    
        static readonly Type Ctr = typeof(IControl);
        static bool ImplementsIControl(Type typ)
        {
            bool[] results =
            {
                typ.IsAssignableFrom(Ctr),
                typ.GetInterfaces().Contains(Ctr),
                typ.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == Ctr),
                typ.GetInterface(nameof(Ctr)) != null
            };

            Console.WriteLine($"{nameof(ImplementsIControl)}({typ.FullName}):");
            //foreach (string res in results)
            for (int i = 0; i < results.Length; i++)
            {
                Console.Write($"{i}: ");
            }
            
            bool retVal = results.All(x => x);
            Console.WriteLine($"Returning {retVal}...");
            return retVal;
        }
    }


    public class CompareItem : AvaloniaObject
    {
        public static readonly StyledProperty<string> TitleProperty =
            AvaloniaProperty.Register<CompareItem, string>(nameof(Title));
        
        public string Title
        {
            get => GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }



        public static readonly StyledProperty<Classes> CompareClassesProperty =
            AvaloniaProperty.Register<CompareItem, Classes>(nameof(CompareClasses));
        
        public Classes CompareClasses
        {
            get => GetValue(CompareClassesProperty);
            set => SetValue(CompareClassesProperty, value);
        }


        public static readonly StyledProperty<Classes> OutCompareClassesProperty =
            AvaloniaProperty.Register<CompareItem, Classes>(nameof(OutCompareClasses));
        
        public Classes OutCompareClasses
        {
            get => GetValue(OutCompareClassesProperty);
            protected set => SetValue(OutCompareClassesProperty, value);
        }

        protected virtual void UpdateOutCompareClasses(Classes value)
        {
            var oldVal = OutCompareClasses;
                
            if (oldVal == null)
                SetValue(OutCompareClassesProperty, value);
            else
                oldVal.Replace(value);
        }


        static CompareItem()
        {
            CompareClassesProperty.Changed.AddClassHandler<CompareItem>((sender, e) =>
            {
                if (sender is CompareItem sned)
                {
                    var outClasses = new Classes("groupBox");
                    
                    var classes = sned.CompareClasses;
                    if (classes != null)
                    {
                        foreach (string clas in classes)
                        {
                            outClasses.Add(clas);
                        }

                        sned.UpdateOutCompareClasses(outClasses);
                    }
                    else
                        sned.UpdateOutCompareClasses(new Classes());
                }
            });
        }



        /*[Content]
        [TemplateContent]
        public object Content { get; set; }

        public Type TargetType { get; set; }

        public ControlTemplateResult Build(ITemplatedControl control)
        {
            var retVal = TemplateContent.Load(Content);
            //var root = retVal.NameScope.Find<Control>("PART_TemplateRoot");

            var rootClasses = /*(root is HeaderedContentControl) ? *new Classes(new string[] { "groupBox" })/* : new Classes()*;

            var compareClasses = CompareClasses;
            foreach (string s in compareClasses)
            {
                rootClasses.Add(s);
            }

            root.Classes.Replace(rootClasses);

            var head = new HeaderedContentControl()
            {
                [!HeaderedContentControl.HeaderProperty] = this[!TitleProperty],
                Content 
            };
        }*
    }

    public class CompareItems : AvaloniaList<CompareItem>
    {
    }*/
}