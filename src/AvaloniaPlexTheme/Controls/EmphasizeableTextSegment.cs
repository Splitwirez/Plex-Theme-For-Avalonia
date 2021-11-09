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
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AvaloniaPlexTheme
{
    public class EmphasizeableTextSegment : INotifyPropertyChanged
    {
        bool _isEmphasized = false;
        public bool IsEmphasized
        {
            get => _isEmphasized;
            set
            {
                _isEmphasized = value;
                NotifyPropertyChanged();
            }
        }


        string _text = string.Empty;
        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                NotifyPropertyChanged();
            }
        }

        public EmphasizeableTextSegment(string text, bool isEmphasized = false)
        {
            Text = text;
            IsEmphasized = isEmphasized;
        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}